using System;
using System.Windows.Forms;

namespace Tesserakt
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
                    Application.Run( new FactionOverviewForm() );
                }
            }
            catch( TLock.TLockNotSuccessfullException )
            {
                Application.Exit();
            }
        }
    }
}
