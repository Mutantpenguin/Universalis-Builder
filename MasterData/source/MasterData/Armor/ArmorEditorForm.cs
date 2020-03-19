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

            this.Icon = Properties.Resources.icon;

            eLevelBindingSource.DataSource = DamageType.ELevelList;

            m_originalArmor = armor;

            Armor modifiedArmor = new Armor( armor );

            armorBindingSource.DataSource = modifiedArmor;

            if( null != modifiedArmor.AttributeModifier )
            {
                toolStripButtonAttribMod.Checked = true;
                toolStripButtonAttribMod.Image = Properties.Resources.ui_check_box;

                attributeModifierBindingSource.DataSource = modifiedArmor.AttributeModifier;
            }
            else
            {
                tableLayoutPanelAttribMods.Enabled = false;
            }

            comboBoxCamouflage.DataSource = Armor.ECamouflageList;
            comboBoxCamouflage.SelectedItem = modifiedArmor.Camouflage;
            numericUpDownCamouflageLevel.Enabled = ( modifiedArmor.Camouflage != Armor.ECamouflage.Keine );

            updateDamageEffects();
            updateDamageTypes();
        }

        private readonly Armor m_originalArmor;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return ( false );
            }

            if( numericUpDownPoints.Value == 0 )
            {
                MessageBox.Show( "Achtung, die Punkte stehen auf '0'!" );
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

        private void toolStripButtonAttribMod_Click( object sender, EventArgs e )
        {
            if( toolStripButtonAttribMod.Checked )
            {
                toolStripButtonAttribMod.Image = Properties.Resources.ui_check_box;

                AttributeModifier attributeModifier = new AttributeModifier
                {
                    AGI = 0,
                    BW = 0,
                    KO = 0,
                    FK = 0,
                    WN = 0,
                    EH = 0
                };

                ( (Armor)armorBindingSource.DataSource ).AttributeModifier = attributeModifier;

                attributeModifierBindingSource.DataSource = attributeModifier;

                tableLayoutPanelAttribMods.Enabled = true;
            }
            else
            {
                toolStripButtonAttribMod.Image = Properties.Resources.ui_check_box_uncheck;

                ( (Armor)armorBindingSource.DataSource ).AttributeModifier = null;

                attributeModifierBindingSource.DataSource = typeof( AttributeModifier );

                tableLayoutPanelAttribMods.Enabled = false;
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
                            ArmorStorage.Save( m_originalArmor );
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
                    ArmorStorage.Save( m_originalArmor );
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
            using( ActorDisplayForm actorDisplay = new ActorDisplayForm( ActorStorage.Instance.ActorsWithArmor( m_originalArmor ) ) )
            {
                actorDisplay.ShowDialog( this );
            }
        }
    }
}
