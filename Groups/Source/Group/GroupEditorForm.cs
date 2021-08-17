using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GroupEditorForm : Form
    {
        public GroupEditorForm( Group group )
        {
            m_groupOriginal = group;
            m_groupModified = new Group( group );

            InitializeComponent();

            this.WindowState = Properties.Settings.Default.GroupEditorWindowState;

            this.Icon = Shared.Properties.Resources.icon;

            pictureBoxFactionIcon.Image = m_groupModified.Faction.Icon;
            toolTip.SetToolTip( pictureBoxFactionIcon, m_groupModified.Faction.Name );

            pictureBoxGroupIcon.Image = m_groupModified.Icon;

            textBoxName.Text = m_groupModified.Name;
            textBoxDescription.Text = m_groupModified.Description;

            updateGridViewActors();

            update();
        }

        private readonly Group m_groupModified;
        private readonly Group m_groupOriginal;

        private void updateGridViewActors()
        {
            groupActorBindingSource.DataSource = m_groupModified.GroupActorList.OrderBy( x => x.Index )
                                                                               .OrderBy( x => x.Actor.Name )
                                                                               .ToList();

            dataGridViewActors.ClearSelection();

            if( dataGridViewActors.RowCount > 0 )
            {
                dataGridViewActors.Rows[ 0 ].Selected = true;
            }
        }

        private void update()
        {
            textBoxCost.Text = m_groupModified.Points.ToString();
        }

        private void buttonSave_Click( object sender, EventArgs e )
        {
            if( mandatoryFieldsFilled() )
            {
                m_groupOriginal.Set( m_groupModified );
                UserDataStorage.Group.Save( m_groupOriginal );
            }
        }

        private bool mandatoryFieldsFilled()
        {
            if( String.IsNullOrEmpty( m_groupModified.Name ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!" );
                return ( false );
            }

            return ( true );
        }

        private void textBoxName_TextChanged( object sender, EventArgs e )
        {
            m_groupModified.Name = textBoxName.Text;

            update();
        }

        private void textBoxDescription_TextChanged( object sender, EventArgs e )
        {
            m_groupModified.Description = textBoxDescription.Text;
        }

#region events
        private void GroupEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Properties.Settings.Default.GroupEditorWindowState = this.WindowState;
            Properties.Settings.Default.Save();

            if( !m_groupModified.Equals( m_groupOriginal ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( mandatoryFieldsFilled() )
                        {
                            m_groupOriginal.Set( m_groupModified );
                            UserDataStorage.Group.Save( m_groupOriginal );
                        }
                        else
                        {
                            if( MessageBox.Show( "Es fehlen noch Pflichtangaben! Änderungen verwerfen?", "Pflichtangaben fehlen", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2 ) == DialogResult.No )
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
#endregion

#region actors
        private void dataGridViewActors_SelectionChanged( object sender, EventArgs e )
        {
            UpdateCard();
        }

        private void UpdateCard()
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewActors.SelectedRows[ 0 ].DataBoundItem;

                pictureBoxCard.Image = groupActor.Actor != null ? CardPainter.GetBitmap( groupActor.Actor ) : Shared.Properties.Resources.empty;
            }
            else
            {
                pictureBoxCard.Image = null;
            }
        }

        private void toolStripButtonActorsAdd_Click( object sender, EventArgs e )
        {
            using( AddActorToGroupForm addActorToGroup = new AddActorToGroupForm( m_groupModified.Faction.ID ) )
            {
                if( addActorToGroup.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addActorToGroup.SelectedActors.Count > 0 )
                    {
                        foreach( Actor actor in addActorToGroup.SelectedActors )
                        {
                            m_groupModified.AddActor( actor );
                        }

                        updateGridViewActors();

                        foreach( DataGridViewRow row in dataGridViewActors.Rows )
                        {
                            if( ( (Group.GroupActor)row.DataBoundItem ).Actor.ID == addActorToGroup.SelectedActors[ 0 ].ID )
                            {
                                row.Selected = true;
                                break;
                            }
                        }

                        update();
                    }
                }
            }
        }

        private void toolStripButtonActorsRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewActors.Rows[ dataGridViewActors.SelectedRows[ 0 ].Index ].DataBoundItem;
                m_groupModified.GroupActorList.Remove( groupActor );

                updateGridViewActors();
                update();
            }
        }
        #endregion actors

        private void dataGridViewActors_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem;

                string toolTipText = String.Empty;

                // show only inactive, if both inactive and missing outfit
                if( groupActor.Actor == null )
                {
                    toolTipText += "Wurde gelöscht und darf nicht mehr verwendet werden!";
                }
                else
                {
                    if( !String.IsNullOrEmpty( groupActor.Actor.Description ) )
                    {
                        toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + ToolTipHelper.FormatMaxWidth( groupActor.Actor.Description );
                    }
                }

                e.ToolTipText = toolTipText;
            }
        }

        private void pictureBoxGroupIcon_DoubleClick( object sender, EventArgs e )
        {
            using( OpenFileDialog iconFileDialog = new OpenFileDialog() )
            {
                iconFileDialog.InitialDirectory = Properties.Settings.Default.groupIconFilePath;

                if( iconFileDialog.ShowDialog( this ) == DialogResult.OK )
                {
                    Properties.Settings.Default.groupIconFilePath = Path.GetDirectoryName( iconFileDialog.FileName );
                    Properties.Settings.Default.Save();

                    Image img = ImageHelper.CreateIconFromImage( ImageHelper.LoadImage( iconFileDialog.FileName ) );

                    if( img != null )
                    {
                        pictureBoxGroupIcon.Image = img;
                        m_groupModified.Icon = new Bitmap( img );
                    }
                }
            }
        }

        private void dataGridViewActors_CellPainting( object sender, DataGridViewCellPaintingEventArgs e )
        {
            if( e.ColumnIndex == nameDataGridViewTextBoxColumn.Index && e.RowIndex != -1 )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem;

                if( groupActor.Actor == null )
                {
                    e.PaintBackground( e.CellBounds, true );
                    e.PaintContent( e.CellBounds );

                    Image imgInactiveActors = Properties.Resources.error;
                    e.Graphics.DrawImageUnscaled( imgInactiveActors, e.CellBounds.X + e.CellBounds.Width - (int)( imgInactiveActors.Width * 1.5 ), e.CellBounds.Y + ( ( e.CellBounds.Height - imgInactiveActors.Height ) / 2 ) );

                    e.Handled = true;
                }
            }
        }

        private void dataGridViewActors_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( e.Button == MouseButtons.Right )
            {
                if( ( e.ColumnIndex != -1 ) && ( e.RowIndex != -1 ) )
                {
                    DataGridViewRow row = dataGridViewActors.Rows[ e.RowIndex ];
                    if( !row.Selected )
                    {
                        dataGridViewActors.ClearSelection();
                        dataGridViewActors.CurrentCell = row.Cells[ e.ColumnIndex ];
                        row.Selected = true;
                    }
                }
            }
        }
    }
}
