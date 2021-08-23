using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public class EquipmentStorage
    {
        private const string s_folderName = "Equipment";

        private readonly string s_path;

        public EquipmentStorage( string path, BackgroundWorker backgroundWorker )
        {
            s_path = Path.Combine( path, Storage.dataSubfolderName, s_folderName );

            if( !Directory.Exists( s_path ) )
            {
                Directory.CreateDirectory( s_path );
            }

            backgroundWorker.DoWork += ( sender, e ) =>
            {
                string[] files = Directory.GetFiles( s_path, Storage.filePattern, SearchOption.TopDirectoryOnly );

                int i = 1;

                foreach( string file in files )
                {
#if DEBUG
                    System.Threading.Thread.Sleep( Storage.delayLoadingMs );
#endif

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

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Length * 100 ), $"Ausrüstung {i}/{files.Length}" );

                    i++;
                }
            };
        }

        public void Save( Equipment equipment )
        {
            if( null == equipment )
            {
                throw new ArgumentNullException( nameof( equipment ) );
            }

            if( !m_equipmentList.Contains( equipment ) )
            {
                m_equipmentList.Add( equipment );
            }

            string filename = GetFilename( equipment );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( equipment, Storage.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( Equipment equipment )
        {
            return Path.ChangeExtension( Path.Combine( s_path, equipment.ID.ToString() ), Storage.fileExtension );
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

        public static Equipment Create()
        {
            return ( new Equipment() );
        }

        public void Delete( Equipment equipment )
        {
            if( null == equipment )
            {
                throw new ArgumentNullException( nameof( equipment ) );
            }

            equipment.Active = false;

            Save( equipment );
        }

        public IList<Equipment> Equipments => ( m_equipmentList.AsReadOnly() );

        private readonly List<Equipment> m_equipmentList = new List<Equipment>();
    }
}
