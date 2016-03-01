using System.Windows.Forms;

namespace Tesserakt
{
    public partial class ProgressorPanel : UserControl
    {
        public ProgressorPanel()
        {
            InitializeComponent();

            this.Dock = DockStyle.Bottom;
        }

        public void SetValues( int progressBarValue, string message )
        {
            progressBar.Value = progressBarValue;
            textBoxMessage.Text = message;
        }
    }
}
