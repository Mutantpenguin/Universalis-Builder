using LibGit2Sharp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Universalis.Source.Helper;

namespace Universalis
{
    public partial class DeityModeForm : Form
    {
        public DeityModeForm( Universe universe, string universePath )
        {
            m_universe = universe;
            m_universePath = universePath;

            InitializeComponent();

            this.CenterToParent();

            this.Icon = Properties.Resources.icon;

            labelHeader.Text = universe.NameWithVersionAndHash();
            labelHeader.Font = new Font( UniversalisFont.Family, 20 );
            labelHeader.Left = ( panelHeader.Width - labelHeader.Width ) / 2;
            labelHeader.Top = ( panelHeader.Height - labelHeader.Height ) / 2;
        }

        UniverseForm universeForm = null;
        MasterDataMainForm masterDataMainForm = null;

        private void buttonQuit_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        readonly Universe m_universe;
        readonly string m_universePath;

        private void buttonGroups_Click( object sender, EventArgs e )
        {
            universeForm = new UniverseForm( m_universe, deityMode: true );

            universeForm.FormClosed += delegate
            {
                buttonGroups.Enabled = true;
                universeForm.Dispose();
                universeForm = null;
            };

            buttonGroups.Enabled = false;

            universeForm.Show( this );
        }

        private void buttonMasterData_Click( object sender, EventArgs e )
        {
            masterDataMainForm = new MasterDataMainForm( m_universe );

            masterDataMainForm.FormClosed += delegate
            {
                buttonMasterData.Enabled = true;
                masterDataMainForm.Dispose();
                masterDataMainForm = null;
            };

            buttonMasterData.Enabled = false;

            masterDataMainForm.Show( this );
        }

        private void DeityModeForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( universeForm != null
                ||
                masterDataMainForm != null )
            {
                MessageBox.Show( "Bitte zuerst alle Fenster schließen!",
                                 String.Empty,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                e.Cancel = true;
            }
            else
            {
                switch( MessageBox.Show( "Wirklich beenden?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) )
                {
                    case DialogResult.Yes:
                        CheckModifiedRepository();
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void CheckModifiedRepository()
        {
            if( Repository.IsValid( m_universePath ) )
            {
                try
                {
                    using( var repo = new Repository( m_universePath ) )
                    {
                        if( repo.Diff.Compare<TreeChanges>().Count > 0
                            ||
                            repo.RetrieveStatus().IsDirty )
                        {
                            if( MessageBox.Show( $"Das Universum '{m_universe.Name}' wurde verändert.\n\nVSCode starten?",
                                                 "Universum wurde verändert",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question,
                                                 MessageBoxDefaultButton.Button1 ) == DialogResult.Yes )
                            {
                                try
                                {
                                    ProcessStartInfo startInfo = new ProcessStartInfo()
                                    {
                                        FileName = "code",
                                        Arguments = $"\"{m_universePath}\"",
                                        UseShellExecute = true,
                                        WindowStyle = ProcessWindowStyle.Hidden
                                    };

                                    Process.Start( startInfo );
                                }
                                catch( Exception ex )
                                {
                                    MessageBox.Show( ex.ToString() );
                                }
                            }
                        }
                    }
                }
                catch( RepositoryNotFoundException ex )
                {
                    MessageBox.Show( ex.Message );
                }
                catch( Exception ex )
                {
                    MessageBox.Show( ex.Message );
                }
            }
        }

        private void pictureBoxInfo_Click( object sender, EventArgs e )
        {
            using( var infoForm = new UniverseInfoForm( m_universe ) )
            {
                infoForm.ShowDialog();
            }
        }

        private void buttons_Paint(object sender, PaintEventArgs e)
        {
            var button = (Button)sender;

            string toolTip = toolTip1.GetToolTip(button);

            ButtonText.Draw(button, toolTip, e.Graphics);
        }
    }
}
