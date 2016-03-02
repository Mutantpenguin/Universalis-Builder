using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public class ActorStorage
    {
        private static ActorStorage s_instance = new ActorStorage();

        private ActorStorage() { }

        public static ActorStorage Instance
        {
            get
            {
                return( s_instance );
            }
        }

        private static string s_path = Path.Combine( StorageSettings.DataPath, "Actors" );

        public void LoadAll( BackgroundWorker backgroundWorker )
        {
            if( !Directory.Exists( s_path ) )
            {
                Directory.CreateDirectory( s_path );
            }

            backgroundWorker.ReportProgress( 0, "Modelle" );

            backgroundWorker.DoWork += ( sender, e ) =>
            {
                string[] files = Directory.GetFiles( s_path, StorageSettings.filePattern, SearchOption.TopDirectoryOnly );

                int i = 1;

                foreach( string file in files )
                {
                    try
                    {
                        Actor actor = JsonConvert.DeserializeObject<Actor>( File.ReadAllText( file ) );
#if DEBUG
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

                    backgroundWorker.ReportProgress( Convert.ToInt32( (float)i / files.Count() * 100 ), $"Modell {i}/{files.Count()} wird geladen..." );

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

            string filename = Path.ChangeExtension( Path.Combine( s_path, actor.ID.ToString() ), StorageSettings.fileExtension );
            string filenameBackup = Path.ChangeExtension( filename, StorageSettings.backupFileExtension );

            if( File.Exists( filename ) )
            {
                File.Copy( filename, filenameBackup, overwrite: true );
            }

            try
            {
                File.WriteAllText( filename, JsonConvert.SerializeObject( actor, StorageSettings.formatting ) );
                File.Delete( filenameBackup );
            }
            catch( Exception ex )
            {
                MessageBox.Show( $"Fehler beim Schreiben der Datei '{filename}':\n{ex.Message}" );
            }
        }

        public Actor Get( Guid id )
        {
            Actor actor = m_actorList.Find( x => x.ID == id );

            if( null == actor )
            {
                throw new InvalidOperationException( $"Das Modell mit der ID {id} konnte nicht gefunden werden!" );
            }

            return ( actor );
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

        public static void Delete( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            actor.Active = false;
            Save( actor );
        }

        public IList<Actor> Actors
        {
            get
            {
                return ( m_actorList.AsReadOnly() );
            }
        }

        public IList<Actor> ActorsWithWeapon( Weapon weapon )
        {
            return ( m_actorList.Where( x => x.Active )
                                .Where( x => x.ActorOutfitsList.Exists( y => y.ActorWeaponsList.Exists( z => z.Weapon.ID == weapon.ID ) ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithArmor( Armor armor )
        {
            return ( m_actorList.Where( x => x.Active )
                                .Where( x => x.Armor != null && x.Armor.ID == armor.ID )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithEquipment( Equipment equipment )
        {
            return ( m_actorList.Where( x => x.Active )
                                .Where( x => x.ActorOutfitsList.Exists( y => y.ActorEquipmentList.Exists( z => z.Equipment.ID == equipment.ID ) ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithTrait( Trait trait )
        {
            return ( m_actorList.Where( x => x.Active )
                                .Where( x => x.ActorTraitsList.Exists( y => y.Trait.ID == trait.ID ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithTraitLevel( Trait trait, TraitLevel traitLevel )
        {
            return ( m_actorList.Where( x => x.Active )
                                .Where( x => x.ActorTraitsList.Exists( y => y.Trait.ID == trait.ID && y.Level == traitLevel.Level ) )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        public IList<Actor> ActorsWithFaction( Faction faction )
        {
            return ( m_actorList.Where( x => x.Active )
                                .Where( x => x.Faction.ID == faction.ID )
                                .OrderBy( x => x.Name )
                                .ToList()
                                .AsReadOnly() );
        }

        private List<Actor> m_actorList = new List<Actor>();
    }
}
