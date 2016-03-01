using Newtonsoft.Json;
using System;
using System.Linq;

namespace Tesserakt
{
    internal class JsonActorOutfitConverter : JsonConverter
    {
        public override bool CanConvert( Type objectType )
        {
            return ( objectType == typeof( Actor.ActorOutfit ) );
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if( reader == null )
            {
                throw new ArgumentNullException( nameof( reader ) );
            }

            if( null != reader.Value )
            {
                Guid guid = new Guid( (string)reader.Value );
                return ( ActorStorage.Instance.Actors.SelectMany( x => x.ActorOutfitsList ).FirstOrDefault( y => y.ID == guid ) );
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
                writer.WriteValue( ( (Actor.ActorOutfit)value ).ID );
            }
        }
    }
}