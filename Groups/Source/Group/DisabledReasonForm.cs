using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universalis
{
    public partial class DisabledReasonForm : Form
    {
        public DisabledReasonForm()
        {
            InitializeComponent();

            textBoxDisabledReason.Select();
        }

        public string DisabledReason;

        private void DisabledReasonForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( DialogResult == DialogResult.OK )
            {
                if( String.IsNullOrEmpty( textBoxDisabledReason.Text ) )
                {
                    // TODO
                    MessageBox.Show( "TODO",
                                     String.Empty,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Warning );

                    e.Cancel = true;
                }
                else
                {
                    DisabledReason = textBoxDisabledReason.Text;
                }
            }
        }
    }
}
