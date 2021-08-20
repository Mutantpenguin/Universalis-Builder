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
            ModelList = new List<Actor>();
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
                Faction != group.Faction )
            {
                return ( false );
            }

            if( Icon != group.Icon )
            {
                return ( false );
            }

            foreach( Actor actor in ModelList )
            {
                if( group.ModelList.Find( x => x.Equals( actor ) ) == null )
                {
                    return ( false );
                }
            }

            foreach( Actor actor in group.ModelList )
            {
                if( ModelList.Find( x => x.Equals( actor ) ) == null )
                {
                    return ( false );
                }
            }

            // when we get to here it is safe to assume that the actors didn't change at all
            // thus we can check if their order changed
            for( int i = 0; i < ModelList.Count; i++ )
            {
                if( !ModelList[ i ].Equals( group.ModelList[ i ] ) )
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

            ModelList.Clear();
            foreach( Actor actor in group.ModelList )
            {
                ModelList.Add( new Actor( actor ) );
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
        } = Shared.Properties.Resources.empty;

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

        public List<Actor> ModelList
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
                    points += GroupTrait.Points( ModelList.Count );
                }

                points += ModelList.Sum( x => x.Points );

                return ( points );
            }
        }

        public bool HasInactiveComposition()
        {
            if( ModelList.Exists( x => x.HasInactiveComposition() ) )
            {
                return ( true );
            }

            return ( false );
        }
    }
}
