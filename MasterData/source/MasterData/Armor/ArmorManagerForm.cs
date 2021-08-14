using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ArmorManagerForm : Form
    {
        public ArmorManagerForm()
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void DataGridViewArmor_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewArmor );
        }

        private void ComboBox_SelectionChangeCommitted( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void refreshGridView()
        {
            List<Armor> armor = MasterDataStorage.Armor.Armors.Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                              .OrderBy( x => x.Name )
                                                              .ToList();

            armorBindingSource.DataSource = armor;
            dataGridViewArmor.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {armor.Count}";
        }

        private void toolStripButtonArmorAdd_Click( object sender, EventArgs e )
        {
            Armor armor = MasterDataStorage.Armor.Create();

            toolStripTextBoxSearch.Text = String.Empty;

            editArmor( armor );

            refreshGridView();

            dataGridViewArmor.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewArmor.Rows )
            {
                if( armor.ID == ( (Armor)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void toolStripButtonArmorDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewArmor.SelectedCells.Count > 0 )
            {
                Armor armor = (Armor)dataGridViewArmor.SelectedRows[ 0 ].DataBoundItem;

                var actorsWithArmor = MasterDataStorage.Actor.ActorsWithArmor( armor );

                if( actorsWithArmor.Any() )
                {
                    using( ActorDisplayForm actorDisplay = new ActorDisplayForm( actorsWithArmor ) )
                    {
                        actorDisplay.ShowDialog( this );
                    }
                }
                else if( MessageBox.Show( $"Rüstung '{armor.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    MasterDataStorage.Armor.Delete( armor );

                    refreshGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewArmor.SelectedRows.Count > 0 )
            {
                Armor armorSource = (Armor)dataGridViewArmor.SelectedRows[ 0 ].DataBoundItem;

                Armor armorNew = MasterDataStorage.Armor.Create();
                armorNew.Set( armorSource );
                armorNew.Name = $"(Kopie von) {armorSource.Name}";
                MasterDataStorage.Armor.Save( armorNew );

                toolStripTextBoxSearch.Text = String.Empty;
                refreshGridView();

                editArmor( armorNew );
            }
        }

        private void dataGridViewArmor_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editArmor( (Armor)dataGridViewArmor.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editArmor( Armor armor )
        {
            using( ArmorEditorForm armorEditorForm = new ArmorEditorForm( armor ) )
            {
                this.Hide();

                armorEditorForm.ShowDialog( this );

                this.Show();
            }

            armorBindingSource.ResetBindings( false );
        }

        private void ArmorManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewArmor_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Armor armor = (Armor)dataGridViewArmor.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( armor.Description );
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            if( dataGridViewArmor.SelectedRows.Count > 0 )
            {
                using( ActorDisplayForm actorDisplay = new ActorDisplayForm( MasterDataStorage.Actor.ActorsWithArmor( (Armor)dataGridViewArmor.SelectedRows[ 0 ].DataBoundItem ) ) )
                {
                    actorDisplay.ShowDialog( this );
                }
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewArmor, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editArmor( (Armor)dataGridViewArmor.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewArmor_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editArmor( (Armor)dataGridViewArmor.CurrentRow.DataBoundItem );
            }
        }
    }
}
