using Newtonsoft.Json;
using System;
using System.Drawing;

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

            Active = faction.Active;

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

            if( Active != faction.Active
                ||
                Name != faction.Name
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

        public string Type
        {
            get;
            set;
        }

        [JsonConverter( typeof( JsonJpegConverter ) )]
        public Bitmap Icon
        {
            get;
            set;
        } = Shared.Properties.Resources.empty_faction;
    }
}