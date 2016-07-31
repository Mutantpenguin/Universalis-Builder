using System;
using System.IO;
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
            GroupPDFExporter.Export( m_group, Path.ChangeExtension( Path.GetTempFileName(), "pdf" ), checkBoxTraits.Checked, checkBoxWeapons.Checked, checkBoxArmor.Checked, checkBoxEquipment.Checked );

            this.Close();
        }
    }
}
