using System;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class EquipmentEditorForm : Form
    {
        public EquipmentEditorForm( Equipment equipment )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            m_originalEquipment = equipment;

            Equipment modifiedEquipment = new Equipment( equipment );

            equipmentBindingSource.DataSource = modifiedEquipment;

            if( null != modifiedEquipment.AttributeModifier )
            {
                toolStripButtonAttribMod.Checked = true;
                toolStripButtonAttribMod.Image = Properties.Resources.ui_check_box;

                attributeModifierBindingSource.DataSource = modifiedEquipment.AttributeModifier;
            }
            else
            {
                tableLayoutPanelAttribMods.Enabled = false;
            }
        }

        private readonly Equipment m_originalEquipment;

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

        private void toolStripButtonAttribMod_Click( object sender, EventArgs e )
        {
            if( toolStripButtonAttribMod.Checked )
            {
                toolStripButtonAttribMod.Image = Properties.Resources.ui_check_box;

                AttributeModifier attributeModifier = new AttributeModifier
                {
                    AGI = 0,
                    BW = 0,
                    KK = 0,
                    HAK = 0,
                    AFG = 0,
                    SH = 0
                };

                ( (Equipment)equipmentBindingSource.DataSource ).AttributeModifier = attributeModifier;

                attributeModifierBindingSource.DataSource = attributeModifier;

                tableLayoutPanelAttribMods.Enabled = true;
            }
            else
            {
                toolStripButtonAttribMod.Image = Properties.Resources.ui_check_box_uncheck;

                ( (Equipment)equipmentBindingSource.DataSource ).AttributeModifier = null;

                attributeModifierBindingSource.DataSource = typeof( AttributeModifier );

                tableLayoutPanelAttribMods.Enabled = false;
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
                            EquipmentStorage.Save( m_originalEquipment );
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
                    EquipmentStorage.Save( m_originalEquipment );
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
            using( ActorDisplayForm actorDisplay = new ActorDisplayForm( ActorStorage.Instance.ActorsWithEquipment( m_originalEquipment ) ) )
            {
                actorDisplay.ShowDialog( this );
            }
        }
    }
}
