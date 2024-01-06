using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;

namespace Universalis
{
    public static class Storage
    {
        public const Formatting formatting = Formatting.Indented;

        public const string dataSubfolderName = "Data";

        public const string fileExtension = "json";

        public const string backupFileExtension = "json.bak";

        public static readonly string filePattern = Path.ChangeExtension( "*.", Storage.fileExtension );

#if DEBUG
        public const int delayLoadingMs = 0;
#endif

        public delegate BackgroundWorker BackgroundWorkerProvider();
    }
}
