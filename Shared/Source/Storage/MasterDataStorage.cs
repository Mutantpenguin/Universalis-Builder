using System;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public static class MasterDataStorage
    {
        public static FactionStorage Faction
        {
            get;
            private set;
        }

        public static ArchetypeStorage Archetype
        {
            get;
            private set;
        }

        public static TraitStorage Trait
        {
            get;
            private set;
        }

        public static ArmorStorage Armor
        {
            get;
            private set;
        }

        public static WeaponStorage Weapon
        {
            get;
            private set;
        }

        public static EquipmentStorage Equipment
        {
            get;
            private set;
        }

        public static ActorStorage Actor
        {
            get;
            private set;
        }

        private static bool setupAlreadyCompleted = false;

        public static void Setup( string universePath, Storage.BackgroundWorkerProvider backgroundWorkerProvider )
        {
            if( setupAlreadyCompleted )
            {
                MessageBox.Show( "Master data was already loaded once!",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );

                throw new InvalidOperationException();
            }

            var universeTrashPath = Path.Combine( universePath, Storage.trashSubfolderName );

            if( !Directory.Exists( universeTrashPath ) )
            {
                Directory.CreateDirectory( universeTrashPath );
            }

            File.SetAttributes( universeTrashPath, FileAttributes.Hidden );

            Faction = new FactionStorage( universePath, backgroundWorkerProvider() );
            Archetype = new ArchetypeStorage( universePath, backgroundWorkerProvider() );
            Trait = new TraitStorage( universePath, backgroundWorkerProvider() );
            Armor = new ArmorStorage( universePath, backgroundWorkerProvider() );
            Weapon = new WeaponStorage( universePath, backgroundWorkerProvider() );
            Equipment = new EquipmentStorage( universePath, backgroundWorkerProvider() );

            // always load actors after the other stuff was loaded
            Actor = new ActorStorage( universePath, backgroundWorkerProvider() );

            setupAlreadyCompleted = true;
        }
    }
}
