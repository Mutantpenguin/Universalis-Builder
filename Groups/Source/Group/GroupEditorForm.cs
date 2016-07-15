using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public partial class GroupEditorForm : Form
    {
        public GroupEditorForm( Group group )
        {
            m_groupOriginal = group;
            m_groupModified = new Group( group );

            InitializeComponent();

            this.WindowState = Properties.Settings.Default.GroupEditorWindowState;

            this.Icon = Properties.Resources.icon;

            pictureBoxFactionIcon.Image = m_groupModified.Faction.Icon;
            toolTip.SetToolTip( pictureBoxFactionIcon, m_groupModified.Faction.Name );

            pictureBoxGroupIcon.Image = m_groupModified.Icon;

            textBoxName.Text = m_groupModified.Name;
            textBoxDescription.Text = m_groupModified.Description;

            updateGridViewActors();

            update();
        }

        private Group m_groupModified;
        private Group m_groupOriginal;

        private void updateGridViewActors()
        {
            groupActorBindingSource.DataSource = m_groupModified.GroupActorList.OrderByDescending( x => ( x.Actor != null ) ? x.ActorOutfit.Name : "zzzzzzzzzzzzzz" )
                                                                               .OrderBy( x => ( x.Actor != null ) ? x.Name : "zzzzzzzzzzzzzz" )
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
                if( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_groupOriginal.Set( m_groupModified );
                    GroupStorage.Save( m_groupOriginal );
                }
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
                            GroupStorage.Save( m_groupOriginal );
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

                if( groupActor.Actor != null )
                {
                    pictureBoxCard.Image = CardPainter.getBitmap( groupActor );
                }
                else
                {
                    pictureBoxCard.Image = TObjects.Properties.Resources.empty;
                }
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
                            if( actor.ActorOutfitsList.Count == 1 )
                            {
                                m_groupModified.AddActor( actor, actor.ActorOutfitsList[ 0 ] );
                            }
                            else
                            {
                                using( SelectOutfitForActorForm selectOutfitForActorForm = new SelectOutfitForActorForm( actor ) )
                                {
                                    if( selectOutfitForActorForm.ShowDialog( this ) == DialogResult.OK )
                                    {
                                        m_groupModified.AddActor( actor, selectOutfitForActorForm.SelectedOutfit );
                                    }
                                }
                            }
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
                    if( groupActor.ActorOutfit == null )
                    {
                        toolTipText += "Fehlendes Outfit!";
                    }

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

                if( groupActor.Actor == null
                    ||
                    groupActor.ActorOutfit == null )
                {
                    e.PaintBackground( e.CellBounds, true );
                    e.PaintContent( e.CellBounds );

                    if( groupActor.Actor == null )
                    {
                        Image imgInactiveActors = Properties.Resources.exclamation_red;
                        e.Graphics.DrawImageUnscaled( imgInactiveActors, e.CellBounds.X + e.CellBounds.Width - (int)( imgInactiveActors.Width * 1.5 ), e.CellBounds.Y + ( ( e.CellBounds.Height - imgInactiveActors.Height ) / 2 ) );
                    }
                    else
                    {
                        Image imgMissingActorOutfits = Properties.Resources.exclamation;
                        e.Graphics.DrawImageUnscaled( imgMissingActorOutfits, e.CellBounds.X + e.CellBounds.Width - (int)( imgMissingActorOutfits.Width * 1.5 ), e.CellBounds.Y + ( ( e.CellBounds.Height - imgMissingActorOutfits.Height ) / 2 ) );
                    }

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

        private void dataGridViewActors_RowContextMenuStripNeeded( object sender, DataGridViewRowContextMenuStripNeededEventArgs e )
        {
            Group.GroupActor groupActor = (Group.GroupActor)dataGridViewActors.CurrentRow.DataBoundItem;

            if( groupActor.Actor == null )
            {
                e.ContextMenuStrip = new ContextMenuStrip();
            }
            else
            {
                e.ContextMenuStrip = contextMenuStripActors;

                // TODO ins ContextMenu einbauen
                if( groupActor.Actor.ActorOutfitsList.Count > 0 )
                {
                    outfitWechselnToolStripMenuItem.DropDownItems.Clear();

                    foreach( Actor.ActorOutfit outfit in groupActor.Actor.ActorOutfitsList.OrderBy( x => x.Name ) )
                    {
                        outfitWechselnToolStripMenuItem.DropDownItems.Add( $"{outfit.Name} - {outfit.Points}pkt", null, delegate
                                                                                                                        {
                                                                                                                            groupActor.ActorOutfit = outfit;

                                                                                                                            groupActorBindingSource.ResetBindings( false );

                                                                                                                            UpdateCard();
                                                                                                                        } );
                    }
                }
                else
                {
                    outfitWechselnToolStripMenuItem.DropDownItems.Add( "Keine Outfits vorhanden" );
                }
            }
        }

        private void umbenennenToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Group.GroupActor groupActor = (Group.GroupActor)dataGridViewActors.CurrentRow.DataBoundItem;

            using( EnterNameForm enterNameForm = new EnterNameForm( groupActor.CustomName, emptyNameAllowed: true ) )
            {
                if( enterNameForm.ShowDialog( this ) == DialogResult.OK )
                {
                    groupActor.CustomName = enterNameForm.NewName;

                    groupActorBindingSource.ResetBindings( false );

                    UpdateCard();
                }
            }
        }

        private void eigenesBildHochladenToolStripMenuItem_Click( object sender, EventArgs e )
        {
            // TODO eigenes Bild einbauen implementieren

            groupActorBindingSource.ResetBindings( false );

            UpdateCard();
        }
    }
}
