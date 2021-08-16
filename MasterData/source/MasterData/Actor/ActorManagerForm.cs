using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ActorManagerForm : Form
    {
        public ActorManagerForm()
        {
            InitializeComponent();

            this.Icon = Shared.Properties.Resources.icon;

            filterFaction.ComboBox.DataSource = MasterDataStorage.Faction.Factions.OrderBy( x => x.Name )
                                                                                  .ToList();
            filterFaction.ComboBox.DisplayMember = nameof( Faction.Name );
            filterFaction.ComboBox.SelectionChangeCommitted += FilterFaction_SelectionChangeCommitted;

            filterType.ComboBox.DataSource = Profile.ETypeList;
            filterType.ComboBox.SelectionChangeCommitted += FilterType_SelectionChangeCommitted;

            RefreshActorsGridView();

            toolStripTextBoxSearch.TextBox.Select();
        }

        private void dataGridViewActors_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                editActor( (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem );
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

            actorBindingSource.ResetBindings( false );
        }

        private void toolStripButtonAddActor_Click( object sender, EventArgs e )
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
                                Actor actor = MasterDataStorage.Actor.Create( factionSelectionForm.SelectedFaction, archetypeSelectionForm.SelectedArchetype );

                                toolStripTextBoxSearch.Text = String.Empty;

                                editActor( actor );

                                RefreshActorsGridView();

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
                        }
                    }
                }
            }
        }

        private void toolStripButtonDeleteActor_Click( object sender, EventArgs e )
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Actor actor = (Actor)dataGridViewActors.SelectedRows[ 0 ].DataBoundItem;

                if( MessageBox.Show( $"Modell '{actor.Name}' wirklich löschen?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    MasterDataStorage.Actor.Delete( actor );

                    RefreshActorsGridView();
                }
            }
        }

        private void toolStripButtonCopy_Click( object sender, EventArgs e )
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Actor actorSource = (Actor)dataGridViewActors.SelectedRows[ 0 ].DataBoundItem;

                Actor actorNew = MasterDataStorage.Actor.Create( actorSource.Faction, actorSource.Archetype );
                actorNew.Set( actorSource );
                actorNew.Name = $"(Kopie von) {actorSource.Name}";
                MasterDataStorage.Actor.Save( actorNew );

                toolStripTextBoxSearch.Text = String.Empty;
                RefreshActorsGridView();

                editActor( actorNew );
            }
        }

        private void FilterFaction_SelectionChangeCommitted( object sender, EventArgs e )
        {
            RefreshActorsGridView();
        }

        private void FilterType_SelectionChangeCommitted( object sender, EventArgs e )
        {
            RefreshActorsGridView();
        }

        private void RefreshActorsGridView()
        {
            List<Actor> actors = MasterDataStorage.Actor.Actors.Where( s => filterFaction.Enabled ? s.Faction.ID == ( (Faction)filterFaction.ComboBox.SelectedValue ).ID : true )
                                                               .Where( s => filterType.Enabled ? s.Archetype.Profile.Type == ( (Profile.EType)filterType.ComboBox.SelectedValue ) : true )
                                                               .Where( s => s.Name.ToUpper().Contains( toolStripTextBoxSearch.Text.ToUpper() ) )
                                                               .OrderBy( x => x.Name )
                                                               .ToList();

            actorBindingSource.DataSource = actors;
            dataGridViewActors.ClearSelection();

            toolStripStatusLabelCount.Text = $"Anzahl: {actors.Count}";
        }

        private void checkBoxFilterFaction_Click( object sender, EventArgs e )
        {
            filterFaction.Enabled = !filterFaction.Enabled;

            checkBoxFilterFaction.Image = checkBoxFilterFaction.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            RefreshActorsGridView();
        }

        private void checkBoxFilterType_Click( object sender, EventArgs e )
        {
            filterType.Enabled = !filterType.Enabled;

            checkBoxFilterType.Image = checkBoxFilterType.Checked ? Properties.Resources.ui_check_box : Properties.Resources.ui_check_box_uncheck;

            RefreshActorsGridView();
        }

        private void toolStripTextBoxSearch_TextChanged( object sender, EventArgs e )
        {
            RefreshActorsGridView();
        }

        private void toolStripButtonClearSearch_Click( object sender, EventArgs e )
        {
            toolStripTextBoxSearch.Clear();
        }

        private void dataGridViewActors_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Actor actor = (Actor)dataGridViewActors.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = ToolTipHelper.FormatMaxWidth( actor.Description );
            }
        }

        private void toolStripButtonChangeFaction_Click( object sender, EventArgs e )
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Actor actor = (Actor)dataGridViewActors.SelectedRows[ 0 ].DataBoundItem;

                using( FactionSelectionForm factionSelectionForm = new FactionSelectionForm( actor.Faction ) )
                {
                    if( factionSelectionForm.ShowDialog( this ) == DialogResult.OK )
                    {
                        if( factionSelectionForm.SelectedFaction != null )
                        {
                            actor.Faction = factionSelectionForm.SelectedFaction;

                            MasterDataStorage.Actor.Save( actor );

                            RefreshActorsGridView();
                        }
                    }
                }
            }
        }

        private void toolStripButtonExportImage_Click( object sender, EventArgs e )
        {
            if( dataGridViewActors.SelectedRows.Count > 0 )
            {
                Actor actor = (Actor)dataGridViewActors.SelectedRows[ 0 ].DataBoundItem;

                if( actor.ActorOutfitsList.Count == 1 )
                {
                    SaveActorWithOutfitAsJPEG( actor, actor.ActorOutfitsList[ 0 ] );
                }
                else
                {
                    using( SelectOutfitForActorForm selectOutfitForActorForm = new SelectOutfitForActorForm( actor ) )
                    {
                        if( selectOutfitForActorForm.ShowDialog( this ) == DialogResult.OK )
                        {
                            Actor.ActorOutfit actorOutfit = selectOutfitForActorForm.SelectedOutfit;
                            SaveActorWithOutfitAsJPEG( actor, actorOutfit );
                        }
                    }
                }
            }
        }

        private static void SaveActorWithOutfitAsJPEG( Actor actor, Actor.ActorOutfit actorOutfit )
        {
            using( SaveFileDialog cardSaveFileDialog = new SaveFileDialog() )
            {
                cardSaveFileDialog.InitialDirectory = Properties.Settings.Default.cardSavePath;
                cardSaveFileDialog.Filter = "JPEG (*.jpg)|*.jpg";
                cardSaveFileDialog.FileName = $"{actor.Name} - {actorOutfit.Name} - {actor.Points( actorOutfit )}pts";

                if( cardSaveFileDialog.ShowDialog() == DialogResult.OK )
                {
                    Properties.Settings.Default.cardSavePath = Path.GetDirectoryName( cardSaveFileDialog.FileName );
                    Properties.Settings.Default.Save();

                    try
                    {
                        using( FileStream fs = new FileStream( cardSaveFileDialog.FileName, FileMode.Create, FileAccess.Write ) )
                        {
                            ImageCodecInfo jgpEncoder = ImageCodecInfo.GetImageDecoders().First( x => x.FormatID == ImageFormat.Jpeg.Guid );

                            using( EncoderParameters encoderParameters = new EncoderParameters( 1 ) )
                            {
                                encoderParameters.Param[ 0 ] = new EncoderParameter( Encoder.Quality, 90L );

                                CardPainter.GetBitmap( actor, actorOutfit ).Save( fs, jgpEncoder, encoderParameters );
                                System.Diagnostics.Process.Start( cardSaveFileDialog.FileName );
                            }
                        }
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( "Das Bild konnte nicht gespeichert werden: " + ex.Message );
                    }
                }
            }
        }

        private void ActorManagerForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void toolStripTextBoxSearch_KeyDown( object sender, KeyEventArgs e )
        {
            if( DataGridViewHelper.HandleArrowUpDown( dataGridViewActors, e.KeyCode ) )
            {
                e.Handled = true;
            }
            else if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editActor( (Actor)dataGridViewActors.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewActors_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                e.Handled = true;
                editActor( (Actor)dataGridViewActors.CurrentRow.DataBoundItem );
            }
        }

        private void dataGridViewActors_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewActors );
        }
    }
}
