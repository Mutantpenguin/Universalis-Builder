using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class TraitEditorForm : Form
    {
        public TraitEditorForm( Trait trait )
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            m_originalTrait = trait;

            Trait modifiedTrait = new Trait( trait );

            traitBindingSource.DataSource = modifiedTrait;
        }

        private readonly Trait m_originalTrait;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return ( false );
            }

            if( String.IsNullOrEmpty( textBoxRules.Text ) )
            {
                MessageBox.Show( "Regeln sind leer, bitte angeben!" );
                return ( false );
            }

            if( !String.IsNullOrEmpty( textBoxRules.Text )
                &&
                ( numericUpDownAdditionalPoints.Value == 0 ) )
            {
                MessageBox.Show( "Achtung, die zusätzlichen Punkte stehen auf '0', obwohl Regeln eingetragen wurden!" );
            }

            if( String.IsNullOrEmpty( textBoxRules.Text )
                &&
                ( numericUpDownAdditionalPoints.Value > 0 ) )
            {
                MessageBox.Show( "Achtung, es sind keine Regeln eingetragen, die zusätzlichen Punkte stehen aber nicht auf '0'!" );
            }

            return ( true );
        }

        private void TraitEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Trait traitModified = (Trait)traitBindingSource.DataSource;

            if( !traitModified.Equals( m_originalTrait ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalTrait.Set( traitModified );
                            MasterDataStorage.Trait.Save( m_originalTrait );
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
                m_originalTrait.Set( (Trait)traitBindingSource.DataSource );
                MasterDataStorage.Trait.Save( m_originalTrait );
            }
        }

        private void TraitEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }
    }
}
