using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public partial class ActorEditorForm : Form
    {
        public ActorEditorForm( Actor actor )
        {
            m_actorOriginal = actor;
            m_actorModified = new Actor( actor, withOutfitID: true );

            InitializeComponent();

            this.WindowState = Properties.Settings.Default.ActorEditorWindowState;

            this.Icon = Shared.Properties.Resources.icon;

            eTraitLevelBindingSource.DataSource = TraitLevel.ELevelList;

            archetypeBindingSource.DataSource = m_actorModified.Archetype;

            profileBindingSource.DataSource = m_actorModified.Archetype.Profile;
            attributesBindingSource.DataSource = m_actorModified.Archetype.Profile.Attributes;

            FillOutfitsComboBox();

            pictureBoxFactionIcon.Image = m_actorModified.Faction.Icon;
            toolTip.SetToolTip( pictureBoxFactionIcon, m_actorModified.Faction.Name );

            pictureBoxActorIcon.Image = m_actorModified.Icon;

            textBoxName.Text = m_actorModified.Name;

            textBoxDescription.Text = m_actorModified.Description;

            updateGridViewWeapons();
            updateGridViewEquipment();
            updateGridViewArmor();
            updateGridViewTraits();

            // we are now completely initialized. if we would set it ealier, the bitmap for the card would get created way too often
            m_initialized = true;

            updateFields();
        }

        private void FillOutfitsComboBox()
        {
            List<Actor.ActorOutfit> sortedActorOutfitsList = m_actorModified.ActorOutfitsList.OrderBy( x => x.Name ).ToList();

            outfitsBindingSource.DataSource = sortedActorOutfitsList;

            int index = sortedActorOutfitsList.FindIndex( a => a == CurrentOutfit() ) + 1;

            toolStripLabelOutfitCount.Text = index.ToString() + "/" + m_actorModified.ActorOutfitsList.Count.ToString();
        }

        private readonly bool m_initialized = false;

        private readonly Actor m_actorModified;
        private readonly Actor m_actorOriginal;

#region values changed

        private void textBoxName_TextChanged( object sender, EventArgs e )
        {
            m_actorModified.Name = textBoxName.Text;

            updateFields();
        }

        private void textBoxDescription_TextChanged( object sender, EventArgs e )
        {
            m_actorModified.Description = textBoxDescription.Text;
        }

#endregion values changed

#region update
        private void updateFields()
        {
            textBoxTragkraft.Text = $"{m_actorModified.ModMaxLoadCapacity( CurrentOutfit() ):n1} kg";

            textBoxBelastung.Text = $"{m_actorModified.LoadoutWeight( CurrentOutfit(), withSelfSustaining: false ):n1} kg";
            if( m_actorModified.LoadoutWeight( CurrentOutfit(), withSelfSustaining: false ) > m_actorModified.ModMaxLoadCapacity( CurrentOutfit() ) )
            {
                textBoxBelastung.BackColor = Color.OrangeRed;
            }
            else
            {
                textBoxBelastung.BackColor = SystemColors.Control;
            }

            textBoxBaseCost.Text = m_actorModified.Points( actorOutfit: null ).ToString();
            textBoxOutfitCost.Text = m_actorModified.Points( CurrentOutfit() ).ToString();

            if( m_initialized )
            {
                pictureBoxCard.Image = CardPainter.GetBitmap( m_actorModified, CurrentOutfit() );
            }
        }
#endregion update

#region buttons
        private void buttonSave_Click( object sender, EventArgs e )
        {
            if( checkValidity() )
            {
                if( MessageBox.Show( "Änderungen speichern?",
                                     String.Empty,
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Warning,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_actorOriginal.SetWithOutfitID( m_actorModified );
                    MasterDataStorage.Actor.Save( m_actorOriginal );
                }
            }
        }

        private void buttonImages_Click( object sender, EventArgs e )
        {
            using( OpenFileDialog iconFileDialog = new OpenFileDialog() )
            {
                iconFileDialog.InitialDirectory = Properties.Settings.Default.imageFilePath;

                if( iconFileDialog.ShowDialog(this ) == DialogResult.OK )
                {
                    Properties.Settings.Default.imageFilePath = Path.GetDirectoryName( iconFileDialog.FileName );
                    Properties.Settings.Default.Save();

                    Image img = ImageHelper.LoadImage( iconFileDialog.FileName );

                    if( null != img )
                    {
                        using( ImageSelectionForm imageSelectionForm = new ImageSelectionForm( "Bild auswählen", img, ImageHelper.imageSize ) )
                        {
                            if( imageSelectionForm.ShowDialog( this ) == DialogResult.OK )
                            {
                                m_actorModified.Img = new Bitmap( imageSelectionForm.Image );

                                SelectActorIcon();

                                updateFields();
                            }
                        }
                    }
                }
            }
        }
#endregion buttons

#region armor
        private void updateGridViewArmor()
        {
            armorBindingSource.DataSource = m_actorModified.Armor;

            dataGridViewArmor.ClearSelection();
        }

        private void toolStripButtonArmorAdd_Click( object sender, EventArgs e )
        {
            if( null != m_actorModified.Armor )
            {
                MessageBox.Show( "Es ist bereits eine Rüstung vorhanden!" );
            }
            else
            {
                using( AddArmorToActorForm addArmorToActor = new AddArmorToActorForm() )
                {
                    if( addArmorToActor.ShowDialog( this ) == DialogResult.OK )
                    {
                        if( addArmorToActor.SelectedArmor != null )
                        {
                            m_actorModified.Armor = addArmorToActor.SelectedArmor;

                            updateGridViewArmor();
                            updateFields();
                        }
                    }
                }
            }
        }

        private void toolStripButtonArmorRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewArmor.RowCount > 0 )
            {
                m_actorModified.Armor = null;

                updateGridViewArmor();
                updateFields();
            }
        }
