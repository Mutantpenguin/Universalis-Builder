using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Universalis
{
    [JsonObject( ItemNullValueHandling = NullValueHandling.Ignore )]
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
                return false;
            }

            return true;
        }

        public String NameWithVersion()
        {
            return Name + ( String.IsNullOrEmpty( Version ) ? String.Empty : " - " + Version );
        }

        public String NameWithVersionAndHash()
        {
            return Name + ( String.IsNullOrEmpty( Version ) ? String.Empty : " - " + Version ) + ( String.IsNullOrEmpty( CommitHash ) ? String.Empty : " - " + CommitHash.Substring( 0, 8 ) );
        }

        [JsonProperty( "id" )]
        public Guid ID
        {
            get;
            set;
        } = Guid.NewGuid();

        [JsonProperty( "name" )]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty( "description" )]
        public string Description
        {
            get;
            set;
        } = String.Empty;

        [JsonProperty( "version" )]
        public string Version
        {
            get;
            set;
        }

        [JsonProperty( "author" )]
        public string Author
        {
            get;
            set;
        }

        [JsonProperty( "contact" )]
        public string Contact
        {
            get;
            set;
        }

        [JsonProperty( "website" )]
        public string Website
        {
            get;
            set;
        }

        [JsonProperty( "costs", Required = Required.Always )]
        public Costs Costs
        {
            get;
            set;
        } = new Costs();

        [JsonIgnore]
        public Image Logo
        {
            get;
            set;
        }

        [JsonIgnore]
        public string CommitHash
        {
            get;
            set;
        }

        [JsonIgnore]
        public bool Modified
        {
            get;
            set;
        }

        private static readonly string universeSettingsFilename = "universe.json";

        public static (Universe, string) Load( string universePath )
        {
            var universeSettingsPath = Path.Combine( universePath, universeSettingsFilename );

            if( !File.Exists( universeSettingsPath ) )
            {
                return (null, "Die Einstellungsdatei für dieses Universum existiert nicht.");
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

        public static string Create( string universePath )
        {
            var universeID = Guid.NewGuid();

            var universeDirectoryPath = Path.Combine( universePath, universeID.ToString() );

            var universeFullPath = Path.Combine( universeDirectoryPath, Universe.universeSettingsFilename );

            var universe = new Universe()
            {
                ID = universeID,
                Name = "Neues Universum - " + DateTime.Now.ToString()
            };

            Directory.CreateDirectory( universeDirectoryPath );

            File.WriteAllText( universeFullPath, JsonConvert.SerializeObject( universe, Storage.formatting ) );

            return universeFullPath;
        }
    }
}