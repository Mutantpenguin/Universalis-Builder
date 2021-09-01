using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Universalis
{
    internal class JsonEquipmentListConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( List<Equipment> ) );
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
                var equipmentList = new List<Equipment>();

                foreach( var id in token.ToObject<List<string>>() )
                {
                    equipmentList.Add( MasterDataStorage.Equipment.Get( new Guid( id ) ) );
                }

                return ( equipmentList );
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

                foreach( var equipment in ( value as List<Equipment> ) )
                {
                    outputList.Add( equipment.ID.ToString() );
                }

                serializer.Serialize( writer, outputList );
            }
        }
    }
}