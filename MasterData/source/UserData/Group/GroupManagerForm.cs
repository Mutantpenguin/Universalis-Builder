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
            using( GroupEditorForm groupEditorForm = new GroupEditorForm( group ) )
            {
                this.Hide();

                groupEditorForm.ShowDialog( this );

                this.Show();
            }

            groupBindingSource.ResetBindings( false );
        }

        private void toolStripButtonAddGroups_Click( object sender, EventArgs e )
        {
            Group group = GroupStorage.Create( m_faction );

            toolStripTextBoxSearch.Text = String.Empty;

            editGroup( group );

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

                if( group.HasInactiveComposition() )
                {
                    toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine : String.Empty ) + "Inaktive Ausstattung vorhanden!";
                }

                toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + $"Anzahl Modelle: {group.ModelList.Count}{Environment.NewLine}{ToolTipHelper.FormatMaxWidth( group.Description )}";

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( toolTipText );
            }
        }

        private void toolStripButtonPDF_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroups.SelectedRows.Count > 0 )
            {
                Group group = (Group)dataGridViewGroups.SelectedRows[ 0 ].DataBoundItem;

                string filename = group.Name + " - " + DateTime.Now.ToString( "yyyyMMdd_HHmmss" );

                foreach( char c in Path.GetInvalidFileNameChars() )
                {
                    filename = filename.Replace( c.ToString(), "" );
                }

                GroupPDFExporter.GeneratePDF( m_universe, group, Path.Combine( Path.GetTempPath(), Path.ChangeExtension( filename, "pdf" ) ) );
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

                if( group.HasInactiveComposition() )
                {
                    Image imgInactiveComposition = Properties.Resources.error_outline;

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
    }
}
