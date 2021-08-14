using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

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
        public Bitmap FactionIcon
        {
            get
            {
                if( null != Faction )
                {
                    return ( Faction.Icon );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public int Points
        {
            get
            {
                int points = 0;

                foreach( GroupActor groupActor in GroupActorList )
                {

                    points += groupActor.Points;
                }

                return ( points );
            }
        }

        public void AddActor( Actor actor, Actor.ActorOutfit actorOutfit )
        {
            GroupActorList.Add( new GroupActor
            {
                Actor = actor,
                ActorOutfit = actorOutfit
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

                if( Actor != groupActor.Actor
                    ||
                    ActorOutfit != groupActor.ActorOutfit
                    ||
                    CustomName != groupActor.CustomName )
                {
                    return ( false );
                }

                if( CustomImg != groupActor.CustomImg )
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

                CustomName = groupActor.CustomName;
                Actor = groupActor.Actor;
                ActorOutfit = groupActor.ActorOutfit;

                CustomImg = groupActor.CustomImg;
            }

            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            public string CustomName
            {
                get;
                set;
            }

            [JsonConverter( typeof( JsonGroupActorConverter ) )]
            public Actor Actor
            {
                get;
                set;
            }

            [JsonConverter( typeof( JsonActorOutfitConverter ) )]
            public Actor.ActorOutfit ActorOutfit
            {
                get;
                set;
            }

            [JsonConverter( typeof( JsonJpegConverter ) )]
            public Bitmap CustomImg
            {
                get;
                set;
            } = null;

            [JsonIgnore]
            public Bitmap Icon
            {
                get
                {
                    if( Actor != null )
                    {
                        return ( Actor.Icon );
                    }
                    else
                    {
                        return ( Shared.Properties.Resources.empty );
                    }
                }
            }

            [JsonIgnore]
            public string Name
            {
                get
                {
                    if( Actor != null )
                    {
                        string name = Actor.Name;

                        if( !String.IsNullOrEmpty( CustomName ) )
                        {
                            name += " - " + CustomName;
                        }

                        if( ActorOutfit != null )
                        {
                            name += Environment.NewLine + ActorOutfit.Name;
                        }

                        return ( name );
                    }
                    else
                    {
                        return( "Modell nicht mehr vorhanden" );
                    }
                }
            }

            [JsonIgnore]
            public int Points
            {
                get
                {
                    if( Actor != null )
                    {
                        return ( Actor.Points( ActorOutfit ) );
                    }
                    else
                    {
                        return ( 0 );
                    }
                }
            }
        }

        public bool HasMissingActorOutfits()
        {
            if( GroupActorList.Exists( x => x.ActorOutfit == null ) )
            {
                return ( true );
            }

            return( false );
        }

        public bool HasMissingActors()
        {
            if( GroupActorList.Exists( x => x.Actor == null ) )
            {
                return ( true );
            }

            return( false );
        }
    }
}
