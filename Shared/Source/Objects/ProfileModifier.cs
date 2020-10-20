using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universalis
{
    public class ProfileModifier
    {
        public ProfileModifier()
        {
            AttributeModifier = new AttributeModifier();
        }

        public ProfileModifier( ProfileModifier profileModifier )
        {
            Speed = profileModifier.Speed;

            AttributeModifier = new AttributeModifier( profileModifier.AttributeModifier );
        }

        public int Speed
        {
            get;
            set;
        }

        public AttributeModifier AttributeModifier
        {
            get;
            set;
        }

        public void Add( ProfileModifier modifier )
        {
            if( null != modifier )
            {
                Speed += modifier.Speed;

                AttributeModifier.Add( modifier.AttributeModifier );
            }
        }

        public int Points()
        {
            int points = 0;

            points += Speed * Costs.Speed;

            if( AttributeModifier != null )
            {
                points += AttributeModifier.Points();
            }

            return( points );
        }

        public override string ToString()
        {
            string text = String.Empty;

            if( Speed != 0 )
            {
                text += $"Geschwindigkeit {Formatter.Modifier( Speed )}";
            }

            if( AttributeModifier != null )
            {
                string attributeModifierString = AttributeModifier.ToString();

                if( !String.IsNullOrEmpty( attributeModifierString ) )
                {
                    text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + attributeModifierString;
                }
            }

            return ( text );
        }

        [JsonIgnore]
        public string SpeedString
        {
            get
            {
                return ( Formatter.Modifier( Speed ) );
            }
        }
    }
}
