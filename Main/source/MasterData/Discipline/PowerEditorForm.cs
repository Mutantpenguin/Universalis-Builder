using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            powerBindingSource.DataSource = m_modifiedPower;
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

            if( numericUpDownWeight.Value == 0 )
            {
                MessageBox.Show( "Achtung, das Gewicht steht auf '0'!" );
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
    }
}
