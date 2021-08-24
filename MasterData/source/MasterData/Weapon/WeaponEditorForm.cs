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

            if( null != modifiedWeapon.ProfileModifier )
            {
                toolStripButtonProfileMod.Checked = true;
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                textBoxProfileModifier.Text = modifiedWeapon.ProfileModifier.ToString();
            }
            else
            {
                toolStripButtonProfileModEditor.Enabled = false;
                panelProfileModifier.Visible = false;
            }

            if( modifiedWeapon.Range != null )
            {
                weaponRangeBindingSource.DataSource = modifiedWeapon.Range;
            }
            else
            {
                weaponRangeBindingSource.DataSource = new WeaponRange();
            }

            comboBoxWeaponClass.DataSource = Weapon.EClassList;
            comboBoxWeaponClass.SelectedItem = weapon.Class;

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

            if( weapon.UseOnce && ( weapon.ProfileModifier != null ) )
            {
                MessageBox.Show( "Einmalnutzung darf nicht mit Profil-Modifikatoren kombiniert werden!" );
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

        private void comboBoxWeaponClass_SelectionChangeCommitted( object sender, EventArgs e )
        {
            ( (Weapon)weaponBindingSource.DataSource ).Class = (Weapon.EClass)comboBoxWeaponClass.SelectedItem;

            weaponBindingSource.ResetCurrentItem();
        }

        private void comboBoxType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            Weapon weapon = (Weapon)weaponBindingSource.DataSource;

            weapon.Type = (Weapon.EType)comboBoxType.SelectedItem;

            switch( weapon.Type )
            {
                case Weapon.EType.Fernkampf:
                    if( m_originalWeapon.Range != null )
                    {
                        weapon.Range = new WeaponRange()
                        {
                            Length = m_originalWeapon.Range.Length,
                            Amount = m_originalWeapon.Range.Amount
                        };
                    }
                    else
                    {
                        weapon.Range = new WeaponRange()
                        {
                            Length = 10,
                            Amount = 1
                        };
                    }
                    break;

                case Weapon.EType.Nahkampf:
                case Weapon.EType.Wurf:
                    weapon.Range = null;
                    break;
            }

            if( weapon.Range != null )
            {
                weaponRangeBindingSource.DataSource = weapon.Range;
            }
            else
            {
                weaponRangeBindingSource.DataSource = new WeaponRange();
            }

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
            if( dataGridViewDamageEffects.Rows.Count >= 5 )
            {
                MessageBox.Show(    "Es dürfen maximal 5 Schadenseffekte ausgewählt werden.",
                                    "Maximum erreicht",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop );
            }
            else
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

                            ( (Weapon)weaponBindingSource.DataSource ).DamageEffectList.AddRange( effectSelectionForm.SelectedDamageEffects );

                            updateEffects();
                        }
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
                    numericUpDownSustainedFire.Enabled = true;
                    checkBoxIndirectFire.Enabled = true;
                    checkBoxIndirectFire.Checked = false;
                    break;

                case Weapon.EType.Nahkampf:
                    numericUpDownWeaponRangeLength.Enabled = false;
                    numericUpDownWeaponRangeAmount.Enabled = false;
                    numericUpDownSustainedFire.Enabled = false;
                    numericUpDownSustainedFire.Value = 0;
                    checkBoxIndirectFire.Enabled = false;
                    checkBoxIndirectFire.Checked = false;
                    break;

                case Weapon.EType.Wurf:
                    numericUpDownWeaponRangeLength.Enabled = false;
                    numericUpDownWeaponRangeAmount.Enabled = false;
                    numericUpDownSustainedFire.Enabled = false;
                    numericUpDownSustainedFire.Value = 0;
                    checkBoxIndirectFire.Enabled = false;
                    checkBoxIndirectFire.Checked = true;
                    break;

                default:
                    throw new InvalidOperationException( "unkown Weapon.EType" );
            }
        }

        private void toolStripButtonProfileMod_Click( object sender, EventArgs e )
        {
            var weapon = (Weapon)weaponBindingSource.DataSource;

            if( toolStripButtonProfileMod.Checked )
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                var profileModifier = new ProfileModifier();

                weapon.ProfileModifier = profileModifier;

                toolStripButtonProfileModEditor.Enabled = true;
                panelProfileModifier.Visible = true;

                openProfileModEditor();
            }
            else
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box_uncheck;

                weapon.ProfileModifier = null;

                toolStripButtonProfileModEditor.Enabled = false;
                panelProfileModifier.Visible = false;

                textBoxProfileModifier.Text = String.Empty;

                weaponBindingSource.ResetBindings( false );
            }
        }

        private void toolStripButtonProfileModEditor_Click( object sender, EventArgs e )
        {
            openProfileModEditor();
        }

        private void openProfileModEditor()
        {
            var armor = (Weapon)weaponBindingSource.DataSource;

            using( var profileModifierEditor = new ProfileModifierEditor( armor.ProfileModifier ) )
            {
                if( profileModifierEditor.ShowDialog( this ) == DialogResult.OK )
                {
                    armor.ProfileModifier = profileModifierEditor.ProfileModifier;
                    textBoxProfileModifier.Text = armor.ProfileModifier.ToString();
                    weaponBindingSource.ResetBindings( false );
                }
            }
        }
    }
}