#endregion armor

#region outfits
        private void toolStripButtonOutfitRename_Click( object sender, EventArgs e )
        {
            Actor.ActorOutfit actorOutfit = (Actor.ActorOutfit)comboBoxOutfits.SelectedItem;

            using( EnterNameForm enterNameForm = new EnterNameForm( actorOutfit.Name, emptyNameAllowed: false ) )
            {
                if( enterNameForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( m_actorModified.ActorOutfitsList.Exists( x => x.Name == enterNameForm.NewName ) )
                    {
                        MessageBox.Show( $"Ein Outfit mit dem Namen '{enterNameForm.NewName}' existiert bereits!" );
                    }
                    else
                    {
                        actorOutfit.Name = enterNameForm.NewName;

                        outfitsBindingSource.ResetBindings( false );

                        updateFields();
                    }
                }
            }
        }

        private void toolStripButtonOutfitAdd_Click( object sender, EventArgs e )
        {
            Actor.ActorOutfit actorOutfit = new Actor.ActorOutfit();

            using( EnterNameForm enterNameForm = new EnterNameForm( actorOutfit.Name, emptyNameAllowed: false ) )
            {
                if( enterNameForm.ShowDialog( this ) == DialogResult.OK )
                {
                    if( m_actorModified.ActorOutfitsList.Exists( x => x.Name == enterNameForm.NewName ) )
                    {
                        MessageBox.Show( $"Ein Outfit mit dem Namen '{enterNameForm.NewName}' existiert bereits!" );
                    }
                    else
                    {
                        actorOutfit.Name = enterNameForm.NewName;

                        m_actorModified.ActorOutfitsList.Add( actorOutfit );

                        FillOutfitsComboBox();

                        comboBoxOutfits.SelectedItem = actorOutfit;

                        updateGridViewWeapons();
                        updateGridViewEquipment();

                        updateFields();
                    }
                }
            }
        }

        private void toolStripButtonOutfitRemove_Click( object sender, EventArgs e )
        {
            if( m_actorModified.ActorOutfitsList.Count < 2 )
            {
                MessageBox.Show( "Dieses Outfit kann nicht gelöscht werden, da es das letzte ist!" );
            }
            else
            {
                Actor.ActorOutfit actorOutfit = (Actor.ActorOutfit)comboBoxOutfits.SelectedItem;

                if( MessageBox.Show( $"Wollen Sie wirklich das Outfit '{actorOutfit.Name}' löschen?",
                                     "Ausstattung löschen",
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Warning,
                                     MessageBoxDefaultButton.Button2 ) == DialogResult.OK )
                {
                    m_actorModified.ActorOutfitsList.Remove( actorOutfit );

                    FillOutfitsComboBox();

                    updateGridViewWeapons();
                    updateGridViewEquipment();

                    updateFields();
                }
            }
        }

        private Actor.ActorOutfit CurrentOutfit()
        {
            return ( (Actor.ActorOutfit)comboBoxOutfits.SelectedItem );
        }

        private void comboBoxOutfits_SelectionChangeCommitted( object sender, EventArgs e )
        {
            updateGridViewWeapons();
            updateGridViewEquipment();

            updateFields();
        }
