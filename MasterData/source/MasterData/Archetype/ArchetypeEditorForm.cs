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

            m_originalArchetype = archetype;

            m_modifiedArchetype = new Archetype( archetype );

            // fill the combobox for the size
            comboBoxSize.DataSource = Profile.ESizeList;

            // fill the combobox for the type
            comboBoxType.DataSource = Profile.ETypeList;

            // fill the combobox for the MovementType
            comboBoxMovementType.DataSource = Enum.GetValues( typeof( EMovementType ) );

            // fill the combobox for the FieldOfView
            comboBoxFOV.DataSource = Enum.GetValues( typeof( EFieldOfView ) );

            archetypeBindingSource.DataSource = m_modifiedArchetype;
            profileBindingSource.DataSource = m_modifiedArchetype.Profile;
            attributeBindingSource.DataSource = m_modifiedArchetype.Profile.Attributes;

            profileBindingSource.CurrentItemChanged += ProfileBindingSource_CurrentItemChanged;
            attributeBindingSource.CurrentItemChanged += AttributeBindingSource_CurrentItemChanged;

            Setup();

            // TODO show GB and WB
        }

        private void ProfileBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            archetypeBindingSource.ResetCurrentItem();
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

                    case Profile.EType.Mech:
                    case Profile.EType.Koloss:
                        if( ( size != Profile.ESize.Groß )
                            &&
                            ( size != Profile.ESize.Riesig ) )
                        {
                            MessageBox.Show( "Mechs und Kolosse müssen immer groß oder riesig sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    case Profile.EType.Fahrzeug:
                        if( size == Profile.ESize.Klein )
                        {
                            MessageBox.Show( "Fahrzeuge dürfen nicht klein sein!",
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
                if( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_originalArchetype.Set( (Archetype)archetypeBindingSource.DataSource );
                    MasterDataStorage.Archetype.Save( m_originalArchetype );
                }
            }
        }

        private void ArchetypeEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            using( ActorDisplayForm actorDisplay = new ActorDisplayForm( MasterDataStorage.Actor.ActorsWithArchetype( m_originalArchetype ) ) )
            {
                actorDisplay.ShowDialog( this );
            }
        }

        private void comboBoxType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            // TODO set attributes AGI, NK, FK and EH to 0 when it is a drone and lock the fields
            // TODO drone: hide dangerarea

            Setup();

            if( Profile.EType.Drohne == (Profile.EType)comboBoxType.SelectedItem )
            {
                numericUpDownAGI.Value = 0;
                numericUpDownNK.Value = 0;
                numericUpDownFK.Value = 0;
                numericUpDownEH.Value = 0;
            }

            //attributeBindingSource.ResetCurrentItem();
        }

        private void Setup()
        {
            if( Profile.EType.Drohne == (Profile.EType)comboBoxType.SelectedItem )
            {
                var attributes = m_modifiedArchetype.Profile.Attributes;

                numericUpDownAGI.Enabled = false;
                numericUpDownNK.Enabled = false;
                numericUpDownFK.Enabled = false;
                numericUpDownEH.Enabled = false;

                numericUpDownAGI.Minimum = 0;
                numericUpDownNK.Minimum = 0;
                numericUpDownFK.Minimum = 0;
                numericUpDownEH.Minimum = 0;
            }
            else
            {
                numericUpDownAGI.Enabled = true;
                numericUpDownNK.Enabled = true;
                numericUpDownFK.Enabled = true;
                numericUpDownEH.Enabled = true;

                numericUpDownAGI.Minimum = 1;
                numericUpDownNK.Minimum = 1;
                numericUpDownFK.Minimum = 1;
                numericUpDownEH.Minimum = 1;
            }
        }
    }
}
