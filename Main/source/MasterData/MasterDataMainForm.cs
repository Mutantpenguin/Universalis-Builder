using System;
using System.Windows.Forms;

namespace Universalis
{
    public partial class MasterDataMainForm : Form
    {
        public MasterDataMainForm( Universe universe )
        {
            InitializeComponent();

            this.CenterToParent();

            this.Text = universe.NameWithVersion() + " Stammdaten";

            this.Icon = Properties.Resources.icon;
        }

        WeaponManagerForm weaponManager = null;
        ArmorManagerForm armorManager = null;
        EquipmentManagerForm equipmentManager = null;
        TraitsManagerForm traitsManager = null;
        FactionManagerForm factionManager = null;
        ArchetypeManagerForm archetypeManager = null;
        DamageEffectManagerForm damageEffectManager = null;
        GroupTraitManagerForm groupTraitManager = null;
        DisciplineManagerForm disciplineManager = null;

        private void buttonWeapons_Click( object sender, EventArgs e )
        {
            weaponManager = new WeaponManagerForm();

            weaponManager.FormClosed += delegate
            {
                buttonWeapons.Enabled = true;
                weaponManager.Dispose();
                weaponManager = null;
            };

            buttonWeapons.Enabled = false;

            weaponManager.Show( this );
        }

        private void buttonArmor_Click( object sender, EventArgs e )
        {
            armorManager = new ArmorManagerForm();

            armorManager.FormClosed += delegate
            {
                buttonArmor.Enabled = true;
                armorManager.Dispose();
                armorManager = null;
            };

            buttonArmor.Enabled = false;

            armorManager.Show( this );
        }

        private void buttonEquipment_Click( object sender, EventArgs e )
        {
            equipmentManager = new EquipmentManagerForm();

            equipmentManager.FormClosed += delegate
            {
                buttonEquipment.Enabled = true;
                equipmentManager.Dispose();
                equipmentManager = null;
            };

            buttonEquipment.Enabled = false;

            equipmentManager.Show( this );
        }

        private void buttonTraits_Click( object sender, EventArgs e )
        {
            traitsManager = new TraitsManagerForm();

            traitsManager.FormClosed += delegate
            {
                buttonTraits.Enabled = true;
                traitsManager.Dispose();
                traitsManager = null;
            };

            buttonTraits.Enabled = false;

            traitsManager.Show( this );
        }

        private void buttonFactions_Click( object sender, EventArgs e )
        {
            factionManager = new FactionManagerForm();

            factionManager.FormClosed += delegate
            {
                buttonFactions.Enabled = true;
                factionManager.Dispose();
                factionManager = null;
            };

            buttonFactions.Enabled = false;

            factionManager.Show( this );
        }

        private void buttonArchetypes_Click( object sender, EventArgs e )
        {
            archetypeManager = new ArchetypeManagerForm();

            archetypeManager.FormClosed += delegate
            {
                buttonArchetypes.Enabled = true;
                archetypeManager.Dispose();
                archetypeManager = null;
            };

            buttonArchetypes.Enabled = false;

            archetypeManager.Show(this);
        }

        private void buttonDamageEffects_Click( object sender, EventArgs e )
        {
            damageEffectManager = new DamageEffectManagerForm();

            damageEffectManager.FormClosed += delegate
            {
                buttonDamageEffects.Enabled = true;
                damageEffectManager.Dispose();
                damageEffectManager = null;
            };

            buttonDamageEffects.Enabled = false;

            damageEffectManager.Show( this );
        }

        private void buttonGroupTraits_Click( object sender, EventArgs e )
        {
            groupTraitManager = new GroupTraitManagerForm();

            groupTraitManager.FormClosed += delegate
            {
                buttonGroupTraits.Enabled = true;
                groupTraitManager.Dispose();
                groupTraitManager = null;
            };

            buttonGroupTraits.Enabled = false;

            groupTraitManager.Show( this );
        }

        private void buttonDisciplines_Click( object sender, EventArgs e )
        {
            disciplineManager = new DisciplineManagerForm();

            disciplineManager.FormClosed += delegate
            {
                buttonDisciplines.Enabled = true;
                disciplineManager.Dispose();
                disciplineManager = null;
            };

            buttonDisciplines.Enabled = false;

            disciplineManager.Show( this );
        }

        private void MasterDataMainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if( weaponManager != null
                ||
                armorManager != null
                ||
                equipmentManager != null
                ||
                archetypeManager != null
                ||
                traitsManager != null
                ||
                factionManager != null
                ||
                damageEffectManager != null
                ||
                groupTraitManager != null
                ||
                disciplineManager != null )
            {
                MessageBox.Show( "Bitte zuerst alle Fenster schließen!",
                                 String.Empty,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Stop );
                e.Cancel = true;
            }
        }

        private void buttonExit_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}
