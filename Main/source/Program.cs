using Mono.Options;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Universalis
{
    static class Program
    {
        [STAThread]
        static void Main( string[] args )
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
                    var p = new OptionSet()
                    {
                        { "d|deitymode", String.Empty, v => Options.DeityMode = v != null },
                    };

                    try
                    {
                        p.Parse( args );

                        try
                        {
                            if( Properties.Settings.Default.UpgradeSettings )
                            {
                                Properties.Settings.Default.Upgrade();
                                Properties.Settings.Default.UpgradeSettings = false;
                                Properties.Settings.Default.Save();
                            }
                        }
                        catch( ConfigurationException ex )
                        {
                            string filename = ( (ConfigurationException)ex.InnerException ).Filename;

                            File.Delete( filename );
                            Properties.Settings.Default.Reload();
                        }

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault( false );

                        Application.Run( new FormSplash() );
                    }
                    catch
                    {}

                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
