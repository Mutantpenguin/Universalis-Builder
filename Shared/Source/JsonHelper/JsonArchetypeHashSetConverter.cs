using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Universalis
{
    internal class JsonArchetypeHashSetConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return objectType == typeof( HashSet<Archetype> );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if( reader == null )
            {
                throw new ArgumentNullException( nameof( reader ) );
            }

            JToken token = JToken.Load( reader );

            if( token.Type == JTokenType.Array )
            {
                var archetypeSet = new HashSet<Archetype>();

                foreach( var id in token.ToObject<HashSet<string>>() )
                {
                    archetypeSet.Add( MasterDataStorage.Archetype.Get( new Guid( id ) ) );
                }

                return archetypeSet;
            }
            else
            {
                return null;
            }
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            if( writer == null )
            {
                throw new ArgumentNullException( nameof( writer ) );
            }

            if( null != value )
            {
                var outputSet = new HashSet<string>();

                foreach( var archetype in ( value as HashSet<Archetype> ) )
                {
                    outputSet.Add( archetype.ID.ToString() );
                }

                serializer.Serialize( writer, outputSet );
            }
        }
    }
}