#endregion outfits

#region weapons
        private void updateGridViewWeapons()
        {
            actorWeaponBindingSource.DataSource = CurrentOutfit().ActorWeaponsList.OrderBy( x => x.Weapon.WK )
                                                                                  .ThenBy( x => x.Weapon.RangeSort )
                                                                                  .ThenBy( x => x.Name )
                                                                                  .ToList();
            dataGridViewWeapons.ClearSelection();
        }

        private void toolStripButtonWeaponAdd_Click( object sender, EventArgs e )
        {
            using( AddWeaponToOutfitForm addWeaponToActor = new AddWeaponToOutfitForm() )
            {
                if( addWeaponToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addWeaponToActor.SelectedWeapons.Count > 0 )
                    {
                        foreach( Weapon weapon in addWeaponToActor.SelectedWeapons )
                        {
                            CurrentOutfit().ActorWeaponsList.Add( new Actor.ActorWeapon
                            {
                                Weapon = weapon
                            } );
                        }

                        updateGridViewWeapons();
                        updateFields();
                    }
                }
            }
        }

        private void toolStripButtonWeaponRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewWeapons.SelectedRows.Count > 0 )
            {
                Guid id = ( (Actor.ActorWeapon)( dataGridViewWeapons.Rows[ dataGridViewWeapons.SelectedRows[ 0 ].Index ].DataBoundItem ) ).ID;
                CurrentOutfit().ActorWeaponsList.RemoveAll( s => s.ID == id );

                updateGridViewWeapons();
                updateFields();
            }
        }
#endregion weapons

#region equipment
        private void updateGridViewEquipment()
        {
            actorEquipmentBindingSource.DataSource = CurrentOutfit().ActorEquipmentList.OrderBy( x => x.Name )
                                                                                       .ToList();

            dataGridViewEquipment.ClearSelection();
        }

        private void toolStripButtonEquipmentAdd_Click( object sender, EventArgs e )
        {
            using( AddEquipmentToOutfitForm addEquipmentToActor = new AddEquipmentToOutfitForm() )
            {
                if( addEquipmentToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addEquipmentToActor.SelectedEquipment.Count > 0 )
                    {
                        foreach( Equipment equipment in addEquipmentToActor.SelectedEquipment )
                        {
                            CurrentOutfit().ActorEquipmentList.Add( new Actor.ActorEquipment
                            {
                                Equipment = equipment
                            } );
                        }

                        updateGridViewEquipment();
                        updateFields();
                    }
                }
            }
        }

        private void toolStripButtonEquipmentRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewEquipment.SelectedRows.Count > 0 )
            {
                Guid id = ( (Actor.ActorEquipment)( dataGridViewEquipment.Rows[ dataGridViewEquipment.SelectedRows[ 0 ].Index ].DataBoundItem ) ).ID;
                CurrentOutfit().ActorEquipmentList.RemoveAll( s => s.ID == id );

                updateGridViewEquipment();
                updateFields();
            }
        }
