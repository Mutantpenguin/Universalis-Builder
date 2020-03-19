using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class FactionManagerForm : Form
    {
        public FactionManagerForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            refreshGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void refreshGridView()
        {
            List<Faction> factions = FactionStorage.Instance.Factions.Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                     .OrderBy( x => x.Name )
                                                                     .ToList();

            factionBindingSource.DataSource = factions;
            dataGridViewFactions.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {factions.Count}";
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            refreshGridView();
        }

        private void toolStripButtonAddFaction_Click( object sender, EventArgs e )
        {
            Faction faction = FactionStorage.Instance.Create();

            toolStripTextBoxSearch.Text = String.Empty;
            refreshGridView();

            editFaction( faction );

            dataGridViewFactions.ClearSelection();
            foreach( DataGridViewRow row in dataGridViewFactions.Rows )
            {
                if( faction.ID == ( (Faction)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        private void toolStripButtonDeleteFaction_Click( object sender, EventArgs e )
        {
            if( dataGridViewFactions.SelectedCells.Count > 0 )
            {
                Faction faction = (Faction)dataGridViewFactions.SelectedRows[ 0 ].DataBoundItem;

                var actorsWithFaction = ActorStorage.Instance.ActorsWithFaction( faction );

                if( actorsWithFaction.Any() )
                {
                    using( ActorDisplayForm actorDisplay = new ActorDisplayForm( actorsWithFaction ) )
                    {
                        actorDisplay.ShowDialog( this );
                    }
                }
                else if( MessageBox.Show( $"Fraktion '{faction.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    FactionStorage.Instance.Delete( faction );

                    refreshGridView();
                }
            }
        }

        private void dataGridViewFaction_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editFaction( (Faction)dataGridViewFactions.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editFaction( Faction faction )
        {
            using( FactionEditorForm factionEditorForm = new FactionEditorForm( faction ) )
            {
                this.Hide();

                factionEditorForm.ShowDialog( this );

                this.Show();
            }

            factionBindingSource.ResetBindings( false );
        }

        private void FactionManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewFactions_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Faction faction = (Faction)dataGridViewFactions.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( faction.Description );
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewFactions, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editFaction( (Faction)dataGridViewFactions.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewFactions_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editFaction( (Faction)dataGridViewFactions.CurrentRow.DataBoundItem );
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            if( dataGridViewFactions.SelectedRows.Count > 0 )
            {
                using( ActorDisplayForm actorDisplay = new ActorDisplayForm( ActorStorage.Instance.ActorsWithFaction( (Faction)dataGridViewFactions.SelectedRows[ 0 ].DataBoundItem ) ) )
                {
                    actorDisplay.ShowDialog( this );
                }
            }
        }
    }
}
