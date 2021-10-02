using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GodModeForm : Form
    {
        public GodModeForm( Universe universe )
        {
            m_universe = universe;

            InitializeComponent();
        }

        FactionOverviewForm factionOverviewForm = null;
        MasterDataMainForm masterDataMainForm = null;

        private void buttonQuit_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        readonly Universe m_universe;
        private void buttonGroups_Click( object sender, EventArgs e )
        {
            factionOverviewForm = new FactionOverviewForm( m_universe );

            factionOverviewForm.FormClosed += delegate
            {
                buttonGroups.Enabled = true;
                factionOverviewForm = null;
            };

            buttonGroups.Enabled = false;

            factionOverviewForm.Show( this );
        }

        private void buttonMasterData_Click( object sender, EventArgs e )
        {
            masterDataMainForm = new MasterDataMainForm( m_universe );

            masterDataMainForm.FormClosed += delegate
            {
                buttonMasterData.Enabled = true;
                masterDataMainForm = null;
            };

            buttonMasterData.Enabled = false;

            masterDataMainForm.Show( this );
        }

        private void GodModeForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( factionOverviewForm != null
                ||
                masterDataMainForm != null )
            {
                MessageBox.Show( "Bitte zuerst alle Fenster schließen!",
                                 "",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                e.Cancel = true;
            }
            else
            {
                switch( MessageBox.Show( "Wirklich beenden?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) )
                {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
