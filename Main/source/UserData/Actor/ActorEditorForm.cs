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
        public ActorEditorForm( Faction faction, Actor actor )
        {
            m_faction = faction;

            m_actorOriginal = actor;
            m_actorModified = new Actor( actor );

            InitializeComponent();

            if( !actor.Active )
            {
                panelMain.Enabled = false;
                buttonSave.Enabled = false;
            }

            this.WindowState = Properties.Settings.Default.ActorEditorWindowState;

            this.Icon = Properties.Resources.icon;

            pictureBoxActorIcon.AllowDrop = true;

            textBoxArchetypeText.Text = m_actorModified.Archetype.Summary();

            traitLevelBindingSource.DataSource = Enumerable.Range( 1, 10 )
                                                           .Select( i => (uint)i )
                                                           .ToList();

            disciplineLevelBindingSource.DataSource = Enumerable.Range( 1, 10 )
                                                                .Select( i => (uint)i )
                                                                .ToList();

            pictureBoxActorIcon.Image = m_actorModified.Icon;

            textBoxName.Text = m_actorModified.Name;

            textBoxBiography.Text = m_actorModified.Biography;

            toolStripLabelArchetypeName.Text = m_actorModified.Archetype.Name + " - " + m_actorModified.Archetype.Type.ToString();

            if( !m_actorModified.Active )
            {
                textBoxInactiveReason.Text = m_actorModified.InactiveReason;
                toolStripLabelInactiveType.Text = m_actorModified.InactiveType.ToString();
            }
            else
            {
                var rowStyle = tableLayoutPanelLeft.RowStyles[ 2 ];

                rowStyle.SizeType = SizeType.Absolute;
                rowStyle.Height = 0;
            }

            toolStripButtonArmorSelect.Checked = ( m_actorModified.Armor != null );

            updateGridViewWeapons();
            updateGridViewEquipment();
            updateGridViewArmor();
            updateGridViewTraits();
            updateGridViewDisciplines();

            // we are now completely initialized. if we would set it ealier, the bitmap for the card would get created way too often
            m_initialized = true;

            updateFields();
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

        private void DataGridViewTraits_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewTraits );
        }

        private void DataGridViewDisciplines_CellFormatting( object sender, DataGridViewCellFormattingEventArgs e )
        {
            DataGridViewHelper.MemberPropertyFormatter( e, dataGridViewDisciplines );
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

        private readonly Faction m_faction;
        private readonly Actor m_actorModified;
        private readonly Actor m_actorOriginal;
        private bool m_dragndrop = false;

        #region values changed

        private void textBoxName_TextChanged( object sender, EventArgs e )
        {
            m_actorModified.Name = textBoxName.Text;

            updateFields();
        }

        private void textBoxDescription_TextChanged( object sender, EventArgs e )
        {
            m_actorModified.Biography = textBoxBiography.Text;
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
                pictureBoxCard.Image?.Dispose();
                pictureBoxCard.Image = ActorCardPainter.GetBitmap( m_faction, m_actorModified );
            }


            // base values
            var profile = m_actorModified.Archetype.Profile;
            var attributes = profile.Attributes;

            textBoxBaseAGI.Text = attributes.AGI.ToString();
            textBoxBaseHTH.Text = attributes.HTH.ToString();
            textBoxBaseLRC.Text = attributes.LRC.ToString();
            textBoxBasePHY.Text = attributes.PHY.ToString();
            textBoxBaseAWA.Text = attributes.AWA.ToString();
            textBoxBaseDET.Text = attributes.DET.ToString();
            textBoxBaseSpeed.Text = profile.Speed.ToString();
            textBoxBaseHP.Text = profile.HitPoints.ToString();
            textBoxBaseCS.Text = "50%";

            // modifications
            var currentProfileModifier = m_actorModified.CurrentProfileModifier();
            var currentAttributeModifier = currentProfileModifier.AttributeModifier;

            textBoxModAGI.Text = currentAttributeModifier.AGIString;
            textBoxModHTH.Text = currentAttributeModifier.HTHString;
            textBoxModLRC.Text = currentAttributeModifier.LRCString;
            textBoxModPHY.Text = currentAttributeModifier.PHYString;
            textBoxModAWA.Text = currentAttributeModifier.AWAString;
            textBoxModDET.Text = currentAttributeModifier.DETString;
            textBoxModSpeed.Text = currentProfileModifier.SpeedString;
            textBoxModHP.Text = currentProfileModifier.HitPointsString;
            textBoxModCS.Text = currentProfileModifier.CritThresholdString;

            // final values
            textBoxResultAGI.Text = m_actorModified.ModAGI().ToString();
            textBoxResultHTH.Text = m_actorModified.ModHTH().ToString();
            textBoxResultLRC.Text = m_actorModified.ModLRC().ToString();
            textBoxResultPHY.Text = m_actorModified.ModPHY().ToString();
            textBoxResultAWA.Text = m_actorModified.ModAWA().ToString();
            textBoxResultDET.Text = m_actorModified.ModDET().ToString();
            textBoxResultSpeed.Text = m_actorModified.ModSpeed().ToString();
            textBoxResultHP.Text = m_actorModified.ModHitPoints().ToString();
            textBoxResultCS.Text = m_actorModified.ModCritThreshold().ToString() + "%";

            var (valid, reason) = m_actorModified.IsValid();

            if( !valid )
            {
                pictureBoxInvalidActor.Visible = true;
                this.toolTip.SetToolTip( pictureBoxInvalidActor, reason );
            }
            else
            {
                pictureBoxInvalidActor.Visible = false;
                this.toolTip.SetToolTip( pictureBoxInvalidActor, String.Empty );
            }
        }
