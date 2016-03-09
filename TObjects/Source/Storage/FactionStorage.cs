using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public class FactionStorage
    {
        private FactionStorage() { }

        public static readonly FactionStorage Instance = new FactionStorage();

        private static readonly string s_path = Path.Combine( StorageSettings.DataPath, "Factions" );

        public void LoadAll( BackgroundWorker backgroundWorker )
        {
            if( !Directory.Exists( s_path ) )
            {
                Directory.CreateDirectory( s_path );
            }

            backgroundWorker.DoWork += ( sender, e ) =>
            {
                string[] files = Directory.GetFiles( s_path, StorageSettings.filePattern, SearchOption.TopDirectoryOnly );

                int i = 1;

                foreach( string file in files )
                {
                    System.Threading.Thread.Sleep( StorageSettings.delayLoadingMs );

                    try
                    {
                        Faction faction = JsonConvert.DeserializeObject<Faction>( File.ReadAllText( file ) );
#if DEBUG
                        if( faction.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Fraktion '{faction.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Faction factionSearch = m_factionList.Find( x => x.ID == faction.ID );
                        if( factionSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Fraktion '{faction.Name}' hat die gleiche ID wie die Fraktion '{factionSearch.Name}'!" + Environment.NewLine + Environment.NewLine + faction.ID );
                        }
#endif
                        m_factionList.Add( faction );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Fraktions-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Count() * 100 ), $"Fraktion {i}/{files.Count()}" );

                    i++;
                }
            };
        }

        public static void Save( Faction faction )
        {
            if( null == faction )
            {
                throw new ArgumentNullException( nameof( faction ) );
            }

            string filename = Path.ChangeExtension( Path.Combine( s_path, faction.ID.ToString() ), StorageSettings.fileExtension );
            string filenameBackup = Path.ChangeExtension( filename, StorageSettings.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( faction, StorageSettings.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        public Faction Get( Guid id )
        {
            Faction faction = m_factionList.Find( x => x.ID == id );

            if( null == faction )
            {
                throw new InvalidOperationException( $"Die Fraktion mit der ID {id} konnte nicht gefunden werden!" );
            }

            return( faction );
        }

        public Faction Create()
        {
            Faction faction = new Faction();

            Save( faction );

            m_factionList.Add( faction );
        
            return ( faction );
        }

        public static void Delete( Faction faction )
        {
            if( null == faction )
            {
                throw new ArgumentNullException( nameof( faction ) );
            }

            faction.Active = false;
            Save( faction );
        }

        public IList<Faction> Factions
        {
            get
            {
                return ( m_factionList.AsReadOnly() );
            }
        }

        private List<Faction> m_factionList = new List<Faction>();
    }
}