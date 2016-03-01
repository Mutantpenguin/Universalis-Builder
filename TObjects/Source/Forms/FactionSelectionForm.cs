using System;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class FactionSelectionForm : Form
    {
        public FactionSelectionForm()
        {
            InitializeComponent();

            updateDataGridViewFactions();
        }

        private void updateDataGridViewFactions()
        {
            factionBindingSource.DataSource = FactionStorage.Instance.Factions.Where( s => s.Active )
                                                                              .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                              .OrderBy( x => x.Name )
                                                                              .ToList();
        }

        public Faction SelectedFaction
        {
            get;
            private set;
        }

        private void dataGridViewFactions_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                Faction faction = (Faction)dataGridViewFactions.Rows[ e.RowIndex ].DataBoundItem;
                if( null != faction )
                {
                    SelectedFaction = faction;
                }

                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            if( dataGridViewFactions.SelectedRows.Count == 1 )
            {
                Faction faction = (Faction)dataGridViewFactions.Rows[ dataGridViewFactions.SelectedRows[ 0 ].Index ].DataBoundItem;
                if( null != faction )
                {
                    SelectedFaction = faction;
                }
            }

            Close();
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            updateDataGridViewFactions();
        }
    }
}
