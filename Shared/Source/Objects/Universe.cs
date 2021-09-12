using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Universalis
{
    public class Universe
    {
        public Universe() { }

        public Universe( Universe universe )
        {
            Set( universe );
        }

        public void Set( Universe universe )
        {
            if( null == universe )
            {
                throw new ArgumentNullException( nameof( universe ) );
            }

            Name = universe.Name;
            Description = universe.Description;
            Version = universe.Version;
            Author = universe.Author;
            Contact = universe.Contact;
            Website = universe.Website;
        }

        public bool Equals( Universe universe )
        {
            if( null == universe )
            {
                throw new ArgumentNullException( nameof( universe ) );
            }

            if( Name != universe.Name
                ||
                Description != universe.Description
                ||
                Version != universe.Version
                ||
                Author != universe.Author
                ||
                Contact != universe.Contact
                ||
                Website != universe.Website )
            {
                return ( false );
            }

            return ( true );
        }

        public String NameWithVersion()
        {
            return ( Name + ( String.IsNullOrEmpty( Version ) ? String.Empty : " - " + Version ) );
        }

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

        public string Version
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public string Contact
        {
            get;
            set;
        }

        public string Website
        {
            get;
            set;
        }

        [JsonIgnore]
        public Image Logo
        {
            get;
            set;
        }

        private static readonly string universeSettingsFilename = "universe.json";

        public static (Universe,string) Load( string universePath )
        {
            var universeSettingsPath = Path.Combine( universePath, universeSettingsFilename );

            if( !File.Exists( universeSettingsPath ) )
            {
                return ( null, "Die Einstellungsdatei für dieses Universum existiert nicht." );
            }

            try
            {
                var universeSchema = JSchema.Parse( Shared.Properties.Resources.schema_universe );

                JObject universeJObject = JObject.Parse( File.ReadAllText( universeSettingsPath ) );

                if( !universeJObject.IsValid( universeSchema, out IList<string> errorMessages ) )
                {
                    return (null, String.Join( ", ", errorMessages ));
                }
                else
                {
                    var universe = universeJObject.ToObject<Universe>();

                    return (universe, null);
                }
            }
            catch( Exception ex )
            {
                return (null, ex.Message);
            }
        }
    }
}