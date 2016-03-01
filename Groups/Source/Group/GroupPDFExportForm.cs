using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class GroupPDFExportForm : Form
    {
        public GroupPDFExportForm( Group group )
        {
            m_group = group;

            InitializeComponent();
        }

        private readonly Group m_group;

        private void buttonExport_Click( object sender, EventArgs e )
        {
            using( CardPainter cardPainter = new CardPainter() )
            {
                GroupPDFExporter.Export( m_group, cardPainter, Path.ChangeExtension( Path.GetTempFileName(), "pdf" ), checkBoxTraits.Checked, checkBoxWeapons.Checked, checkBoxArmor.Checked, checkBoxEquipment.Checked );
            }

            this.Close();
        }
    }
}
