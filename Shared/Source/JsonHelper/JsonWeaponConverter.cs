using Newtonsoft.Json;
using System;

namespace Universalis
{
    internal class JsonWeaponConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( Weapon ) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if( reader == null )
            {
                throw new ArgumentNullException( nameof( reader ) );
            }

            if( null != reader.Value )
            {
                return ( MasterDataStorage.Weapon.Get( new Guid( (string)reader.Value ) ) );
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
                writer.WriteValue( ( (Weapon)value ).ID );
            }
        }
    }
}