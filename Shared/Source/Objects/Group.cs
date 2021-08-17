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
            GroupActorList = new List<GroupActor>();
        }

        public bool Equals( Group group )
        {
            if( null == group )
            {
                throw new ArgumentNullException( nameof( group ) );
            }

            if( Name != group.Name
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

            foreach( GroupActor groupActor in GroupActorList )
            {
                if( group.GroupActorList.Find( x => x.Equals( groupActor ) ) == null )
                {
                    return ( false );
                }
            }

            foreach( GroupActor groupActor in group.GroupActorList )
            {
                if( GroupActorList.Find( x => x.Equals( groupActor ) ) == null )
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

            Name = group.Name;
            Description = group.Description;
            Icon = group.Icon;
            Faction = group.Faction;

            GroupActorList.Clear();
            foreach( GroupActor groupActor in group.GroupActorList )
            {
                GroupActorList.Add( new GroupActor( groupActor ) );
            }
        }

        public Guid ID
        {
            get;
            set;
        } = Guid.NewGuid();

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

        public List<GroupActor> GroupActorList
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

                points += GroupActorList.Sum( x => x.Actor.Points );

                return ( points );
            }
        }

        public void AddActor( Actor actor )
        {
            GroupActorList.Add( new GroupActor
            {
                Actor = actor
            } );
        }

        public class GroupActor
        {
            public GroupActor(){}

            public GroupActor( GroupActor groupActor )
                : this()
            {
                Set( groupActor );
            }

            public bool Equals( GroupActor groupActor )
            {
                if( null == groupActor )
                {
                    throw new ArgumentNullException( nameof( groupActor ) );
                }

                if( ID != groupActor.ID )
                {
                    return ( false );
                }

                if( Actor != groupActor.Actor )
                {
                    return ( false );
                }

                return ( true );
            }

            public void Set( GroupActor groupActor )
            {
                if( null == groupActor )
                {
                    throw new ArgumentNullException( nameof( groupActor ) );
                }

                ID = groupActor.ID;

                Actor = groupActor.Actor;
            }

            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            [JsonConverter( typeof( JsonActorConverter ) )]
            public Actor Actor
            {
                get;
                set;
            }

            public int Index
            {
                get;
                set;
            } = 0;
        }
    }
}
