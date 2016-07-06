using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public class EquipmentStorage
    {
        private EquipmentStorage() { }

        public static readonly EquipmentStorage Instance = new EquipmentStorage();

        private static readonly string s_path = Path.Combine( StorageSettings.DataPath, "Equipment" );
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
                        Equipment equipment = JsonConvert.DeserializeObject<Equipment>( File.ReadAllText( file ) );
#if DEBUG
                        if( equipment.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Ausrüstung '{equipment.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Equipment equipmentSearch = m_equipmentList.Find( x => x.ID == equipment.ID );
                        if( equipmentSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Ausrüstung '{equipment.Name}' hat die gleiche ID wie die Ausrüstung '{equipmentSearch.Name}'!" + Environment.NewLine + Environment.NewLine + equipment.ID );
                        }
#endif
                        m_equipmentList.Add( equipment );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Ausrüstungs-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Count() * 100 ), $"Ausrüstung {i}/{files.Count()}" );

                    i++;
                }
            };
        }

        public static void Save( Equipment equipment )
        {
            if( null == equipment )
            {
                throw new ArgumentNullException( nameof( equipment ) );
            }
            string filename = GetFilename( equipment );
            string filenameBackup = Path.ChangeExtension( filename, StorageSettings.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( equipment, StorageSettings.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private static string GetFilename( Equipment equipment )
        {
            return Path.ChangeExtension( Path.Combine( s_path, equipment.ID.ToString() ), StorageSettings.fileExtension );
        }

        private static string GetFilenameTrash( Equipment equipment )
        {
            return Path.ChangeExtension( Path.Combine( s_pathTrash, equipment.ID.ToString() ), StorageSettings.fileExtension );
        }

        public Equipment Get( Guid id )
        {
            Equipment equipment = m_equipmentList.Find( x => x.ID == id );

            if( null == equipment )
            {
                throw new InvalidOperationException( $"Die Ausrüstung mit der ID {id} konnte nicht gefunden werden!" );
            }

            return ( equipment );
        }

        public Equipment Create()
        {
            Equipment equipment = new Equipment();

            Save( equipment );

            m_equipmentList.Add( equipment );

            return ( equipment );
        }

        public void Delete( Equipment equipment )
        {
            if( null == equipment )
            {
                throw new ArgumentNullException( nameof( equipment ) );
            }

            m_equipmentList.Remove( equipment );

            if( !Directory.Exists( s_pathTrash ) )
            {
                Directory.CreateDirectory( s_pathTrash );
            }

            File.Move( GetFilename( equipment ), GetFilenameTrash( equipment ) );
        }

        public IList<Equipment> Equipments
        {
            get
            {
                return ( m_equipmentList.AsReadOnly() );
            }
        }

        private List<Equipment> m_equipmentList = new List<Equipment>();
    }
}
