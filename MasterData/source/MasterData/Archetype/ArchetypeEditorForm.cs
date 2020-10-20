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
            comboBoxSize.SelectedItem = m_modifiedArchetype.Profile.Size;

            // fill the combobox for the type
            comboBoxType.DataSource = Profile.ETypeList;
            comboBoxType.SelectedItem = m_modifiedArchetype.Profile.Type;

            // fill the combobox for the MovementType
            comboBoxMovementType.DataSource = Enum.GetValues( typeof( EMovementType ) );
            comboBoxMovementType.SelectedItem = m_modifiedArchetype.Profile.MovementType;

            // fill the combobox for the FieldOfView
            comboBoxFOV.DataSource = Enum.GetValues( typeof( EFieldOfView ) );
            comboBoxFOV.SelectedItem = m_modifiedArchetype.Profile.Fov;

            archetypeBindingSource.DataSource = m_modifiedArchetype;

            attributeBindingSource.DataSource = m_modifiedArchetype.Profile.Attributes;

            attributeBindingSource.CurrentItemChanged += AttributeBindingSource_CurrentItemChanged;
        }

        private void AttributeBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            archetypeBindingSource.ResetCurrentItem();
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

            if( ( m_modifiedArchetype.Profile.Speed <= 0 ) && ( EMovementType.Stationär != m_modifiedArchetype.Profile.MovementType ) )
            {
                MessageBox.Show( "Geschwindigkeit ist kleiner/gleich 0. Daher bitte die Bewegungsart " + EMovementType.Stationär.ToString() + " auswählen!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
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
                            ( size != Profile.ESize.Mittel ) )
                        {
                            MessageBox.Show( "Drohnen dürfen nur klein oder mittel sein!",
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
    }
}
