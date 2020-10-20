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
                throw new ArgumentNullException( nameof( archetype) );
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
                return( false );
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
        // TODO move to Profile?
        public float Weight
        {
            get
            {
                float typeMultiplicator = 0.0f;

                switch( this.Profile.Type )
                {
                    case Profile.EType.Infanterie:
                        typeMultiplicator = 17.5f;
                        break;

                    case Profile.EType.Koloss:
                    case Profile.EType.Mech:
                        typeMultiplicator = 30.0f;
                        break;

                    case Profile.EType.Drohne:
                        typeMultiplicator = 10.0f;
                        break;

                    case Profile.EType.Fahrzeug:
                        // TODO
                        typeMultiplicator = 50.0f;
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
                }

                float sizeMultiplicator = 0.0f;

                switch( this.Profile.Size )
                {
                    case Profile.ESize.Klein:
                        sizeMultiplicator = 0.5f;
                        break;

                    case Profile.ESize.Mittel:
                        sizeMultiplicator = 1.0f;
                        break;

                    case Profile.ESize.Groß:
                        sizeMultiplicator = 2.0f;
                        break;

                    case Profile.ESize.Riesig:
                        sizeMultiplicator = 3.0f;
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Profile.ESize ) );
                }

                return ( this.Profile.Attributes.KO * typeMultiplicator * sizeMultiplicator );
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
