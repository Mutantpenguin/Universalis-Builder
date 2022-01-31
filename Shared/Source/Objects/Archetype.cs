using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Universalis
{
    public class Archetype
    {
        public Archetype()
        { }

        public Archetype( Archetype archetype )
        {
            Set( archetype );
        }

        public void Set( Archetype archetype )
        {
            if( null == archetype )
            {
                throw new ArgumentNullException( nameof( archetype ) );
            }

            Active = archetype.Active;

            Name = archetype.Name;
            Description = archetype.Description;
            Faction = archetype.Faction;
            Size = archetype.Size;
            MovementType = archetype.MovementType;
            Type = archetype.Type;
            MaxQuantity = archetype.MaxQuantity;

            Profile.Set( archetype.Profile );

            if( null != Traits )
            {
                Traits.Clear();
            }
            else
            {
                Traits = new List<ArchetypeTrait>();
            }

            if( null != archetype.Traits )
            {
                foreach( ArchetypeTrait archetypeTrait in archetype.Traits )
                {
                    Traits.Add( new ArchetypeTrait( archetypeTrait ) );
                }
            }
        }

        public bool Equals( Archetype archetype )
        {
            if( null == archetype )
            {
                throw new ArgumentNullException( nameof( archetype ) );
            }

            if( Active != archetype.Active
                ||
                Name != archetype.Name
                ||
                Description != archetype.Description
                ||
                Faction != archetype.Faction
                ||
                Size != archetype.Size
                ||
                MovementType != archetype.MovementType
                ||
                Type != archetype.Type
                ||
                MaxQuantity != archetype.MaxQuantity )
            {
                return ( false );
            }

            if( !Profile.Equals( archetype.Profile ) )
            {
                return ( false );
            }

            foreach( ArchetypeTrait archetypeTrait in Traits )
            {
                if( !archetype.Traits.Any( x => x.Equals( archetypeTrait ) ) )
                {
                    return ( false );
                }
            }

            foreach( ArchetypeTrait archetypeTrait in archetype.Traits )
            {
                if( !Traits.Any( x => x.Equals( archetypeTrait ) ) )
                {
                    return ( false );
                }
            }

            return ( true );
        }

        #region members

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
        }

        [JsonConverter( typeof( JsonFactionConverter ) )]
        public Faction Faction
        {
            get;
            set;
        }

        public EType Type
        {
            get;
            set;
        } = EType.Infanterie;

        public ESize Size
        {
            get;
            set;
        } = ESize.Mittel;

        public EMovementType MovementType
        {
            get;
            set;
        } = EMovementType.Beine;

        public Profile Profile
        {
            get;
            set;
        } = new Profile();

        public uint MaxQuantity
        {
            get;
            set;
        } = 0;

        #endregion members

        public class ArchetypeTrait
        {
            public ArchetypeTrait() { }

            public ArchetypeTrait( ArchetypeTrait archetypeTrait )
            {
                if( null == archetypeTrait )
                {
                    throw new ArgumentNullException( nameof( archetypeTrait ) );
                }

                ID = archetypeTrait.ID;

                Trait = archetypeTrait.Trait;
                Level = archetypeTrait.Level;
            }

            public bool Equals( ArchetypeTrait archetypeTrait )
            {
                if( null == archetypeTrait )
                {
                    throw new ArgumentNullException( nameof( archetypeTrait ) );
                }

                if( ID != archetypeTrait.ID
                    ||
                    Trait != archetypeTrait.Trait
                    ||
                    Level != archetypeTrait.Level )
                {
                    return ( false );
                }

                return ( true );
            }

            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            [JsonConverter( typeof( JsonTraitConverter ) )]
            public Trait Trait
            {
                get;
                set;
            }

            public uint Level
            {
                get;
                set;
            } = 1;

            [JsonIgnore]
            public int Points
            {
                get
                {
                    return ( Trait.Points( Level ) );
                }
            }
        }

        public List<ArchetypeTrait> Traits
        {
            get;
            set;
        } = new List<ArchetypeTrait>();

        [JsonIgnore]
        public int Points
        {
            get
            {
                var costs = Costs.Get();

                int points = 0;

                points += costs.Movement.movementCost( MovementType );

                points += Profile.Points( Type );

                if( null != Traits )
                {
                    points += Traits.Sum( x => x.Points );
                }

                return ( points );
            }
        }

        [JsonIgnore]
        public float Weight
        {
            get
            {
                float typeMultiplicator = 0.0f;

                switch( Type )
                {
                    case EType.Infanterie:
                        typeMultiplicator = 17.5f;
                        break;

                    case EType.Koloss:
                        typeMultiplicator = 30.0f;
                        break;

                    case EType.Drohne:
                        typeMultiplicator = 10.0f;
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( EType ) );
                }

                float sizeMultiplicator = 0.0f;

                switch( Size )
                {
                    case ESize.Klein:
                        sizeMultiplicator = 0.7f;
                        break;

                    case ESize.Mittel:
                        sizeMultiplicator = 1.0f;
                        break;

                    case ESize.Groß:
                        sizeMultiplicator = 2.0f;
                        break;

                    case ESize.Riesig:
                        sizeMultiplicator = 3.0f;
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( ESize ) );
                }

                return ( Profile.Attributes.PHY * typeMultiplicator * sizeMultiplicator );
            }
        }

        [JsonIgnore]
        public float MaxLoadCapacity
        {
            get
            {
                return ( LoadCapacity.Max( Type, Profile.Attributes.PHY ) );
            }
        }

        [JsonIgnore]
        public string MaxQuantityString
        {
            get
            {
                if( MaxQuantity == 0 )
                {
                    return String.Empty;
                }
                else
                {
                    return MaxQuantity.ToString();
                }
            }
        }

        public int? DangerArea( AttributeModifier modifier )
        {
            if( Type == EType.Drohne )
            {
                return ( null );
            }
            else
            {
                int lengthDangerArea = Presets.MaxLengthDangerArea - Profile.Attributes.ModDET( modifier );

                if( lengthDangerArea < 0 )
                {
                    return ( 0 );
                }
                else
                {
                    return ( lengthDangerArea );
                }
            }
        }

        public int AreaOfPerception( AttributeModifier modifier )
        {
            return ( Presets.AreaOfPerceptionMultiplier * Profile.Attributes.ModAWA( modifier ) );
        }

        #region enums
        public enum ESize
        {
            Klein = 1,
            Mittel = 2,
            Groß = 3,
            Riesig = 4
        }

        public static readonly IList<ESize> ESizeList = Enum.GetValues( typeof( ESize ) ).Cast<ESize>().ToList().AsReadOnly();

        public enum EType
        {
            Infanterie = 1,
            Koloss = 2,
            Drohne = 3
        }

        public static readonly IList<EType> ETypeList = Enum.GetValues( typeof( EType ) ).Cast<EType>().ToList().AsReadOnly();

        public enum EMovementType
        {
            Stationär = 0,
            Schweben = 1,
            Beine = 2,
            Flug = 3,
            Kette = 4,
            Rad = 5
        }

        public static readonly IList<EMovementType> EMovementTypeList = Enum.GetValues( typeof( EMovementType ) ).Cast<EMovementType>().ToList().AsReadOnly();

        #endregion enums
    }
}
