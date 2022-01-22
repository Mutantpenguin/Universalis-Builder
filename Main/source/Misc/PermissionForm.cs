using System;
using System.Drawing;
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
                checkedListBoxTypeBlacklist.Items.Add( type );
            }

            AdjustCheckedListBoxSize( checkedListBoxTypeWhitelist );
            AdjustCheckedListBoxSize( checkedListBoxTypeBlacklist );

            foreach( var size in Archetype.ESizeList )
            {
                checkedListBoxSizeWhitelist.Items.Add( size );
                checkedListBoxSizeBlacklist.Items.Add( size );
            }

            foreach( var movementType in Archetype.EMovementTypeList )
            {
                checkedListBoxMovementTypeWhitelist.Items.Add( movementType );
                checkedListBoxMovementTypeBlacklist.Items.Add( movementType );
            }

            /* TODO to save the values back into the object
            permissions.ArchetypeTypeWhitelist.Clear();

            foreach( var checkedItem in checkedListBoxTypeWhitelist.CheckedItems )
            {
                permissions.ArchetypeTypeWhitelist.Add( (Archetype.EType)checkedItem );
                permissions.ArchetypeTypeBlacklist.Add( (Archetype.EType)checkedItem );
            }
            */

            toolStripButtonFaction.Checked = modifiedPermissions.FactionWhitelist.Count > 0 || modifiedPermissions.FactionBlacklist.Count > 0;
            toolStripButtonArchetype.Checked = modifiedPermissions.ArchetypeWhitelist.Count > 0 || modifiedPermissions.ArchetypeBlacklist.Count > 0;
            toolStripButtonType.Checked = modifiedPermissions.ArchetypeTypeWhitelist.Count > 0 || modifiedPermissions.ArchetypeTypeBlacklist.Count > 0;
            toolStripButtonSize.Checked = modifiedPermissions.SizeWhitelist.Count > 0 || modifiedPermissions.SizeBlacklist.Count > 0;
            toolStripButtonMovementType.Checked = modifiedPermissions.MovementTypeWhitelist.Count > 0 || modifiedPermissions.MovementTypeBlacklist.Count > 0;
        }

        private void AdjustCheckedListBoxSize( CheckedListBox checkedListBox )
        {
            checkedListBox.Size = new Size( checkedListBox.ClientSize.Width, checkedListBox.GetItemRectangle( 0 ).Height * checkedListBox.Items.Count );
        }

        private Permissions m_originalPermissions;

        private void toolStripButtonFaction_Click( object sender, EventArgs e )
        {
            
        }

        private void toolStripButtonArchetype_Click( object sender, EventArgs e )
        {
            
        }

        private void toolStripButtonType_Click( object sender, EventArgs e )
        {
            
        }

        private void toolStripButtonSize_Click( object sender, EventArgs e )
        {
            
        }

        private void toolStripButtonMovementType_Click( object sender, EventArgs e )
        {
            
        }

        private void toolStripButtonFaction_CheckedChanged( object sender, EventArgs e )
        {
            if( toolStripButtonFaction.Checked )
            {
                toolStripButtonFaction.Image = Properties.Resources.ui_check_box;
                tableLayoutPanelFactions.Visible = true;
            }
            else
            {
                toolStripButtonFaction.Image = Properties.Resources.ui_check_box_uncheck;
                tableLayoutPanelFactions.Visible = false;
            }
        }

        private void toolStripButtonArchetype_CheckedChanged( object sender, EventArgs e )
        {
            if( toolStripButtonArchetype.Checked )
            {
                toolStripButtonArchetype.Image = Properties.Resources.ui_check_box;
                tableLayoutPanelArchetypes.Visible = true;
            }
            else
            {
                toolStripButtonArchetype.Image = Properties.Resources.ui_check_box_uncheck;
                tableLayoutPanelArchetypes.Visible = false;
            }
        }

        private void toolStripButtonType_CheckedChanged( object sender, EventArgs e )
        {
            if( toolStripButtonType.Checked )
            {
                toolStripButtonType.Image = Properties.Resources.ui_check_box;
                tableLayoutPanelType.Visible = true;
            }
            else
            {
                toolStripButtonType.Image = Properties.Resources.ui_check_box_uncheck;
                tableLayoutPanelType.Visible = false;
            }
        }

        private void toolStripButtonSize_CheckedChanged( object sender, EventArgs e )
        {
            if( toolStripButtonSize.Checked )
            {
                toolStripButtonSize.Image = Properties.Resources.ui_check_box;
                tableLayoutPanelSize.Visible = true;
            }
            else
            {
                toolStripButtonSize.Image = Properties.Resources.ui_check_box_uncheck;
                tableLayoutPanelSize.Visible = false;
            }
        }

        private void toolStripButtonMovementType_CheckedChanged( object sender, EventArgs e )
        {
            if( toolStripButtonMovementType.Checked )
            {
                toolStripButtonMovementType.Image = Properties.Resources.ui_check_box;
                tableLayoutPanelMovementType.Visible = true;
            }
            else
            {
                toolStripButtonMovementType.Image = Properties.Resources.ui_check_box_uncheck;
                tableLayoutPanelMovementType.Visible = false;
            }
        }
    }
}
