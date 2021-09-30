using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class UniverseInfoForm : Form
    {
        public UniverseInfoForm( Universe universe )
        {
            InitializeComponent();

            pictureBoxLogo.Image = universe.Logo;

            if( !String.IsNullOrEmpty( universe.Description ) )
            {
                textBoxDescription.Text = universe.Description;
                textBoxDescription.Visible = true;
            }

            if( !String.IsNullOrEmpty( universe.Author ) )
            {
                labelAuthor.Text = $"von {universe.Author}";
                panelAuthor.Visible = true;
            }

            if( !String.IsNullOrEmpty( universe.Contact ) )
            {
                linkLabelContact.Text = universe.Contact;
                panelContact.Visible = true;
            }

            if( !String.IsNullOrEmpty( universe.Website ) )
            {
                linkLabelWebsite.Text = universe.Website;
                panelWebsite.Visible = true;
            }
        }

        private void linkLabelContact_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            linkLabelContact.LinkVisited = true;

            try
            {
                System.Diagnostics.Process.Start( $"mailto:{linkLabelContact.Text}" );
            }
            catch
            {
                // do nothing if someone entered garbage here
            }
        }

        private void linkLabelWebsite_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            linkLabelWebsite.LinkVisited = true;

            try
            {
                System.Diagnostics.Process.Start( linkLabelWebsite.Text );
            }
            catch
            {
                // do nothing if someone entered garbage here
            }
        }
    }
}
