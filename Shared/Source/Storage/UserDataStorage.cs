using System;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public static class UserDataStorage
    {
        private static readonly string UserDataSubFolder = "UserData";

        private static readonly string UserDataPath = Path.Combine( UniversalisSettings.UserAppFolder, UserDataSubFolder );

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
            if( !Directory.Exists( UserDataPath ) )
            {
                Directory.CreateDirectory( UserDataPath );
            }

            String universeUserDataPath = Path.Combine( UserDataPath, universeId.ToString() );

            if( !Directory.Exists( universeUserDataPath ) )
            {
                Directory.CreateDirectory( universeUserDataPath );
            }

            if( setupAlreadyCompleted )
            {
                MessageBox.Show( "User data was already loaded once!",
                                 "Error",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error );

                throw new InvalidOperationException();
            }

            Actor = new ActorStorage( universeUserDataPath, backgroundWorkerProvider() );

            Group = new GroupStorage( universeUserDataPath, backgroundWorkerProvider() );

            setupAlreadyCompleted = true;
        }
    }
}
