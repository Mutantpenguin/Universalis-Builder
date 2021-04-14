using System.IO;

namespace Universalis
{
    public class RepositoryHelper
    {
        public static void Delete( string path )
        {
            // can't delete a git repo just like that since some files are protected so we need to reset their file attributes first
            var directory = new DirectoryInfo( path ) { Attributes = FileAttributes.Normal };

            foreach( var info in directory.GetFileSystemInfos( "*", SearchOption.AllDirectories ) )
            {
                info.Attributes = FileAttributes.Normal;
            }

            directory.Delete( true );
        }
    }
}
