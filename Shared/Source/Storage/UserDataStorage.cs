using System;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public static class UserDataStorage
    {
        private static readonly string GroupsSubFolder = "Groups";

        private static readonly string GroupsPath = Path.Combine( UniversalisSettings.UserAppFolder, GroupsSubFolder );

        public static ActorStorage Actor
        {
            get;
            private set;
        }

        public static GroupStorage Group
        {
            get;
            private set;
        }

        private static bool setupAlreadyCompleted = false;

        public static void Setup( Guid universeId, Storage.BackgroundWorkerProvider backgroundWorkerProvider )
        {
            if( !Directory.Exists( GroupsPath ) )
            {
                Directory.CreateDirectory( GroupsPath );
            }

            String universeGroupsPath = Path.Combine( GroupsPath, universeId.ToString() );

            if( !Directory.Exists( universeGroupsPath ) )
            {
                Directory.CreateDirectory( universeGroupsPath );
            }

            if( setupAlreadyCompleted )
            {
                MessageBox.Show( "User data was already loaded once!",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );

                throw new InvalidOperationException();
            }

            var universeTrashPath = Path.Combine( universeGroupsPath, Storage.trashSubfolderName );

            if( !Directory.Exists( universeTrashPath ) )
            {
                Directory.CreateDirectory( universeTrashPath );
            }

            File.SetAttributes( universeTrashPath, FileAttributes.Hidden );

            Actor = new ActorStorage( GroupsPath, backgroundWorkerProvider() );

            Group = new GroupStorage( universeGroupsPath, backgroundWorkerProvider() );

            setupAlreadyCompleted = true;
        }
    }
}
