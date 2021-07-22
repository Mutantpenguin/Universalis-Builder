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
            HitPoints = profileModifier.HitPoints;

            AttributeModifier = new AttributeModifier( profileModifier.AttributeModifier );
        }

        public int Speed
        {
            get;
            set;
        }

        public int HitPoints
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
                HitPoints += modifier.HitPoints;

                AttributeModifier.Add( modifier.AttributeModifier );
            }
        }

        public int Points()
        {
            int points = 0;

            // TODO higher costs for modifiers?
            points += Speed * Costs.Speed;
            points += HitPoints * Costs.HitPoints;

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

            if( HitPoints != 0 )
            {
                text += $"Trefferpunkte {Formatter.Modifier( HitPoints )}";
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

        [JsonIgnore]
        public string HitPointsString
        {
            get
            {
                return ( Formatter.Modifier( HitPoints ) );
            }
        }
    }
}
