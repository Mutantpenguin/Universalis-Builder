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
            using( var mutex = new Mutex( false, "6df075ee-027d-401c-b6f7-5791d03920d3" ) )
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

                    UniverseSelectionForm.FormToOpen formToOpen = ( string universePath, Universe universe ) => new FactionOverviewForm( universePath, universe );

                    Application.Run( new FormSplash( formToOpen ) );

                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
