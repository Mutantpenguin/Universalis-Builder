using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    public class DisciplineStorage
    {
        private readonly JsonConverter[] Converters = { FactionStorage.JsonFactionHashSetConverter, ArchetypeStorage.JsonArchetypeHashSetConverter };

        private const string s_folderName = "Disciplines";

        private readonly string s_path;

        private readonly Discipline m_nullDiscipline = new Discipline()
        {
            ID = Guid.Empty,
            Active = false,
            Name = "--- GELÖSCHT ---",
            BasePoints = 10000,
            Description = "Diese Disziplin gibt es nicht (mehr)."
        };

        public DisciplineStorage( string path, BackgroundWorker backgroundWorker )
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
                        Discipline discipline = JsonConvert.DeserializeObject<Discipline>( File.ReadAllText( file ), Converters );
#if DEBUG
                        if( discipline.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Ausrüstung '{discipline.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Discipline disciplineSearch = m_disciplineList.Find( x => x.ID == discipline.ID );
                        if( disciplineSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Ausrüstung '{discipline.Name}' hat die gleiche ID wie die Ausrüstung '{disciplineSearch.Name}'!" + Environment.NewLine + Environment.NewLine + discipline.ID );
                        }
#endif
                        m_disciplineList.Add( discipline );
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

        public void Save( Discipline discipline )
        {
            if( null == discipline )
            {
                throw new ArgumentNullException( nameof( discipline ) );
            }

            if( !m_disciplineList.Contains( discipline ) )
            {
                m_disciplineList.Add( discipline );
            }

            string filename = GetFilename( discipline );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( discipline, Storage.formatting, Converters ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( Discipline discipline )
        {
            return Path.ChangeExtension( Path.Combine( s_path, discipline.ID.ToString() ), Storage.fileExtension );
        }

        public Discipline Get( Guid id )
        {
            Discipline discipline = m_disciplineList.Find( x => x.ID == id );

            return discipline ?? m_nullDiscipline;
        }

        public static Discipline Create()
        {
            return new Discipline();
        }

        public void Delete( Discipline discipline )
        {
            if( null == discipline )
            {
                throw new ArgumentNullException( nameof( discipline ) );
            }

            discipline.Active = false;

            Save( discipline );
        }

        public IList<Discipline> Disciplines => ( m_disciplineList.AsReadOnly() );

        private readonly List<Discipline> m_disciplineList = new List<Discipline>();
    }
}
