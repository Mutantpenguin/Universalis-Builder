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
        private readonly JsonConverter[] Converters = { FactionStorage.JsonFactionHashSetConverter, ArchetypeStorage.JsonArchetypeHashSetConverter };

        private const string s_folderName = "Traits";

        private readonly string s_path;

        private readonly Trait m_nullTrait = new Trait()
        {
            ID = Guid.Empty,
            Active = false,
            Name = "--- GELÖSCHT ---",
            AdditionalPoints = 10000,
            Description = "Diese Eigenschaft gibt es nicht (mehr)."
        };

        public TraitStorage( string path, BackgroundWorker backgroundWorker )
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
                        Trait trait = JsonConvert.DeserializeObject<Trait>( File.ReadAllText( file ), Converters );
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

        public void Save( Trait trait )
        {
            if( null == trait )
            {
                throw new ArgumentNullException( nameof( trait ) );
            }

            if( !m_traitsList.Contains( trait ) )
            {
                m_traitsList.Add( trait );
            }

            string filename = GetFilename( trait );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( trait, Storage.formatting, Converters ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( Trait trait )
        {
            return Path.ChangeExtension( Path.Combine( s_path, trait.ID.ToString() ), Storage.fileExtension );
        }

        public Trait Get( Guid id )
        {
            Trait trait = m_traitsList.Find( x => x.ID == id );

            return ( trait ?? m_nullTrait );
        }

        public static Trait Create()
        {
            Trait trait = new Trait();

            return ( trait );
        }

        public void Delete( Trait trait )
        {
            if( null == trait )
            {
                throw new ArgumentNullException( nameof( trait ) );
            }

            trait.Active = false;

            Save( trait );
        }

        public IList<Trait> Traits => ( m_traitsList.AsReadOnly() );

        private readonly List<Trait> m_traitsList = new List<Trait>();
    }
}
