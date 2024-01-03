using System;
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

            comboBoxSize.DataSource = Enum.GetValues( typeof( Archetype.ESize ) );
            comboBoxSize.SelectedItem = archetype.Size;

            comboBoxType.DataSource = Enum.GetValues( typeof( Archetype.EType ) );
            comboBoxType.SelectedItem = archetype.Type;

            comboBoxMovementType.DataSource = Enum.GetValues( typeof( Archetype.EMovementType ) );
            comboBoxMovementType.SelectedItem = archetype.MovementType;

            toolStripComboBoxFaction.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
            toolStripComboBoxFaction.ComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;
            toolStripComboBoxFaction.ComboBox.DataSource = Enum.GetValues(typeof(EPermissionType));

            toolStripComboBoxFaction.ComboBox.SelectedItem = m_modifiedArchetype.FactionPermissions?.PermissionType ?? EPermissionType.None;

            RefreshGridViews();

            TypeDependantFields();

            SetupPermittedConditions();
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
                return false;
            }

            if( ( m_modifiedArchetype.Profile.Speed > 0 ) && ( Archetype.EMovementType.Stationär == m_modifiedArchetype.MovementType ) )
            {
                MessageBox.Show( "Geschwindigkeit ist größer als 0. Daher bitte eine andere Bewegungsart als " + Archetype.EMovementType.Stationär.ToString() + " auswählen!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return false;
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
                    return false;
                }
            }

            {
                Archetype.ESize size = (Archetype.ESize)comboBoxSize.SelectedItem;

                switch( (Archetype.EType)comboBoxType.SelectedItem )
                {
                    case Archetype.EType.Standard:
                        if( ( size != Archetype.ESize.Klein )
                            &&
                            ( size != Archetype.ESize.Mittel )
                            &&
                            ( size != Archetype.ESize.Groß ) )
                        {
                            MessageBox.Show( "Standard-Modelle dürfen nur klein, mittel oder groß sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return false;
                        }
                        break;

                    case Archetype.EType.Telematon:
                        if( ( size != Archetype.ESize.Klein )
                            &&
                            ( size != Archetype.ESize.Mittel )
                            &&
                            ( size != Archetype.ESize.Groß )
                            &&
                            ( size != Archetype.ESize.Riesig ) )
                        {
                            MessageBox.Show( "Telematons dürfen nur klein, mittel, groß oder riesig sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return false;
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
                            return false;
                        }
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
                }
            }

            if( ( numericUpDownAdditionalPoints.Value == 0 ) && !String.IsNullOrEmpty( textBoxRules.Text ) )
            {
                if( MessageBox.Show( "Ohne Zusatzpunkte können keine Regeln verwendet werden. Weiter und Regeln löschen?",
                                     "Ohne Punkte keine Regeln",
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    textBoxRules.Text = String.Empty;
                }
                else
                {
                    return false;
                }
            }

            return true;
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
            if( Archetype.EType.Telematon == (Archetype.EType)comboBoxType.SelectedItem )
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
                case Archetype.EType.Telematon:
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

        private void numericUpDownAdditionalPoints_ValueChanged( object sender, EventArgs e )
        {
            SetupPermittedConditions();
        }

        private void SetupPermittedConditions()
        {
            if( numericUpDownAdditionalPoints.Value == 0 )
            {
                textBoxRules.Visible = false;
            }
            else
            {
                textBoxRules.Visible = true;
            }
        }

        private void RefreshGridViews()
        {
            factionsBindingSource.DataSource = m_modifiedArchetype.FactionPermissions?.Values.OrderBy(x => x.Name)
                                                                                             .ToList();
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch ((EPermissionType)toolStripComboBoxFaction.SelectedItem)
            {
                case EPermissionType.None:
                    m_modifiedArchetype.FactionPermissions = null;
                    break;

                default:
                    if (m_modifiedArchetype.FactionPermissions != null)
                    {
                        m_modifiedArchetype.FactionPermissions.PermissionType = (EPermissionType)toolStripComboBoxFaction.SelectedItem;
                    }
                    else
                    {
                        m_modifiedArchetype.FactionPermissions = new PermissionSet<Faction>((EPermissionType)toolStripComboBoxFaction.SelectedItem);
                    }
                    break;
            }
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((m_modifiedArchetype.FactionPermissions == null)
                ||
                (m_modifiedArchetype.FactionPermissions.PermissionType == EPermissionType.None))
            {
                toolStripButtonFactionDelete.Visible = false;
                toolStripButtonFactionAdd.Visible = false;
                dataGridViewFaction.Visible = false;
            }
            else
            {
                toolStripButtonFactionDelete.Visible = true;
                toolStripButtonFactionAdd.Visible = true;
                dataGridViewFaction.Visible = true;
            }
        }

        private void toolStripButtonFactionDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewFaction.SelectedRows.Count > 0)
            {
                var faction = (Faction)dataGridViewFaction.SelectedRows[0].DataBoundItem;
                m_modifiedArchetype.FactionPermissions.Values.Remove(faction);

                RefreshGridViews();
            }
        }

        private void toolStripButtonFactionAdd_Click(object sender, EventArgs e)
        {
            using (FactionSelectionForm factionSelectionForm = new FactionSelectionForm(m_modifiedArchetype.FactionPermissions?.Values.ToList()))
            {
                if (factionSelectionForm.ShowDialog(this) == DialogResult.OK)
                {
                    if (factionSelectionForm.SelectedFaction != null)
                    {
                        m_modifiedArchetype.FactionPermissions.Values.Add(factionSelectionForm.SelectedFaction);

                        RefreshGridViews();
                    }
                }
            }
        }
    }
}
