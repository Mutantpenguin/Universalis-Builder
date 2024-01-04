using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universalis.Source.MasterData.Discipline
{
    public partial class PowerEditorForm : Form
    {
        public PowerEditorForm(Power power)
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            m_originalPower = power;

            m_modifiedPower = new Power( power );

            comboBoxAttribute.DataSource = Enum.GetValues( typeof( Power.EAttribute ) );
            comboBoxAttribute.SelectedItem = m_modifiedPower.Attribute;

            comboBoxTarget.DataSource = Enum.GetValues( typeof( Power.ETarget ) );
            comboBoxTarget.SelectedItem = m_modifiedPower.Target;

            comboBoxRange.DataSource = Enum.GetValues( typeof( Power.ERange ) );
            comboBoxRange.SelectedItem = m_modifiedPower.Range;

            comboBoxDamageApplication.DataSource = Enum.GetValues( typeof( Power.EDamageApplication ) );
            comboBoxDamageApplication.SelectedItem = m_modifiedPower.DamageApplication;

            comboBoxDuration.DataSource = Enum.GetValues( typeof( Power.EDuration ) );
            comboBoxDuration.SelectedItem = m_modifiedPower.Duration;

            powerBindingSource.DataSource = m_modifiedPower;

            HandleDamageValue();
        }

        private readonly Power m_originalPower;
        private Power m_modifiedPower;

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( textBoxName.Text ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return false;
            }

            if( String.IsNullOrEmpty( textBoxRules.Text ) )
            {
                MessageBox.Show( "Regeln sind leer, bitte angeben!" );
                return false;
            }

            if( m_modifiedPower.DamageApplication != Power.EDamageApplication.Keinen
                &&
                m_modifiedPower.DamageValue == 0 )
            {
                MessageBox.Show( "Bei TP-Verlust darf der Wert nicht 0 sein." );
                return false;
            }

            return true;
        }

        private void PowerEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Power powerModified = (Power)powerBindingSource.DataSource;

            if( !powerModified.Equals( m_originalPower ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_originalPower.Set( powerModified );
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
                m_originalPower.Set( m_modifiedPower );
            }
        }

        private void PowerEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void comboBoxTarget_SelectionChangeCommitted( object sender, EventArgs e )
        {
            m_modifiedPower.Target = (Power.ETarget)comboBoxTarget.SelectedItem;
        }

        private void comboBoxRange_SelectionChangeCommitted( object sender, EventArgs e )
        {
            m_modifiedPower.Range = (Power.ERange)comboBoxRange.SelectedItem;
        }

        private void comboBoxDamageApplication_SelectionChangeCommitted( object sender, EventArgs e )
        {
            m_modifiedPower.DamageApplication = (Power.EDamageApplication)comboBoxDamageApplication.SelectedItem;
            HandleDamageValue();
        }

        private void HandleDamageValue()
        {
            if( m_modifiedPower.DamageApplication == Power.EDamageApplication.Keinen )
            {
                m_modifiedPower.DamageValue = 0;
                numericUpDownDamageValue.Visible = false;
            }
            else
            {
                numericUpDownDamageValue.Visible = true;
            }
        }

        private void comboBoxDuration_SelectionChangeCommitted( object sender, EventArgs e )
        {
            m_modifiedPower.Duration = (Power.EDuration)comboBoxDuration.SelectedItem;
        }

        private void comboBoxAttribute_SelectionChangeCommitted( object sender, EventArgs e )
        {
            m_modifiedPower.Attribute = (Power.EAttribute)comboBoxAttribute.SelectedItem;
        }
    }
}
