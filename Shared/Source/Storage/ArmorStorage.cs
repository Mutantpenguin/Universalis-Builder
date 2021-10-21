using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public class ArmorStorage
    {
        private const string s_folderName = "Armor";

        private readonly string s_path;

        private readonly Armor m_nullArmor = new Armor()
        {
            ID = Guid.Empty,
            Active = false,
            Name = "--- GELÖSCHT ---",
            AdditionalPoints = 10000,
            Description = "Diese Rüstung gibt es nicht (mehr)."
        };

        public ArmorStorage( string path, BackgroundWorker backgroundWorker )
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

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Length * 100 ), $"Rüstung {i}/{files.Length}" );

                    i++;
                }
            };
        }

        public void Save( Armor armor )
        {
            if( null == armor )
            {
                throw new ArgumentNullException( nameof( armor ) );
            }

            if( !m_armorList.Contains( armor ) )
            {
                m_armorList.Add( armor );
            }

            string filename = GetFilename( armor );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( armor, Storage.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( Armor armor )
        {
            return Path.ChangeExtension( Path.Combine( s_path, armor.ID.ToString() ), Storage.fileExtension );
        }
        public Armor Get( Guid id )
        {
            Armor armor = m_armorList.Find( x => x.ID == id );

            return ( armor ?? m_nullArmor );
        }

        public static Armor Create()
        {
            return ( new Armor() );
        }

        public void Delete( Armor armor )
        {
            if( null == armor )
            {
                throw new ArgumentNullException( nameof( armor ) );
            }

            armor.Active = false;

            Save( armor );
        }

        public IList<Armor> Armors => ( m_armorList.AsReadOnly() );

        public IList<Armor> ArmorsWithDamageEffect( DamageEffect damageEffect )
        {
            return ( m_armorList.Where( x => x.DamageEffectSet.Any( y => y.ID == damageEffect.ID ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        private readonly List<Armor> m_armorList = new List<Armor>();
    }
}
