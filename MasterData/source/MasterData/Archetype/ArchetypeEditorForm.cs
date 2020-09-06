using System;
using System.Linq;
using System.Collections.Generic;
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

            Archetype modifiedArchetype = new Archetype( archetype );

            archetypeBindingSource.DataSource = modifiedArchetype;
        }

        private readonly Archetype m_originalArchetype;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return ( false );
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
                        if( mandatoryFieldsFilled() )
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
            if( mandatoryFieldsFilled() )
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
