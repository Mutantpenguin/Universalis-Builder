using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class InactiveReasonForm : Form
    {
        public InactiveReasonForm()
        {
            InitializeComponent();

            textBoxDisabledReason.Select();
        }

        public string InactiveReason;

        private void InactiveReasonForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( DialogResult == DialogResult.OK )
            {
                if( String.IsNullOrEmpty( textBoxDisabledReason.Text ) )
                {
                    MessageBox.Show( "Bitte zuerst einen Grund eingeben, warum das Modell inaktiv ist!",
                                     String.Empty,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning );

                    e.Cancel = true;
                }
                else
                {
                    InactiveReason = textBoxDisabledReason.Text;
                }
            }
        }
    }
}
