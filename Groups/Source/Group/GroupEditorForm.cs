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
            groupActorBindingSource.DataSource = m_groupModified.GroupActorList.OrderBy( x => x.Name )
                                                                               .OrderByDescending( x => x.Points )
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

            if( null == m_groupModified.Faction )
            {
                MessageBox.Show( "Fraktion ist leer, bitte angeben!" );
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

        private void toolStripButtonActorOutfit_Click( object sender, EventArgs e )
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewActors.Rows[ dataGridViewActors.SelectedRows[ 0 ].Index ].DataBoundItem;

                if( groupActor.Actor == null )
                {
                    MessageBox.Show( "Dieses Modell wurde gelöscht und kann daher nicht mehr geändert werden!" );
                }
                else
                {
                    using( SelectOutfitForActorForm selectOutfitForActorForm = new SelectOutfitForActorForm( groupActor.Actor ) )
                    {
                        if( selectOutfitForActorForm.ShowDialog( this ) == DialogResult.OK )
                        {
                            groupActor.ActorOutfit = selectOutfitForActorForm.SelectedOutfit;

                            groupActorBindingSource.ResetBindings( false );

                            UpdateCard();
                        }
                    }
                }
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

        private void dataGridViewActors_EditingControlShowing( object sender, DataGridViewEditingControlShowingEventArgs e )
        {
            if( dataGridViewActors.CurrentCell.ColumnIndex == nameDataGridViewTextBoxColumn.Index )
            {
                Group.GroupActor groupActor = (Group.GroupActor)dataGridViewActors.CurrentRow.DataBoundItem;
                dataGridViewActors.EditingControl.Text = groupActor.CustomName;
            }
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if( ( keyData == Keys.Escape ) && ( dataGridViewActors.IsCurrentCellInEditMode ) )
            {
                dataGridViewActors.CancelEdit();
                dataGridViewActors.EndEdit();

                return ( true );
            }

            return( base.ProcessCmdKey( ref msg, keyData ) );
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

        private void dataGridViewActors_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            UpdateCard();
        }
    }
}
