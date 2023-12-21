using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class TraitsManagerForm : Form
    {
        public TraitsManagerForm()
        {
            InitializeComponent();

            this.Icon = Icon.FromHandle( Properties.Resources.icon_trait.GetHicon() );

            HasPermissions.DefaultCellStyle.NullValue = null;

            filterGroup.ComboBox.DataSource = MasterDataStorage.Trait.Traits.Select(x => x.Group)
                                                                            .Distinct()
                                                                            .OrderBy(x => x)
                                                                            .ToList();
            filterGroup.ComboBox.SelectedIndex = 0;
            filterGroup.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            refreshGridView();
        }

        private void refreshGridView()
        {
            List<Trait> traits = MasterDataStorage.Trait.Traits.Where( s => s.Active )
                                                               .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                               .Where( s => filterGroup.Enabled ? s.Group == (string)filterGroup.ComboBox.SelectedItem : true)
                                                               .Where( s => toolStripMenuItemPositives.Checked ? true : ( s.MinPoints <= 0 ) )
                                                               .Where( s => toolStripMenuItemNegatives.Checked ? true : ( s.MinPoints >= 0 ) )
                                                               .Where( s => toolStripMenuItemNeutrals.Checked ? true : ( s.MinPoints != 0 ) )
                                                               .OrderBy( s => s.Name )
                                                               .ToList();

            traitBindingSource.DataSource = null;
            traitBindingSource.DataSource = traits;
            dataGridViewTraits.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {traits.Count}";
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripMenuItemPositives_CheckedChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripMenuItemNegatives_CheckedChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripMenuItemNeutrals_CheckedChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripButtonTraitAdd_Click( object sender, EventArgs e )
        {
            Trait trait = TraitStorage.Create();

            toolStripTextBoxSearch.Text = String.Empty;

            editTrait( trait );

            refreshGridView();

            dataGridViewTraits.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewTraits.Rows )
            {
                if( trait.ID == ( (Trait)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void toolStripButtonTraitDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewTraits.SelectedCells.Count > 0 )
            {
                Trait trait = (Trait)dataGridViewTraits.SelectedRows[ 0 ].DataBoundItem;

                if( MessageBox.Show( $"Eigenschaft '{trait.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    MasterDataStorage.Trait.Delete( trait );

                    refreshGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewTraits.SelectedRows.Count > 0 )
            {
                Trait traitSource = (Trait)dataGridViewTraits.SelectedRows[ 0 ].DataBoundItem;

                Trait traitNew = TraitStorage.Create();
                traitNew.Set( traitSource );
                traitNew.Name = $"(Kopie von) {traitSource.Name}";
                MasterDataStorage.Trait.Save( traitNew );

                toolStripTextBoxSearch.Text = String.Empty;
                refreshGridView();

                editTrait( traitNew );
            }
        }

        private void dataGridViewTraits_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editTrait( (Trait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editTrait( Trait trait )
        {
            using( TraitEditorForm traitEditorForm = new TraitEditorForm( trait ) )
            {
                this.Hide();

                traitEditorForm.ShowDialog( this );

                this.Show();
            }

            traitBindingSource.ResetBindings( false );
        }

        private void TraitManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewTraits_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Trait trait = (Trait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( trait.Description );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewTraits, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editTrait( (Trait)dataGridViewTraits.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewTraits_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editTrait( (Trait)dataGridViewTraits.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewTraits_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewTraits );

            if( e.RowIndex != -1 )
            {
                if( e.ColumnIndex == HasPermissions.Index )
                {
                    Trait trait = (Trait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem;

                    if( trait.Permissions != null )
                    {
                        e.Value = Properties.Resources.outline_key_black_18dp;
                    }
                }
            }
        }

        private void checkBoxFilterTraitGroup_Click(object sender, EventArgs e)
        {
            filterGroup.Enabled = !filterGroup.Enabled;

            checkBoxFilterTraitGroup.Image = checkBoxFilterTraitGroup.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            refreshGridView();
        }
    }
}
