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
        private const string s_folderName = "Archetypes";

        private readonly string s_path;
        private readonly string s_pathTrash;

        public ArchetypeStorage( string path, BackgroundWorker backgroundWorker )
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
                        Archetype archetype = JsonConvert.DeserializeObject<Archetype>( File.ReadAllText( file ) );
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
            string filename = GetFilename( archetype );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( archetype, Storage.formatting ) );
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

        private string GetFilenameTrash( Archetype archetype )
        {
            return Path.ChangeExtension( Path.Combine( s_pathTrash, archetype.ID.ToString() ), Storage.fileExtension );
        }

        public Archetype Get( Guid id )
        {
            Archetype archetype = m_archetypeList.Find( x => x.ID == id );

            if( null == archetype )
            {
                throw new InvalidOperationException( $"Der Archetyp mit der ID {id} konnte nicht gefunden werden!" );
            }

            return ( archetype );
        }

        public Archetype Create( Faction faction )
        {
            if( null == faction )
            {
                throw new ArgumentNullException(nameof(faction ) );
            }

            Archetype archetype = new Archetype()
            {
                Faction = faction
            };

            Save( archetype );

            m_archetypeList.Add( archetype );

            return ( archetype );
        }

        public void Delete( Archetype archetype )
        {
            if( null == archetype )
            {
                throw new ArgumentNullException( nameof( archetype ) );
            }

            m_archetypeList.Remove( archetype );

            if( !Directory.Exists( s_pathTrash ) )
            {
                Directory.CreateDirectory( s_pathTrash );
            }

            File.Move( GetFilename( archetype ), GetFilenameTrash( archetype ) );
        }

        public IList<Archetype> Archetypes => ( m_archetypeList.AsReadOnly() );

        private readonly List<Archetype> m_archetypeList = new List<Archetype>();
    }
}
