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
    public partial class PermissionForm : Form
    {
        public PermissionForm( Permissions permissions )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;


            m_originalPermissions = permissions;

            Permissions modifiedPermissions = new Permissions( permissions );

            permissionsBindingSource.DataSource = modifiedPermissions;


            foreach( var type in Archetype.ETypeList )
            {
                checkedListBoxTypeWhitelist.Items.Add( type );
            }

            permissions.ArchetypeTypeWhitelist.Clear();

            foreach( var checkedItem in checkedListBoxTypeWhitelist.CheckedItems )
            {
                permissions.ArchetypeTypeWhitelist.Add( (Archetype.EType)checkedItem );
            }

            //checkedListBoxType.Items.AddRange( Enum.GetValues( typeof( Archetype.EMovementType ) ) );

            //checkedListBoxType.Items.Add()
        }

        private Permissions m_originalPermissions;

        private void toolStripButtonFaction_Click( object sender, EventArgs e )
        {
            if( toolStripButtonFaction.Checked )
            {
                toolStripButtonFaction.Image = Properties.Resources.ui_check_box;
            }
            else
            {
                toolStripButtonFaction.Image = Properties.Resources.ui_check_box_uncheck;
            }
        }

        private void toolStripButtonArchetype_Click( object sender, EventArgs e )
        {
            if( toolStripButtonArchetype.Checked )
            {
                toolStripButtonArchetype.Image = Properties.Resources.ui_check_box;
            }
            else
            {
                toolStripButtonArchetype.Image = Properties.Resources.ui_check_box_uncheck;
            }
        }

        private void toolStripButtonType_Click( object sender, EventArgs e )
        {
            if( toolStripButtonType.Checked )
            {
                toolStripButtonType.Image = Properties.Resources.ui_check_box;
            }
            else
            {
                toolStripButtonType.Image = Properties.Resources.ui_check_box_uncheck;
            }
        }

        private void toolStripButtonSize_Click( object sender, EventArgs e )
        {
            if( toolStripButtonSize.Checked )
            {
                toolStripButtonSize.Image = Properties.Resources.ui_check_box;
            }
            else
            {
                toolStripButtonSize.Image = Properties.Resources.ui_check_box_uncheck;
            }
        }

        private void toolStripButtonMovementType_Click( object sender, EventArgs e )
        {
            if( toolStripButtonMovementType.Checked )
            {
                toolStripButtonMovementType.Image = Properties.Resources.ui_check_box;
            }
            else
            {
                toolStripButtonMovementType.Image = Properties.Resources.ui_check_box_uncheck;
            }
        }
    }
}
