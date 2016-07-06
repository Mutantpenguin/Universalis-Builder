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
        private ArmorStorage() { }

        public static readonly ArmorStorage Instance = new ArmorStorage();

        private static readonly string s_path = Path.Combine( StorageSettings.DataPath, "Armor" );
        private static readonly string s_pathTrash = Path.Combine( s_path, StorageSettings.trashSubfolderName );

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

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Count() * 100 ), $"Rüstung {i}/{files.Count()}" );

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
            string filename = GetFilename( armor );
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

        private static string GetFilename( Armor armor )
        {
            return Path.ChangeExtension( Path.Combine( s_path, armor.ID.ToString() ), StorageSettings.fileExtension );
        }

        private static string GetFilenameTrash( Armor armor )
        {
            return Path.ChangeExtension( Path.Combine( s_pathTrash, armor.ID.ToString() ), StorageSettings.fileExtension );
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

        public void Delete( Armor armor )
        {
            if( null == armor )
            {
                throw new ArgumentNullException( nameof( armor ) );
            }

            m_armorList.Remove( armor );

            if( !Directory.Exists( s_pathTrash ) )
            {
                Directory.CreateDirectory( s_pathTrash );
            }

            File.Move( GetFilename( armor ), GetFilenameTrash( armor ) );
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
