using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class InactiveReasonForm : Form
    {
        public InactiveReasonForm()
        {
            InitializeComponent();

            comboBoxInactiveType.DataSource = Actor.EInactiveTypeList;
            comboBoxInactiveType.SelectedItem = Actor.EInactiveType.Kein;

            comboBoxInactiveType.Select();
        }

        public Actor.EInactiveType InactiveType;
        public string InactiveReason;

        private void InactiveReasonForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( DialogResult == DialogResult.OK )
            {
                if( (Actor.EInactiveType)comboBoxInactiveType.SelectedValue == Actor.EInactiveType.Kein )
                {
                    MessageBox.Show( "Bitte zuerst einen Grund auswählen, warum das Modell inaktiv ist!",
                                     String.Empty,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning );

                    e.Cancel = true;
                }
                else
                {
                    InactiveType = (Actor.EInactiveType)comboBoxInactiveType.SelectedItem;
                    InactiveReason = textBoxDisabledReason.Text;
                }
            }
        }
    }
}