#endregion equipment

#region traits
        private void updateGridViewTraits()
        {
            actorTraitBindingSource.DataSource = m_actorModified.ActorTraitsList.OrderBy( x => x.Name )
                                                                                .ToList();

            dataGridViewTraits.ClearSelection();
        }

        private void dataGridViewTraits_CellBeginEdit( object sender, DataGridViewCellCancelEventArgs e )
        {
            if( e.ColumnIndex == levelDataGridViewComboBoxColumn.Index )
            {
                DataGridViewRow row = dataGridViewTraits.Rows[ e.RowIndex ];

                Actor.ActorTrait actorTrait = (Actor.ActorTrait)row.DataBoundItem;

                ( row.Cells[ levelDataGridViewComboBoxColumn.Index ] as DataGridViewComboBoxCell ).DataSource = actorTrait.Trait.TraitLevelList.Select( x => x.Level )
                                                                                                                                               .Distinct()
                                                                                                                                               .ToList();
            }
        }

        private void dataGridViewTraits_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( dataGridViewTraits.CurrentCell.ColumnIndex == levelDataGridViewComboBoxColumn.Index )
            {
                dataGridViewTraits.CommitEdit( DataGridViewDataErrorContexts.Commit );

                updateFields();
            }
        }

        private void toolStripButtonTraitAdd_Click( object sender, EventArgs e )
        {
            List<Trait> traitList = m_actorModified.ActorTraitsList.Select( x => x.Trait )
                                                                   .Distinct()
                                                                   .ToList();

            using( AddTraitToActorForm addTraitToActor = new AddTraitToActorForm( traitList ) )
            {
                if( addTraitToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addTraitToActor.SelectedTraits.Count > 0 )
                    {
                        foreach( Trait trait in addTraitToActor.SelectedTraits )
                        {
                            m_actorModified.ActorTraitsList.Add( new Actor.ActorTrait
                            {
                                Trait = trait,
                                Level = trait.MinLevel
                            } );
                        }

                        updateGridViewTraits();
                        updateFields();
                    }
                }
            }
        }

        private void toolStripButtonTraitRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewTraits.SelectedRows.Count > 0 )
            {
                Guid id = ( (Actor.ActorTrait)( dataGridViewTraits.Rows[ dataGridViewTraits.SelectedRows[ 0 ].Index ].DataBoundItem ) ).ID;
                m_actorModified.ActorTraitsList.Remove( m_actorModified.ActorTraitsList.Single( s => s.ID == id ) );

                updateGridViewTraits();
                updateFields();
            }
        }
#endregion traits

