using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Universalis
{
    public partial class WeaponEditorForm : Form
    {
        public WeaponEditorForm( Weapon weapon )
        {
            if( null == weapon )
            {
                throw new ArgumentNullException( nameof( weapon ) );
            }

            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            m_originalWeapon = weapon;

            Weapon modifiedWeapon = new Weapon( weapon );

            weaponBindingSource.DataSource = modifiedWeapon;

            weaponRangeBindingSource.DataSource = modifiedWeapon.WeaponRange;

            comboBoxWK.DataSource = Weapon.EClassList;
            comboBoxWK.SelectedItem = weapon.WK;

            comboBoxType.DataSource = Weapon.ETypeList;
            comboBoxType.SelectedItem = weapon.Type;

            comboBoxDamageTypeType.DataSource = DamageType.ETypeList;
            comboBoxDamageTypeType.SelectedItem = weapon.DamageType.Type;

            comboBoxDamageTypeLevel.DataSource = DamageType.ELevelList;
            comboBoxDamageTypeLevel.SelectedItem = weapon.DamageType.Level;

            updateEffects();

            damageEffectsBindingSource.CurrentItemChanged += ChildBindingSource_CurrentItemChanged;
        }

        private void ChildBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            weaponBindingSource.ResetCurrentItem();
        }

        private readonly Weapon m_originalWeapon;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return ( false );
            }

            if( !String.IsNullOrEmpty( textBoxRules.Text )
                &&
                ( numericUpDownAdditionalPoints.Value == 0 ) )
            {
                MessageBox.Show( "Achtung, die zusätzlichen Punkte stehen auf '0', obwohl Regeln eingetragen wurden!" );
            }

            if( String.IsNullOrEmpty( textBoxRules.Text )
                &&
                ( numericUpDownAdditionalPoints.Value > 0 ) )
            {
                MessageBox.Show( "Achtung, es sind keine Regeln eingetragen, die zusätzlichen Punkte stehen aber nicht auf '0'!" );
            }

            if( numericUpDownWeight.Value == 0 )
            {
                MessageBox.Show( "Achtung, das Gewicht steht auf '0'!" );
            }

            var weapon = ( weaponBindingSource.DataSource as Weapon );

            if( weapon.AdditiveStrength && weapon.Strength == 0 )
            {
                MessageBox.Show( "Bei additiver Stärke muss die Stärke größer 0 sein!" );
                return ( false );
            }

            return ( true );
        }

        private void weaponRangeBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            updateMaxRange();
        }

        private void updateMaxRange()
        {
            textBoxMaxRange.Text = ( (Weapon)weaponBindingSource.DataSource ).MaxRange;
        }

        private void comboBoxWK_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Weapon)weaponBindingSource.DataSource ).WK = (Weapon.EClass)comboBoxWK.SelectedItem;

            weaponBindingSource.ResetCurrentItem();
        }

        private void comboBoxType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Weapon)weaponBindingSource.DataSource ).Type = (Weapon.EType)comboBoxType.SelectedItem;

            updateMaxRange();
        }

        private void comboBoxDamageTypeType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Weapon)weaponBindingSource.DataSource ).DamageType.Type = (DamageType.EType)comboBoxDamageTypeType.SelectedItem;
            
            pictureBoxDamageType.Image = ( (Weapon)weaponBindingSource.DataSource ).DamageTypeImage;
        }

        private void comboBoxDamageTypeLevel_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Weapon)weaponBindingSource.DataSource ).DamageType.Level = (DamageType.ELevel)comboBoxDamageTypeLevel.SelectedItem;

            pictureBoxDamageType.Image = ( (Weapon)weaponBindingSource.DataSource ).DamageTypeImage;

            weaponBindingSource.ResetCurrentItem();
        }

        private void updateEffects()
        {
            Weapon weapon = (Weapon)weaponBindingSource.DataSource;

            if( null != weapon.DamageEffectList )
            {
                damageEffectsBindingSource.DataSource = weapon.DamageEffectList.OrderBy( x => x.Name )
                                                                               .ToList();
            }

            dataGridViewDamageEffects.ClearSelection();

            pictureBoxDamageEffects.Image = weapon.EffectsImage;
            toolTip.SetToolTip( pictureBoxDamageEffects, weapon.EffectsString );
        }

        private void toolStripButtonAddEffect_Click( object sender, EventArgs e )
        {
            using( DamageEffectSelectionForm effectSelectionForm = new DamageEffectSelectionForm( DamageEffect.EUsageType.Waffe, ( (Weapon)weaponBindingSource.DataSource ).DamageEffectList ) )
            {
                if( effectSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( effectSelectionForm.SelectedDamageEffects.Count > 0 )
                    {
                        if( null == ( (Weapon)weaponBindingSource.DataSource ).DamageEffectList )
                        {
                            ( (Weapon)weaponBindingSource.DataSource ).DamageEffectList = new List<DamageEffect>();
                        }

                        foreach( DamageEffect damageEffect in effectSelectionForm.SelectedDamageEffects )
                        {
                            ( (Weapon)weaponBindingSource.DataSource ).DamageEffectList.Add( damageEffect );
                        }

                        updateEffects();
                    }
                }
            }
        }

        private void toolStripButtonRemoveEffect_Click( object sender, EventArgs e )
        {
            if( dataGridViewDamageEffects.SelectedRows.Count > 0 )
            {
                DamageEffect damageEffect = (DamageEffect)( dataGridViewDamageEffects.Rows[ dataGridViewDamageEffects.SelectedRows[ 0 ].Index ].DataBoundItem );
                ( (Weapon)weaponBindingSource.DataSource ).DamageEffectList.RemoveAll( x => x.ID == damageEffect.ID );

                updateEffects();
            }
        }

        private void WeaponEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Weapon weaponModified = (Weapon)weaponBindingSource.DataSource;

            if( !weaponModified.Equals( m_originalWeapon ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalWeapon.Set( weaponModified );
                            MasterDataStorage.Weapon.Save( m_originalWeapon );
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
                m_originalWeapon.Set( (Weapon)weaponBindingSource.DataSource );
                MasterDataStorage.Weapon.Save( m_originalWeapon );
            }
        }

        private void WeaponEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void comboBoxType_SelectedValueChanged( object sender, EventArgs e )
        {
            Weapon weapon = (Weapon)weaponBindingSource.DataSource;

            switch( weapon.Type )
            {
                case Weapon.EType.Fernkampf:
                    numericUpDownWeaponRangeLength.Enabled = true;
                    numericUpDownWeaponRangeAmount.Enabled = true;
                    numericUpDownAF.Enabled = true;
                    checkBoxIndirectFire.Enabled = true;
                    checkBoxIndirectFire.Checked = false;
                    break;

                case Weapon.EType.Nahkampf:
                    numericUpDownWeaponRangeLength.Enabled = false;
                    numericUpDownWeaponRangeAmount.Enabled = false;
                    numericUpDownAF.Enabled = false;
                    numericUpDownAF.Value = 0;
                    checkBoxIndirectFire.Enabled = false;
                    checkBoxIndirectFire.Checked = false;
                    break;

                case Weapon.EType.Wurf:
                    numericUpDownWeaponRangeLength.Enabled = false;
                    numericUpDownWeaponRangeAmount.Enabled = false;
                    numericUpDownAF.Enabled = false;
                    numericUpDownAF.Value = 0;
                    checkBoxIndirectFire.Enabled = false;
                    checkBoxIndirectFire.Checked = true;
                    break;

                default:
                    throw new InvalidOperationException( "unkown Weapon.EType" );
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            using( ActorDisplayForm actorDisplay = new ActorDisplayForm( MasterDataStorage.Actor.ActorsWithWeapon( m_originalWeapon ) ) )
            {
                actorDisplay.ShowDialog( this );
            }
        }
    }
}