#endregion update

#region buttons
        private void buttonSave_Click( object sender, EventArgs e )
        {
            if( checkValidity() )
            {
                m_actorOriginal.Set( m_actorModified );
            }
        }

        private void buttonSelectImages_Click( object sender, EventArgs e )
        {
            using (OpenFileDialog iconFileDialog = new OpenFileDialog())
            {
                iconFileDialog.InitialDirectory = Properties.Settings.Default.imageFilePath;

                if (iconFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    Properties.Settings.Default.imageFilePath = Path.GetDirectoryName(iconFileDialog.FileName);
                    Properties.Settings.Default.Save();

                    var img = ImageHelper.LoadImage(iconFileDialog.FileName);

                    SelectImages(img);
                }
            }
        }

        private void buttonWebcam_Click(object sender, EventArgs e)
        {
            using (var actorWebcamImageForm = new ActorWebcamImageForm())
            {
                if (actorWebcamImageForm.ShowDialog(this) == DialogResult.OK)
                {
                    using (Image img = actorWebcamImageForm.Image)
                    {
                        SelectImages(img);
                    }
                }
            }
        }

        private void SelectImages( Image img )
        {
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
        #endregion buttons

        #region armor
        private void updateGridViewArmor()
        {
            armorBindingSource.DataSource = m_actorModified.Armor;

            dataGridViewArmor.ClearSelection();
        }

        private void toolStripButtonArmorSelect_Click( object sender, EventArgs e )
        {
            if(null != m_actorModified.Armor)
            {
                m_actorModified.Armor = null;

                updateGridViewArmor();
                updateFields();
            }
            else
            {
                using( AddArmorToActorForm addArmorToActor = new AddArmorToActorForm(m_faction, m_actorModified.Archetype ) )
                {
                    if( addArmorToActor.ShowDialog( this ) == DialogResult.OK && addArmorToActor.SelectedArmor != null )
                    {
                        m_actorModified.Armor = addArmorToActor.SelectedArmor;

                        updateGridViewArmor();
                        updateFields();
                    }
                    else
                    {
                        toolStripButtonArmorSelect.Checked = false;
                    }
                }
            }
        }

        private void toolStripButtonArmorSelect_CheckedChanged(object sender, EventArgs e)
        {
            if( toolStripButtonArmorSelect.Checked )
            {
                toolStripButtonArmorSelect.Image = Properties.Resources.trash;
            }
            else
            {
                toolStripButtonArmorSelect.Image = Properties.Resources.plus;
            }
        }
#endregion armor

#region weapons
        private void updateGridViewWeapons()
        {
            // if we don't do this, CellFormatting for the Datagrid will throw an exception because it's still working with the old content
            actorWeaponBindingSource.DataSource = null;
            actorWeaponBindingSource.DataSource = m_actorModified.Weapons.OrderBy( x => x.Weapon.Class )
                                                                            .ThenBy( x => x.Weapon.RangeSort )
                                                                            .ThenBy( x => x.Weapon.Name )
                                                                            .ToList();
            dataGridViewWeapons.ClearSelection();
        }

        private void toolStripButtonWeaponAdd_Click( object sender, EventArgs e )
        {
            using( AddWeaponToActorForm addWeaponToActor = new AddWeaponToActorForm(m_faction, m_actorModified.Archetype ) )
            {
                if( addWeaponToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addWeaponToActor.SelectedWeapons.Count > 0 )
                    {
                        foreach( Weapon weapon in addWeaponToActor.SelectedWeapons )
                        {
                            m_actorModified.Weapons.Add( new Actor.ActorWeapon
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
                var weapon = (Actor.ActorWeapon)dataGridViewWeapons.Rows[ dataGridViewWeapons.SelectedRows[ 0 ].Index ].DataBoundItem;
                m_actorModified.Weapons.Remove( weapon );

                updateGridViewWeapons();
                updateFields();
            }
        }
#endregion weapons

#region equipment
        private void updateGridViewEquipment()
        {
            // if we don't do this, CellFormatting for the Datagrid will throw an exception because it's still working with the old content
            actorEquipmentBindingSource.DataSource = null;
            actorEquipmentBindingSource.DataSource = m_actorModified.Equipments.OrderBy( x => x.Equipment.Name )
                                                                                  .ToList();

            dataGridViewEquipment.ClearSelection();
        }

        private void toolStripButtonEquipmentAdd_Click( object sender, EventArgs e )
        {
            using( AddEquipmentToActorForm addEquipmentToActor = new AddEquipmentToActorForm(m_faction, m_actorModified.Archetype ) )
            {
                if( addEquipmentToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addEquipmentToActor.SelectedEquipment.Count > 0 )
                    {
                        foreach( Equipment equipment in addEquipmentToActor.SelectedEquipment )
                        {
                            m_actorModified.Equipments.Add( new Actor.ActorEquipment
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
                var equipment = (Actor.ActorEquipment)dataGridViewEquipment.Rows[ dataGridViewEquipment.SelectedRows[ 0 ].Index ].DataBoundItem;
                m_actorModified.Equipments.Remove( equipment );

                updateGridViewEquipment();
                updateFields();
            }
        }
#endregion equipment

#region traits
        private void updateGridViewTraits()
        {
            // if we don't do this, CellFormatting for the Datagrid will throw an exception because it's still working with the old content
            actorTraitBindingSource.DataSource = null;
            actorTraitBindingSource.DataSource = m_actorModified.Traits.OrderBy( x => x.Trait.Name )
                                                                          .ToList();

            dataGridViewTraits.ClearSelection();
        }

        private void toolStripButtonTraitAdd_Click( object sender, EventArgs e )
        {
            List<Trait> traitList = m_actorModified.Traits.Select( x => x.Trait )
                                                             .Distinct()
                                                             .ToList();

            using( AddTraitToActorForm addTraitToActor = new AddTraitToActorForm(m_faction, m_actorModified.Archetype, traitList ) )
            {
                if( addTraitToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addTraitToActor.SelectedTraits.Count > 0 )
                    {
                        foreach( Trait trait in addTraitToActor.SelectedTraits )
                        {
                            m_actorModified.Traits.Add( new Actor.ActorTrait()
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
                var trait = (Actor.ActorTrait)dataGridViewTraits.Rows[ dataGridViewTraits.SelectedRows[ 0 ].Index ].DataBoundItem;
                m_actorModified.Traits.Remove( trait );

                updateGridViewTraits();
                updateFields();
            }
        }
#endregion traits

#region disciplines
        private void updateGridViewDisciplines()
        {
            // if we don't do this, CellFormatting for the Datagrid will throw an exception because it's still working with the old content
            actorDisciplineBindingSource.DataSource = null;
            actorDisciplineBindingSource.DataSource = m_actorModified.Disciplines.OrderBy( x => x.Discipline.Name )
                                                                                 .ToList();

            dataGridViewDisciplines.ClearSelection();
        }

        private void toolStripButtonDisciplineAdd_Click( object sender, EventArgs e )
        {
            List<Discipline> disciplineList = m_actorModified.Disciplines.Select( x => x.Discipline )
                                                                         .Distinct()
                                                                         .ToList();

            using( AddDisciplineToActorForm addDisciplineToActor = new AddDisciplineToActorForm(m_faction, m_actorModified.Archetype, disciplineList ) )
            {
                if( addDisciplineToActor.ShowDialog( this ) == DialogResult.OK )
                {
                    if( addDisciplineToActor.SelectedDisciplines.Count > 0 )
                    {
                        foreach( Discipline discipline in addDisciplineToActor.SelectedDisciplines )
                        {
                            m_actorModified.Disciplines.Add( new Actor.ActorDiscipline()
                            {
                                Discipline = discipline
                            } );
                        }

                        updateGridViewDisciplines();
                        updateFields();
                    }
                }
            }
        }

        private void toolStripButtonDisciplineRemove_Click( object sender, EventArgs e )
        {
            if( dataGridViewDisciplines.SelectedRows.Count > 0 )
            {
                var discipline = (Actor.ActorDiscipline)dataGridViewDisciplines.Rows[ dataGridViewDisciplines.SelectedRows[ 0 ].Index ].DataBoundItem;
                m_actorModified.Disciplines.Remove( discipline );

                updateGridViewDisciplines();
                updateFields();
            }
        }
#endregion disciplines

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
                return false;
            }

            if( m_actorModified.ModSpeed() < 0 )
            {
                MessageBox.Show( "Geschwindigkeit darf nicht negativ sein!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return false;
            }

            if( m_actorModified.ModHitPoints() <= 0 )
            {
                MessageBox.Show( "Trefferpunkte dürfen nicht 0 oder negativ sein!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return false;
            }

            if( m_actorModified.ModCritThreshold() < 0 )
            {
                MessageBox.Show( "Die kritische Schwelle darf nicht kleiner als 0 sein!",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return false;
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
                return false;
            }

            if( ( m_actorModified.ModSpeed() <= 0 ) && ( Archetype.EMovementType.Stationär != m_actorModified.Archetype.MovementType ) )
            {
                MessageBox.Show( "Geschwindigkeit ist gleich 0, die Bewegungsart ist aber nicht stationär. Speichern wird abgebrochen.",
                                 caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                return false;
            }

            return true;
        }

        private void dataGridViewTraits_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Actor.ActorTrait actorTrait = (Actor.ActorTrait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem;

                string traitSummary = actorTrait.Trait.Summary( actorTrait.Level );

                if( !String.IsNullOrEmpty( traitSummary ) )
                {
                    string text = actorTrait.Trait.FormattedName( actorTrait.Level ) + ":";

                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( traitSummary );

                    e.ToolTipText = text;
                }
                else
                {
                    e.ToolTipText = String.Empty;
                }
            }
        }

        private void dataGridViewDisciplines_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                if( e.ColumnIndex != showPowersDataGridViewImageColumn.Index )
                {
                    Actor.ActorDiscipline actorDiscipline = (Actor.ActorDiscipline)dataGridViewDisciplines.Rows[e.RowIndex].DataBoundItem;

                    string disciplineSummary = actorDiscipline.Discipline.Summary();

                    if( !String.IsNullOrEmpty( disciplineSummary ) )
                    {
                        string text = actorDiscipline.Discipline.FormattedName( actorDiscipline.Level ) + ":";

                        text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( disciplineSummary );

                        e.ToolTipText = text;
                    }
                    else
                    {
                        e.ToolTipText = String.Empty;
                    }
                }
            }
        }

        private void dataGridViewWeapons_CellToolTipTextNeeded( object sender, DataGridViewCellToolTipTextNeededEventArgs e )
        {
            if( e.RowIndex > -1 )
            {
                Weapon weapon = ((Actor.ActorWeapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem).Weapon;

                string weaponSummary = weapon.Summary();

                if( !String.IsNullOrEmpty( weaponSummary ) )
                {
                    string text = weapon.Name + ":";

                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( weaponSummary );

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

                string armorSummary = armor.Summary();

                if( !String.IsNullOrEmpty( armorSummary ) )
                {
                    string text = armor.Name + ":";

                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( armorSummary );

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

                string equipmentSummary = equipment.Summary();

                if( !String.IsNullOrEmpty( equipmentSummary ) )
                {
                    string text = equipment.Name + ":";

                    text += Environment.NewLine + ToolTipHelper.FormatMaxWidth( equipmentSummary );

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

        private void dataGridViewTraits_RowPrePaint( object sender, DataGridViewRowPrePaintEventArgs e )
        {
            var trait = ((Actor.ActorTrait)dataGridViewTraits.Rows[ e.RowIndex ].DataBoundItem).Trait;

            if( !trait.Active )
            {
                dataGridViewTraits.Rows[ e.RowIndex ].DefaultCellStyle.BackColor = Color.Firebrick;
            }
        }

        private void dataGridViewDisciplines_RowPrePaint( object sender, DataGridViewRowPrePaintEventArgs e )
        {
            var discipline = ( (Actor.ActorDiscipline)dataGridViewDisciplines.Rows[ e.RowIndex ].DataBoundItem ).Discipline;

            if( !discipline.Active )
            {
                dataGridViewDisciplines.Rows[ e.RowIndex ].DefaultCellStyle.BackColor = Color.Firebrick;
            }
        }

        private void dataGridViewArmor_RowPrePaint( object sender, DataGridViewRowPrePaintEventArgs e )
        {
            var armor = (Armor)dataGridViewArmor.Rows[ e.RowIndex ].DataBoundItem;

            if( !armor.Active )
            {
                dataGridViewArmor.Rows[ e.RowIndex ].DefaultCellStyle.BackColor = Color.Firebrick;
            }
        }

        private void dataGridViewWeapons_RowPrePaint( object sender, DataGridViewRowPrePaintEventArgs e )
        {
            var weapon = ((Actor.ActorWeapon)dataGridViewWeapons.Rows[ e.RowIndex ].DataBoundItem).Weapon;

            if( !weapon.Active )
            {
                dataGridViewWeapons.Rows[ e.RowIndex ].DefaultCellStyle.BackColor = Color.Firebrick;
            }
        }

        private void dataGridViewEquipment_RowPrePaint( object sender, DataGridViewRowPrePaintEventArgs e )
        {
            var equipment = ((Actor.ActorEquipment)dataGridViewEquipment.Rows[ e.RowIndex ].DataBoundItem ).Equipment;

            if( !equipment.Active )
            {
                dataGridViewEquipment.Rows[ e.RowIndex ].DefaultCellStyle.BackColor = Color.Firebrick;
            }
        }

        private void ActorEditorForm_Shown( object sender, EventArgs e )
        {
            dataGridViewTraits.ClearSelection();
            dataGridViewDisciplines.ClearSelection();
            dataGridViewArmor.ClearSelection();
            dataGridViewWeapons.ClearSelection();
            dataGridViewEquipment.ClearSelection();
        }

        private void dataGridViewTraits_CellBeginEdit( object sender, DataGridViewCellCancelEventArgs e )
        {
            if( e.ColumnIndex == traitLevelDataGridViewComboBoxColumn.Index )
            {
                DataGridViewRow row = dataGridViewTraits.Rows[ e.RowIndex ];

                Trait trait = ( (Actor.ActorTrait)row.DataBoundItem ).Trait;

                ( row.Cells[ traitLevelDataGridViewComboBoxColumn.Index ] as DataGridViewComboBoxCell ).DataSource = Enumerable.Range( 1, (int)trait.MaxLevel )
                                                                                                                               .Select( i => (uint)i )
                                                                                                                               .ToList();
            }
        }

        private void dataGridViewTraits_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( dataGridViewTraits.CurrentCell.ColumnIndex == traitLevelDataGridViewComboBoxColumn.Index )
            {
                dataGridViewTraits.CommitEdit( DataGridViewDataErrorContexts.Commit );

                updateFields();
            }
        }

        private void dataGridViewDisciplines_CellBeginEdit( object sender, DataGridViewCellCancelEventArgs e )
        {
            if( e.ColumnIndex == disciplineLevelDataGridViewComboBoxColumn.Index )
            {
                DataGridViewRow row = dataGridViewDisciplines.Rows[ e.RowIndex ];

                Discipline discipline = ( (Actor.ActorDiscipline)row.DataBoundItem ).Discipline;

                ( row.Cells[ disciplineLevelDataGridViewComboBoxColumn.Index ] as DataGridViewComboBoxCell ).DataSource = Enumerable.Range( 1, (int)discipline.MaxLevel )
                                                                                                                                    .Select( i => (uint)i )
                                                                                                                                    .ToList();
            }
        }

        private void dataGridViewDisciplines_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( dataGridViewDisciplines.CurrentCell.ColumnIndex == disciplineLevelDataGridViewComboBoxColumn.Index )
            {
                dataGridViewDisciplines.CommitEdit( DataGridViewDataErrorContexts.Commit );

                updateFields();
            }
        }

        private void ActorEditorForm_DragEnter(object sender, DragEventArgs e)
        {
            m_dragndrop = true;
            pictureBoxActorIcon.Refresh();

            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ActorEditorForm_DragLeave(object sender, EventArgs e)
        {
            m_dragndrop = false;
            pictureBoxActorIcon.Refresh();
        }

        private void ActorEditorForm_DragDrop(object sender, DragEventArgs e)
        {
            m_dragndrop = false;
            pictureBoxActorIcon.Refresh();
        }

        private void pictureBoxActorIcon_Paint( object sender, PaintEventArgs e )
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

        private void pictureBoxActorIcon_DragDrop( object sender, DragEventArgs e )
        {
            m_dragndrop = false;
            pictureBoxActorIcon.Refresh();

            string[] s = (string[])e.Data.GetData( DataFormats.FileDrop, false );

            if( s.Length == 1 )
            {
                using( var img = ImageHelper.LoadImage( s[0] ) )
                {
                    SelectImages( img );
                }
            }
        }

        private void pictureBoxActorIcon_DragEnter( object sender, DragEventArgs e )
        {
            m_dragndrop = true;
            pictureBoxActorIcon.Refresh();

            if( e.Data.GetDataPresent( DataFormats.FileDrop ) )
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridViewDisciplines_CellClick( object sender, DataGridViewCellEventArgs e )
        {
            if( -1 != e.RowIndex )
            {
                if( e.ColumnIndex == showPowersDataGridViewImageColumn.Index )
                {
                    var actorDiscipline = (Actor.ActorDiscipline)dataGridViewDisciplines.Rows[e.RowIndex].DataBoundItem;

                    var discipline = actorDiscipline.Discipline;

                    using( var disciplineOverviewForm = new DisciplineOverviewForm( discipline ) )
                    {
                        disciplineOverviewForm.ShowDialog( this );
                    }
                }
            }
        }
    }
}
