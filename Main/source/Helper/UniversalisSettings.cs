using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public class UniversalisSettings
    {
        public static string UserAppFolder
        {
            get
            {
                // get folder without version
                var userAppDirectory = Directory.GetParent( Application.UserAppDataPath );

                return userAppDirectory.ToString();
            }
        }
    }
}
