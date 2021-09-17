using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public class GroupTraitStorage
    {
        private const string s_folderName = "GroupTrait";

        private readonly string s_path;

        private readonly GroupTrait m_nullGroupTrait = new GroupTrait()
        {
            ID = Guid.Empty,
            Active = false,
            Name = "--- GELÖSCHT ---",
            PointsPerModel = 10000,
            Description = "Diese Gruppeneigenschaft gibt es nicht (mehr)."
        };

        public GroupTraitStorage( string path, BackgroundWorker backgroundWorker )
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
                        GroupTrait groupTrait = JsonConvert.DeserializeObject<GroupTrait>( File.ReadAllText( file ) );
#if DEBUG
                        if( groupTrait.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Gruppeneigenschaft '{groupTrait.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        GroupTrait groupTraitSearch = m_groupTraitList.Find( x => x.ID == groupTrait.ID );
                        if( groupTraitSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Gruppeneigenschaft '{groupTrait.Name}' hat die gleiche ID wie die Gruppeneigenschaft '{groupTraitSearch.Name}'!" + Environment.NewLine + Environment.NewLine + groupTrait.ID );
                        }
#endif
                        m_groupTraitList.Add( groupTrait );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Gruppeneigenschafts-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Length * 100 ), $"Gruppeneigenschaft {i}/{files.Length}" );

                    i++;
                }
            };
        }

        public void Save( GroupTrait groupTrait )
        {
            if( null == groupTrait )
            {
                throw new ArgumentNullException( nameof( groupTrait ) );
            }

            if( !m_groupTraitList.Contains( groupTrait ) )
            {
                m_groupTraitList.Add( groupTrait );
            }

            string filename = GetFilename( groupTrait );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( groupTrait, Storage.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( GroupTrait groupTrait )
        {
            return Path.ChangeExtension( Path.Combine( s_path, groupTrait.ID.ToString() ), Storage.fileExtension );
        }
        public GroupTrait Get( Guid id )
        {
            GroupTrait groupTrait = m_groupTraitList.Find( x => x.ID == id );

            return ( groupTrait ?? m_nullGroupTrait );
        }

        public static GroupTrait Create()
        {
            return ( new GroupTrait() );
        }

        public void Delete( GroupTrait groupTrait )
        {
            if( null == groupTrait )
            {
                throw new ArgumentNullException( nameof( groupTrait ) );
            }

            groupTrait.Active = false;

            Save( groupTrait );
        }

        public IList<GroupTrait> GroupTraits => ( m_groupTraitList.AsReadOnly() );

        private readonly List<GroupTrait> m_groupTraitList = new List<GroupTrait>();
    }
}
