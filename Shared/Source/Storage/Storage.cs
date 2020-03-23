using Newtonsoft.Json;
using System.IO;

namespace Universalis
{
    public static class Storage
    {
        public const Formatting formatting = Formatting.Indented;

        public static readonly string DataPath = Path.Combine( Directory.GetCurrentDirectory(), "Data" );

        public static readonly string TrashPath = Path.Combine( Directory.GetCurrentDirectory(), "Trash" );

        public const string fileExtension = "json";

        public const string backupFileExtension = "json.bak";

        public const string trashSubfolderName = "Trash";

        public static readonly string filePattern = Path.ChangeExtension( "*.", Storage.fileExtension );

        public const int delayLoadingMs = 0;

        public static void Setup()
        {
            if( !Directory.Exists( DataPath ) )
            {
                Directory.CreateDirectory( DataPath );
            }

            File.SetAttributes( DataPath, FileAttributes.Hidden );

            if( !Directory.Exists( TrashPath ) )
            {
                Directory.CreateDirectory( TrashPath );
            }

            File.SetAttributes( TrashPath, FileAttributes.Hidden );
        }
    }
}
