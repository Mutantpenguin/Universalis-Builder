using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GroupTraitEditorForm : Form
    {
        public GroupTraitEditorForm( GroupTrait groupTrait )
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            m_originalGroupTrait = groupTrait;

            GroupTrait modifiedGroupTrait = new GroupTrait( groupTrait );

            groupTraitBindingSource.DataSource = modifiedGroupTrait;
        }

        private readonly GroupTrait m_originalGroupTrait;

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
                ( numericUpDownPoints.Value == 0 ) )
            {
                MessageBox.Show( "Achtung, die zusätzlichen Punkte stehen auf '0', obwohl Regeln eingetragen wurden!" );
            }

            if( String.IsNullOrEmpty( textBoxRules.Text )
                &&
                ( numericUpDownPoints.Value > 0 ) )
            {
                MessageBox.Show( "Achtung, es sind keine Regeln eingetragen, die zusätzlichen Punkte stehen aber nicht auf '0'!" );
            }

            return ( true );
        }

        private void GroupTraitEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            GroupTrait groupTraitModified = (GroupTrait)groupTraitBindingSource.DataSource;

            if( !groupTraitModified.Equals( m_originalGroupTrait ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalGroupTrait.Set( groupTraitModified );
                            MasterDataStorage.GroupTrait.Save( m_originalGroupTrait );
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
                m_originalGroupTrait.Set( (GroupTrait)groupTraitBindingSource.DataSource );
                MasterDataStorage.GroupTrait.Save( m_originalGroupTrait );
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
