using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public class WeaponStorage
    {
        private static WeaponStorage s_instance = new WeaponStorage();

        private WeaponStorage() { }

        public static WeaponStorage Instance
        {
            get
            {
                return( s_instance );
            }
        }

        private static string s_path = Path.Combine( StorageSettings.DataPath, "Weapons" );

        public void LoadAll( BackgroundWorker backgroundWorker )
        {
            if( !Directory.Exists( s_path ) )
            {
                Directory.CreateDirectory( s_path );
            }

            backgroundWorker.ReportProgress( 0, "Waffen" );

            backgroundWorker.DoWork += ( sender, e ) =>
            {
                string[] files = Directory.GetFiles( s_path, StorageSettings.filePattern, SearchOption.TopDirectoryOnly );

                int i = 1;

                foreach( string file in files )
                {
                    try
                    {
                        Weapon weapon = JsonConvert.DeserializeObject<Weapon>( File.ReadAllText( file ) );
#if DEBUG
                        Weapon weaponSearch = m_weaponList.Find( x => x.ID == weapon.ID );
                        if( weaponSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, das Modell '{weapon.Name}' hat die gleiche ID wie das Modell '{weaponSearch.Name}'!" + Environment.NewLine + Environment.NewLine + weapon.ID );
                        }
#endif
                        m_weaponList.Add( weapon );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Count() * 100 ), $"Waffe {i}/{files.Count()} wird geladen..." );

                    i++;
                }
            };
        }

        public static void Save( Weapon weapon )
        {
            if( null == weapon )
            {
                throw new ArgumentNullException( nameof( weapon ) );
            }

            string filename = Path.ChangeExtension( Path.Combine( s_path, weapon.ID.ToString() ), StorageSettings.fileExtension );
            string filenameBackup = Path.ChangeExtension( filename, StorageSettings.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( weapon, StorageSettings.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
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

        public static void Delete( Weapon weapon )
        {
            if( null == weapon )
            {
                throw new ArgumentNullException( nameof( weapon ) );
            }

            weapon.Active = false;
            Save( weapon );
        }

        public IList<Weapon> Weapons
        {
            get
            {
                return ( m_weaponList.AsReadOnly() );
            }
        }

        private List<Weapon> m_weaponList = new List<Weapon>();
    }
}
