using Newtonsoft.Json;
using System;
using System.Drawing;

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

            Name = archetype.Name;
            Description = archetype.Description;
            Faction = archetype.Faction;

            Profile.Set( archetype.Profile );
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
                Faction != archetype.Faction )
            {
                return ( false );
            }

            if( !Profile.Equals( archetype.Profile ) )
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

        public Profile Profile
        {
            get;
            set;
        } = new Profile();

        #endregion members

        [JsonIgnore]
        public int Points
        {
            get
            {
                int points = 0;

                points += Profile.Points;

                return ( points );
            }
        }
    }
}
