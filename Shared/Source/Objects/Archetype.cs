using Newtonsoft.Json;
using System;

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
            Rules = archetype.Rules;
            AdditionalPoints = archetype.AdditionalPoints;
            Size = archetype.Size;
            MovementType = archetype.MovementType;
            Type = archetype.Type;
            MaxQuantity = archetype.MaxQuantity;

            Profile.Set( archetype.Profile );

            if (null != archetype.FactionPermissions)
            {
                FactionPermissions = new PermissionSet<Faction>(archetype.FactionPermissions);
            }
            else
            {
                FactionPermissions = null;
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
                Rules != archetype.Rules
                ||
                AdditionalPoints != archetype.AdditionalPoints
                ||
                Size != archetype.Size
                ||
                MovementType != archetype.MovementType
                ||
                Type != archetype.Type
                ||
                MaxQuantity != archetype.MaxQuantity )
            {
                return false;
            }

            if( !Profile.Equals( archetype.Profile ) )
            {
                return false;
            }

            if (((null != FactionPermissions) && (null == archetype.FactionPermissions))
                ||
                ((null == FactionPermissions) && (null != archetype.FactionPermissions)))
            {
                return false;
            }
            else if ((null != FactionPermissions) && (null != archetype.FactionPermissions))
            {
                if (!FactionPermissions.Equals(archetype.FactionPermissions))
                {
                    return false;
                }
            }

            return true;
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

        public string Rules
        {
            get;
            set;
        } = String.Empty;

        public int AdditionalPoints
        {
            get;
            set;
        } = 0;

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

        public PermissionSet<Faction> FactionPermissions
        {
            get;
            set;
        }

        #endregion members

        [JsonIgnore]
        public int Points
        {
            get
            {
                var costs = Costs.Get();

                int points = 0;

                points += AdditionalPoints;

                points += costs.Movement.movementCost( MovementType );

                points += Profile.Points( Type );

                return points;
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

                    case EType.Telematon:
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

                return Profile.Attributes.PHY * typeMultiplicator * sizeMultiplicator;
            }
        }

        [JsonIgnore]
        public float MaxLoadCapacity
        {
            get
            {
                return LoadCapacity.Max( Type, Profile.Attributes.PHY );
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
            if( Type == EType.Telematon )
            {
                return null;
            }
            else
            {
                int lengthDangerArea = Presets.MaxLengthDangerArea - Profile.Attributes.ModDET( modifier );

                if( lengthDangerArea < 0 )
                {
                    return 0;
                }
                else
                {
                    return lengthDangerArea;
                }
            }
        }

        public int AreaOfPerception( AttributeModifier modifier )
        {
            return Presets.AreaOfPerceptionMultiplier * Profile.Attributes.ModAWA( modifier );
        }

        public string Summary()
        {
            string text = String.Empty;

            if(!String.IsNullOrEmpty( Rules ))
            {
                text += ( !String.IsNullOrEmpty( text ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + "Regeln:" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( Rules );
            }

            if(!String.IsNullOrEmpty( Description ))
            {
                text += ( !String.IsNullOrEmpty( text ) ? Environment.NewLine + Environment.NewLine : String.Empty ) + "Beschreibung:" + Environment.NewLine + ToolTipHelper.FormatMaxWidth( Description );
            }

            return text;
        }

        #region enums
        public enum ESize
        {
            Klein = 1,
            Mittel = 2,
            Groß = 3,
            Riesig = 4
        }

        public enum EType
        {
            Infanterie = 1,
            Koloss = 2,
            Telematon = 3
        }

        public enum EMovementType
        {
            Stationär = 0,
            Schweben = 1,
            Beine = 2,
            Flug = 3,
            Kette = 4,
            Rad = 5
        }

        #endregion enums
    }
}
