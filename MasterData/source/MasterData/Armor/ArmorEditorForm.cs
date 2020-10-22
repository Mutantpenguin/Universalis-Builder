using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ArmorEditorForm : Form
    {
        public ArmorEditorForm( Armor armor )
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            eLevelBindingSource.DataSource = DamageType.ELevelList.Where( x => x != DamageType.ELevel.O );

            m_originalArmor = armor;

            m_modifiedArmor = new Armor( armor );

            armorBindingSource.DataSource = m_modifiedArmor;

            if( null != m_modifiedArmor.ProfileModifier )
            {
                toolStripButtonProfileMod.Checked = true;
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                profileModifierBindingSource.DataSource = m_modifiedArmor.ProfileModifier;

                attributeModifierBindingSource.DataSource = m_modifiedArmor.ProfileModifier.AttributeModifier;
            }
            else
            {
                panelProfileMods.Enabled = false;
            }

            comboBoxCamouflage.DataSource = Armor.ECamouflageList;
            comboBoxCamouflage.SelectedItem = m_modifiedArmor.Camouflage;
            numericUpDownCamouflageLevel.Enabled = ( m_modifiedArmor.Camouflage != Armor.ECamouflage.Keine );

            updateDamageEffects();
            updateDamageTypes();

            profileModifierBindingSource.CurrentItemChanged += ProfileModifierBindingSource_CurrentItemChanged;
            attributeModifierBindingSource.CurrentItemChanged += AttributeModifierBindingSource_CurrentItemChanged;

            damageEffectsBindingSource.CurrentItemChanged += DamageEffectsBindingSource_CurrentItemChanged;
            damageTypeBindingSource.CurrentItemChanged += DamageTypeBindingSource_CurrentItemChanged;
        }

        private void DamageTypeBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            armorBindingSource.ResetCurrentItem();
        }

        private void DamageEffectsBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            armorBindingSource.ResetCurrentItem();
        }

        private void AttributeModifierBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            profileModifierBindingSource.ResetCurrentItem();
        }

        private void ProfileModifierBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            armorBindingSource.ResetCurrentItem();
        }

        private readonly Armor m_originalArmor;
        private Armor m_modifiedArmor;

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

            return ( true );
        }

        private void updateDamageTypes()
        {
            Armor armor = (Armor)armorBindingSource.DataSource;

            if( null != armor.DamageTypeList )
            {
                damageTypeBindingSource.DataSource = armor.DamageTypeList.OrderBy( x => x.Type.ToString() )
                                                                         .ToList();
            }

            dataGridViewDamageTypes.ClearSelection();

            pictureBoxDamageTypes.Image = armor.TypesImage;
        }

        private void updateDamageEffects()
        {
            Armor armor = (Armor)armorBindingSource.DataSource;

            if( null != armor.DamageEffectList )
            {
                damageEffectsBindingSource.DataSource = armor.DamageEffectList.OrderBy( x => x.Type.ToString() )
                                                                              .ToList();
            }

            dataGridViewDamageEffects.ClearSelection();

            pictureBoxDamageEffects.Image = armor.EffectsImage;
            toolTip.SetToolTip( pictureBoxDamageEffects, armor.EffectsString );
        }

        private void toolStripButtonAddEffect_Click( object sender, EventArgs e )
        {
            using( EffectSelectionForm effectSelectionForm = new EffectSelectionForm( ( (Armor)armorBindingSource.DataSource ).DamageEffectList ) )
            {
                if( effectSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( effectSelectionForm.SelectedDamageEffects.Count > 0 )
                    {
                        if( null == ( (Armor)armorBindingSource.DataSource ).DamageEffectList )
                        {
                            ( (Armor)armorBindingSource.DataSource ).DamageEffectList = new List<DamageEffect>();
                        }

                        foreach( DamageEffect damageEffect in effectSelectionForm.SelectedDamageEffects )
                        {
                            ( (Armor)armorBindingSource.DataSource ).DamageEffectList.Add( damageEffect );
                        }

                        updateDamageEffects();
                    }
                }
            }
        }

        private void toolStripButtonRemoveEffect_Click( object sender, EventArgs e )
        {
            if( dataGridViewDamageEffects.SelectedRows.Count > 0 )
            {
                DamageEffect.EType type = ( (DamageEffect)( dataGridViewDamageEffects.Rows[ dataGridViewDamageEffects.SelectedRows[ 0 ].Index ].DataBoundItem ) ).Type;
                ( (Armor)armorBindingSource.DataSource ).DamageEffectList.RemoveAll( s => s.Type == type );

                updateDamageEffects();
            }
        }

        private void toolStripButtonProfileMod_Click( object sender, EventArgs e )
        {
            if( toolStripButtonProfileMod.Checked )
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                var profileModifier = new ProfileModifier();

                m_modifiedArmor.ProfileModifier = profileModifier;

                profileModifierBindingSource.DataSource = profileModifier;
                attributeModifierBindingSource.DataSource = profileModifier.AttributeModifier;

                panelProfileMods.Enabled = true;
            }
            else
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box_uncheck;

                m_modifiedArmor.ProfileModifier = null;

                profileModifierBindingSource.DataSource = typeof( ProfileModifier );
                attributeModifierBindingSource.DataSource = typeof( AttributeModifier );

                panelProfileMods.Enabled = false;
            }
        }

        private void toolStripButtonAddType_Click( object sender, EventArgs e )
        {
            Armor armor = ( (Armor)armorBindingSource.DataSource );

            using( DamageTypeSelectionForm damageTypeSelectionForm = new DamageTypeSelectionForm( armor.DamageTypeList ) )
            {
                if( damageTypeSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( damageTypeSelectionForm.SelectedDamageTypes.Count > 0 )
                    {
                        if( null == ( (Armor)armorBindingSource.DataSource ).DamageTypeList )
                        {
                            ( (Armor)armorBindingSource.DataSource ).DamageTypeList = new List<DamageType>();
                        }

                        foreach( DamageType damageType in damageTypeSelectionForm.SelectedDamageTypes )
                        {
                            ( (Armor)armorBindingSource.DataSource ).DamageTypeList.Add( damageType );
                        }

                        updateDamageTypes();
                    }
                }
            }
        }

        private void toolStripButtonRemoveType_Click( object sender, EventArgs e )
        {
            if( dataGridViewDamageTypes.SelectedRows.Count > 0 )
            {
                DamageType.EType type = ( (DamageType)( dataGridViewDamageTypes.Rows[ dataGridViewDamageTypes.SelectedRows[ 0 ].Index ].DataBoundItem ) ).Type;
                ( (Armor)armorBindingSource.DataSource ).DamageTypeList.RemoveAll( s => s.Type == type );

                updateDamageTypes();
            }
        }

        private void ArmorEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Armor armorModified = (Armor)armorBindingSource.DataSource;

            if( !armorModified.Equals( m_originalArmor ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalArmor.Set( armorModified );
                            MasterDataStorage.Armor.Save( m_originalArmor );
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
                if( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_originalArmor.Set( (Armor)armorBindingSource.DataSource );
                    MasterDataStorage.Armor.Save( m_originalArmor );
                }
            }
        }

        private void ArmorEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void comboBoxCamouflage_SelectionChangeCommitted( object sender, EventArgs e )
        {
            Armor.ECamouflage camouflage = (Armor.ECamouflage)comboBoxCamouflage.SelectedItem;

            ( (Armor)armorBindingSource.DataSource ).Camouflage = camouflage;

            numericUpDownCamouflageLevel.Enabled = ( camouflage != Armor.ECamouflage.Keine );

            armorBindingSource.ResetCurrentItem();
        }

        private void dataGridViewDamageTypes_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( dataGridViewDamageTypes.CurrentCell.ColumnIndex == typeLevelDataGridViewComboBoxColumn.Index )
            {
                dataGridViewDamageTypes.CommitEdit( DataGridViewDataErrorContexts.Commit );

                updateDamageTypes();
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            using( ActorDisplayForm actorDisplay = new ActorDisplayForm( MasterDataStorage.Actor.ActorsWithArmor( m_originalArmor ) ) )
            {
                actorDisplay.ShowDialog( this );
            }
        }
    }
}
