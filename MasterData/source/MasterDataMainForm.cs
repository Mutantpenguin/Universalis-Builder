using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public partial class MasterDataMainForm : Form
    {
        public MasterDataMainForm()
        {
            try
            {
                if( Properties.Settings.Default.UpgradeSettings )
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.UpgradeSettings = false;
                    Properties.Settings.Default.Save();
                }
            }
            catch( ConfigurationException ex )
            {
                string filename = ( (ConfigurationException)ex.InnerException ).Filename;

                File.Delete( filename );
                Properties.Settings.Default.Reload();
            }

            Storage.Setup();

            using( ProgressForm progressForm = new ProgressForm() )
            {
                // load the masterdata
                FactionStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );
                TraitStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );
                ArmorStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );
                WeaponStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );
                EquipmentStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );

                // load Actors after loading the masterdata
                ActorStorage.Instance.LoadAll( progressForm.CreateBackgroundWorker() );

                progressForm.ShowDialog();
            }

            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;
        }

        ActorManagerForm actorManager = null;
        WeaponManagerForm weaponManager = null;
        ArmorManagerForm armorManager = null;
        EquipmentManagerForm equipmentManager = null;
        TraitsManagerForm traitsManager = null;
        FactionManagerForm factionManager = null;

        private void buttonActors_Click( object sender, EventArgs e )
        {
            actorManager = new ActorManagerForm();

            actorManager.FormClosed += delegate
            {
                buttonActors.Enabled = true;
                actorManager = null;
            };

            buttonActors.Enabled = false;

            actorManager.Show( this );
        }

        private void buttonWeapons_Click( object sender, EventArgs e )
        {
            weaponManager = new WeaponManagerForm();

            weaponManager.FormClosed += delegate
            {
                buttonWeapons.Enabled = true;
                weaponManager = null;
            };

            buttonWeapons.Enabled = false;

            weaponManager.Show( this );
        }

        private void buttonArmor_Click( object sender, EventArgs e )
        {
            armorManager = new ArmorManagerForm();

            armorManager.FormClosed += delegate
            {
                buttonArmor.Enabled = true;
                armorManager = null;
            };

            buttonArmor.Enabled = false;

            armorManager.Show( this );
        }

        private void buttonEquipment_Click( object sender, EventArgs e )
        {
            equipmentManager = new EquipmentManagerForm();

            equipmentManager.FormClosed += delegate
            {
                buttonEquipment.Enabled = true;
                equipmentManager = null;
            };

            buttonEquipment.Enabled = false;

            equipmentManager.Show( this );
        }

        private void buttonTraits_Click( object sender, EventArgs e )
        {
            traitsManager = new TraitsManagerForm();

            traitsManager.FormClosed += delegate
            {
                buttonTraits.Enabled = true;
                traitsManager = null;
            };

            buttonTraits.Enabled = false;

            traitsManager.Show( this );
        }

        private void buttonFactions_Click( object sender, EventArgs e )
        {
            factionManager = new FactionManagerForm();

            factionManager.FormClosed += delegate
            {
                buttonFactions.Enabled = true;
                factionManager = null;
            };

            buttonFactions.Enabled = false;

            factionManager.Show( this );
        }

        private void MasterDataMainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( actorManager != null
                ||
                weaponManager != null
                ||
                armorManager != null
                ||
                equipmentManager != null
                ||
                traitsManager != null
                ||
                factionManager != null )
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

        private void buttonExit_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}
