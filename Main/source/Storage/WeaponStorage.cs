using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public class WeaponStorage
    {
        private readonly JsonConverter[] Converters = { FactionStorage.JsonFactionHashSetConverter, ArchetypeStorage.JsonArchetypeHashSetConverter };

        private const string s_folderName = "Weapons";

        private readonly string s_path;

        private readonly Weapon m_nullWeapon = new Weapon()
        {
            ID = Guid.Empty,
            Active = false,
            Name = "--- GELÖSCHT ---",
            AdditionalPoints = 10000,
            Description = "Dies Waffe gibt es nicht (mehr)."
        };

        public WeaponStorage( string path, BackgroundWorker backgroundWorker )
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
                        Weapon weapon = JsonConvert.DeserializeObject<Weapon>( File.ReadAllText( file ), Converters );
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

            if( !m_weaponList.Contains( weapon ) )
            {
                m_weaponList.Add( weapon );
            }

            string filename = GetFilename( weapon );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( weapon, Storage.formatting, Converters ) );
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

        public Weapon Get( Guid id )
        {
            Weapon weapon = m_weaponList.Find( x => x.ID == id );

            return weapon ?? m_nullWeapon;
        }

        public static Weapon Create()
        {
            return new Weapon();
        }

        public void Delete( Weapon weapon )
        {
            if( null == weapon )
            {
                throw new ArgumentNullException( nameof( weapon ) );
            }

            weapon.Active = false;

            Save( weapon );
        }

        public IList<Weapon> Weapons => ( m_weaponList.AsReadOnly() );

        public IList<Weapon> WeaponsWithDamageEffect( DamageEffect damageEffect )
        {
            return m_weaponList.Where( x => x.DamageEffects.Any( y => y.ID == damageEffect.ID ) )
                               .OrderBy( x => x.Name )
                               .ToList()
                               .AsReadOnly();
        }

        private readonly List<Weapon> m_weaponList = new List<Weapon>();
    }
}
