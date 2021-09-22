using Newtonsoft.Json;
using System;

namespace Universalis
{
    public class AttributeModifier
    {
        public AttributeModifier()
        { }

        public AttributeModifier( AttributeModifier attributeModifier )
        {
            AGI = attributeModifier.AGI;
            HTH = attributeModifier.HTH;
            LRC = attributeModifier.LRC;
            PHY = attributeModifier.PHY;
            AWA = attributeModifier.AWA;
            DET = attributeModifier.DET;
        }

        public bool Equals( AttributeModifier attributeModifier )
        {
            if( null == attributeModifier )
            {
                throw new ArgumentNullException( nameof( attributeModifier ) );
            }

            if( AGI != attributeModifier.AGI
                ||
                HTH != attributeModifier.HTH
                ||
                LRC != attributeModifier.LRC
                ||
                PHY != attributeModifier.PHY
                ||
                AWA != attributeModifier.AWA
                ||
                DET != attributeModifier.DET )
            {
                return ( false );
            }

            return ( true );
        }

        public override string ToString()
        {
            string text = String.Empty;

            if( AGI != 0 )
            {
                text += $"AGI {Formatter.Modifier( AGI )}";
            }

            if( HTH != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"NK {Formatter.Modifier( HTH )}";
            }

            if( LRC != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"FK {Formatter.Modifier( LRC )}";
            }

            if( PHY != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"KO {Formatter.Modifier( PHY )}";
            }

            if( AWA != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"WN {Formatter.Modifier( AWA )}";
            }

            if( DET != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"EH {Formatter.Modifier( DET )}";
            }

            return ( text );
        }

        public void Add( AttributeModifier modifier )
        {
            if( null != modifier )
            {
                AGI += modifier.AGI;
                HTH += modifier.HTH;
                LRC += modifier.LRC;
                PHY += modifier.PHY;
                AWA += modifier.AWA;
                DET += modifier.DET;
            }
        }

        public int Points()
        {
            var costs = Costs.Get();
            var attributeCosts = costs.Attributes;
            var modifierCosts = costs.Modifier;

            int points = 0;

            points += AGI * Convert.ToInt32( attributeCosts.AGI * modifierCosts.Surcharge );
            points += HTH * Convert.ToInt32( attributeCosts.HTH * modifierCosts.Surcharge );
            points += LRC * Convert.ToInt32( attributeCosts.LRC * modifierCosts.Surcharge );
            points += PHY * Convert.ToInt32( attributeCosts.PHY * modifierCosts.Surcharge );
            points += AWA * Convert.ToInt32( attributeCosts.AWA * modifierCosts.Surcharge );
            points += DET * Convert.ToInt32( attributeCosts.DET * modifierCosts.Surcharge );

            return ( points );
        }

        #region attributes
        /// <summary>
        /// Agility / "Agilität"
        /// </summary>
        public int AGI
        {
            get;
            set;
        }

        /// <summary>
        /// Hand-To-Hand / "Nahkampf"
        /// </summary>
        public int HTH
        {
            get;
            set;
        }

        /// <summary>
        /// Long-Range-Combat / "Fernkampf"
        /// </summary>
        public int LRC
        {
            get;
            set;
        }

        /// <summary>
        /// Physique / "Konstitution"
        /// </summary>
        public int PHY
        {
            get;
            set;
        }

        /// <summary>
        /// Awareness / "Wahrnehmung"
        /// </summary>
        public int AWA
        {
            get;
            set;
        }

        /// <summary>
        /// Determination / "Entschlossenheit"
        /// </summary>
        public int DET
        {
            get;
            set;
        }
        #endregion attributes

        #region attribute_strings

        [JsonIgnore]
        public string AGIString => Formatter.Modifier( AGI );

        [JsonIgnore]
        public string HTHString => Formatter.Modifier( HTH );

        [JsonIgnore]
        public string LRCString => Formatter.Modifier( LRC );

        [JsonIgnore]
        public string PHYString => Formatter.Modifier( PHY );

        [JsonIgnore]
        public string AWAString => Formatter.Modifier( AWA );

        [JsonIgnore]
        public string DETString => Formatter.Modifier( DET );

        #endregion attribute_strings
    }
}