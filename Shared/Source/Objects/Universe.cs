using Newtonsoft.Json;
using System;
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
                Version != universe.Version )
            {
                return ( false );
            }

            return ( true );
        }

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

        private static readonly string universeSettingsFilename = "universe.json";

        public static Universe Load( string universePath )
        {
            var universeSettingsPath = Path.Combine( universePath, universeSettingsFilename );

            if( !File.Exists( universeSettingsPath ) )
            {
                // TODO show message
                return ( null );
            }

            Universe universe = null;

            try
            {
                // TODO check against schema before trying to deserialize it

                universe = JsonConvert.DeserializeObject<Universe>( File.ReadAllText( universeSettingsPath ) );
            }
            catch( Exception ex )
            {
                // TODO
            }

            return ( universe );
        }
    }
}