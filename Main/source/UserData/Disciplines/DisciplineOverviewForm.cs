using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class DisciplineOverviewForm : Form
    {
        public DisciplineOverviewForm(Discipline discipline)
        {
            InitializeComponent();

            this.Icon = System.Drawing.Icon.FromHandle( Properties.Resources.icon_discipline.GetHicon() );

            m_discipline = discipline;

            labelHeader.Text = discipline.Name;
            labelHeader.Font = new Font( UniversalisFont.Family, 20 );
            labelHeader.Left = ( panelHeader.Width - labelHeader.Width ) / 2;
            labelHeader.Top = ( panelHeader.Height - labelHeader.Height ) / 2;

            listViewPowers.Font = new Font( UniversalisFont.Family, 10 );

            displayPowers();
        }

        private readonly Discipline m_discipline;

        private void displayPowers()
        {
            int maxImageSize = 256;
            float scale = (float)maxImageSize / Math.Max( PowerCardPainter.SCardWidth, PowerCardPainter.SCardHeight );
            
            var cardSize = new Size( (int)(PowerCardPainter.SCardWidth * scale), (int)(PowerCardPainter.SCardHeight * scale) );
            imageListPowers.ImageSize = cardSize;

            imageListPowers.Images.Clear();
            listViewPowers.Clear();

            var powers = m_discipline.Powers
                .Where( x => x.Active )
                .OrderBy( x => x.Name );

            foreach( var power in powers )
            {
                var powerCard = PowerCardPainter.GetBitmap( m_discipline, power, monochrome: false );

                imageListPowers.Images.Add( power.ID.ToString(), powerCard );

                ListViewItem lvi = new ListViewItem()
                {
                    ImageKey = power.ID.ToString(),
                    ToolTipText = power.Description,
                    Checked = true,
                };

                listViewPowers.Items.Add( lvi );
            }
        }

        private void buttonPrint_Click( object sender, EventArgs e )
        {
            var powerList = new List<Power>();

            foreach( ListViewItem item in listViewPowers.CheckedItems )
            {
                powerList.Add( m_discipline.Powers.Find( x => x.ID.ToString() == item.ImageKey ) );
            }

            string filename = m_discipline.Name + " - " + DateTime.Now.ToString( "yyyyMMdd_HHmmss" );

            foreach( char c in Path.GetInvalidFileNameChars() )
            {
                filename = filename.Replace( c.ToString(), String.Empty );
            }

            PowersPDFExporter.GeneratePDF( m_discipline, powerList, Path.Combine( Path.GetTempPath(), Path.ChangeExtension( filename, "pdf" ) ) );
        }
    }
}
