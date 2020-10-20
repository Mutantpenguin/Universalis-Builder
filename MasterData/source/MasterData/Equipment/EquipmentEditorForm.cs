using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class EquipmentEditorForm : Form
    {
        public EquipmentEditorForm( Equipment equipment )
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            m_originalEquipment = equipment;

            m_modifiedEquipment = new Equipment( equipment );

            equipmentBindingSource.DataSource = m_modifiedEquipment;

            if( null != m_modifiedEquipment.ProfileModifier )
            {
                toolStripButtonProfileMod.Checked = true;
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                profileModifierBindingSource.DataSource = m_modifiedEquipment.ProfileModifier;
                attributeModifierBindingSource.DataSource = m_modifiedEquipment.ProfileModifier.AttributeModifier;
            }
            else
            {
                panelProfileMods.Enabled = false;
            }

            profileModifierBindingSource.CurrentItemChanged += ChildBindingSource_CurrentItemChanged;
            attributeModifierBindingSource.CurrentItemChanged += ChildBindingSource_CurrentItemChanged;
        }

        private void ChildBindingSource_CurrentItemChanged( object sender, EventArgs e )
        {
            equipmentBindingSource.ResetCurrentItem();
        }

        private readonly Equipment m_originalEquipment;
        private Equipment m_modifiedEquipment;

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

        private void toolStripButtonProfileMod_Click( object sender, EventArgs e )
        {
            if( toolStripButtonProfileMod.Checked )
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box;

                var profileModifier = new ProfileModifier();

                m_modifiedEquipment.ProfileModifier = profileModifier;

                profileModifierBindingSource.DataSource = profileModifier;
                attributeModifierBindingSource.DataSource = profileModifier.AttributeModifier;

                panelProfileMods.Enabled = true;
            }
            else
            {
                toolStripButtonProfileMod.Image = Properties.Resources.ui_check_box_uncheck;

                m_modifiedEquipment.ProfileModifier = null;

                profileModifierBindingSource.DataSource = typeof( ProfileModifier );
                attributeModifierBindingSource.DataSource = typeof( AttributeModifier );

                panelProfileMods.Enabled = false;
            }
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
                if( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_originalEquipment.Set( (Equipment)equipmentBindingSource.DataSource );
                    MasterDataStorage.Equipment.Save( m_originalEquipment );
                }
            }
        }

        private void EquipmentEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void toolStripButtonUsage_Click( object sender, EventArgs e )
        {
            using( ActorDisplayForm actorDisplay = new ActorDisplayForm( MasterDataStorage.Actor.ActorsWithEquipment( m_originalEquipment ) ) )
            {
                actorDisplay.ShowDialog( this );
            }
        }
    }
}
