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
            ActorList = new List<Actor>();
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

            foreach( Actor actor in ActorList )
            {
                if( group.ActorList.Find( x => x.Equals( actor ) ) == null )
                {
                    return ( false );
                }
            }

            foreach( Actor actor in group.ActorList )
            {
                if( ActorList.Find( x => x.Equals( actor ) ) == null )
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

            ActorList.Clear();
            foreach( Actor actor in group.ActorList )
            {
                ActorList.Add( new Actor( actor ) );
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

        public List<Actor> ActorList
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

                points += ActorList.Sum( x => x.Points );

                return ( points );
            }
        }
    }
}
