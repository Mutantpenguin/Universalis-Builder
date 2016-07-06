using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tesserakt
{
    public class TraitLevel
    {
        public enum ELevel
        {
            Kein = 0,
            I = 1,
            II = 2,
            III = 3
        }

        public static readonly IList<ELevel> ELevelList = Enum.GetValues( typeof( ELevel ) ).Cast<ELevel>().ToList().AsReadOnly();

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

        public ELevel Level
        {
            get;
            set;
        } = TraitLevel.ELevel.Kein;

        public int Points
        {
            get;
            set;
        } = 0;
    }

    public class Trait
    {
        public Trait() {}

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

            Name = trait.Name;
            Description = trait.Description;
            Rules = trait.Rules;
            Type = trait.Type;

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

            if( Name != trait.Name
                ||
                Description != trait.Description
                ||
                Rules != trait.Rules
                ||
                Type != trait.Type )
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

        public string Type
        {
            get;
            set;
        } = "=";

        public List<TraitLevel> TraitLevelList
        {
            get;
            set;
        } = new List<TraitLevel>();

        [JsonIgnore]
        public TraitLevel.ELevel MinLevel
        {
            get
            {
                return ( TraitLevelList.Min( x => x.Level ) );
            }
        }

        [JsonIgnore]
        public string AvailableLevels
        {
            get
            {
                int minLevel = TraitLevelList.Min( x => (int)x.Level );

                if( minLevel == 0 )
                {
                    return ( "-" );
                }
                else
                {
                    int maxLevel = TraitLevelList.Max( x => (int)x.Level );

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

        public int Points( TraitLevel.ELevel level )
        {
            return ( TraitLevelList.Find( x => x.Level == level ).Points );
        }

        public string RulesWithLevel( TraitLevel.ELevel lvl )
        {
            if( lvl == TraitLevel.ELevel.Kein )
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