using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class AddTraitToActorForm : Form
    {
        public AddTraitToActorForm( List<Trait> traitsList )
        {
            InitializeComponent();

            m_TraitsList = traitsList;

            updateDataGridViewTraits();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private List<Trait> m_TraitsList;

        public List<Trait> SelectedTraits
        {
            get;
            private set;
        }

        private void updateDataGridViewTraits()
        {
            traitBindingSource.DataSource = TraitStorage.Instance.Traits.Where( s => s.Active )
                                                                        .Where( s => m_TraitsList.Find( x => x.ID == s.ID ) == null )
                                                                        .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                        .Where( s => toolStripMenuItemPositives.Checked ? true : ( s.Type != "+" ) )
                                                                        .Where( s => toolStripMenuItemNegatives.Checked ? true : ( s.Type != "-" ) )
                                                                        .Where( s => toolStripMenuItemNeutrals.Checked ? true : ( s.Type != "=" ) )
                                                                        .OrderBy( x => x.Name )
                                                                        .ToList();
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            CloseWithSelected();
        }

        private void CloseWithSelected()
        {
            SelectedTraits = new List<Trait>();

            for( int i = 0; i < dataGridViewTraits.SelectedRows.Count; i++ )
            {
                SelectedTraits.Add( (Trait)dataGridViewTraits.Rows[ dataGridViewTraits.SelectedRows[ i ].Index ].DataBoundItem );
            }

            Close();
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewTraits();
        }

        private void toolStripMenuItemPositives_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewTraits();
        }

        private void toolStripMenuItemNegatives_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewTraits();
        }

        private void toolStripMenuItemNeutrals_CheckedChanged( object sender, EventArgs e )
        {
            updateDataGridViewTraits();
        }

        private void dataGridViewTraits_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                SelectedTraits = new List<Trait>();
                SelectedTraits.Add( (Trait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem );

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridViewTraits_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Trait trait = (Trait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = trait.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( trait.RulesWithLevel( TraitLevel.ELevel.Kein ) );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewTraits_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                this.DialogResult = DialogResult.OK;
                e.Handled = true;
                CloseWithSelected();
            }
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewTraits, e.KeyCode ) )
            {
                e.Handled = true;
            }
        }
    }
}
