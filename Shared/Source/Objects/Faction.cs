using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Universalis
{
    public class Faction
    {
        public Faction() { }

        public Faction( Faction faction )
        {
            Set( faction );
        }

        public void Set( Faction faction )
        {
            if( null == faction )
            {
                throw new ArgumentNullException( nameof( faction ) );
            }

            Name = faction.Name;
            Description = faction.Description;
            Icon = faction.Icon;
            Type = faction.Type;
        }

        public bool Equals( Faction faction )
        {
            if( null == faction )
            {
                throw new ArgumentNullException( nameof( faction ) );
            }

            if( Name != faction.Name
                ||
                Description != faction.Description
                ||
                Icon != faction.Icon
                ||
                Type != faction.Type )
            {
                return ( false );
            }

            return ( true );
        }

        public enum EType
        {
            Unbekannt = 0,
            Terrestrisch = 1,
            Extraterrestrisch = 2
        }

        public static readonly IList<EType> ETypeList = Enum.GetValues( typeof( EType ) ).Cast<EType>().ToList().AsReadOnly();

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

        public EType Type
        {
            get;
            set;
        } = EType.Unbekannt;

        [JsonConverter( typeof( JsonImageConverter ) )]
        public Bitmap Icon
        {
            get;
            set;
        } = Shared.Properties.Resources.empty;
    }
}