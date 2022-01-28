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

            toolStripComboBoxFaction.ComboBox.SelectionChangeCommitted += ComboBoxFaction_SelectionChangeCommitted;
            toolStripComboBoxArchetype.ComboBox.SelectionChangeCommitted += ComboBoxArchetype_SelectionChangeCommitted;
            toolStripComboBoxType.ComboBox.SelectionChangeCommitted += ComboBoxType_SelectionChangeCommitted;
            toolStripComboBoxSize.ComboBox.SelectionChangeCommitted += ComboBoxSize_SelectionChangeCommitted;
            toolStripComboBoxMovementType.ComboBox.SelectionChangeCommitted += ComboBoxMovementType_SelectionChangeCommitted;

            toolStripComboBoxFaction.ComboBox.SelectedValueChanged += ComboBoxFaction_SelectedValueChanged;
            toolStripComboBoxArchetype.ComboBox.SelectedValueChanged += ComboBoxArchetype_SelectedValueChanged;
            toolStripComboBoxType.ComboBox.SelectedValueChanged += ComboBoxType_SelectedValueChanged;
            toolStripComboBoxSize.ComboBox.SelectedValueChanged += ComboBoxSize_SelectedValueChanged;
            toolStripComboBoxMovementType.ComboBox.SelectedValueChanged += ComboBoxMovementType_SelectedValueChanged;

            toolStripComboBoxFaction.ComboBox.DataSource = Enum.GetValues( typeof( EPermissionType ) );
            toolStripComboBoxArchetype.ComboBox.DataSource = Enum.GetValues( typeof( EPermissionType ) );
            toolStripComboBoxType.ComboBox.DataSource = Enum.GetValues( typeof( EPermissionType ) );
            toolStripComboBoxSize.ComboBox.DataSource = Enum.GetValues( typeof( EPermissionType ) );
            toolStripComboBoxMovementType.ComboBox.DataSource = Enum.GetValues( typeof( EPermissionType ) );

            toolStripComboBoxFaction.ComboBox.SelectedItem = Permissions.Faction.Type;
            toolStripComboBoxArchetype.ComboBox.SelectedItem = Permissions.Archetype.Type;
            toolStripComboBoxType.ComboBox.SelectedItem = Permissions.Type.Type;
            toolStripComboBoxSize.ComboBox.SelectedItem = Permissions.Size.Type;
            toolStripComboBoxMovementType.ComboBox.SelectedItem = Permissions.MovementType.Type;

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

        private void ComboBoxFaction_SelectedValueChanged( object sender, EventArgs e )
        {
            if( Permissions.Faction.Type != EPermissionType.None )
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

        private void ComboBoxArchetype_SelectedValueChanged( object sender, EventArgs e )
        {
            if( Permissions.Archetype.Type != EPermissionType.None )
            {
                toolStripButtonArchetypeDelete.Visible = true;
                toolStripButtonArchetypeAdd.Visible = true;
                dataGridViewArchetype.Visible = true;
            }
            else
            {
                toolStripButtonArchetypeDelete.Visible = false;
                toolStripButtonArchetypeAdd.Visible = false;
                dataGridViewArchetype.Visible = false;
            }
        }

        private void ComboBoxType_SelectedValueChanged( object sender, EventArgs e )
        {
            if( Permissions.Type.Type != EPermissionType.None )
            {
                checkedListBoxType.Visible = true;
            }
            else
            {
                checkedListBoxType.Visible = false;
            }
        }

        private void ComboBoxSize_SelectedValueChanged( object sender, EventArgs e )
        {
            if( Permissions.Size.Type != EPermissionType.None )
            {
                checkedListBoxSize.Visible = true;
            }
            else
            {
                checkedListBoxSize.Visible = false;
            }
        }

        private void ComboBoxMovementType_SelectedValueChanged( object sender, EventArgs e )
        {
            if( Permissions.MovementType.Type != EPermissionType.None )
            {
                checkedListBoxMovementType.Visible = true;
            }
            else
            {
                checkedListBoxMovementType.Visible = false;
            }
        }

        private void ComboBoxFaction_SelectionChangeCommitted( object sender, EventArgs e )
        {
            Permissions.Faction.Type = (EPermissionType)toolStripComboBoxFaction.SelectedItem;
        }

        private void ComboBoxArchetype_SelectionChangeCommitted( object sender, EventArgs e )
        {
            Permissions.Archetype.Type = (EPermissionType)toolStripComboBoxArchetype.SelectedItem;
        }

        private void ComboBoxType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            Permissions.Type.Type = (EPermissionType)toolStripComboBoxType.SelectedItem;
        }

        private void ComboBoxSize_SelectionChangeCommitted( object sender, EventArgs e )
        {
            Permissions.Size.Type = (EPermissionType)toolStripComboBoxSize.SelectedItem;
        }

        private void ComboBoxMovementType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            Permissions.MovementType.Type = (EPermissionType)toolStripComboBoxMovementType.SelectedItem;
        }

        public Permissions Permissions;

        private void RefreshGridViews()
        {
            factionsWhitelistBindingSource.DataSource = Permissions.Faction.Values.OrderBy( x => x.Name )
                                                                                  .ToList();

            archetypesWhitelistBindingSource.DataSource = Permissions.Archetype.Values.OrderBy( x => x.Name )
                                                                                      .ToList();
        }

        private void AdjustCheckedListBoxSize( CheckedListBox checkedListBox )
        {
            checkedListBox.ClientSize = new Size( checkedListBox.ClientSize.Width, checkedListBox.ItemHeight * checkedListBox.Items.Count );
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

        private void toolStripButtonFactionAdd_Click( object sender, EventArgs e )
        {
            SelectFaction( Permissions.Faction.Values );
        }

        private void toolStripButtonFactionDelete_Click( object sender, EventArgs e )
        {
            if( dataGridViewFaction.SelectedRows.Count > 0 )
            {
                var faction = (Faction)dataGridViewFaction.SelectedRows[ 0 ].DataBoundItem;
                Permissions.Faction.Values.Remove( faction );

                RefreshGridViews();
            }
        }

        private void toolStripButtonArchetypeAdd_Click( object sender, EventArgs e )
        {
            SelectArchetype( Permissions.Archetype.Values );
        }

        private void toolStripButtonArchetypeDelete_Click( object sender, EventArgs e )
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
