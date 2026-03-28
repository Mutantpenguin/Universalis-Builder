using System;
using System.Windows.Forms;
using static Universalis.Costs;

namespace Universalis
{
    public partial class EquipmentEditorForm : Form
    {
        public EquipmentEditorForm( Equipment equipment )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            m_originalEquipment = equipment;

            m_modifiedEquipment = new Equipment( equipment );

            equipmentBindingSource.DataSource = m_modifiedEquipment;

            if( null != m_modifiedEquipment.ProfileModifier )
            {
                toolStripButtonProfileMod.Checked = true;
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                textBoxProfileModifier.Text = m_modifiedEquipment.ProfileModifier.Summary();
            }
            else
            {
                toolStripButtonProfileModEditor.Enabled = false;
                panelProfileModifier.Visible = false;
            }

            if( null != m_modifiedEquipment.Permissions )
            {
                toolStripButtonPermissions.Checked = true;
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box;

                textBoxPermissions.Text = m_modifiedEquipment.Permissions.Summary();
            }
            else
            {
                toolStripButtonPermissionsEditor.Enabled = false;
                panelPermissions.Visible = false;
            }

            SetupPermittedConditions();
        }

        private void SetupPermittedConditions()
        {
            if( numericUpDownBasePoints.Value == 0 )
            {
                textBoxRules.Visible = false;
                numericUpDownAP.Enabled = false;
                checkBoxUseOnce.Enabled = false;
            }
            else
            {
                textBoxRules.Visible = true;
                numericUpDownAP.Enabled = true;
                checkBoxUseOnce.Enabled = true;
            }

            toolStripButtonProfileMod.Enabled = true;

            if( checkBoxUseOnce.Checked )
            {
                toolStripButtonProfileMod.Enabled = false;
            }
            else if( toolStripButtonProfileMod.Checked )
            {
                checkBoxUseOnce.Enabled = false;
            }
        }

        private readonly Equipment m_originalEquipment;
        private Equipment m_modifiedEquipment;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return false;
            }

            if( numericUpDownWeight.Value == 0 )
            {
                MessageBox.Show( "Achtung, das Gewicht steht auf '0'!" );
            }

            if( ( numericUpDownBasePoints.Value == 0 ) && ( !String.IsNullOrEmpty( textBoxRules.Text )
                                                                  ||
                                                                  ( numericUpDownAP.Value > 0 )
                                                                  ||
                                                                  checkBoxUseOnce.Checked ) )
            {
                if( MessageBox.Show( "Ohne Zusatzpunkte können keine Regeln/AP/Einmalnutzung verwendet werden. Weiter und Regeln/AP/Einmalnutzung löschen?",
                                     "Ohne Punkte keine Regeln",
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    textBoxRules.Text = String.Empty;
                    numericUpDownAP.Value = 0;
                    checkBoxUseOnce.Checked = false;
                }
                else
                {
                    return false;
                }
            }

            var equipment = ( equipmentBindingSource.DataSource as Equipment );

            if( equipment.MaxModelQuantity > 0 && equipment.MaxGroupQuantity > 0 && equipment.MaxGroupQuantity < equipment.MaxModelQuantity )
            {
                MessageBox.Show( "Die maximale Anzahl je Gruppe muss größer oder gleich der maximalen Anzahl je Modell sein!" );
                return false;
            }

            return true;
        }

        private void toolStripButtonProfileMod_Click( object sender, EventArgs e )
        {
            if( toolStripButtonProfileMod.Checked )
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                var profileModifier = new ProfileModifier();

                m_modifiedEquipment.ProfileModifier = profileModifier;

                toolStripButtonProfileModEditor.Enabled = true;
                panelProfileModifier.Visible = true;

                openProfileModEditor();
            }
            else
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box_uncheck;

                m_modifiedEquipment.ProfileModifier = null;

                toolStripButtonProfileModEditor.Enabled = false;
                panelProfileModifier.Visible = false;

                textBoxProfileModifier.Text = String.Empty;

                equipmentBindingSource.ResetBindings( false );
            }

            SetupPermittedConditions();
        }

        private void EquipmentEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Equipment equipmentModified = (Equipment)equipmentBindingSource.DataSource;

            if( !equipmentModified.Equals( m_originalEquipment ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalEquipment.Set( equipmentModified );
                            MasterDataStorage.Equipment.Save( m_originalEquipment );
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
                m_originalEquipment.Set( (Equipment)equipmentBindingSource.DataSource );
                MasterDataStorage.Equipment.Save( m_originalEquipment );
            }
        }

        private void EquipmentEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void toolStripButtonProfileModEditor_Click( object sender, EventArgs e )
        {
            openProfileModEditor();
        }

        private void openProfileModEditor()
        {
            var armor = (Equipment)equipmentBindingSource.DataSource;

            using( var profileModifierEditor = new ProfileModifierEditor( armor.ProfileModifier ) )
            {
                if( profileModifierEditor.ShowDialog( this ) == DialogResult.OK )
                {
                    armor.ProfileModifier = profileModifierEditor.ProfileModifier;
                    textBoxProfileModifier.Text = armor.ProfileModifier.Summary();
                    equipmentBindingSource.ResetBindings( false );
                }
            }
        }

        private void openPermissionsEditor()
        {
            var equipment = (Equipment)equipmentBindingSource.DataSource;

            using( var permissionsEditor = new PermissionsEditor( equipment.Permissions ) )
            {
                if( permissionsEditor.ShowDialog( this ) == DialogResult.OK )
                {
                    equipment.Permissions = permissionsEditor.Permissions;
                    textBoxPermissions.Text = equipment.Permissions.Summary();
                    equipmentBindingSource.ResetBindings( false );
                }
            }
        }

        private void numericUpDownBasePoints_ValueChanged( object sender, EventArgs e )
        {
            SetupPermittedConditions();
        }

        private void numericUpDownAP_ValueChanged( object sender, EventArgs e )
        {
            SetupPermittedConditions();
        }

        private void checkBoxUseOnce_CheckedChanged( object sender, EventArgs e )
        {
            SetupPermittedConditions();
        }

        private void toolStripButtonPermissions_Click( object sender, EventArgs e )
        {
            var equipment = (Equipment)equipmentBindingSource.DataSource;

            if( toolStripButtonPermissions.Checked )
            {
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box;

                var permissions = new Permissions();

                equipment.Permissions = permissions;

                toolStripButtonPermissionsEditor.Enabled = true;
                panelPermissions.Visible = true;

                openPermissionsEditor();
            }
            else
            {
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box_uncheck;

                equipment.Permissions = null;

                toolStripButtonPermissionsEditor.Enabled = false;
                panelPermissions.Visible = false;

                textBoxPermissions.Text = String.Empty;

                equipmentBindingSource.ResetBindings( false );
            }
        }

        private void toolStripButtonPermissionsEditor_Click( object sender, EventArgs e )
        {
            openPermissionsEditor();
        }

        private void textBoxPermissions_TextChanged( object sender, EventArgs e )
        {
            var messageSize = TextRenderer.MeasureText( textBoxPermissions.Text,
                                                        textBoxPermissions.Font,
                                                        new System.Drawing.Size( textBoxPermissions.Width, 0 ) );

            textBoxPermissions.Height = messageSize.Height;
        }
    }
}
