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
        private static GroupStorage s_instance = new GroupStorage();

        private GroupStorage() { }

        public static GroupStorage Instance
        {
            get
            {
                return( s_instance );
            }
        }

        private static string s_path = Path.Combine( StorageSettings.DataPath, "Groups" );

        public void LoadAll( BackgroundWorker backgroundWorker )
        {
            if( !Directory.Exists( s_path ) )
            {
                Directory.CreateDirectory( s_path );
            }

            backgroundWorker.ReportProgress( 0, "Gruppen" );

            backgroundWorker.DoWork += delegate
            {
                string[] files = Directory.GetFiles( s_path, StorageSettings.filePattern, SearchOption.TopDirectoryOnly );

                int i = 1;

                foreach( string file in files )
                {
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

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Count() * 100 ), $"Gruppe {i}/{files.Count()} wird geladen..." );

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
            string filename = Path.ChangeExtension( Path.Combine( s_path, group.ID.ToString() ), StorageSettings.fileExtension );

            SaveAs( group, filename );
        }

        public static void SaveAs( Group group, string filename )
        {
            if( null == group )
            {
                throw new ArgumentNullException( nameof( group ) );
            }

            string filenameBackup = Path.ChangeExtension( filename, StorageSettings.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( group, StorageSettings.formatting ) );
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

        public static void Delete( Group group )
        {
            if( null == group )
            {
                throw new ArgumentNullException( nameof( group ) );
            }

            group.Active = false;
            Save( group );
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
