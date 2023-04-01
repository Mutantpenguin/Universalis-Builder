using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class TraitEditorForm : Form
    {
        public TraitEditorForm( Trait trait )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            m_originalTrait = trait;

            m_modifiedTrait = new Trait( trait );

            traitBindingSource.DataSource = m_modifiedTrait;

            if( null != m_modifiedTrait.ProfileModifier )
            {
                toolStripButtonProfileMod.Checked = true;
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                textBoxProfileModifier.Text = m_modifiedTrait.ProfileModifier.Summary();
            }
            else
            {
                toolStripButtonProfileModEditor.Enabled = false;
                panelProfileModifier.Visible = false;
            }

            if( null != m_modifiedTrait.Permissions )
            {
                toolStripButtonPermissions.Checked = true;
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box;

                textBoxPermissions.Text = m_modifiedTrait.Permissions.Summary();
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
                numericUpDownMaxLevel.Enabled = false;
                labelMaxLevel.Enabled = false;
                buttonInsertLevelPlaceholder.Enabled = false;
                numericUpDownAP.Enabled = false;
                checkBoxUseOnce.Enabled = false;
            }
            else
            {
                textBoxRules.Visible = true;
                numericUpDownMaxLevel.Enabled = true;
                labelMaxLevel.Enabled = true;
                buttonInsertLevelPlaceholder.Enabled = true;
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

        private readonly Trait m_originalTrait;
        private Trait m_modifiedTrait;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return false;
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
                    numericUpDownMaxLevel.Value = 1;
                    numericUpDownAP.Value = 0;
                    checkBoxUseOnce.Checked = false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private void TraitEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( !m_modifiedTrait.Equals( m_originalTrait ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalTrait.Set( m_modifiedTrait );
                            MasterDataStorage.Trait.Save( m_originalTrait );
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
                m_originalTrait.Set( (Trait)traitBindingSource.DataSource );
                MasterDataStorage.Trait.Save( m_originalTrait );
            }
        }

        private void TraitEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void toolStripButtonProfileMod_Click( object sender, EventArgs e )
        {
            if( toolStripButtonProfileMod.Checked )
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                var profileModifier = new ProfileModifier();

                m_modifiedTrait.ProfileModifier = profileModifier;

                toolStripButtonProfileModEditor.Enabled = true;
                panelProfileModifier.Visible = true;

                openProfileModEditor();
            }
            else
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box_uncheck;

                m_modifiedTrait.ProfileModifier = null;

                toolStripButtonProfileModEditor.Enabled = false;
                panelProfileModifier.Visible = false;

                textBoxProfileModifier.Text = String.Empty;

                traitBindingSource.ResetBindings( false );
            }

            SetupPermittedConditions();
        }

        private void toolStripButtonProfileModEditor_Click( object sender, EventArgs e )
        {
            openProfileModEditor();
        }

        private void openProfileModEditor()
        {
            var trait = (Trait)traitBindingSource.DataSource;

            using( var profileModifierEditor = new ProfileModifierEditor( trait.ProfileModifier ) )
            {
                if( profileModifierEditor.ShowDialog( this ) == DialogResult.OK )
                {
                    trait.ProfileModifier = profileModifierEditor.ProfileModifier;
                    textBoxProfileModifier.Text = trait.ProfileModifier.Summary();
                    traitBindingSource.ResetBindings( false );
                }
            }
        }

        private void openPermissionsEditor()
        {
            var trait = (Trait)traitBindingSource.DataSource;

            using( var permissionsEditor = new PermissionsEditor( trait.Permissions ) )
            {
                if( permissionsEditor.ShowDialog( this ) == DialogResult.OK )
                {
                    trait.Permissions = permissionsEditor.Permissions;
                    textBoxPermissions.Text = trait.Permissions.Summary();
                    traitBindingSource.ResetBindings( false );
                }
            }
        }

        private void buttonInsertLevelPlaceholder_Click( object sender, EventArgs e )
        {
            textBoxRules.Paste( Trait.LevelPlaceholder );

            textBoxRules.Focus();
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
            var trait = (Trait)traitBindingSource.DataSource;

            if( toolStripButtonPermissions.Checked )
            {
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box;

                var permissions = new Permissions();

                trait.Permissions = permissions;

                toolStripButtonPermissionsEditor.Enabled = true;
                panelPermissions.Visible = true;

                openPermissionsEditor();
            }
            else
            {
                toolStripButtonPermissions.Image = Properties.Resources.ui_check_box_uncheck;

                trait.Permissions = null;

                toolStripButtonPermissionsEditor.Enabled = false;
                panelPermissions.Visible = false;

                textBoxPermissions.Text = String.Empty;

                traitBindingSource.ResetBindings( false );
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
