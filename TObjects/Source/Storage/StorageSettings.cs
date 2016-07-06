using Newtonsoft.Json;
using System.IO;

namespace Tesserakt
{
    static class StorageSettings
    {
        public const Formatting formatting = Formatting.Indented;

        public static readonly string DataPath = Path.Combine( Directory.GetCurrentDirectory(), "Data" );

        public const string fileExtension = "json";

        public const string backupFileExtension = "json.bak";

        public const string trashSubfolderName = "Trash";

        public static readonly string filePattern = Path.ChangeExtension( "*.", StorageSettings.fileExtension );

        public const int delayLoadingMs = 0;
    }
}
