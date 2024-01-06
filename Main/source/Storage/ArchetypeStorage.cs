using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public class ArchetypeStorage
    {
        private readonly JsonConverter[] Converters = { FactionStorage.JsonFactionHashSetConverter };

        internal static readonly JsonArchetypeHashSetConverter JsonArchetypeHashSetConverter = new JsonArchetypeHashSetConverter();

        private const string s_folderName = "Archetypes";

        private readonly string s_path;

        private readonly Archetype m_nullArchetype = new Archetype()
        {
            ID = Guid.Empty,
            Active = false,
            Name = "--- GELÖSCHT ---",
            Description = "Diesen Archetyp gibt es nicht (mehr)."
        };

        public ArchetypeStorage( string path, BackgroundWorker backgroundWorker )
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
                        Archetype archetype = JsonConvert.DeserializeObject<Archetype>( File.ReadAllText( file ), Converters);
#if DEBUG
                        if( archetype.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, der Archetyp '{archetype.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Archetype archetypeSearch = m_archetypeList.Find( x => x.ID == archetype.ID );
                        if( archetypeSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, der Archetyp '{archetype.Name}' hat die gleiche ID wie der Archetyp '{archetypeSearch.Name}'!" + Environment.NewLine + Environment.NewLine + archetype.ID );
                        }
#endif
                        m_archetypeList.Add( archetype );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Archetypen-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Length * 100 ), $"Archetyp {i}/{files.Length}" );

                    i++;
                }
            };
        }

        public void Save( Archetype archetype )
        {
            if( null == archetype )
            {
                throw new ArgumentNullException( nameof( archetype ) );
            }

            if( !m_archetypeList.Contains( archetype ) )
            {
                m_archetypeList.Add( archetype );
            }

            string filename = GetFilename( archetype );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( archetype, Storage.formatting, Converters) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( Archetype archetype )
        {
            return Path.ChangeExtension( Path.Combine( s_path, archetype.ID.ToString() ), Storage.fileExtension );
        }

        public Archetype Get( Guid id )
        {
            Archetype archetype = m_archetypeList.Find( x => x.ID == id );

            return archetype ?? m_nullArchetype;
        }

        public static Archetype Create()
        {
            return new Archetype();
        }

        public void Delete( Archetype archetype )
        {
            if( null == archetype )
            {
                throw new ArgumentNullException( nameof( archetype ) );
            }

            archetype.Active = false;

            Save( archetype );
        }

        public IList<Archetype> Archetypes => ( m_archetypeList.AsReadOnly() );

        private readonly List<Archetype> m_archetypeList = new List<Archetype>();
    }
}
