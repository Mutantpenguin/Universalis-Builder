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
                return ( false );
            }

            if( Icon != group.Icon )
            {
                return ( false );
            }

            foreach( Actor actor in Models )
            {
                if( !group.Models.Any( x => x.Equals( actor ) ) )
                {
                    return ( false );
                }
            }

            foreach( Actor actor in group.Models )
            {
                if( !Models.Any( x => x.Equals( actor ) ) )
                {
                    return ( false );
                }
            }

            // when we get to here it is safe to assume that the actors didn't change at all
            // thus we can check if their order changed
            for( int i = 0; i < Models.Count; i++ )
            {
                if( !Models[ i ].Equals( group.Models[ i ] ) )
                {
                    return ( false );
                }
            }

            return ( true );
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
        } = Shared.Properties.Resources.empty_group;

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
                    points += GroupTrait.Points( Models.Count );
                }

                points += Models.Where( x => x.Active )
                                   .Sum( x => x.Points );

                return ( points );
            }
        }

        public (bool status, String reason) IsValid()
        {
            string reasonString = String.Empty;

            var archetypesOverMaxQuantity = Models.Where( x => x.Active )
                                                  .GroupBy( x => x.Archetype )
                                                  .Where( x => x.Key.MaxQuantity > 0 && x.Count() > x.Key.MaxQuantity );

            foreach( var element in archetypesOverMaxQuantity )
            {
                reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : Environment.NewLine ) + $"Archetyp '{element.Key.Name}' ist {element.Count()}x vorhanden, aber nur {element.Key.MaxQuantity}x erlaubt.";
            }

            if( Models.Exists( x => x.HasInactiveComposition() ) )
            {
                reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) +  "Inaktive Ausstattung vorhanden.";
            }

            return ( String.IsNullOrEmpty( reasonString ), reasonString );
        }
    }
}
