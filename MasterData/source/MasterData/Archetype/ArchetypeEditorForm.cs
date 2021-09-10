using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ArchetypeEditorForm : Form
    {
        public ArchetypeEditorForm( Archetype archetype )
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            profileBindingSource.CurrentItemChanged += ProfileBindingSource_CurrentItemChanged;
            attributeBindingSource.CurrentItemChanged += AttributeBindingSource_CurrentItemChanged;

            m_originalArchetype = archetype;

            m_modifiedArchetype = new Archetype( archetype );

            archetypeBindingSource.DataSource = m_modifiedArchetype;
            profileBindingSource.DataSource = m_modifiedArchetype.Profile;
            attributeBindingSource.DataSource = m_modifiedArchetype.Profile.Attributes;

            // fill the combobox for the size
            comboBoxSize.DataSource = Profile.ESizeList;
            comboBoxSize.SelectedItem = archetype.Profile.Size;

            // fill the combobox for the type
            comboBoxType.DataSource = Profile.ETypeList;
            comboBoxType.SelectedItem = archetype.Profile.Type;

            // fill the combobox for the MovementType
            comboBoxMovementType.DataSource = Enum.GetValues( typeof( EMovementType ) );
            comboBoxMovementType.SelectedItem = archetype.Profile.MovementType;

            TypeDependantFields();
        }

        private void ProfileBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            archetypeBindingSource.ResetCurrentItem();

            AreaOfPerception.Text = Convert.ToString( ( (Profile)profileBindingSource.DataSource ).AreaOfPerception( new AttributeModifier() ) );
            DangerArea.Text = Convert.ToString( ( (Profile)profileBindingSource.DataSource ).DangerArea( new AttributeModifier() ) );
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

            if( ( m_modifiedArchetype.Profile.Speed > 0 ) && ( EMovementType.Stationär == m_modifiedArchetype.Profile.MovementType ) )
            {
                MessageBox.Show( "Geschwindigkeit ist größer als 0. Daher bitte eine andere Bewegungsart als " + EMovementType.Stationär.ToString() + " auswählen!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( ( m_modifiedArchetype.Profile.Speed == 0 ) && ( EMovementType.Stationär != m_modifiedArchetype.Profile.MovementType ) )
            {
                if( MessageBox.Show( "Geschwindigkeit ist gleich 0. Die Bewegungsart auf '" + EMovementType.Stationär.ToString() + "' setzen?",
                                     caption,
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Stop,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_modifiedArchetype.Profile.MovementType = EMovementType.Stationär;
                }
                else
                {
                    return ( false );
                }
            }

            {
                Profile.ESize size = (Profile.ESize)comboBoxSize.SelectedItem;

                switch( (Profile.EType)comboBoxType.SelectedItem )
                {
                    case Profile.EType.Infanterie:
                        if( ( size != Profile.ESize.Klein )
                            &&
                            ( size != Profile.ESize.Mittel )
                            &&
                            ( size != Profile.ESize.Groß ) )
                        {
                            MessageBox.Show( "Infanterie darf nur klein, mittel oder groß sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    case Profile.EType.Drohne:
                        if( ( size != Profile.ESize.Klein )
                            &&
                            ( size != Profile.ESize.Mittel )
                            &&
                            ( size != Profile.ESize.Groß )
                            &&
                            ( size != Profile.ESize.Riesig ) )
                        {
                            MessageBox.Show( "Drohnen dürfen nur klein, mittel, groß oder riesig sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    case Profile.EType.Koloss:
                        if( ( size != Profile.ESize.Groß )
                            &&
                            ( size != Profile.ESize.Riesig ) )
                        {
                            MessageBox.Show( "Kolosse müssen immer groß oder riesig sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
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
            if( Profile.EType.Drohne == (Profile.EType)comboBoxType.SelectedItem )
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
            Profile profile = (Profile)profileBindingSource.DataSource;

            switch( profile.Type )
            {
                case Profile.EType.Drohne:
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
            ( (Profile)profileBindingSource.DataSource ).Type = (Profile.EType)comboBoxType.SelectedItem;

            profileBindingSource.ResetCurrentItem();

            TypeDependantFields();
        }

        private void comboBoxSize_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Profile)profileBindingSource.DataSource ).Size = (Profile.ESize)comboBoxSize.SelectedItem;

            profileBindingSource.ResetCurrentItem();
        }

        private void comboBoxMovementType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Profile)profileBindingSource.DataSource ).MovementType = (EMovementType)comboBoxMovementType.SelectedItem;

            profileBindingSource.ResetCurrentItem();
        }
    }
}
