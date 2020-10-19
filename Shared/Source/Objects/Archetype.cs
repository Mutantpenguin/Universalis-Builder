using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Universalis
{
    public class Archetype
    {
        public Archetype() {}

        public Archetype( Archetype archetype )
        {
            Set( archetype );
        }

        public void Set( Archetype archetype )
        {
            if( null == archetype )
            {
                throw new ArgumentNullException( nameof( archetype) );
            }

            Name = archetype.Name;
            Description = archetype.Description;
            Faction = archetype.Faction;
            Size = archetype.Size;
            HitPoints = archetype.HitPoints;
            MovementType = archetype.MovementType;
            Type = archetype.Type;

            Attributes = new Attributes
            {
                AGI = archetype.Attributes.AGI,
                BW = archetype.Attributes.BW,
                KO = archetype.Attributes.KO,
                NK = archetype.Attributes.NK,
                FK = archetype.Attributes.FK,
                WN = archetype.Attributes.WN,
                EH = archetype.Attributes.EH
            };
        }

        public bool Equals( Archetype archetype )
        {
            if( null == archetype )
            {
                throw new ArgumentNullException( nameof( archetype ) );
            }

            if( Name != archetype.Name
                ||
                Description != archetype.Description
                ||
                Faction != archetype.Faction
                ||
                Size != archetype.Size
                ||
                HitPoints != archetype.HitPoints
                ||
                MovementType != archetype.MovementType
                ||
                Type != archetype.Type )
            {
                return( false );
            }

            if( Attributes.AGI != archetype.Attributes.AGI
                ||
                Attributes.BW != archetype.Attributes.BW
                ||
                Attributes.KO != archetype.Attributes.KO
                ||
                Attributes.NK != archetype.Attributes.NK
                ||
                Attributes.FK != archetype.Attributes.FK
                ||
                Attributes.WN != archetype.Attributes.WN
                ||
                Attributes.EH != archetype.Attributes.EH )
            {
                return ( false );
            }

            return ( true );
        }

#region members

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
        } = "Bitte Beschreibung eingeben";

        [JsonConverter( typeof( JsonFactionConverter ) )]
        public Faction Faction
        {
            get;
            set;
        }

        public ESize Size
        {
            get;
            set;
        } = ESize.Mittel;

        public int HitPoints
        {
            get;
            set;
        } = 5;

        public EMovementType MovementType
        {
            get;
            set;
        } = EMovementType.Fuss;

        #endregion members

        public EType Type
        {
            get;
            set;
        } = EType.Infanterie;

        public enum ESize
        {
            Klein = 1,
            Mittel = 2,
            Groß = 3,
            Riesig = 4
        }

        public static readonly IList<ESize> ESizeList = Enum.GetValues(typeof(ESize)).Cast<ESize>().ToList().AsReadOnly();

        public enum EType
        {
            Infanterie = 1,
            Mech = 2,
            Koloss = 3,
            Fahrzeug = 4,
            Drohne = 5
        }

        public static readonly IList<EType> ETypeList = Enum.GetValues(typeof(EType)).Cast<EType>().ToList().AsReadOnly();

        public Attributes Attributes
        {
            get;
            set;
        } = new Attributes
        {
            AGI = 4,
            BW = 4,
            KO = 4,
            NK = 4,
            FK = 4,
            WN = 4,
            EH = 4
        };

        [JsonIgnore]
        public float Weight
        {
            get
            {
                float typeMultiplicator = 0.0f;

                switch( this.Type )
                {
                    case EType.Infanterie:
                        typeMultiplicator = 17.5f;
                        break;

                    case EType.Koloss:
                    case EType.Mech:
                        typeMultiplicator = 30.0f;
                        break;

                    case EType.Drohne:
                        typeMultiplicator = 10.0f;
                        break;

                    case EType.Fahrzeug:
                        // TODO
                        typeMultiplicator = 50.0f;
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( EType ) );
                }

                float sizeMultiplicator = 0.0f;

                switch( this.Size )
                {
                    case ESize.Klein:
                        sizeMultiplicator = 0.5f;
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

                return ( this.Attributes.KO * typeMultiplicator * sizeMultiplicator );
            }
        }

        [JsonIgnore]
        public Bitmap FactionIcon
        {
            get
            {
                if( null != Faction )
                {
                    return( Faction.Icon );
                }
                else
                {
                    return( null );
                }
            }
        }
    }
}
