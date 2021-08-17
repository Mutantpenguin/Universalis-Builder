using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Universalis
{
    public class TraitLevel
    {
        public static readonly IList<uint> LevelList = Enumerable.Range( 0, 21 ).Select( x => (uint)x ).ToList();

        public TraitLevel() {}

        public TraitLevel( TraitLevel traitLevel )
        {
            Level = traitLevel.Level;
            Points = traitLevel.Points;
        }

        public bool Equals( TraitLevel traitLevel )
        {
            if( null == traitLevel )
            {
                throw new ArgumentNullException( nameof( traitLevel ) );
            }

            if( Level != traitLevel.Level
                ||
                Points != traitLevel.Points )
            {
                return ( false );
            }

            return ( true );
        }

        public uint Level
        {
            get;
            set;
        } = 0;

        public int Points
        {
            get;
            set;
        } = 0;
    }

    public class Trait
    {
        public Trait() { }

        public Trait( Trait trait )
        {
            Set( trait );
        }

        public void Set( Trait trait )
        {
            if( null == trait )
            {
                throw new ArgumentNullException( nameof( trait ) );
            }

            Active = trait.Active;

            Name = trait.Name;
            Description = trait.Description;
            Rules = trait.Rules;
            UseOnce = trait.UseOnce;

            if( null != TraitLevelList )
            {
                TraitLevelList.Clear();
            }
            else
            {
                TraitLevelList = new List<TraitLevel>();
            }

            if( null != trait.TraitLevelList )
            {
                foreach( TraitLevel traitLevel in trait.TraitLevelList )
                {
                    TraitLevelList.Add( new TraitLevel( traitLevel ) );
                }
            }
        }

        public bool Equals( Trait trait )
        {
            if( null == trait )
            {
                throw new ArgumentNullException( nameof( trait ) );
            }

            if( Active != trait.Active
                ||
                Name != trait.Name
                ||
                Description != trait.Description
                ||
                Rules != trait.Rules
                ||
                UseOnce != trait.UseOnce )
            {
                return ( false );
            }

            foreach( TraitLevel traitLevel in TraitLevelList )
            {
                if( trait.TraitLevelList.Find( x => x.Equals( traitLevel ) ) == null )
                {
                    return ( false );
                }
            }

            foreach( TraitLevel traitLevel in trait.TraitLevelList )
            {
                if( TraitLevelList.Find( x => x.Equals( traitLevel ) ) == null )
                {
                    return ( false );
                }
            }

            return ( true );
        }

        public const string LevelString = "[LVL]";

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
        } = "Bitte Namen eingeben";

        public string Description
        {
            get;
            set;
        } = String.Empty;

        public string Rules
        {
            get;
            set;
        } = "Bitte Regeln eingeben";

        public bool UseOnce
        {
            get;
            set;
        } = false;

        [JsonIgnore]
        public string Type
        {
            get
            {
                var minPoints = TraitLevelList.Min( x => x.Points );

                if( minPoints > 0 )
                {
                    return "+";
                }
                else if ( minPoints < 0 )
                {
                    return "-";
                }
                else
                {
                    return "=";
                }
            }
        }

        public List<TraitLevel> TraitLevelList
        {
            get;
            set;
        } = new List<TraitLevel>();

        [JsonIgnore]
        public string AvailableLevels
        {
            get
            {
                uint minLevel = TraitLevelList.Min( x => x.Level );

                if( minLevel == 0 )
                {
                    return ( "-" );
                }
                else
                {
                    uint maxLevel = TraitLevelList.Max( x => x.Level );

                    if( minLevel == maxLevel )
                    {
                        return ( minLevel.ToString() );
                    }
                    else
                    {
                        return ( minLevel + " - " + maxLevel );
                    }
                }
            }
        }

        [JsonIgnore]
        public string PointsRange
        {
            get
            {
                int minPoints = TraitLevelList.Min( x => x.Points );
                int maxPoints = TraitLevelList.Max( x => x.Points );

                if( minPoints == maxPoints )
                {
                    return ( minPoints.ToString() );
                }
                else
                {
                    return ( minPoints + " - " + maxPoints );
                }
            }
        }

        public int Points( uint level )
        {
            return ( TraitLevelList.Find( x => x.Level == level ).Points );
        }

        public string RulesWithLevel( uint lvl )
        {
            if( lvl == 0 )
            {
                return ( this.Rules.Replace( LevelString, "X" ) );
            }
            else
            {
                return ( this.Rules.Replace( LevelString, ( (int)lvl ).ToString() ) );
            }
        }
    }
}