using System.Windows.Forms;

namespace Universalis
{
    public partial class ProfileModifierEditor : Form
    {
        public ProfileModifierEditor( ProfileModifier profileModifier )
        {
            InitializeComponent();

            ProfileModifier = new ProfileModifier( profileModifier );

            profileModifierBindingSource.DataSource = ProfileModifier;

            attributeModifierBindingSource.DataSource = ProfileModifier.AttributeModifier;
        }

        public ProfileModifier ProfileModifier;

        private void buttonOk_Click( object sender, System.EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
