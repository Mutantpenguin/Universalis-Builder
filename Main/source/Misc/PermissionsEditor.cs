using System;
using System.Collections.Generic;
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

            Permissions = new Permissions( permissions );

            permissionsBindingSource.DataSource = Permissions;
            
            RefreshGridViews();

            foreach( var type in Archetype.ETypeList )
            {
                checkedListBoxTypeWhitelist.Items.Add( type, Permissions.TypeWhitelist.Contains( type ) );
                checkedListBoxTypeBlacklist.Items.Add( type, Permissions.TypeBlacklist.Contains( type ) );
            }

            foreach( var size in Archetype.ESizeList )
            {
                checkedListBoxSizeWhitelist.Items.Add( size, Permissions.SizeWhitelist.Contains( size ) );
                checkedListBoxSizeBlacklist.Items.Add( size, Permissions.SizeBlacklist.Contains( size ) );
            }

            foreach( var movementType in Archetype.EMovementTypeList )
            {
                checkedListBoxMovementTypeWhitelist.Items.Add( movementType, Permissions.MovementTypeWhitelist.Contains( movementType ) );
                checkedListBoxMovementTypeBlacklist.Items.Add( movementType, Permissions.MovementTypeBlacklist.Contains( movementType ) );
            }

            AdjustCheckedListBoxSize( checkedListBoxTypeWhitelist );
            AdjustCheckedListBoxSize( checkedListBoxTypeBlacklist );
            AdjustCheckedListBoxSize( checkedListBoxSizeWhitelist );
            AdjustCheckedListBoxSize( checkedListBoxSizeBlacklist );
            AdjustCheckedListBoxSize( checkedListBoxMovementTypeWhitelist );
            AdjustCheckedListBoxSize( checkedListBoxMovementTypeBlacklist );

            toolStripButtonFaction.Checked = Permissions.FactionWhitelist.Count > 0 || Permissions.FactionBlacklist.Count > 0;
            toolStripButtonArchetype.Checked = Permissions.ArchetypeWhitelist.Count > 0 || Permissions.ArchetypeBlacklist.Count > 0;
            toolStripButtonType.Checked = Permissions.TypeWhitelist.Count > 0 || Permissions.TypeBlacklist.Count > 0;
            toolStripButtonSize.Checked = Permissions.SizeWhitelist.Count > 0 || Permissions.SizeBlacklist.Count > 0;
            toolStripButtonMovementType.Checked = Permissions.MovementTypeWhitelist.Count > 0 || Permissions.MovementTypeBlacklist.Count > 0;
        }

        public Permissions Permissions;

        private void RefreshGridViews()
        {
            factionsWhitelistBindingSource.DataSource = Permissions.FactionWhitelist.OrderBy( x => x.Name )
                                                                                    .ToList();
            factionsBlacklistBindingSource.DataSource = Permissions.FactionBlacklist.OrderBy( x => x.Name )
                                                                                    .ToList();

            archetypesWhitelistBindingSource.DataSource = Permissions.ArchetypeWhitelist.OrderBy( x => x.Name )
                                                                                        .ToList();
            archetypesBlacklistBindingSource.DataSource = Permissions.ArchetypeBlacklist.OrderBy( x => x.Name )
                                                                                        .ToList();
        }

        private void AdjustCheckedListBoxSize( CheckedListBox checkedListBox )
        {
            checkedListBox.ClientSize = new Size( checkedListBox.ClientSize.Width, checkedListBox.ItemHeight * checkedListBox.Items.Count );
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

        private void PermissionForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Permissions.TypeWhitelist.Clear();
            foreach( var item in checkedListBoxTypeWhitelist.CheckedItems )
            {
                Permissions.TypeWhitelist.Add( (Archetype.EType)item );
            }

            Permissions.TypeBlacklist.Clear();
            foreach( var item in checkedListBoxTypeBlacklist.CheckedItems )
            {
                Permissions.TypeBlacklist.Add( (Archetype.EType)item );
            }

            Permissions.SizeWhitelist.Clear();
            foreach( var item in checkedListBoxSizeWhitelist.CheckedItems )
            {
                Permissions.SizeWhitelist.Add( (Archetype.ESize)item );
            }

            Permissions.SizeBlacklist.Clear();
            foreach( var item in checkedListBoxSizeBlacklist.CheckedItems )
            {
                Permissions.SizeBlacklist.Add( (Archetype.ESize)item );
            }

            Permissions.MovementTypeWhitelist.Clear();
            foreach( var item in checkedListBoxMovementTypeWhitelist.CheckedItems )
            {
                Permissions.MovementTypeWhitelist.Add( (Archetype.EMovementType)item );
            }

            Permissions.MovementTypeBlacklist.Clear();
            foreach( var item in checkedListBoxMovementTypeBlacklist.CheckedItems )
            {
                Permissions.MovementTypeBlacklist.Add( (Archetype.EMovementType)item );
            }

            var (status, reason) = Permissions.IsValid();

            if( !status )
            {
                if( MessageBox.Show( $"{reason}\n\nÄnderungen verwerfen?", "Unlogische Berechtigungen", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2 ) == DialogResult.No )
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonOk_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SelectFaction( HashSet<Faction> factionList )
        {
            using( FactionSelectionForm factionSelectionForm = new FactionSelectionForm() )
            {
                if( factionSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( factionSelectionForm.SelectedFaction != null )
                    {
                        factionList.Add( factionSelectionForm.SelectedFaction );

                        RefreshGridViews();
                    }
                }
            }
        }

        private void SelectArchetype( HashSet<Archetype> archetypeList )
        {
            using( FactionSelectionForm factionSelectionForm = new FactionSelectionForm() )
            {
                if( factionSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( factionSelectionForm.SelectedFaction != null )
                    {
                        using( ArchetypeSelectionForm archetypeSelectionForm = new ArchetypeSelectionForm( factionSelectionForm.SelectedFaction ) )
                        {
                            if( archetypeSelectionForm.ShowDialog( this ) == DialogResult.OK )
                            {
                                archetypeList.Add( archetypeSelectionForm.SelectedArchetype );

                                RefreshGridViews();
                            }
                        }
                    }
                }
            }
        }

        private void toolStripButtonFactionWhitelistAdd_Click( object sender, EventArgs e )
        {
            SelectFaction( Permissions.FactionWhitelist );
        }

        private void toolStripButtonFactionBlacklistAdd_Click( object sender, EventArgs e )
        {
            SelectFaction( Permissions.FactionBlacklist );
        }

        private void toolStripButtonArchetypeWhitelistAdd_Click( object sender, EventArgs e )
        {
            SelectArchetype( Permissions.ArchetypeWhitelist );
        }

        private void toolStripButtonArchetypeBlacklistAdd_Click( object sender, EventArgs e )
        {
            SelectArchetype( Permissions.ArchetypeBlacklist );
        }

        private void toolStripButtonFactionWhitelistDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewFactionWhitelist.SelectedRows.Count > 0 )
            {
                var faction = (Faction)dataGridViewFactionWhitelist.SelectedRows[ 0 ].DataBoundItem;
                Permissions.FactionWhitelist.Remove( faction );

                RefreshGridViews();
            }
        }

        private void toolStripButtonFactionBlacklistDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewFactionBlacklist.SelectedRows.Count > 0 )
            {
                var faction = (Faction)dataGridViewFactionBlacklist.SelectedRows[ 0 ].DataBoundItem;
                Permissions.FactionBlacklist.Remove( faction );

                RefreshGridViews();
            }
        }

        private void toolStripButtonArchetypeWhitelistDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewArchetypeWhitelist.SelectedRows.Count > 0 )
            {
                var archetype = (Archetype)dataGridViewArchetypeWhitelist.SelectedRows[ 0 ].DataBoundItem;
                Permissions.ArchetypeWhitelist.Remove( archetype );

                RefreshGridViews();
            }
        }

        private void toolStripButtonArchetypeBlacklistDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewArchetypeBlacklist.SelectedRows.Count > 0 )
            {
                var archetype = (Archetype)dataGridViewArchetypeBlacklist.SelectedRows[ 0 ].DataBoundItem;
                Permissions.ArchetypeBlacklist.Remove( archetype );

                RefreshGridViews();
            }
        }
    }
}
