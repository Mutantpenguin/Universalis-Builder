using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ArchetypeEditorForm : Form
    {
        public ArchetypeEditorForm( Archetype archetype )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            profileBindingSource.CurrentItemChanged += ProfileBindingSource_CurrentItemChanged;
            attributeBindingSource.CurrentItemChanged += AttributeBindingSource_CurrentItemChanged;

            m_originalArchetype = archetype;

            m_modifiedArchetype = new Archetype( archetype );

            archetypeBindingSource.DataSource = m_modifiedArchetype;
            profileBindingSource.DataSource = m_modifiedArchetype.Profile;
            attributeBindingSource.DataSource = m_modifiedArchetype.Profile.Attributes;

            traitLevelBindingSource.DataSource = Enumerable.Range( 1, 10 )
                                                           .Select( i => (uint)i )
                                                           .ToList();

            comboBoxSize.DataSource = Enum.GetValues( typeof( Archetype.ESize ) );
            comboBoxSize.SelectedItem = archetype.Size;

            comboBoxType.DataSource = Enum.GetValues( typeof( Archetype.EType ) );
            comboBoxType.SelectedItem = archetype.Type;

            comboBoxMovementType.DataSource = Enum.GetValues( typeof( Archetype.EMovementType ) );
            comboBoxMovementType.SelectedItem = archetype.MovementType;

            TypeDependantFields();

            updateGridViewTraits();
        }

        private void updateGridViewTraits()
        {
            // if we don't do this, CellFormatting for the Datagrid will throw an exception because it's still working with the old content
            archetypeTraitBindingSource.DataSource = null;
            archetypeTraitBindingSource.DataSource = m_modifiedArchetype.Traits.OrderBy( x => x.Trait.Name )
                                                                                  .ToList();

            dataGridViewTraits.ClearSelection();
        }

        private void ProfileBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            archetypeBindingSource.ResetCurrentItem();

            AreaOfPerception.Text = Convert.ToString( m_modifiedArchetype.AreaOfPerception( new AttributeModifier() ) );
            DangerArea.Text = Convert.ToString( m_modifiedArchetype.DangerArea( new AttributeModifier() ) );
        }

        private void AttributeBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            profileBindingSource.ResetCurrentItem();
        }

        private readonly Archetype m_originalArchetype;
        private Archetype m_modifiedArchetype;

        private bool checkValidity()
        {
            string caption = "Fehlende oder falsche Angaben";

            if( String.IsNullOrEmpty( m_modifiedArchetype.Name ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( null == m_modifiedArchetype.Faction )
            {
                MessageBox.Show( "Fraktion ist leer, bitte angeben!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( ( m_modifiedArchetype.Profile.Speed > 0 ) && ( Archetype.EMovementType.Stationär == m_modifiedArchetype.MovementType ) )
            {
                MessageBox.Show( "Geschwindigkeit ist größer als 0. Daher bitte eine andere Bewegungsart als " + Archetype.EMovementType.Stationär.ToString() + " auswählen!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( ( m_modifiedArchetype.Profile.Speed == 0 ) && ( Archetype.EMovementType.Stationär != m_modifiedArchetype.MovementType ) )
            {
                if( MessageBox.Show( "Geschwindigkeit ist gleich 0. Die Bewegungsart auf '" + Archetype.EMovementType.Stationär.ToString() + "' setzen?",
                                     caption,
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Stop,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_modifiedArchetype.MovementType = Archetype.EMovementType.Stationär;
                }
                else
                {
                    return ( false );
                }
            }

            {
                Archetype.ESize size = (Archetype.ESize)comboBoxSize.SelectedItem;

                switch( (Archetype.EType)comboBoxType.SelectedItem )
                {
                    case Archetype.EType.Infanterie:
                        if( ( size != Archetype.ESize.Klein )
                            &&
                            ( size != Archetype.ESize.Mittel )
                            &&
                            ( size != Archetype.ESize.Groß ) )
                        {
                            MessageBox.Show( "Infanterie darf nur klein, mittel oder groß sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    case Archetype.EType.Drohne:
                        if( ( size != Archetype.ESize.Klein )
                            &&
                            ( size != Archetype.ESize.Mittel )
                            &&
                            ( size != Archetype.ESize.Groß )
                            &&
                            ( size != Archetype.ESize.Riesig ) )
                        {
                            MessageBox.Show( "Drohnen dürfen nur klein, mittel, groß oder riesig sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    case Archetype.EType.Koloss:
                        if( ( size != Archetype.ESize.Groß )
                            &&
                            ( size != Archetype.ESize.Riesig ) )
                        {
                            MessageBox.Show( "Kolosse müssen immer groß oder riesig sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
                }
            }

            return ( true );
        }

        private void ArchetypeEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Archetype archetypeModified = (Archetype)archetypeBindingSource.DataSource;

            if( !archetypeModified.Equals( m_originalArchetype ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( checkValidity() )
                        {
                            m_originalArchetype.Set( archetypeModified );
                            MasterDataStorage.Archetype.Save( m_originalArchetype );
                        }
                        else
                        {
                            if( MessageBox.Show( "Es fehlen noch Pflichtangaben! Änderungen verwerfen?", "Pflichtangaben fehlen", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                            {
                                e.Cancel = true;
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void toolStripButtonSave_Click( object sender, EventArgs e )
        {
            if( checkValidity() )
            {
                m_originalArchetype.Set( (Archetype)archetypeBindingSource.DataSource );
                MasterDataStorage.Archetype.Save( m_originalArchetype );
            }
        }

        private void ArchetypeEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void TypeDependantFields()
        {
            if( Archetype.EType.Drohne == (Archetype.EType)comboBoxType.SelectedItem )
            {
                numericUpDownAGI.Minimum = 0;
                numericUpDownHTH.Minimum = 0;
                numericUpDownLRC.Minimum = 0;
                numericUpDownDET.Minimum = 0;

                numericUpDownAGI.Value = 0;
                numericUpDownHTH.Value = 0;
                numericUpDownLRC.Value = 0;
                numericUpDownDET.Value = 0;
            }
            else
            {
                numericUpDownAGI.Minimum = 1;
                numericUpDownHTH.Minimum = 1;
                numericUpDownLRC.Minimum = 1;
                numericUpDownDET.Minimum = 1;

                var attributes = m_originalArchetype.Profile.Attributes;

                numericUpDownAGI.Value = Math.Max( attributes.AGI, 1 );
                numericUpDownHTH.Value = Math.Max( attributes.HTH, 1 );
                numericUpDownLRC.Value = Math.Max( attributes.LRC, 1 );
                numericUpDownDET.Value = Math.Max( attributes.DET, 1 );
            }
        }

        private void comboBoxType_SelectedValueChanged( object sender, EventArgs e )
        {
            switch( m_modifiedArchetype.Type )
            {
                case Archetype.EType.Drohne:
                    DangerArea.Visible = false;
                    labelGB.Visible = false;

                    numericUpDownAGI.Enabled = false;
                    numericUpDownHTH.Enabled = false;
                    numericUpDownLRC.Enabled = false;
                    numericUpDownDET.Enabled = false;

                    break;

                default:
                    DangerArea.Visible = true;
                    labelGB.Visible = true;

                    numericUpDownAGI.Enabled = true;
                    numericUpDownHTH.Enabled = true;
                    numericUpDownLRC.Enabled = true;
                    numericUpDownDET.Enabled = true;

                    break;
            }
        }

        private void comboBoxType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            m_modifiedArchetype.Type = (Archetype.EType)comboBoxType.SelectedItem;

            archetypeBindingSource.ResetCurrentItem();

            TypeDependantFields();
        }

        private void comboBoxSize_SelectionChangeCommitted( object sender, EventArgs e )
        {
            m_modifiedArchetype.Size = (Archetype.ESize)comboBoxSize.SelectedItem;

            archetypeBindingSource.ResetCurrentItem();
        }

        private void comboBoxMovementType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            m_modifiedArchetype.MovementType = (Archetype.EMovementType)comboBoxMovementType.SelectedItem;
        }

        private void toolStripButtonTraitRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewTraits.SelectedRows.Count > 0 )
            {
                var trait = (Archetype.ArchetypeTrait)dataGridViewTraits.Rows[ dataGridViewTraits.SelectedRows[ 0 ].Index ].DataBoundItem;
                m_modifiedArchetype.Traits.Remove( trait );

                updateGridViewTraits();
            }
        }

        private void toolStripButtonTraitAdd_Click( object sender, EventArgs e )
        {
            List<Trait> traitList = m_modifiedArchetype.Traits.Select( x => x.Trait )
                                                                 .Distinct()
                                                                 .ToList();

            using( AddTraitToArchetypeForm addTraitToArchetype = new AddTraitToArchetypeForm( traitList ) )
            {
                if( addTraitToArchetype.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addTraitToArchetype.SelectedTraits.Count > 0 )
                    {
                        foreach( Trait trait in addTraitToArchetype.SelectedTraits )
                        {
                            m_modifiedArchetype.Traits.Add( new Archetype.ArchetypeTrait()
                            {
                                Trait = trait
                            } );
                        }

                        updateGridViewTraits();
                    }
                }
            }
        }

        private void dataGridViewTraits_CellBeginEdit( object sender, DataGridViewCellCancelEventArgs e )
        {
            if( e.ColumnIndex == traitLevelDataGridViewComboBoxColumn.Index )
            {
                DataGridViewRow row = dataGridViewTraits.Rows[ e.RowIndex ];

                Trait trait = ( (Archetype.ArchetypeTrait)row.DataBoundItem ).Trait;

                ( row.Cells[ traitLevelDataGridViewComboBoxColumn.Index ] as DataGridViewComboBoxCell ).DataSource = Enumerable.Range( 1, (int)trait.MaxLevel )
                                                                                                                               .Select( i => (uint)i )
                                                                                                                               .ToList();
            }
        }

        private void dataGridViewTraits_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewTraits );
        }

        private void dataGridViewTraits_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Archetype.ArchetypeTrait archetypeTrait = (Archetype.ArchetypeTrait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem;

                string traitSummary = archetypeTrait.Trait.Summary( archetypeTrait.Level );

                if( !String.IsNullOrEmpty( traitSummary ) )
                {
                    string text = archetypeTrait.Trait.FormattedName( archetypeTrait.Level ) + ":";

                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( traitSummary );

                    e.ToolTipText = text;
                }
                else
                {
                    e.ToolTipText = String.Empty;
                }
            }
        }

        private void dataGridViewTraits_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( dataGridViewTraits.CurrentCell.ColumnIndex == traitLevelDataGridViewComboBoxColumn.Index )
            {
                dataGridViewTraits.CommitEdit( DataGridViewDataErrorContexts.Commit );
            }
        }
    }
}
