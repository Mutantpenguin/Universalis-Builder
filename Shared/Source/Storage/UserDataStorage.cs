using System;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public static class UserDataStorage
    {
        public static GroupStorage Group
        {
            get;
            private set;
        }

        private static bool setupAlreadyCompleted = false;

        public static void Setup( string universePath, Storage.BackgroundWorkerProvider backgroundWorkerProvider )
        {
            if( setupAlreadyCompleted )
            {
                MessageBox.Show( "User data was already loaded once!",
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

            Group = new GroupStorage( universePath, backgroundWorkerProvider() );

            setupAlreadyCompleted = true;
        }
    }
}
