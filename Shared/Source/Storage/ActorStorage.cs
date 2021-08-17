using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public class ActorStorage
    {
        private const string s_folderName = "Models";

        private readonly string s_path;

        public ActorStorage( string path, BackgroundWorker backgroundWorker )
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
                        Actor actor = JsonConvert.DeserializeObject<Actor>( File.ReadAllText( file ) );
#if DEBUG
                        if( actor.ID != new Guid( Path.GetFileNameWithoutExtension( file ) ) )
                        {
                            MessageBox.Show( $"ACHTUNG, das Modell '{actor.Name}' hat eine abweichende ID im Dateinamen!" + Environment.NewLine + Environment.NewLine + Path.GetFileName( file ) );
                        }

                        Actor actorSearch = m_actorList.Find( x => x.ID == actor.ID );
                        if( actorSearch != null )
                        {
                            MessageBox.Show( $"ACHTUNG, das Modell '{actor.Name}' hat die gleiche ID wie das Modell '{actorSearch.Name}'!" + Environment.NewLine + Environment.NewLine + actor.ID );
                        }
#endif
                        m_actorList.Add( actor );
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show( $"Problem beim Lesen der Modell-Datei '{Path.GetFileName( file )}':\n{ex.Message}" );
                    }

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Length * 100 ), $"Modell {i}/{files.Length}" );

                    i++;
                }
            };
        }

        public void Save( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            if( !m_actorList.Contains( actor ) )
            {
                m_actorList.Add( actor );
            }

            string filename = GetFilename( actor );
            string filenameBackup = Path.ChangeExtension( filename, Storage.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( actor, Storage.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        private string GetFilename( Actor actor )
        {
            return( Path.ChangeExtension( Path.Combine( s_path, actor.ID.ToString() ), Storage.fileExtension ) );
        }

        public Actor Get( Guid id )
        {
            return ( m_actorList.Find( x => x.ID == id ) );
        }

        public Actor Create( Archetype archetype )
        {
            if( null == archetype )
            {
                throw new ArgumentNullException( nameof( archetype ) );
            }

            Actor actor = new Actor( archetype );

            return ( actor );
        }

        public void Delete( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            actor.Active = false;

            Save( actor );
        }

        public IList<Actor> Actors => ( m_actorList.AsReadOnly() );

        public IList<Actor> ActorsWithArchetype( Archetype archetype )
        {
            return( m_actorList.Where( x => x.Archetype.ID == archetype.ID )
                               .OrderBy( x => x.Name )
                               .ToList()
                               .AsReadOnly());
        }

        public IList<Actor> ActorsWithWeapon( Weapon weapon )
        {
            return ( m_actorList.Where( x => x.ActorWeaponsList.Exists( z => z.Weapon.ID == weapon.ID ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithArmor( Armor armor )
        {
            return ( m_actorList.Where( x => x.Armor != null && x.Armor.ID == armor.ID )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithEquipment( Equipment equipment )
        {
            return ( m_actorList.Where( x => x.ActorEquipmentList.Exists( z => z.Equipment.ID == equipment.ID ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithTrait( Trait trait )
        {
            return ( m_actorList.Where( x => x.ActorTraitsList.Exists( y => y.Trait.ID == trait.ID ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        private readonly List<Actor> m_actorList = new List<Actor>();
    }
}
