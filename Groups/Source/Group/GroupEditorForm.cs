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

            dataGridViewGroupActors.ClearSelection();

            if( dataGridViewGroupActors.RowCount > 0 )
            {
                dataGridViewGroupActors.Rows[ 0 ].Selected = true;
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
            if( dataGridViewGroupActors.SelectedRows.Count > 0 )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewGroupActors.SelectedRows[ 0 ].DataBoundItem;

                pictureBoxCard.Image = CardPainter.GetBitmap( groupActor.Actor );
            }
            else
            {
                pictureBoxCard.Image = null;
            }
        }

        private void toolStripButtonActorsCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroupActors.SelectedRows.Count > 0 )
            {
                Actor actorSource = ((Group.GroupActor)dataGridViewGroupActors.SelectedRows[ 0 ].DataBoundItem).Actor;

                Actor actorNew = UserDataStorage.Actor.Create( actorSource.Archetype );
                actorNew.Set( actorSource );
                actorNew.Name = $"(Kopie von) {actorSource.Name}";
                UserDataStorage.Actor.Save( actorNew );

                m_groupModified.AddActor( actorNew );
                UserDataStorage.Group.Save( m_groupModified ); // BUG this triggers the question, if group should be saved after closing the window

                updateGridViewActors();

                editActor( actorNew );
            }
        }

        private void toolStripButtonActorsAdd_Click( object sender, EventArgs e )
        {
            using( ArchetypeSelectionForm archetypeSelectionForm = new ArchetypeSelectionForm( m_groupModified.Faction ) )
            {
                if( archetypeSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    Actor actor = UserDataStorage.Actor.Create( archetypeSelectionForm.SelectedArchetype );

                    dataGridViewGroupActors.ClearSelection();

                    editActor( actor );

                    if( UserDataStorage.Actor.Exists( actor ) )
                    {
                        m_groupModified.AddActor( actor );
                        UserDataStorage.Group.Save( m_groupModified ); // BUG this triggers the question, if group should be saved after closing the window

                        updateGridViewActors();

                        foreach( DataGridViewRow row in dataGridViewGroupActors.Rows )
                        {
                            if( actor.ID == ( (Group.GroupActor)row.DataBoundItem ).Actor.ID )
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }                    
                }
            }
        }

        private void toolStripButtonActorsRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewGroupActors.SelectedRows.Count > 0 )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewGroupActors.Rows[ dataGridViewGroupActors.SelectedRows[ 0 ].Index ].DataBoundItem;
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
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewGroupActors.Rows[ e.RowIndex ].DataBoundItem;

                string toolTipText = String.Empty;

                // show only inactive, if both inactive and missing outfit
                if( !groupActor.Actor.Active )
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
            if( e.ColumnIndex == groupActorNameDataGridViewTextBoxColumn.Index && e.RowIndex != -1 )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewGroupActors.Rows[ e.RowIndex ].DataBoundItem;

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

        private void editActor( Actor actor )
        {
            using( ActorEditorForm actorEditorForm = new ActorEditorForm( actor ) )
            {
                this.Hide();

                actorEditorForm.ShowDialog( this );

                this.Show();
            }

            groupActorBindingSource.ResetBindings( false );
        }

        private void dataGridViewActors_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editActor( ((Group.GroupActor)dataGridViewGroupActors.CurrentRow.DataBoundItem).Actor );
            }
        }

        private void dataGridViewGroupActors_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editActor( ((Group.GroupActor)dataGridViewGroupActors.Rows[ e.RowIndex ].DataBoundItem).Actor );
            }
        }

        private void dataGridViewGroupActors_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewGroupActors );
        }
    }
}
