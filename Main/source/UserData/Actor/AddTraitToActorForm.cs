using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class AddTraitToActorForm : Form
    {
        public AddTraitToActorForm(Faction faction, Archetype archetype, List<Trait> traitsList )
        {
            InitializeComponent();

            m_faction = faction;
            m_archetype = archetype;
            m_TraitsList = traitsList;

            filterGroup.ComboBox.DataSource = MasterDataStorage.Trait.Traits.Select(x => x.Group)
                                                                            .Distinct()
                                                                            .OrderBy(x => x)
                                                                            .ToList();
            filterGroup.ComboBox.SelectedIndex = 0;
            filterGroup.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;

            updateDataGridViewTraits();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            updateDataGridViewTraits();
        }

        private readonly Faction m_faction;
        private readonly Archetype m_archetype;
        private readonly List<Trait> m_TraitsList;

        public List<Trait> SelectedTraits
        {
            get;
            private set;
        }

        private void updateDataGridViewTraits()
        {
            traitBindingSource.DataSource = MasterDataStorage.Trait.Traits.Where( s => s.Active )
                                                                          .Where( s => s.UseOnce || !m_TraitsList.Any( x => x.ID == s.ID ) )
                                                                          .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                          .Where(s => filterGroup.Enabled ? s.Group == (string)filterGroup.ComboBox.SelectedItem : true)
                                                                          .Where( s => toolStripMenuItemPositives.Checked ? true : ( s.MinPoints <= 0 ) )
                                                                          .Where( s => toolStripMenuItemNegatives.Checked ? true : ( s.MinPoints >= 0 ) )
                                                                          .Where( s => toolStripMenuItemNeutrals.Checked ? true : ( s.MinPoints != 0 ) )
                                                                          .Where( s => s.Permissions?.Granted(m_faction, m_archetype ) ?? true )
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
                SelectedTraits = new List<Trait>
                {
                    (Trait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem
                };

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridViewTraits_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Trait trait = (Trait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = trait.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( trait.Rules );
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

        private void dataGridViewTraits_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewTraits );
        }

        private void checkBoxFilterTraitGroup_Click(object sender, EventArgs e)
        {
            filterGroup.Enabled = !filterGroup.Enabled;

            checkBoxFilterTraitGroup.Image = checkBoxFilterTraitGroup.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            updateDataGridViewTraits();
        }
    }
}
