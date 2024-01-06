using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Universalis
{
    internal class JsonPngConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return objectType == typeof( Image );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if( reader == null )
            {
                throw new ArgumentNullException( nameof( reader ) );
            }

            if( null != reader.Value )
            {
                return ImageBase64Helper.Base64ToImage( (string)reader.Value );
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

            writer.WriteValue( ImageBase64Helper.PngToBase64( (Image)value ) );
        }
    }
}