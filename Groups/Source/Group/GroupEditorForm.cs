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

            groupBindingSource.DataSource = m_groupModified;

            updateGridViewActors();
        }

        private readonly Group m_groupModified;
        private readonly Group m_groupOriginal;

        private void updateGridViewActors()
        {
            actorsBindingSource.DataSource = m_groupModified.ModelList.ToList();

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
            if( pictureBoxCard.Image != null )
            {
                pictureBoxCard.Image.Dispose();
            }

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

        private void toolStripButtonActorsCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Actor actorSource = (Actor)dataGridViewActors.SelectedRows[ 0 ].DataBoundItem;

                var actorNew = actorSource.Copy();
                actorNew.Name = $"(Kopie von) {actorSource.Name}";

                m_groupModified.ModelList.Add( actorNew );

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
                    var actor = new Actor( archetypeSelectionForm.SelectedArchetype );

                    dataGridViewActors.ClearSelection();

                    editActor( actor );

                    m_groupModified.ModelList.Add( actor );

                    updateGridViewActors();

                    foreach( DataGridViewRow row in dataGridViewActors.Rows )
                    {
                        if( actor.ID == ((Actor)row.DataBoundItem).ID )
                        {
                            row.Selected = true;
                            break;
                        }
                    }                    
                }
            }
        }

        private void toolStripButtonActorsRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Actor actor = (Actor)dataGridViewActors.Rows[ dataGridViewActors.SelectedRows[ 0 ].Index ].DataBoundItem;

                if( MessageBox.Show( $"Das Model '{actor.Name}' wirklich löschen?",
                                     "Model löschen",
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Warning,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_groupModified.ModelList.Remove( actor );

                    updateGridViewActors();
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
                    toolTipText += "Wurde gelöscht und darf nicht mehr verwendet werden!";
                }

                if( actor.HasInactiveComposition() )
                {
                    toolTipText += "Inaktive Ausstattung vorhanden!";
                }

                if( !String.IsNullOrEmpty( actor.Description ) )
                {
                    toolTipText += ( !String.IsNullOrEmpty( toolTipText ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + ToolTipHelper.FormatMaxWidth( actor.Description );
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
            if( e.ColumnIndex == actorNameDataGridViewTextBoxColumn.Index && e.RowIndex != -1 )
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
        }

        private void editActor( Actor actor )
        {
            using( ActorEditorForm actorEditorForm = new ActorEditorForm( actor ) )
            {
                actorEditorForm.ShowDialog( this );
            }

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
        }

        private void dataGridViewActors_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {
            var senderGrid = (DataGridView)sender;

            if( senderGrid.Columns[ e.ColumnIndex ] is DataGridViewButtonColumn && e.RowIndex >= 0 )
            {
                if( e.ColumnIndex == actorUpDataGridViewTextBoxColumn.Index )
                {
                    if( e.RowIndex > 0 )
                    {
                        var tmp = m_groupModified.ModelList[ e.RowIndex ];
                        m_groupModified.ModelList[ e.RowIndex ] = m_groupModified.ModelList[ e.RowIndex - 1 ];
                        m_groupModified.ModelList[ e.RowIndex - 1 ] = tmp;

                        updateGridViewActors();

                        dataGridViewActors.Rows[ e.RowIndex - 1 ].Selected = true;
                    }
                }
                else if( e.ColumnIndex == actorDownDataGridViewTextBoxColumn.Index )
                {
                    if( e.RowIndex < ( m_groupModified.ModelList.Count - 1 ) )
                    {
                        var tmp = m_groupModified.ModelList[ e.RowIndex ];
                        m_groupModified.ModelList[ e.RowIndex ] = m_groupModified.ModelList[ e.RowIndex + 1 ];
                        m_groupModified.ModelList[ e.RowIndex + 1 ] = tmp;

                        updateGridViewActors();

                        dataGridViewActors.Rows[ e.RowIndex + 1 ].Selected = true;
                    }
                }
            }
        }

        private void toolStripButtonGroupTraitSelect_Click( object sender, EventArgs e )
        {
            if( null != m_groupModified.GroupTrait )
            {
                MessageBox.Show( "Es ist bereits eine Gruppeneigenschaft vorhanden!" );
            }
            else
            {
                using( var groupTraitSelectionForm = new GroupTraitSelectionForm( m_groupModified.Faction ) )
                {
                    if( groupTraitSelectionForm.ShowDialog( this ) == DialogResult.OK )
                    {
                        if( groupTraitSelectionForm.SelectedGroupTrait != null )
                        {
                            m_groupModified.GroupTrait = groupTraitSelectionForm.SelectedGroupTrait;

                            groupBindingSource.ResetBindings( false );
                        }
                    }
                }
            }
        }

        private void toolStripButtonGroupTraitRemove_Click( object sender, EventArgs e )
        {
            if( m_groupModified.GroupTrait != null )
            {
                m_groupModified.GroupTrait = null;

                groupBindingSource.ResetBindings( false );
            }
        }
    }
}
