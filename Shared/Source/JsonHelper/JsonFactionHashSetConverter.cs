using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Universalis
{
    internal class JsonFactionHashSetConverter : JsonConverter<HashSet<Faction>>
    {
        public override HashSet<Faction> ReadJson( JsonReader reader, Type objectType, HashSet<Faction> existingValue, bool hasExistingValue, JsonSerializer serializer )
        {
            if( reader == null )
            {
                throw new ArgumentNullException( nameof( reader ) );
            }

            JToken token = JToken.Load( reader );

            if( token.Type == JTokenType.Array )
            {
                var factionSet = new HashSet<Faction>();

                foreach( var id in token.ToObject<HashSet<string>>() )
                {
                    factionSet.Add( MasterDataStorage.Faction.Get( new Guid( id ) ) );
                }

                return ( factionSet );
            }
            else
            {
                return ( null );
            }
        }

        public override void WriteJson( JsonWriter writer, HashSet<Faction> value, JsonSerializer serializer )
        {
            if( writer == null )
            {
                throw new ArgumentNullException( nameof( writer ) );
            }

            if( null != value )
            {
                var outputSet = new HashSet<string>();

                foreach( var faction in ( value as HashSet<Faction> ) )
                {
                    outputSet.Add( faction.ID.ToString() );
                }

                serializer.Serialize( writer, outputSet );
            }
        }
    }
}