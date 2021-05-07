using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
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
            using( var mutex = new Mutex( false, "8de494a8-5c74-4caf-95eb-3426d719c2b5" ) )
            {
                if( !mutex.WaitOne( TimeSpan.Zero ) )
                {
                    MessageBox.Show( $"Das Programm '{Assembly.GetExecutingAssembly().GetName().Name}' darf nur einmal zur gleichen Zeit laufen!",
                                     String.Empty,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Stop );

                    Application.Exit();
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault( false );

                    UniverseSelectionForm.FormToOpen formToOpen = ( string universePath, Universe universe ) => new MasterDataMainForm( universePath, universe );

                    Application.Run( new FormSplash( formToOpen ) );

                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
