using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class PermissionsEditor : Form
    {
        public PermissionsEditor( Permissions permissions )
        {
            InitializeComponent();

            this.Icon = Properties.Resources.icon;

            // TODO überarbeiten wie beim ProfileModifierEditor
            m_originalPermissions = permissions;

            Permissions modifiedPermissions = new Permissions( permissions );

            permissionsBindingSource.DataSource = modifiedPermissions;

            factionsWhitelistBindingSource.DataSource = modifiedPermissions.FactionWhitelist.OrderBy( x => x.Name )
                                                                                            .ToList();
            factionsBlacklistBindingSource.DataSource = modifiedPermissions.FactionBlacklist.OrderBy( x => x.Name )
                                                                                            .ToList();

            archetypesWhitelistBindingSource.DataSource = modifiedPermissions.ArchetypeWhitelist.OrderBy( x => x.Name )
                                                                                                .ToList();
            archetypesBlacklistBindingSource.DataSource = modifiedPermissions.ArchetypeBlacklist.OrderBy( x => x.Name )
                                                                                                .ToList();


            foreach( var type in Archetype.ETypeList )
            {
                checkedListBoxTypeWhitelist.Items.Add( type, modifiedPermissions.ArchetypeTypeWhitelist.Contains( type ) );
                checkedListBoxTypeBlacklist.Items.Add( type, modifiedPermissions.ArchetypeTypeBlacklist.Contains( type ) );
            }

            foreach( var size in Archetype.ESizeList )
            {
                checkedListBoxSizeWhitelist.Items.Add( size, modifiedPermissions.SizeWhitelist.Contains( size ) );
                checkedListBoxSizeBlacklist.Items.Add( size, modifiedPermissions.SizeBlacklist.Contains( size ) );
            }

            foreach( var movementType in Archetype.EMovementTypeList )
            {
                checkedListBoxMovementTypeWhitelist.Items.Add( movementType, modifiedPermissions.MovementTypeWhitelist.Contains( movementType ) );
                checkedListBoxMovementTypeBlacklist.Items.Add( movementType, modifiedPermissions.MovementTypeBlacklist.Contains( movementType ) );
            }

            AdjustCheckedListBoxSize( checkedListBoxTypeWhitelist );
            AdjustCheckedListBoxSize( checkedListBoxTypeBlacklist );
            AdjustCheckedListBoxSize( checkedListBoxSizeWhitelist );
            AdjustCheckedListBoxSize( checkedListBoxSizeBlacklist );
            AdjustCheckedListBoxSize( checkedListBoxMovementTypeWhitelist );
            AdjustCheckedListBoxSize( checkedListBoxMovementTypeBlacklist );

            /*foreach( var type in modifiedPermissions.ArchetypeTypeWhitelist )
            {
                checkedListBoxTypeWhitelist.Items.
            }*/

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
            checkedListBox.ClientSize = new Size( checkedListBox.ClientSize.Width, checkedListBox.ItemHeight * checkedListBox.Items.Count );
        }

        private Permissions m_originalPermissions;

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

        private void PermissionForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Permissions permissionsModified = (Permissions)permissionsBindingSource.DataSource;

            permissionsModified.ArchetypeTypeWhitelist.Clear();
            foreach( var item in checkedListBoxTypeWhitelist.CheckedItems )
            {
                permissionsModified.ArchetypeTypeWhitelist.Add( (Archetype.EType)item );
            }

            permissionsModified.ArchetypeTypeBlacklist.Clear();
            foreach( var item in checkedListBoxTypeBlacklist.CheckedItems )
            {
                permissionsModified.ArchetypeTypeBlacklist.Add( (Archetype.EType)item );
            }

            permissionsModified.SizeWhitelist.Clear();
            foreach( var item in checkedListBoxSizeWhitelist.CheckedItems )
            {
                permissionsModified.SizeWhitelist.Add( (Archetype.ESize)item );
            }

            permissionsModified.SizeBlacklist.Clear();
            foreach( var item in checkedListBoxSizeBlacklist.CheckedItems )
            {
                permissionsModified.SizeBlacklist.Add( (Archetype.ESize)item );
            }

            permissionsModified.MovementTypeWhitelist.Clear();
            foreach( var item in checkedListBoxMovementTypeWhitelist.CheckedItems )
            {
                permissionsModified.MovementTypeWhitelist.Add( (Archetype.EMovementType)item );
            }

            permissionsModified.MovementTypeBlacklist.Clear();
            foreach( var item in checkedListBoxMovementTypeBlacklist.CheckedItems )
            {
                permissionsModified.MovementTypeBlacklist.Add( (Archetype.EMovementType)item );
            }

            if( !permissionsModified.Equals( m_originalPermissions ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        var (status, reason) = permissionsModified.IsValid();

                        if( status )
                        {
                            m_originalPermissions.Set( permissionsModified );
                        }
                        else
                        {
                            if( MessageBox.Show( $"{reason}\n\nÄnderungen verwerfen?", "Unlogische Berechtigungen", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                            {
                                e.Cancel = true;
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
