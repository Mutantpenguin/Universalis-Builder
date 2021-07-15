using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Universalis
{
    internal class JsonDamageEffectListConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( List<DamageEffect> ) );
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
                var damageEffectList = new List<DamageEffect>();

                foreach( var id in token.ToObject<List<string>>() )
                {
                    damageEffectList.Add( MasterDataStorage.DamageEffect.Get( new Guid( id ) ) );
                }

                return ( damageEffectList );
            }
            else
            {
                return ( null );
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
                var outputList = new List<string>();

                foreach( var damageEffect in ( value as List<DamageEffect> ) )
                {
                    outputList.Add( damageEffect.ID.ToString() );
                }

                serializer.Serialize( writer, outputList );
            }
        }
    }
}