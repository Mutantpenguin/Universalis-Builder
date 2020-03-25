using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public class WeaponStorage
    {
        private const string s_folderName = "Weapons";

        private readonly string s_path;
        private readonly string s_pathTrash;

        public WeaponStorage( string path, BackgroundWorker backgroundWorker )
        {
            s_path = Path.Combine( path, Storage.dataSubfolderName, s_folderName );
            s_pathTrash = Path.Combine( path, Storage.trashSubfolderName, s_folderName );

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
                        Weapon weapon = JsonConvert.DeserializeObject<Weapon>( File.ReadAllText( file ) );
#if DEBUG
                        if( weapon.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Waffe '{weapon.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Weapon weaponSearch = m_weaponList.Find( x => x.ID == weapon.ID );
                        if( weaponSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Waffe '{weapon.Name}' hat die gleiche ID wie die Waffe '{weaponSearch.Name}'!" + Environment.NewLine + Environment.NewLine + weapon.ID );
                        }
#endif
                        m_weaponList.Add( weapon );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Waffen-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Length * 100 ), $"Waffe {i}/{files.Length}" );

                    i++;
                }
            };
        }

        public void Save( Weapon weapon )
        {
            if( null == weapon )
            {
                throw new ArgumentNullException( nameof( weapon ) );
            }
            string filename = GetFilename( weapon );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( weapon, Storage.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( Weapon weapon )
        {
            return Path.ChangeExtension( Path.Combine( s_path, weapon.ID.ToString() ), Storage.fileExtension );
        }

        private string GetFilenameTrash( Weapon weapon )
        {
            return Path.ChangeExtension( Path.Combine( s_pathTrash, weapon.ID.ToString() ), Storage.fileExtension );
        }

        public Weapon Get( Guid id )
        {
            Weapon weapon = m_weaponList.Find( x => x.ID == id );

            if( null == weapon )
            {
                throw new InvalidOperationException( $"Die Waffe mit der ID {id} konnte nicht gefunden werden!" );
            }

            return ( weapon );
        }

        public Weapon Create()
        {
            Weapon weapon = new Weapon();

            Save( weapon );

            m_weaponList.Add( weapon );

            return ( weapon );
        }

        public void Delete( Weapon weapon )
        {
            if( null == weapon )
            {
                throw new ArgumentNullException( nameof( weapon ) );
            }

            m_weaponList.Remove( weapon );

            if( !Directory.Exists( s_pathTrash ) )
            {
                Directory.CreateDirectory( s_pathTrash );
            }

            File.Move( GetFilename( weapon ), GetFilenameTrash( weapon ) );
        }

        public IList<Weapon> Weapons => ( m_weaponList.AsReadOnly() );

        private readonly List<Weapon> m_weaponList = new List<Weapon>();
    }
}
