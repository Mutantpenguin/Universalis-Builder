using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class GroupEditorForm : Form
    {
        public GroupEditorForm( Universe universe, Group group )
        {
            m_universe = universe;

            m_groupOriginal = group;
            m_groupModified = new Group( group );

            InitializeComponent();

            pictureBoxGroupIcon.AllowDrop = true;

            if( !Options.DeityMode )
            {
                buttonRefresh.Visible = false;
            }

            this.CenterToParent();

            this.WindowState = Properties.Settings.Default.GroupEditorWindowState;

            this.Icon = Properties.Resources.icon;

            pictureBoxFactionIcon.Image = m_groupModified.Faction.Icon;
            toolTip.SetToolTip( pictureBoxFactionIcon, m_groupModified.Faction.Name );

            pictureBoxGroupIcon.Image = m_groupModified.Icon;

            textBoxName.Text = m_groupModified.Name;
            textBoxDescription.Text = m_groupModified.Description;

            groupBindingSource.DataSource = m_groupModified;

            toolStripButtonGroupTraitSelect.Checked = ( m_groupModified.GroupTrait != null );

            updateGroupTrait();

            updateGridViewActors();
        }

        private void updateGroupTrait()
        {
            if( m_groupModified.GroupTrait != null )
            {
                toolStripLabelGroupTrait.Text = m_groupModified.GroupTrait.Name;
            }
            else
            {
                toolStripLabelGroupTrait.Text = String.Empty;
            }
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                components?.Dispose();

                pictureBoxCard.Image?.Dispose();
            }

            base.Dispose( disposing );
        }

        private readonly Universe m_universe;

        private readonly Group m_groupModified;
        private readonly Group m_groupOriginal;
        private bool m_dragndrop;

        private void updateGridViewActors()
        {
            actorsBindingSource.DataSource = m_groupModified.Models.ToList();

            dataGridViewActors.ClearSelection();

            if( dataGridViewActors.RowCount > 0 )
            {
                dataGridViewActors.Rows[ 0 ].Selected = true;
            }
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
            pictureBoxCard.Image?.Dispose();

            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Actor actor = (Actor)dataGridViewActors.SelectedRows[ 0 ].DataBoundItem;

                pictureBoxCard.Image = CardPainter.GetBitmap( actor );
            }
            else
            {
                pictureBoxCard.Image = null;
            }
        }

        private void toolStripButtonActorsAdd_Click( object sender, EventArgs e )
        {
            using( ArchetypeSelectionForm archetypeSelectionForm = new ArchetypeSelectionForm( m_groupModified.Faction ) )
            {
                if( archetypeSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    var archetype = archetypeSelectionForm.SelectedArchetype;

                    var actor = new Actor( archetype );

                    dataGridViewActors.ClearSelection();

                    m_groupModified.Models.Add( actor );

                    if( archetype.MaxQuantity > 0 )
                    {
                        var archetypeCount = m_groupModified.Models.Where( x => x.Archetype == archetype ).Count();

                        if( archetypeCount > archetype.MaxQuantity )
                        {
                            MessageBox.Show( $"Der Archetyp '{archetype.Name}' darf (aktiv) maximal nur {archetype.MaxQuantity}x in einer Gruppe vorkommen.\n\nEr ist nun aber {archetypeCount}x vorhanden.",
                                             "Maximale Anzahl überschritten",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Warning );
                        }
                    }

                    editActor( actor );

                    updateGridViewActors();

                    SelectActor( actor );
                }
            }
        }

        private void SelectActor( Actor actor )
        {
            dataGridViewActors.ClearSelection();

            foreach( DataGridViewRow row in dataGridViewActors.Rows )
            {
                if( actor.ID == ( (Actor)row.DataBoundItem ).ID )
                {
                    row.Selected = true;
                    break;
                }
            }
        }
        #endregion actors

        private void dataGridViewActors_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Actor actor = (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem;

                string toolTipText = String.Empty;

                if( !actor.Active )
                {
                    toolTipText += $"Ist inaktiv und kann nicht verwendet werden: {actor.InactiveType}";
                }

                if( actor.HasInactiveComposition() )
                {
                    toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + "Inaktive Ausstattung vorhanden!";
                }

                if( !String.IsNullOrEmpty( actor.Archetype.Rules ) )
                {
                    toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + "Regeln:" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( actor.Archetype.Rules );
                }

                if(!String.IsNullOrEmpty( actor.Biography ))
                {
                    toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + "Biografie:" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( actor.Biography );
                }

                e.ToolTipText = toolTipText;
            }
        }

        private void dataGridViewActors_CellPainting( object sender, DataGridViewCellPaintingEventArgs e )
        {
            if( e.RowIndex != -1 )
            {
                if( e.ColumnIndex == actorNameDataGridViewTextBoxColumn.Index )
                {
                    Actor actor = (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem;

                    if( actor.HasInactiveComposition() )
                    {
                        e.PaintBackground( e.CellBounds, true );
                        e.PaintContent( e.CellBounds );

                        Image imgInactiveComposition = Properties.Resources.error_outline;
                        e.Graphics.DrawImageUnscaled( imgInactiveComposition, e.CellBounds.X + e.CellBounds.Width - (int)( imgInactiveComposition.Width * 1.5 ), e.CellBounds.Y + ( ( e.CellBounds.Height - imgInactiveComposition.Height ) / 2 ) );

                        e.Handled = true;
                    }
                }
                else if( e.ColumnIndex == actorIconDataGridViewImageColumn.Index )
                {
                    e.PaintBackground( e.CellBounds, true );

                    Actor actor = (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem;

                    if( !actor.Active )
                    {
                        var drawRect = new Rectangle( e.CellBounds.X + 1, e.CellBounds.Y, e.CellBounds.Width - 2, e.CellBounds.Height - 1 );

                        using( ImageAttributes attributes = new ImageAttributes() )
                        {
                            attributes.SetColorMatrix( ImageHelper.colorMatrixGreyAndLight );

                            e.Graphics.DrawImage( actor.Icon, drawRect, 0, 0, actor.Icon.Width, actor.Icon.Height, GraphicsUnit.Pixel, attributes );
                        }

                        e.Graphics.DrawImage( Properties.Resources.disabled_overlay, new Rectangle( drawRect.X + ( drawRect.Width / 2 ), drawRect.Y + ( drawRect.Height / 2 ), drawRect.Width / 2, drawRect.Height / 2 ) );
                    }
                    else
                    {
                        e.PaintContent( e.CellBounds );
                    }

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

            groupBindingSource.ResetBindings( false );
            actorsBindingSource.ResetBindings( false );
        }

        private void dataGridViewActors_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editActor( (Actor)dataGridViewActors.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewGroupActors_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editActor( (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem );
            }
        }

        private void dataGridViewGroupActors_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewActors );

            if( e.RowIndex != -1 )
            {
                if( e.ColumnIndex == actorNameDataGridViewTextBoxColumn.Index )
                {
                    Actor actor = (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem;

                    e.Value = actor.Name + Environment.NewLine + actor.Archetype.Name;
                }
            }
        }

        private void toolStripButtonGroupTraitSelect_Click( object sender, EventArgs e )
        {
            if( null != m_groupModified.GroupTrait )
            {
                m_groupModified.GroupTrait = null;

                groupBindingSource.ResetBindings( false );

                updateGroupTrait();
            }
            else
            {
                using( var groupTraitSelectionForm = new GroupTraitSelectionForm( m_groupModified.Faction ) )
                {
                    if( groupTraitSelectionForm.ShowDialog( this ) == DialogResult.OK && groupTraitSelectionForm.SelectedGroupTrait != null )
                    {
                        m_groupModified.GroupTrait = groupTraitSelectionForm.SelectedGroupTrait;

                        groupBindingSource.ResetBindings( false );

                        updateGroupTrait();
                    }
                    else
                    {
                        toolStripButtonGroupTraitSelect.Checked = false;
                        toolStripButtonGroupTraitSelect.Image = Properties.Resources.ui_check_box_uncheck;
                    }
                }
            }
        }

        private void toolStripButtonGroupTraitSelect_CheckedChanged(object sender, EventArgs e)
        {
            if(toolStripButtonGroupTraitSelect.Checked)
            {
                toolStripButtonGroupTraitSelect.Image = Properties.Resources.ui_check_box;
            }
            else
            {
                toolStripButtonGroupTraitSelect.Image = Properties.Resources.ui_check_box_uncheck;
            }
        }

        private void dataGridViewActors_CellContextMenuStripNeeded( object sender, DataGridViewCellContextMenuStripNeededEventArgs e )
        {
            if( e.RowIndex >= 0 && e.ColumnIndex >= 0 )
            {
                e.ContextMenuStrip = contextMenuStripActor;

                Actor actor = (Actor)dataGridViewActors.CurrentRow.DataBoundItem;

                if( !actor.Active )
                {
                    disableToolStripMenuItem.Visible = false;
                    enableToolStripMenuItem.Visible = true;
                    copyToolStripMenuItem.Visible = false;
                }
                else
                {
                    disableToolStripMenuItem.Visible = true;
                    enableToolStripMenuItem.Visible = false;
                    copyToolStripMenuItem.Visible = true;
                }
            }
            else
            {
                e.ContextMenuStrip = new ContextMenuStrip();
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

        private void disableToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Actor actor = (Actor)dataGridViewActors.CurrentRow.DataBoundItem;

            if( !actor.Active )
            {
                MessageBox.Show( $"Das Model '{actor.Name}' ist bereits inaktiv.",
                                    String.Empty,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information );
            }
            else
            {
                using( var inactiveReasonForm = new InactiveReasonForm() )
                {
                    if( inactiveReasonForm.ShowDialog() == DialogResult.OK )
                    {
                        actor.Active = false;
                        actor.InactiveType = inactiveReasonForm.InactiveType;
                        actor.InactiveReason = inactiveReasonForm.InactiveReason;

                        updateGridViewActors();

                        SelectActor( actor );

                        groupBindingSource.ResetBindings( false );
                    }
                }
            }
        }

        private void enableToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Actor actor = (Actor)dataGridViewActors.CurrentRow.DataBoundItem;

            if( MessageBox.Show( $"Das Model '{actor.Name}' wirklich reaktivieren?\n\nGrund für Inaktivierung: {actor.InactiveType}",
                                 "Reaktivieren",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Warning,
                                 MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
            {
                if( actor.Active )
                {
                    MessageBox.Show( $"Das Model '{actor.Name}' ist bereits aktiv.",
                                     String.Empty,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information );
                }
                else
                {
                    actor.Active = true;
                    actor.InactiveType = Actor.EInactiveType.Kein;
                    actor.InactiveReason = String.Empty;

                    updateGridViewActors();

                    SelectActor( actor );

                    groupBindingSource.ResetBindings( false );
                }
            }
        }

        private void copyToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Actor actorSource = (Actor)dataGridViewActors.CurrentRow.DataBoundItem;

            var actorNew = actorSource.Copy();
            actorNew.Name = $"(Kopie von) {actorSource.Name}";

            m_groupModified.Models.Add( actorNew );

            updateGridViewActors();

            SelectActor( actorNew );

            editActor( actorNew );
        }

        private void deleteToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Actor actor = (Actor)dataGridViewActors.CurrentRow.DataBoundItem;

            if( MessageBox.Show( $"Das Model '{actor.Name}' wirklich löschen?\n\nDies kann nicht rückgängig gemacht werden.",
                                 "Model löschen",
                                 MessageBoxButtons.OKCancel,
                                 MessageBoxIcon.Warning,
                                 MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
            {
                m_groupModified.Models.Remove( actor );

                updateGridViewActors();

                groupBindingSource.ResetBindings( false );
            }
        }

        private void buttonClose_Click( object sender, EventArgs e )
        {
            Close();
        }

        private void buttonRefresh_Click( object sender, EventArgs e )
        {
            groupBindingSource.ResetBindings( false );
            actorsBindingSource.ResetBindings( false );
        }

        private void buttonPrint_Click( object sender, EventArgs e )
        {
            if( !m_groupModified.Equals( m_groupOriginal ) )
            {
                MessageBox.Show( "Es wurden Änderungen an der Gruppe vorgenommen. Bitte speichern Sie die Gruppe vorher!",
                                 String.Empty,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );

                return;
            }

            var (status, reason) = m_groupModified.IsValid();

            if( !status )
            {
                MessageBox.Show( $"Die Gruppe ist nicht regelkonform. Bitte korrigieren Sie die Probleme vorher:\n\n{reason}",
                                 String.Empty,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );

                return;
            }

            string filename = m_groupModified.Name + " - " + DateTime.Now.ToString( "yyyyMMdd_HHmmss" );

            foreach( char c in Path.GetInvalidFileNameChars() )
            {
                filename = filename.Replace( c.ToString(), String.Empty );
            }

            GroupPDFExporter.GeneratePDF( m_universe, m_groupModified, Path.Combine( Path.GetTempPath(), Path.ChangeExtension( filename, "pdf" ) ) );
        }

        private void buttonImage_Click( object sender, EventArgs e )
        {
            using( OpenFileDialog iconFileDialog = new OpenFileDialog() )
            {
                iconFileDialog.InitialDirectory = Properties.Settings.Default.groupIconFilePath;

                if( iconFileDialog.ShowDialog( this ) == DialogResult.OK )
                {
                    Properties.Settings.Default.groupIconFilePath = Path.GetDirectoryName( iconFileDialog.FileName );
                    Properties.Settings.Default.Save();

                    SelectIconFromPath( iconFileDialog.FileName );
                }
            }
        }

        private void SelectIconFromPath( String path )
        {
            var img = ImageHelper.LoadImage( path );

            if( img != null )
            {
                if( img.Width != img.Height )
                {
                    using( ImageSelectionForm imageSelectionForm = new ImageSelectionForm( "Icon auswählen", img, ImageHelper.iconSize ) )
                    {
                        if( imageSelectionForm.ShowDialog() == DialogResult.OK )
                        {
                            pictureBoxGroupIcon.Image = imageSelectionForm.Image;
                            m_groupModified.Icon = new Bitmap( imageSelectionForm.Image );
                        }
                    }
                }
                else
                {
                    img = ImageHelper.CreateIconFromImage( img, withTransparency: false );

                    if( img != null )
                    {
                        pictureBoxGroupIcon.Image = img;
                        m_groupModified.Icon = new Bitmap( img );
                    }
                }
            }
        }

        private void GroupEditorForm_DragEnter( object sender, DragEventArgs e )
        {
            m_dragndrop = true;
            pictureBoxGroupIcon.Refresh();

            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void GroupEditorForm_DragLeave( object sender, EventArgs e )
        {
            m_dragndrop = false;
            pictureBoxGroupIcon.Refresh();
        }

        private void GroupEditorForm_DragDrop( object sender, DragEventArgs e )
        {
            m_dragndrop = false;
            pictureBoxGroupIcon.Refresh();
        }

        private void pictureBoxGroupIcon_Paint( object sender, PaintEventArgs e )
        {
            if( m_dragndrop )
            {
                ControlPaint.DrawBorder( e.Graphics, e.ClipRectangle,
                          Color.Red, 3, ButtonBorderStyle.Solid,
                          Color.Red, 3, ButtonBorderStyle.Solid,
                          Color.Red, 3, ButtonBorderStyle.Solid,
                          Color.Red, 3, ButtonBorderStyle.Solid );
            }
            else
            {
                ControlPaint.DrawBorder( e.Graphics, e.ClipRectangle, this.BackColor, ButtonBorderStyle.None );
            }
        }

        private void pictureBoxGroupIcon_DragDrop( object sender, DragEventArgs e )
        {
            m_dragndrop = false;
            pictureBoxGroupIcon.Refresh();

            string[] s = (string[])e.Data.GetData( DataFormats.FileDrop, false );

            if( s.Length == 1 )
            {
                SelectIconFromPath( s[0] );
            }
        }

        private void pictureBoxGroupIcon_DragEnter( object sender, DragEventArgs e )
        {
            m_dragndrop = true;
            pictureBoxGroupIcon.Refresh();

            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;

        private void dataGridViewActors_MouseDown( object sender, MouseEventArgs e )
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dataGridViewActors.HitTest( e.X, e.Y ).RowIndex;

            if( rowIndexFromMouseDown != -1 )
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;

                // Create a rectangle using the DragSize, with the mouse position being at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle( new Point( e.X - ( dragSize.Width / 2 ), e.Y - ( dragSize.Height / 2 ) ), dragSize );
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void dataGridViewActors_MouseMove( object sender, MouseEventArgs e )
        {
            if( ( e.Button & MouseButtons.Left ) == MouseButtons.Left )
            {
                // If the mouse moves outside the rectangle, start the drag.
                if( ( dragBoxFromMouseDown != Rectangle.Empty ) && !dragBoxFromMouseDown.Contains( e.X, e.Y ) )
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    dataGridViewActors.DoDragDrop( dataGridViewActors.Rows[ rowIndexFromMouseDown ], DragDropEffects.Move );
                }
            }
        }

        private void dataGridViewActors_DragOver( object sender, DragEventArgs e )
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridViewActors_DragDrop( object sender, DragEventArgs e )
        {
            // The mouse locations are relative to the screen, so they must be  converted to client coordinates.
            Point clientPoint = dataGridViewActors.PointToClient( new Point( e.X, e.Y ) );

            // Get the row index of the item the mouse is below. 
            int rowIndexOfItemUnderMouseToDrop = dataGridViewActors.HitTest( clientPoint.X, clientPoint.Y ).RowIndex;

            if( rowIndexOfItemUnderMouseToDrop != -1 )
            {
                // If the drag operation was a move then remove and insert the row.
                if( e.Effect == DragDropEffects.Move )
                {

                    var rowToMove = m_groupModified.Models[ rowIndexFromMouseDown ];
                    m_groupModified.Models.RemoveAt( rowIndexFromMouseDown );
                    m_groupModified.Models.Insert( rowIndexOfItemUnderMouseToDrop, rowToMove );

                    updateGridViewActors();

                    dataGridViewActors.Rows[ rowIndexOfItemUnderMouseToDrop ].Selected = true;
                }
            }
        }
    }
}
