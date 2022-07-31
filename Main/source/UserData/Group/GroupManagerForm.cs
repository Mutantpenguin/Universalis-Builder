using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GroupManagerForm : Form    
    {
        public GroupManagerForm( Universe universe, Faction faction )
        {
            InitializeComponent();

            this.CenterToParent();

            this.Text = faction.Name + " - " + this.Text;

            textBoxFactionDescription.Font = new System.Drawing.Font( UniversalisFont.Family, 10 );

            this.Icon = Properties.Resources.icon;

            m_universe = universe;
            m_faction = faction;

            pictureBoxFaction.Image = faction.Icon;
            textBoxFactionDescription.Text = faction.Description;

            RefreshGroupsGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private readonly Universe m_universe;
        private readonly Faction m_faction;

        private void dataGridViewGroups_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editGroup( (Group)dataGridViewGroups.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void editGroup( Group group )
        {
            this.Hide();

            GroupEditorForm groupEditorForm = new GroupEditorForm( m_universe, group );

            groupEditorForm.FormClosed += delegate
            {
                this.Show();

                RefreshGroupsGridView();

                dataGridViewGroups.ClearSelection();
                foreach( DataGridViewRow row in dataGridViewGroups.Rows )
                {
                    if( group.ID == ( (Group)row.DataBoundItem ).ID )
                    {
                        row.Selected = true;
                        break;
                    }
                }

                groupEditorForm.Dispose();
            };

            groupEditorForm.Show( this );
        }

        private void toolStripButtonAddGroup_Click( object sender, EventArgs e )
        {
            Group group = GroupStorage.Create( m_faction );

            toolStripTextBoxSearch.Text = String.Empty;

            editGroup( group );
        }

        private void toolStripButtonDeleteGroup_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroups.SelectedRows.Count > 0 )
            {
                Group group = (Group)dataGridViewGroups.SelectedRows[ 0 ].DataBoundItem;

                if( MessageBox.Show( $"Gruppe '{group.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    UserDataStorage.Group.Delete( group );

                    RefreshGroupsGridView();
                }
            }
        }

        private void RefreshGroupsGridView()
        {
            List<Group> groups = UserDataStorage.Group.Groups.Where( s => s.Active )
                                                             .Where( s => s.Faction.ID == m_faction.ID )
                                                             .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                             .OrderBy( x => x.Name ).ThenBy( x => x.Points )
                                                             .ToList();

            groupBindingSource.DataSource = groups;
            dataGridViewGroups.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {groups.Count}";
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            RefreshGroupsGridView();
        }

        private void dataGridViewGroups_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Group group = (Group)dataGridViewGroups.Rows[ e.RowIndex ].DataBoundItem;

                string toolTipText = String.Empty;

                var (status, reason) = group.IsValid();

                if( !status )
                {
                    toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine : String.Empty ) + reason;
                }

                if(!String.IsNullOrEmpty( group.Description ))
                {
                    toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + ToolTipHelper.FormatMaxWidth( group.Description );
                }

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( toolTipText );
            }
        }

        private void GroupManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                Close();
            }
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewGroups_CellPainting( object sender, DataGridViewCellPaintingEventArgs e )
        {
            if( e.ColumnIndex == nameDataGridViewTextBoxColumn.Index && e.RowIndex != -1 )
            {
                Group group = (Group)dataGridViewGroups.Rows[ e.RowIndex ].DataBoundItem;

                if( !group.IsValid().status )
                {
                    Image imgInactiveComposition = Properties.Resources.alert_circle_red_18dp;

                    e.PaintBackground( e.CellBounds, true );
                    e.PaintContent( e.CellBounds );

                    e.Graphics.DrawImageUnscaled( imgInactiveComposition, e.CellBounds.X + e.CellBounds.Width - (int)( imgInactiveComposition.Width * 1.5 ), e.CellBounds.Y + ( ( e.CellBounds.Height - imgInactiveComposition.Height ) / 2 ) );

                    e.Handled = true;
                }
            }
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewGroups, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editGroup( (Group)dataGridViewGroups.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewGroups_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editGroup( (Group)dataGridViewGroups.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewGroups_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewGroups );
        }
    }
}