#region events
        private void ActorEditorForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Properties.Settings.Default.ActorEditorWindowState = this.WindowState;
            Properties.Settings.Default.Save();

            if( !m_actorModified.Equals( m_actorOriginal ) )
            {
                switch( MessageBox.Show( "Änderungen speichern?", String.Empty, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3 ) )
                {
                    case DialogResult.Yes:
                        if( checkValidity() )
                        {
                            m_actorOriginal.SetWithOutfitID( m_actorModified );
                            MasterDataStorage.Actor.Save( m_actorOriginal );
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
#endregion events

        private bool checkValidity()
        {
            string caption = "Fehlende oder falsche Angaben";

            if( String.IsNullOrEmpty( m_actorModified.Name ) )
            {
                MessageBox.Show( "Name ist leer, bitte angeben!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( null == m_actorModified.Faction )
            {
                MessageBox.Show( "Fraktion ist leer, bitte angeben!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            Actor.ActorOutfit currentOutfit = CurrentOutfit();

            if( m_actorModified.ModSpeed( currentOutfit ) < 0 )
            {
                MessageBox.Show( "Geschwindigkeit darf nicht negativ sein!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( ( m_actorModified.ModAGI( currentOutfit ) < 0 )
                ||
                ( m_actorModified.ModNK( currentOutfit ) < 0 )
                ||
                ( m_actorModified.ModFK( currentOutfit ) < 0 )
                ||
                ( m_actorModified.ModKO( currentOutfit ) < 0 )
                ||
                ( m_actorModified.ModWN( currentOutfit ) < 0 )
                ||
                ( m_actorModified.ModEH( currentOutfit ) < 0 ) )
            {
                MessageBox.Show( "Attribute dürfen nicht negativ sein!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( ( m_actorModified.ModSpeed( CurrentOutfit() ) <= 0 ) && ( EMovementType.Stationär != m_actorModified.Archetype.Profile.MovementType ) )
            {
                MessageBox.Show( "Geschwindigkeit ist gleich 0, die Bewegungsart ist aber nicht stationär. Speichern wird abgebrochen.",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            return ( true );
        }

        private void dataGridViewTraits_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Actor.ActorTrait actorTrait = (Actor.ActorTrait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = actorTrait.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( actorTrait.Trait.RulesWithLevel( actorTrait.Level ) );
            }
        }

        private void dataGridViewWeapons_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Actor.ActorWeapon actorWeapon = (Actor.ActorWeapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem;

                e.ToolTipText = actorWeapon.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( actorWeapon.Weapon.Rules );
            }
        }

        private void dataGridViewArmor_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Armor armor = (Armor)dataGridViewArmor.Rows[ e.RowIndex ].DataBoundItem;

                string text = armor.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( armor.Rules );

                if( null != armor.ProfileModifier )
                {
                    string profileModifierString = armor.ProfileModifier.ToString();

                    if( !String.IsNullOrEmpty( profileModifierString ) )
                    {
                        text += Environment.NewLine + profileModifierString;
                    }
                }

                e.ToolTipText = text;
            }
        }

        private void dataGridViewEquipment_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Actor.ActorEquipment actorEquipment = (Actor.ActorEquipment)dataGridViewEquipment.Rows[ e.RowIndex ].DataBoundItem;

                string text = actorEquipment.Equipment.Name + ":";

                string equipmentString = actorEquipment.Equipment.ToString();

                if( !String.IsNullOrEmpty( equipmentString ) )
                {
                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( equipmentString );
                }

                e.ToolTipText = text;
            }
        }

        private void pictureBoxActorIcon_DoubleClick( object sender, EventArgs e )
        {
            SelectActorIcon();
        }

        private void SelectActorIcon()
        {
            using( ImageSelectionForm imageSelectionForm = new ImageSelectionForm( "Icon auswählen", m_actorModified.Img, ImageHelper.iconSize ) )
            {
                if( imageSelectionForm.ShowDialog() == DialogResult.OK )
                {
                    pictureBoxActorIcon.Image = imageSelectionForm.Image;
                    m_actorModified.Icon = new Bitmap( imageSelectionForm.Image );
                }
            }
        }

        private void buttonBack_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void ActorEditorForm_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Escape )
            {
                this.Close();
            }
        }

        private void buttonRefresh_Click( object sender, EventArgs e )
        {
            updateFields();
        }

        private void toolStripButtonChangeArchetype_Click( object sender, EventArgs e )
        {
            using( ArchetypeSelectionForm archetypeSelectionForm = new ArchetypeSelectionForm( m_actorModified.Faction ) )
            {
                if( archetypeSelectionForm.ShowDialog( this ) == DialogResult.OK )
                {
                    m_actorModified.Archetype = archetypeSelectionForm.SelectedArchetype;

                    archetypeBindingSource.DataSource = m_actorModified.Archetype;

                    updateFields();
                }
            }
        }
    }
}
