using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Universalis
{
    public class Group
    {
        public Group( Group group )
            : this()
        {
            Set( group );
        }

        public Group()
        {
            Models = new List<Actor>();
        }

        public bool Equals( Group group )
        {
            if( null == group )
            {
                throw new ArgumentNullException( nameof( group ) );
            }

            if( Active != group.Active
                ||
                Name != group.Name
                ||
                Description != group.Description
                ||
                Faction != group.Faction
                ||
                GroupTrait != group.GroupTrait )
            {
                return false;
            }

            if( Icon != group.Icon )
            {
                return false;
            }

            foreach( Actor actor in Models )
            {
                if( !group.Models.Any( x => x.Equals( actor ) ) )
                {
                    return false;
                }
            }

            foreach( Actor actor in group.Models )
            {
                if( !Models.Any( x => x.Equals( actor ) ) )
                {
                    return false;
                }
            }

            // when we get to here it is safe to assume that the actors didn't change at all
            // thus we can check if their order changed
            for( int i = 0; i < Models.Count; i++ )
            {
                if( !Models[ i ].Equals( group.Models[ i ] ) )
                {
                    return false;
                }
            }

            return true;
        }

        public void Set( Group group )
        {
            if( null == group )
            {
                throw new ArgumentNullException( nameof( group ) );
            }

            Active = group.Active;

            Name = group.Name;
            Description = group.Description;
            Icon = group.Icon;
            Faction = group.Faction;
            GroupTrait = group.GroupTrait;

            Models.Clear();
            foreach( Actor actor in group.Models )
            {
                Models.Add( new Actor( actor ) );
            }
        }

        public Guid ID
        {
            get;
            set;
        } = Guid.NewGuid();

        public bool Active
        {
            get;
            set;
        } = true;

        public string Name
        {
            get;
            set;
        } = "Bitte Namen angeben";

        public string Description
        {
            get;
            set;
        }

        [JsonConverter( typeof( JsonJpegConverter ) )]
        public Bitmap Icon
        {
            get;
            set;
        } = Properties.Resources.empty_group;

        [JsonConverter( typeof( JsonFactionConverter ) )]
        public Faction Faction
        {
            get;
            set;
        }

        [JsonConverter( typeof( JsonGroupTraitConverter ) )]
        public GroupTrait GroupTrait
        {
            get;
            set;
        }

        public List<Actor> Models
        {
            get;
            set;
        }

        [JsonIgnore]
        public int Points
        {
            get
            {
                int points = 0;

                if( GroupTrait != null )
                {
                    points += GroupTrait.Points( Models.Where( x => x.Active ).Count() );
                }

                points += Models.Where( x => x.Active )
                                   .Sum( x => x.Points );

                return points;
            }
        }

        public (bool valid, String reason) IsValid()
        {
            string reasonString = String.Empty;

            var archetypesOverMaxQuantity = Models.Where( x => x.Active )
                                                  .GroupBy( x => x.Archetype )
                                                  .Where( x => x.Key.MaxQuantity > 0 && x.Count() > x.Key.MaxQuantity );

            foreach( var element in archetypesOverMaxQuantity )
            {
                reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : Environment.NewLine ) + $"Archetyp '{element.Key.Name}' ist {element.Count()}x vorhanden, aber nur {element.Key.MaxQuantity}x erlaubt.";
            }

            foreach( var model in Models.Where( x => x.Active ) )
            {
                var hasInactiveComposition = model.HasInactiveComposition();
                var outfitExceedsMaxQuantity = model.OutfitExceedsMaxQuantity();

                if( hasInactiveComposition || outfitExceedsMaxQuantity )
                {
                    reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) + model.Name + ":";

                    if( hasInactiveComposition )
                    {
                        reasonString += Environment.NewLine + "- Inaktive Ausstattung vorhanden.";
                    }

                    if( outfitExceedsMaxQuantity )
                    {
                        reasonString += Environment.NewLine + "- Maximale Menge an Ausstattung pro Modell überschritten.";
                    }
                }
            }

            {
                var weapons = Models.Where( x => x.Active )
                                    .SelectMany( x => x.Weapons )
                                    .Select( x => x.Weapon )
                                    .Where( x => x.MaxGroupQuantity > 0 )
                                    .GroupBy( x => x )
                                    .Select( x => new { weapon = x.Key, count = x.Count() } )
                                    .Where( x => x.count > x.weapon.MaxGroupQuantity );

                foreach( var entry in weapons )
                {
                    reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) + $"Waffe '{entry.weapon.Name}' darf nur {entry.weapon.MaxGroupQuantity}x in der Gruppe vorkommen, kommt aber {entry.count}x vor:";

                    foreach( var model in Models.Where( x => x.Active && x.Weapons.Exists( y => y.Weapon == entry.weapon ) ) )
                    {
                        reasonString += Environment.NewLine + "- " + model.Name;
                    }
                }
            }

            {
                var equipments = Models.Where( x => x.Active )
                                       .SelectMany( x => x.Equipments )
                                       .Select( x => x.Equipment )
                                       .Where( x => x.MaxGroupQuantity > 0 )
                                       .GroupBy( x => x )
                                       .Select( x => new { equipment = x.Key, count = x.Count() } )
                                       .Where( x => x.count > x.equipment.MaxGroupQuantity );

                foreach( var entry in equipments )
                {
                    reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) + $"Ausrüstung '{entry.equipment.Name}' darf nur {entry.equipment.MaxGroupQuantity}x in der Gruppe vorkommen, kommt aber {entry.count}x vor:";

                    foreach( var model in Models.Where( x => x.Active && x.Equipments.Exists( y => y.Equipment == entry.equipment ) ) )
                    {
                        reasonString += Environment.NewLine + "- " + model.Name;
                    }
                }
            }

            {
                var armors = Models.Where( x => x.Active )
                                   .Select( x => x.Armor )
                                   .Where( x => x != null && x.MaxGroupQuantity > 0 )
                                   .GroupBy( x => x )
                                   .Select( x => new { armor = x.Key, count = x.Count() } )
                                   .Where( x => x.count > x.armor.MaxGroupQuantity );

                foreach( var entry in armors )
                {
                    reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) + $"Rüstung '{entry.armor.Name}' darf nur {entry.armor.MaxGroupQuantity}x in der Gruppe vorkommen, kommt aber {entry.count}x vor:";

                    foreach( var model in Models.Where( x => x.Active && x.Armor == entry.armor ) )
                    {
                        reasonString += Environment.NewLine + "- " + model.Name;
                    }
                }
            }

            {
                var traits = Models.Where( x => x.Active )
                                   .SelectMany( x => x.Traits )
                                   .Select( x => x.Trait )
                                   .Where( x => x.MaxGroupQuantity > 0 )
                                   .GroupBy( x => x )
                                   .Select( x => new { trait = x.Key, count = x.Count() } )
                                   .Where( x => x.count > x.trait.MaxGroupQuantity );

                foreach( var entry in traits )
                {
                    reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) + $"Eigenschaft '{entry.trait.Name}' darf nur {entry.trait.MaxGroupQuantity}x in der Gruppe vorkommen, kommt aber {entry.count}x vor:";

                    foreach( var model in Models.Where( x => x.Active && x.Traits.Exists( y => y.Trait == entry.trait ) ) )
                    {
                        reasonString += Environment.NewLine + "- " + model.Name;
                    }
                }
            }

            {
                var disciplines = Models.Where( x => x.Active )
                                        .SelectMany( x => x.Disciplines )
                                        .Select( x => x.Discipline )
                                        .Where( x => x.MaxGroupQuantity > 0 )
                                        .GroupBy( x => x )
                                        .Select( x => new { discipline = x.Key, count = x.Count() } )
                                        .Where( x => x.count > x.discipline.MaxGroupQuantity );

                foreach( var entry in disciplines )
                {
                    reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) + $"Eigenschaft '{entry.discipline.Name}' darf nur {entry.discipline.MaxGroupQuantity}x in der Gruppe vorkommen, kommt aber {entry.count}x vor:";

                    foreach( var model in Models.Where( x => x.Active && x.Disciplines.Exists( y => y.Discipline == entry.discipline ) ) )
                    {
                        reasonString += Environment.NewLine + "- " + model.Name;
                    }
                }
            }

            return (String.IsNullOrEmpty( reasonString ), reasonString);
        }
    }
}
