using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public class TraitStorage
    {
        private TraitStorage() { }

        public static readonly TraitStorage Instance = new TraitStorage();

        private const string s_folderName = "Traits";

        private static readonly string s_path = Path.Combine( Storage.DataPath, s_folderName );
        private static readonly string s_pathTrash = Path.Combine( Storage.TrashPath, s_folderName );

        public void LoadAll( BackgroundWorker backgroundWorker )
        {
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
                    System.Threading.Thread.Sleep( Storage.delayLoadingMs );

                    try
                    {
                        Trait trait = JsonConvert.DeserializeObject<Trait>( File.ReadAllText( file ) );
#if DEBUG
                        if( trait.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Eigenschaft '{trait.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Trait traitSearch = m_traitsList.Find( x => x.ID == trait.ID );
                        if( traitSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Eigenschaft '{trait.Name}' hat die gleiche ID wie die Eigenschaft '{traitSearch.Name}'!" + Environment.NewLine + Environment.NewLine + trait.ID );
                        }
#endif
                        m_traitsList.Add( trait );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Eigenschaft-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Length * 100 ), $"Eigenschaft {i}/{files.Length}" );

                    i++;
                }
            };
        }

        public static void Save( Trait trait )
        {
            if( null == trait )
            {
                throw new ArgumentNullException( nameof( trait ) );
            }
            string filename = GetFilename( trait );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( trait, Storage.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private static string GetFilename( Trait trait )
        {
            return Path.ChangeExtension( Path.Combine( s_path, trait.ID.ToString() ), Storage.fileExtension );
        }

        private static string GetFilenameTrash( Trait trait )
        {
            return Path.ChangeExtension( Path.Combine( s_pathTrash, trait.ID.ToString() ), Storage.fileExtension );
        }

        public Trait Get( Guid id )
        {
            Trait trait = m_traitsList.Find( x => x.ID == id );

            if( null == trait )
            {
                throw new InvalidOperationException( $"Die Eigenschaft mit der ID {id} konnte nicht gefunden werden!" );
            }

            return ( trait );
        }

        public Trait Create()
        {
            Trait trait = new Trait();
            trait.TraitLevelList.Add( new TraitLevel() );

            Save( trait );

            m_traitsList.Add( trait );

            return ( trait );
        }

        public void Delete( Trait trait )
        {
            if( null == trait )
            {
                throw new ArgumentNullException( nameof( trait ) );
            }

            m_traitsList.Remove( trait );

            if( !Directory.Exists( s_pathTrash ) )
            {
                Directory.CreateDirectory( s_pathTrash );
            }

            File.Move( GetFilename( trait ), GetFilenameTrash( trait ) );
        }

        public IList<Trait> Traits => ( m_traitsList.AsReadOnly() );

        private readonly List<Trait> m_traitsList = new List<Trait>();
    }
}
