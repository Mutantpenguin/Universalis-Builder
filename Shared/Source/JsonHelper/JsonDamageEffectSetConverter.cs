using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Universalis
{
    internal class JsonDamageEffectSetConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( HashSet<DamageEffect> ) );
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
                var damageEffectSet = new HashSet<DamageEffect>();

                foreach( var id in token.ToObject<HashSet<string>>() )
                {
                    damageEffectSet.Add( MasterDataStorage.DamageEffect.Get( new Guid( id ) ) );
                }

                return ( damageEffectSet );
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
                var outputSet = new HashSet<string>();

                foreach( var damageEffect in ( value as HashSet<DamageEffect> ) )
                {
                    outputSet.Add( damageEffect.ID.ToString() );
                }

                serializer.Serialize( writer, outputSet );
            }
        }
    }
}