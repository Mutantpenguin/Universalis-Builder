using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public class GroupStorage
    {
        private GroupStorage() { }

        public static readonly GroupStorage Instance = new GroupStorage();

        private const string s_folderName = "Groups";

        private static readonly string s_path = Path.Combine( Storage.DataPath, s_folderName );
        private static readonly string s_pathTrash = Path.Combine( Storage.TrashPath, s_folderName );

        public void LoadAll( BackgroundWorker backgroundWorker )
        {
            if( !Directory.Exists( s_path ) )
            {
                Directory.CreateDirectory( s_path );
            }

            backgroundWorker.DoWork += delegate
            {
                string[] files = Directory.GetFiles( s_path, Storage.filePattern, SearchOption.TopDirectoryOnly );

                int i = 1;

                foreach( string file in files )
                {
                    System.Threading.Thread.Sleep( Storage.delayLoadingMs );

                    try
                    {
                        Group group = Load( file );
#if DEBUG
                        if( group.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, die Gruppe '{group.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Group groupSearch = m_groupList.Find( x => x.ID == group.ID );
                        if( groupSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, die Gruppe '{group.Name}' hat die gleiche ID wie die Gruppe '{groupSearch.Name}'!" + Environment.NewLine + Environment.NewLine + group.ID );
                        }
#endif
                        m_groupList.Add( group );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Gruppen-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Count() * 100 ), $"Gruppe {i}/{files.Count()}" );

                    i++;
                }
            };
        }

        public static Group Load( string file )
        {
            return( JsonConvert.DeserializeObject<Group>( File.ReadAllText( file ) ) );
        }

        public Group FindByID( Guid id )
        {
            return ( m_groupList.Find( x => x.ID == id ) );
        }

        public static void Save( Group group )
        {
            string filename = GetFilename( group );

            SaveAs( group, filename );
        }

        private static string GetFilename( Group group )
        {
            return Path.ChangeExtension( Path.Combine( s_path, group.ID.ToString() ), Storage.fileExtension );
        }

        private static string GetFilenameTrash( Group group )
        {
            return Path.ChangeExtension( Path.Combine( s_pathTrash, group.ID.ToString() ), Storage.fileExtension );
        }

        public static void SaveAs( Group group, string filename )
        {
            if( null == group )
            {
                throw new ArgumentNullException( nameof( group ) );
            }

            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( group, Storage.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        public Group Create( Faction faction )
        {
            if( null == faction )
            {
                throw new ArgumentNullException( nameof( faction ) );
            }

            Group group = new Group
            {
                Faction = faction
            };

            Save( group );

            m_groupList.Add( group );

            return ( group );
        }

        public void Add( Group group )
        {
            m_groupList.Add( group );
            Save( group );
        }

        public void Delete( Group group )
        {
            if( null == group )
            {
                throw new ArgumentNullException( nameof( group ) );
            }

            m_groupList.Remove( group );

            if( !Directory.Exists( s_pathTrash ) )
            {
                Directory.CreateDirectory( s_pathTrash );
            }

            File.Move( GetFilename( group ), GetFilenameTrash( group ) );
        }

        public IList<Group> Groups
        {
            get
            {
                return ( m_groupList.AsReadOnly() );
            }
        }

        private List<Group> m_groupList = new List<Group>();
    }
}
