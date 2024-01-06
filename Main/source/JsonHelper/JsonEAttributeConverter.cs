using Newtonsoft.Json;
using System;
using System.Linq;

namespace Source.JsonHelper
{
    internal class JsonEAttributeConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return objectType == typeof( Universalis.Power.EAttribute );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if( reader == null )
            {
                throw new ArgumentNullException( nameof( reader ) );
            }

            if( null != reader.Value )
            {
                return Universalis.Power.AttributeMapping.FirstOrDefault( x => x.Value == (string)reader.Value ).Key;
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
                writer.WriteValue( Universalis.Power.AttributeMapping[(Universalis.Power.EAttribute)value] );
            }
        }
    }
}