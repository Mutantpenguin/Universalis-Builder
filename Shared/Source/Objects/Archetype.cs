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
                Size != archetype.Size )
            {
                return( false );
            }

            return( true );
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

        [JsonIgnore]
        public float Weight
        {
            get
            {
                // TODO - calculate based on Type, Size and KO
                return (0.0f);
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
