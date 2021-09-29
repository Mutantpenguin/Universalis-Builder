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

                textBoxProfileModifier.Text = m_modifiedArmor.ProfileModifier.Summary();
            }
            else
            {
                toolStripButtonProfileModEditor.Enabled = false;
                panelProfileModifier.Visible = false;
            }

            updateDamageEffects();
            updateDamageTypes();

            damageEffectsBindingSource.CurrentItemChanged += DamageEffectsBindingSource_CurrentItemChanged;
            damageTypeBindingSource.CurrentItemChanged += DamageTypeBindingSource_CurrentItemChanged;

            SetupPermittedConditions();
        }

        private void SetupPermittedConditions()
        {
            if( numericUpDownAdditionalPoints.Value == 0 )
            {
                textBoxRules.Visible = false;
            }
            else
            {
                textBoxRules.Visible = true;
            }
        }

        private void DamageTypeBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            armorBindingSource.ResetCurrentItem();
        }

        private void DamageEffectsBindingSource_CurrentItemChanged( object sender, EventArgs e )
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

            if( numericUpDownWeight.Value == 0 )
            {
                MessageBox.Show( "Achtung, das Gewicht steht auf '0'!" );
            }

            if( ( numericUpDownAdditionalPoints.Value == 0 ) && !String.IsNullOrEmpty( textBoxRules.Text ) )
            {
                if( MessageBox.Show( "Ohne Zusatzpunkte können keine Regeln verwendet werden. Weiter und Regeln löschen?",
                                     "Ohne Punkte keine Regeln",
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    textBoxRules.Text = String.Empty;
                }
                else
                {
                    return ( false );
                }
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
                damageEffectsBindingSource.DataSource = armor.DamageEffectList.OrderBy( x => x.Name )
                                                                              .ToList();
            }

            dataGridViewDamageEffects.ClearSelection();

            pictureBoxDamageEffects.Image = armor.EffectsImage;
            toolTip.SetToolTip( pictureBoxDamageEffects, armor.EffectsString );
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
                using( DamageEffectSelectionForm effectSelectionForm = new DamageEffectSelectionForm( DamageEffect.EUsageType.Rüstung, ( (Armor)armorBindingSource.DataSource ).DamageEffectList ) )
                {
                    if( effectSelectionForm.ShowDialog( this ) == DialogResult.OK )
                    {
                        if( effectSelectionForm.SelectedDamageEffects.Count > 0 )
                        {
                            if( null == ( (Armor)armorBindingSource.DataSource ).DamageEffectList )
                            {
                                ( (Armor)armorBindingSource.DataSource ).DamageEffectList = new List<DamageEffect>();
                            }

                            ( (Armor)armorBindingSource.DataSource ).DamageEffectList.AddRange( effectSelectionForm.SelectedDamageEffects );

                            updateDamageEffects();
                        }
                    }
                }
            }
        }

        private void toolStripButtonRemoveEffect_Click( object sender, EventArgs e )
        {
            if( dataGridViewDamageEffects.SelectedRows.Count > 0 )
            {
                var damageEffect = (DamageEffect)( dataGridViewDamageEffects.Rows[ dataGridViewDamageEffects.SelectedRows[ 0 ].Index ].DataBoundItem );
                ( (Armor)armorBindingSource.DataSource ).DamageEffectList.RemoveAll( x => x.ID == damageEffect.ID );

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

                toolStripButtonProfileModEditor.Enabled = true;
                panelProfileModifier.Visible = true;

                openProfileModEditor();
            }
            else
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box_uncheck;

                m_modifiedArmor.ProfileModifier = null;

                toolStripButtonProfileModEditor.Enabled = false;
                panelProfileModifier.Visible = false;

                textBoxProfileModifier.Text = String.Empty;

                armorBindingSource.ResetBindings( false );
            }

            SetupPermittedConditions();
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

                        ( (Armor)armorBindingSource.DataSource ).DamageTypeList.AddRange( damageTypeSelectionForm.SelectedDamageTypes );

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
                m_originalArmor.Set( (Armor)armorBindingSource.DataSource );
                MasterDataStorage.Armor.Save( m_originalArmor );
            }
        }

        private void ArmorEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void dataGridViewDamageTypes_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( dataGridViewDamageTypes.CurrentCell.ColumnIndex == typeLevelDataGridViewComboBoxColumn.Index )
            {
                dataGridViewDamageTypes.CommitEdit( DataGridViewDataErrorContexts.Commit );

                updateDamageTypes();
            }
        }

        private void toolStripButtonProfileModEditor_Click( object sender, EventArgs e )
        {
            openProfileModEditor();
        }

        private void openProfileModEditor()
        {
            var armor = (Armor)armorBindingSource.DataSource;

            using( var profileModifierEditor = new ProfileModifierEditor( armor.ProfileModifier ) )
            {
                if( profileModifierEditor.ShowDialog( this ) == DialogResult.OK )
                {
                    armor.ProfileModifier = profileModifierEditor.ProfileModifier;
                    textBoxProfileModifier.Text = armor.ProfileModifier.Summary();
                    armorBindingSource.ResetBindings( false );
                }
            }
        }

        private void numericUpDownAdditionalPoints_ValueChanged( object sender, EventArgs e )
        {
            SetupPermittedConditions();
        }
    }
}
