using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class FactionSelectionForm : Form
    {
        public FactionSelectionForm( List<Faction> excludeFactions = null )
        {
            m_excludeFactions = excludeFactions;

            InitializeComponent();

            updateDataGridViewFactions();

            this.Icon = System.Drawing.Icon.FromHandle( Properties.Resources.icon_faction.GetHicon() );
        }

        private void updateDataGridViewFactions()
        {
            factionBindingSource.DataSource = MasterDataStorage.Faction.Factions.Where( s => s.Active )
                                                                                .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                                                .Where( s => ( m_excludeFactions != null ) ? !m_excludeFactions.Any( x => x.ID == s.ID ) : true )
                                                                                .OrderBy( x => x.Name )
                                                                                .ToList();
        }

        private readonly List<Faction> m_excludeFactions;

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

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }
    }
}
