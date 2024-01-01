using System;
using System.Drawing;
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

            labelHeader.Text = discipline.Name;
            labelHeader.Font = new Font( UniversalisFont.Family, 20 );
            labelHeader.Left = ( panelHeader.Width - labelHeader.Width ) / 2;
            labelHeader.Top = ( panelHeader.Height - labelHeader.Height ) / 2;

            listViewPowers.Font = new Font( UniversalisFont.Family, 10 );

            displayPowers( discipline );
        }

        private void displayPowers( Discipline discipline )
        {
            int maxImageSize = 256;
            float scale = (float)maxImageSize / Math.Max( PowerCardPainter.SCardWidth, PowerCardPainter.SCardHeight );
            
            var cardSize = new Size( (int)(PowerCardPainter.SCardWidth * scale), (int)(PowerCardPainter.SCardHeight * scale) );
            imageListPowers.ImageSize = cardSize;

            imageListPowers.Images.Clear();
            listViewPowers.Clear();

            var powers = discipline.Powers
                .Where( x => x.Active )
                .OrderBy( x => x.Name );

            foreach( var power in powers )
            {
                var powerCard = PowerCardPainter.GetBitmap( discipline, power, monochrome: false );

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
    }
}
