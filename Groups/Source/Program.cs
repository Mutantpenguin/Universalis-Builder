using System;
using System.Drawing;
using System.Windows.Forms;

namespace Universalis
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using( TLock tlock = new TLock() )
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault( false );

                    UniverseSelectionForm.FormToOpen formToOpen = ( Image universeImage, string universePath, string universeName ) => new FactionOverviewForm( universeImage, universePath, universeName );

                    Application.Run( new UniverseSelectionForm( formToOpen ) );
                }
            }
            catch( TLock.TLockNotSuccessfullException )
            {
                Application.Exit();
            }
        }
    }
}
