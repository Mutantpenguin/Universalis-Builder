using System.IO;

namespace Universalis
{
    public static class UserDataStorage
    {
        public static GroupStorage Group
        {
            get;
            private set;
        }

        public static void Setup( string universePath, Storage.BackgroundWorkerProvider backgroundWorkerProvider )
        {
            var universeTrashPath = Path.Combine( universePath, Storage.trashSubfolderName );

            if( !Directory.Exists( universeTrashPath ) )
            {
                Directory.CreateDirectory( universeTrashPath );
            }

            File.SetAttributes( universeTrashPath, FileAttributes.Hidden );

            Group = new GroupStorage( universePath, backgroundWorkerProvider() );
        }
    }
}
