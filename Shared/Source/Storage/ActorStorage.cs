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
        private ActorStorage() { }

        public static readonly ActorStorage Instance = new ActorStorage();

        private const string s_folderName = "Models";

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

        public static void Save( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
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

        private static string GetFilename( Actor actor )
        {
            return( Path.ChangeExtension( Path.Combine( s_path, actor.ID.ToString() ), Storage.fileExtension ) );
        }

        private static string GetFilenameTrash( Actor actor )
        {
            return ( Path.ChangeExtension( Path.Combine( s_pathTrash, actor.ID.ToString() ), Storage.fileExtension ) );
        }

        public Actor Get( Guid id )
        {
            return ( m_actorList.Find( x => x.ID == id ) );
        }

        public Actor Create( Faction faction )
        {
            if( null == faction )
            {
                throw new ArgumentNullException( nameof( faction ) );
            }

            Actor actor = new Actor()
            {
                Faction = faction
            };

            actor.ActorOutfitsList.Add( new Actor.ActorOutfit()
            {
                Name = "Bitte Namen eingeben"
            } );

            Save( actor );

            m_actorList.Add( actor );

            return ( actor );
        }

        public void Delete( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            m_actorList.Remove( actor );

            if( !Directory.Exists( s_pathTrash ) )
            {
                Directory.CreateDirectory( s_pathTrash );
            }

            File.Move( GetFilename( actor ), GetFilenameTrash( actor ) );
        }

        public IList<Actor> Actors => ( m_actorList.AsReadOnly() );

        public IList<Actor> ActorsWithWeapon( Weapon weapon )
        {
            return ( m_actorList.Where( x => x.ActorOutfitsList.Exists( y => y.ActorWeaponsList.Exists( z => z.Weapon.ID == weapon.ID ) ) )
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
            return ( m_actorList.Where( x => x.ActorOutfitsList.Exists( y => y.ActorEquipmentList.Exists( z => z.Equipment.ID == equipment.ID ) ) )
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

        public IList<Actor> ActorsWithTraitLevel( Trait trait, TraitLevel traitLevel )
        {
            return ( m_actorList.Where( x => x.ActorTraitsList.Exists( y => y.Trait.ID == trait.ID && y.Level == traitLevel.Level ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithFaction( Faction faction )
        {
            return ( m_actorList.Where( x => x.Faction.ID == faction.ID )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        private readonly List<Actor> m_actorList = new List<Actor>();
    }
}
