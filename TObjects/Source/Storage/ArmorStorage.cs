using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public class ArmorStorage
    {
        private static ArmorStorage s_instance = new ArmorStorage();

        private ArmorStorage() { }

        public static ArmorStorage Instance
        {
            get
            {
                return( s_instance );
            }
        }

        private static string s_path = Path.Combine( StorageSettings.DataPath, "Armor" );

        public void LoadAll( BackgroundWorker backgroundWorker )
        {
            if( !Directory.Exists( s_path ) )
            {
                Directory.CreateDirectory( s_path );
            }

            backgroundWorker.ReportProgress( 0, "Rüstungen" );

            backgroundWorker.DoWork += ( sender, e ) =>
            {
                string[] files = Directory.GetFiles( s_path, StorageSettings.filePattern, SearchOption.TopDirectoryOnly );

                int i = 1;

                foreach( string file in files )
                {
                    try
                    {
                        Armor armor = JsonConvert.DeserializeObject<Armor>( File.ReadAllText( file ) );
#if DEBUG
                        if( armor.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Rüstung '{armor.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Armor armorSearch = m_armorList.Find( x => x.ID == armor.ID );
                        if( armorSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Rüstung '{armor.Name}' hat die gleiche ID wie die Rüstung '{armorSearch.Name}'!" + Environment.NewLine + Environment.NewLine + armor.ID );
                        }
#endif
                        m_armorList.Add( armor );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Rüstungs-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Count() * 100 ), $"Rüstung {i}/{files.Count()} wird geladen..." );

                    i++;
                }
            };
        }

        public static void Save( Armor armor )
        {
            if( null == armor )
            {
                throw new ArgumentNullException( nameof( armor ) );
            }

            string filename = Path.ChangeExtension( Path.Combine( s_path, armor.ID.ToString() ), StorageSettings.fileExtension );
            string filenameBackup = Path.ChangeExtension( filename, StorageSettings.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( armor, StorageSettings.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        public Armor Get( Guid id )
        {
            Armor armor = m_armorList.Find( x => x.ID == id );

            if( null == armor )
            {
                throw new InvalidOperationException( $"Die Rüstung mit der ID {id} konnte nicht gefunden werden!" );
            }

            return ( armor );
        }

        public Armor Create()
        {
            Armor armor = new Armor();

            Save( armor );

            m_armorList.Add( armor );

            return ( armor );
        }

        public static void Delete( Armor armor )
        {
            if( null == armor )
            {
                throw new ArgumentNullException( nameof( armor ) );
            }

            armor.Active = false;
            Save( armor );
        }

        public IList<Armor> Armors
        {
            get
            {
                return ( m_armorList.AsReadOnly() );
            }
        }

        private List<Armor> m_armorList = new List<Armor>();
    }
}
