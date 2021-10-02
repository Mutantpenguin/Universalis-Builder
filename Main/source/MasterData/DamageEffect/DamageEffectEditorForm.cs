using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public partial class DamageEffectEditorForm : Form
    {
        public DamageEffectEditorForm( DamageEffect damageEffect )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            m_originalDamageEffect = damageEffect;

            DamageEffect modifiedDamageEffect = new DamageEffect( damageEffect );

            damageEffectBindingSource.DataSource = modifiedDamageEffect;

            toolStripComboBoxUsageType.ComboBox.DataSource = DamageEffect.EUsageTypeList;
            toolStripComboBoxUsageType.ComboBox.SelectedItem = modifiedDamageEffect.UsageType;
            toolStripComboBoxUsageType.ComboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
        }

        private void ComboBox_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (DamageEffect)damageEffectBindingSource.DataSource ).UsageType = (DamageEffect.EUsageType)toolStripComboBoxUsageType.SelectedItem;
        }

        private readonly DamageEffect m_originalDamageEffect;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return ( false );
            }

            if( String.IsNullOrEmpty( textBoxRules.Text ) )
            {
                MessageBox.Show( "Regeln sind leer, bitte angeben!" );
                return ( false );
            }

            if( numericUpDownPoints.Value == 0 )
            {
                MessageBox.Show( "Punkte sind leer, bitte angeben!" );
                return ( false );
            }

            if( pictureBoxIcon.Image == null )
            {
                MessageBox.Show( "Icon ist leer, bitte angeben!" );
                return ( false );
            }

            return ( true );
        }

        private void TraitEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            DamageEffect damageEffectModified = (DamageEffect)damageEffectBindingSource.DataSource;

            if( !damageEffectModified.Equals( m_originalDamageEffect ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalDamageEffect.Set( damageEffectModified );
                            MasterDataStorage.DamageEffect.Save( m_originalDamageEffect );
                        }
                        else
                        {
                            if( MessageBox.Show( "Es fehlen noch Pflichtangaben! Änderungen verwerfen?", "Pflichtangaben fehlen", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                            {
                                e.Cancel = true;
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void toolStripButtonSave_Click( object sender, EventArgs e )
        {
            if( mandatoryFieldsFilled() )
            {
                m_originalDamageEffect.Set( (DamageEffect)damageEffectBindingSource.DataSource );
                MasterDataStorage.DamageEffect.Save( m_originalDamageEffect );
            }
        }

        private void TraitEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            contextMenuStripUsage.Show( toolStripMain.PointToScreen( toolStripButtonUsage.Bounds.Location ) );
        }

        private void armorToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using( ArmorDisplayForm armorDisplay = new ArmorDisplayForm( MasterDataStorage.Armor.ArmorsWithDamageEffect( m_originalDamageEffect ) ) )
            {
                armorDisplay.ShowDialog( this );
            }
        }

        private void weaponToolStripMenuItem_Click( object sender, EventArgs e )
        {
            using( WeaponDisplayForm weaponDisplay = new WeaponDisplayForm( MasterDataStorage.Weapon.WeaponsWithDamageEffect( m_originalDamageEffect ) ) )
            {
                weaponDisplay.ShowDialog( this );
            }
        }

        private void pictureBoxIcon_DoubleClick( object sender, EventArgs e )
        {
            using( OpenFileDialog iconFileDialog = new OpenFileDialog() )
            {
                iconFileDialog.InitialDirectory = Properties.Settings.Default.factionIconFilePath;

                if( iconFileDialog.ShowDialog() == DialogResult.OK )
                {
                    Properties.Settings.Default.factionIconFilePath = Path.GetDirectoryName( iconFileDialog.FileName );
                    Properties.Settings.Default.Save();

                    // TODO resize if too big?
                    using( FileStream fs = new FileStream( iconFileDialog.FileName, FileMode.Open, FileAccess.Read ) )
                    {
                        Bitmap img = new Bitmap( fs );

                        if( img.Width != img.Height )
                        {
                            MessageBox.Show( "Es sind nur quadratische Bilder erlaubt!",
                                             "",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Stop );
                        }
                        else
                        {
                            pictureBoxIcon.Image = img;
                            ( (DamageEffect)damageEffectBindingSource.DataSource ).Icon = new Bitmap( img );
                        }
                    }
                }
            }
        }
    }
}
