using Newtonsoft.Json;
using System.IO;

namespace Tesserakt
{
    class StorageSettings
    {
        private StorageSettings() { }

        public const Formatting formatting = Formatting.Indented;

        public static string DataPath
        {
            get
            {
                return ( Path.Combine( Directory.GetCurrentDirectory(), "Data" ) );
            }
        }

        public const string fileExtension = "json";

        public const string backupFileExtension = "json.bak";

        public static string filePattern
        {
            get
            {
                return ( Path.ChangeExtension( "*.", StorageSettings.fileExtension ) );
            }
        }
    }
}
