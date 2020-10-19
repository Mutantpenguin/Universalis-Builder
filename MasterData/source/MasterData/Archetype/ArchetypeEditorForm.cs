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
            comboBoxSize.DataSource = Archetype.ESizeList;
            comboBoxSize.SelectedItem = m_modifiedArchetype.Size;

            // fill the combobox for the type
            comboBoxType.DataSource = Archetype.ETypeList;
            comboBoxType.SelectedItem = m_modifiedArchetype.Type;

            // fill the combobox for the MovementType
            comboBoxMovementType.DataSource = Enum.GetValues( typeof( EMovementType ) );
            comboBoxMovementType.SelectedItem = m_modifiedArchetype.MovementType;

            archetypeBindingSource.DataSource = m_modifiedArchetype;

            attributeBindingSource.DataSource = m_modifiedArchetype.Attributes;

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

            if( ( m_modifiedArchetype.Attributes.BW > 0 ) && ( EMovementType.Stationär == m_modifiedArchetype.MovementType ) )
            {
                MessageBox.Show( "BW ist größer als 0. Daher bitte eine andere Bewegungsart als " + EMovementType.Stationär.ToString() + " auswählen!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( ( m_modifiedArchetype.Attributes.BW <= 0 ) && ( EMovementType.Stationär != m_modifiedArchetype.MovementType ) )
            {
                MessageBox.Show( "BW ist kleiner/gleich 0. Daher bitte die Bewegungsart " + EMovementType.Stationär.ToString() + " auswählen!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
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
                            ( size != Archetype.ESize.Mittel ) )
                        {
                            MessageBox.Show( "Drohnen dürfen nur klein oder mittel sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    case Archetype.EType.Mech:
                    case Archetype.EType.Koloss:
                        if( ( size != Archetype.ESize.Groß )
                            &&
                            ( size != Archetype.ESize.Riesig ) )
                        {
                            MessageBox.Show( "Mechs und Kolosse müssen immer groß oder riesig sein!",
                                             caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                            return ( false );
                        }
                        break;

                    case Archetype.EType.Fahrzeug:
                        if( size == Archetype.ESize.Klein )
                        {
                            MessageBox.Show( "Fahrzeuge dürfen nicht klein sein!",
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
