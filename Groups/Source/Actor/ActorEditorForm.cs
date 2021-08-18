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
            m_actorModified = new Actor( actor );

            InitializeComponent();

            this.WindowState = Properties.Settings.Default.ActorEditorWindowState;

            this.Icon = Shared.Properties.Resources.icon;

            archetypeBindingSource.DataSource = m_actorModified.Archetype;

            profileBindingSource.DataSource = m_actorModified.Archetype.Profile;
            attributesBindingSource.DataSource = m_actorModified.Archetype.Profile.Attributes;

            pictureBoxFactionIcon.Image = m_actorModified.Archetype.Faction.Icon;
            toolTip.SetToolTip( pictureBoxFactionIcon, m_actorModified.Archetype.Faction.Name );

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

        private void DataGridViewTraits_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewTraits );
        }

        private void dataGridViewWeapons_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewWeapons );
        }

        private void dataGridViewEquipment_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewEquipment );
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
            textBoxTragkraft.Text = $"{m_actorModified.ModMaxLoadCapacity():n1} kg";

            textBoxBelastung.Text = $"{m_actorModified.LoadoutWeight(withSelfSustaining: false ):n1} kg";
            if( m_actorModified.LoadoutWeight( withSelfSustaining: false ) > m_actorModified.ModMaxLoadCapacity() )
            {
                textBoxBelastung.BackColor = Color.OrangeRed;
            }
            else
            {
                textBoxBelastung.BackColor = SystemColors.Control;
            }

            textBoxPointCost.Text = m_actorModified.Points.ToString();

            if( m_initialized )
            {
                pictureBoxCard.Image = CardPainter.GetBitmap( m_actorModified );
            }
        }
#endregion update

#region buttons
        private void buttonSave_Click( object sender, EventArgs e )
        {
            if( checkValidity() )
            {
                m_actorOriginal.Set( m_actorModified );
                UserDataStorage.Actor.Save( m_actorOriginal );
            }
        }

        private void buttonImages_Click( object sender, EventArgs e )
        {
            SelectImages();
        }

        private void SelectImages()
        {
            using( OpenFileDialog iconFileDialog = new OpenFileDialog() )
            {
                iconFileDialog.InitialDirectory = Properties.Settings.Default.imageFilePath;

                if( iconFileDialog.ShowDialog( this ) == DialogResult.OK )
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

#region weapons
        private void updateGridViewWeapons()
        {
            actorWeaponBindingSource.DataSource = m_actorModified.ActorWeaponsList.OrderBy( x => x.Weapon.Class )
                                                                                  .ThenBy( x => x.Weapon.RangeSort )
                                                                                  .ThenBy( x => x.Weapon.Name )
                                                                                  .ToList();
            dataGridViewWeapons.ClearSelection();
        }

        private void toolStripButtonWeaponAdd_Click( object sender, EventArgs e )
        {
            using( AddWeaponToActorForm addWeaponToActor = new AddWeaponToActorForm() )
            {
                if( addWeaponToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addWeaponToActor.SelectedWeapons.Count > 0 )
                    {
                        foreach( Weapon weapon in addWeaponToActor.SelectedWeapons )
                        {
                            m_actorModified.ActorWeaponsList.Add( new Actor.ActorWeapon
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
                m_actorModified.ActorWeaponsList.RemoveAll( s => s.ID == id );

                updateGridViewWeapons();
                updateFields();
            }
        }
#endregion weapons

#region equipment
        private void updateGridViewEquipment()
        {
            actorEquipmentBindingSource.DataSource = m_actorModified.ActorEquipmentList.OrderBy( x => x.Equipment.Name )
                                                                                       .ToList();

            dataGridViewEquipment.ClearSelection();
        }

        private void toolStripButtonEquipmentAdd_Click( object sender, EventArgs e )
        {
            using( AddEquipmentToActorForm addEquipmentToActor = new AddEquipmentToActorForm() )
            {
                if( addEquipmentToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addEquipmentToActor.SelectedEquipment.Count > 0 )
                    {
                        foreach( Equipment equipment in addEquipmentToActor.SelectedEquipment )
                        {
                            m_actorModified.ActorEquipmentList.Add( new Actor.ActorEquipment
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
                m_actorModified.ActorEquipmentList.RemoveAll( s => s.ID == id );

                updateGridViewEquipment();
                updateFields();
            }
        }
#endregion equipment

#region traits
        private void updateGridViewTraits()
        {
            actorTraitBindingSource.DataSource = m_actorModified.ActorTraitsList.OrderBy( x => x.Trait.Name )
                                                                                .ToList();

            dataGridViewTraits.ClearSelection();
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
                                Trait = trait
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
                            m_actorOriginal.Set( m_actorModified );
                            UserDataStorage.Actor.Save( m_actorOriginal );
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

            if( m_actorModified.ModSpeed() < 0 )
            {
                MessageBox.Show( "Geschwindigkeit darf nicht negativ sein!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( m_actorModified.ModHitPoints() <= 0 )
            {
                MessageBox.Show( "Trefferpunkte dürfen nicht 0 oder negativ sein!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( ( m_actorModified.ModAGI() < 0 )
                ||
                ( m_actorModified.ModHTH() < 0 )
                ||
                ( m_actorModified.ModLRC() < 0 )
                ||
                ( m_actorModified.ModPHY() < 0 )
                ||
                ( m_actorModified.ModAWA() < 0 )
                ||
                ( m_actorModified.ModDET() < 0 ) )
            {
                MessageBox.Show( "Attribute dürfen nicht negativ sein!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return ( false );
            }

            if( ( m_actorModified.ModSpeed() <= 0 ) && ( EMovementType.Stationär != m_actorModified.Archetype.Profile.MovementType ) )
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

                e.ToolTipText = actorTrait.Trait.Name + ":" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( actorTrait.Trait.Rules );
            }
        }

        private void dataGridViewWeapons_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Weapon weapon = ((Actor.ActorWeapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem).Weapon;


                string weaponString = weapon.ToString();

                if( !String.IsNullOrEmpty( weaponString ) )
                {
                    string text = weapon.Name + ":";

                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( weaponString );

                    e.ToolTipText = text;
                }
                else
                {
                    e.ToolTipText = String.Empty;
                }
            }
        }

        private void dataGridViewArmor_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Armor armor = (Armor)dataGridViewArmor.Rows[ e.RowIndex ].DataBoundItem;

                string armorString = armor.ToString();

                if( !String.IsNullOrEmpty( armorString ) )
                {
                    string text = armor.Name + ":";

                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( armorString );

                    e.ToolTipText = text;
                }
                else
                {
                    e.ToolTipText = String.Empty;
                }                
            }
        }

        private void dataGridViewEquipment_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Equipment equipment = ( (Actor.ActorEquipment)dataGridViewEquipment.Rows[ e.RowIndex ].DataBoundItem ).Equipment;

                string equipmentString = equipment.ToString();

                if( !String.IsNullOrEmpty( equipmentString ) )
                {
                    string text = equipment.Name + ":";

                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( equipmentString );

                    e.ToolTipText = text;
                }
                else
                {
                    e.ToolTipText = String.Empty;
                }
            }
        }

        private void pictureBoxActorIcon_DoubleClick( object sender, EventArgs e )
        {
            SelectActorIcon();
        }

        private void SelectActorIcon()
        {
            if( m_actorModified.Img == null )
            {
                MessageBox.Show( "Sie müssen zunächst ein Bild auswählen bevor Sie ein Icon daraus extrahieren können." );

                SelectImages();
            }
            else
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
    }
}
