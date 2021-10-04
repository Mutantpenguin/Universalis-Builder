using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GodModeForm : Form
    {
        public GodModeForm( Universe universe, string universePath )
        {
            m_universe = universe;
            m_universePath = universePath;

            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            labelHeader.Text = universe.NameWithVersionAndHash();
            labelHeader.Font = new Font( UniversalisFont.Family, 20 );
            labelHeader.Left = ( panelHeader.Width - labelHeader.Width ) / 2;
            labelHeader.Top = ( panelHeader.Height - labelHeader.Height ) / 2;
        }

        FactionOverviewForm factionOverviewForm = null;
        MasterDataMainForm masterDataMainForm = null;

        private void buttonQuit_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        readonly Universe m_universe;
        readonly string m_universePath;

        private void buttonGroups_Click( object sender, EventArgs e )
        {
            factionOverviewForm = new FactionOverviewForm( m_universe, godMode: true );

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
                            if( MessageBox.Show( "Das Universum wurde modifiziert. Änderungen committen?",
                                                 "Universum wurde modifiziert",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning,
                                                 MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
                            {
                                Signature signature = repo.Config.BuildSignature( DateTimeOffset.Now );

                                Commands.Stage( repo, "*" );

                                // TODO hier commit message abfragen in Schleife, es seih denn es soll doch nicht comittet werden

                                repo.Commit( "newest changes", signature, signature );
                            }
                        }

                        /*
                        if( repo.Head.TrackingDetails.AheadBy > 0 )
                        {
                            // TODO push doesn't work without username and password
                            // TODO but why does it work on the console without entering anything?

                            
                            var pushOptions = new PushOptions();
                            pushOptions.CredentialsProvider = new CredentialsHandler(
                                    ( _url, _user, _cred ) =>
                                    new cred() );
                            
                            //new UsernamePasswordCredentials() {  Username = Settings.GetSetting( Constants.GitUsername ), Password = Settings.GetSetting( Constants.GitPassword ) );


                            //repo.Network.Push( repo.Network.Remotes[ "origin" ], repo.Head.CanonicalName, null, pushOptions );
                            //repo.Network.Push( repo.Network.Remotes[ "origin" ], repo.Head.CanonicalName, repo.Config. );
                        }
                        */
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
    }
}
