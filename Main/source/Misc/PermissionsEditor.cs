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

            toolStripComboBoxFaction.ComboBox.DataSource = Permissions.EPermissionTypeList;
            toolStripComboBoxArchetype.ComboBox.DataSource = Permissions.EPermissionTypeList;
            toolStripComboBoxType.ComboBox.DataSource = Permissions.EPermissionTypeList;
            toolStripComboBoxSize.ComboBox.DataSource = Permissions.EPermissionTypeList;
            toolStripComboBoxMovementType.ComboBox.DataSource = Permissions.EPermissionTypeList;

            toolStripComboBoxFaction.ComboBox.SelectedValue = Permissions.Faction == null ? EPermissionType.None : Permissions.Faction.Type;
            toolStripComboBoxArchetype.ComboBox.SelectedValue = Permissions.Archetype == null ? EPermissionType.None : Permissions.Archetype.Type;
            toolStripComboBoxType.ComboBox.SelectedValue = Permissions.Type == null ? EPermissionType.None : Permissions.Type.Type;
            toolStripComboBoxSize.ComboBox.SelectedValue = Permissions.Size == null ? EPermissionType.None : Permissions.Size.Type;
            toolStripComboBoxMovementType.ComboBox.SelectedValue = Permissions.MovementType == null ? EPermissionType.None : Permissions.MovementType.Type;

            // TODO after setting the field toolStripComboBoxFaction.ComboBox.SelectionChangeCommitted += ComboBoxFaction_SelectionChangeCommitted;
            
            RefreshGridViews();

            foreach( var type in Archetype.ETypeList )
            {
                checkedListBoxType.Items.Add( type, Permissions.Type.Values.Contains( type ) );
            }

            foreach( var size in Archetype.ESizeList )
            {
                checkedListBoxSize.Items.Add( size, Permissions.Size.Values.Contains( size ) );
            }

            foreach( var movementType in Archetype.EMovementTypeList )
            {
                checkedListBoxMovementType.Items.Add( movementType, Permissions.MovementType.Values.Contains( movementType ) );
            }

            AdjustCheckedListBoxSize( checkedListBoxType );
            AdjustCheckedListBoxSize( checkedListBoxSize );
            AdjustCheckedListBoxSize( checkedListBoxMovementType );
        }

        private void ComboBoxFaction_SelectionChangeCommitted( object sender, EventArgs e )
        {
            // TODO set bzw. dele PermissionsSet for Factions here

            if( (EPermissionType)toolStripComboBoxFaction.SelectedItem != EPermissionType.None )
            {
                toolStripButtonFactionDelete.Visible = true;
                toolStripButtonFactionAdd.Visible = true;
                dataGridViewFaction.Visible = true;
            }
            else
            {
                toolStripButtonFactionDelete.Visible = false;
                toolStripButtonFactionAdd.Visible = false;
                dataGridViewFaction.Visible = false;
            }
        }

        public Permissions Permissions;

        private void RefreshGridViews()
        {
            factionsWhitelistBindingSource.DataSource = Permissions.Faction?.Values.OrderBy( x => x.Name )
                                                                                   .ToList();

            archetypesWhitelistBindingSource.DataSource = Permissions.Archetype?.Values.OrderBy( x => x.Name )
                                                                                       .ToList();
        }

        private void AdjustCheckedListBoxSize( CheckedListBox checkedListBox )
        {
            checkedListBox.ClientSize = new Size( checkedListBox.ClientSize.Width, checkedListBox.ItemHeight * checkedListBox.Items.Count );
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
            Permissions.Type.Values.Clear();
            foreach( var item in checkedListBoxType.CheckedItems )
            {
                Permissions.Type.Values.Add( (Archetype.EType)item );
            }

            Permissions.Size.Values.Clear();
            foreach( var item in checkedListBoxSize.CheckedItems )
            {
                Permissions.Size.Values.Add( (Archetype.ESize)item );
            }

            Permissions.MovementType.Values.Clear();
            foreach( var item in checkedListBoxMovementType.CheckedItems )
            {
                Permissions.MovementType.Values.Add( (Archetype.EMovementType)item );
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
            SelectFaction( Permissions.Faction.Values );
        }

        private void toolStripButtonArchetypeWhitelistAdd_Click( object sender, EventArgs e )
        {
            SelectArchetype( Permissions.Archetype.Values );
        }

        private void toolStripButtonFactionWhitelistDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewFaction.SelectedRows.Count > 0 )
            {
                var faction = (Faction)dataGridViewFaction.SelectedRows[ 0 ].DataBoundItem;
                Permissions.Faction.Values.Remove( faction );

                RefreshGridViews();
            }
        }

        private void toolStripButtonArchetypeWhitelistDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewArchetype.SelectedRows.Count > 0 )
            {
                var archetype = (Archetype)dataGridViewArchetype.SelectedRows[ 0 ].DataBoundItem;
                Permissions.Archetype.Values.Remove( archetype );

                RefreshGridViews();
            }
        }
    }
}
