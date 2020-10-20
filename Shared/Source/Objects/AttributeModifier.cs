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
            KO = attributeModifier.KO;
            NK = attributeModifier.NK;
            FK = attributeModifier.FK;
            WN = attributeModifier.WN;
            EH = attributeModifier.EH;
        }

        public bool Equals( AttributeModifier attributeModifier )
        {
            if( null == attributeModifier )
            {
                throw new ArgumentNullException( nameof( attributeModifier ) );
            }

            if( AGI != attributeModifier.AGI
                ||
                KO != attributeModifier.KO
                ||
                NK != attributeModifier.NK
                ||
                FK != attributeModifier.FK
                ||
                WN != attributeModifier.WN
                ||
                EH != attributeModifier.EH )
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

            if( KO != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"KO {Formatter.Modifier( KO )}";
            }

            if( NK != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"NK {Formatter.Modifier( NK )}";
            }

            if( FK != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"FK {Formatter.Modifier( FK )}";
            }

            if( WN != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"WN {Formatter.Modifier( WN )}";
            }

            if( EH != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"EH {Formatter.Modifier( EH )}";
            }

            return ( text );
        }

        public void Add( AttributeModifier modifier )
        {
            if( null != modifier )
            {
                AGI += modifier.AGI;
                KO += modifier.KO;
                NK += modifier.NK;
                FK += modifier.FK;
                WN += modifier.WN;
                EH += modifier.EH;
            }
        }

        public int Points()
        {
            int points = 0;

            points += AGI * Costs.AGI;
            points += KO * Costs.KO;
            points += NK * Costs.NK;
            points += FK * Costs.FK;
            points += WN * Costs.WN;
            points += EH * Costs.EH;

            return ( points );
        }

        #region attributes
        public int AGI
        {
            get;
            set;
        }

        public int KO
        {
            get;
            set;
        }

        public int NK
        {
            get;
            set;
        }

        public int FK
        {
            get;
            set;
        }

        public int WN
        {
            get;
            set;
        }

        public int EH
        {
            get;
            set;
        }
        #endregion attributes

        #region attribute_strings

        [JsonIgnore]
        public string AGIString
        {
            get
            {
                return ( Formatter.Modifier( AGI ) );
            }
        }

        [JsonIgnore]
        public string KOString
        {
            get
            {
                return ( Formatter.Modifier( KO ) );
            }
        }

        [JsonIgnore]
        public string NKString
        {
            get
            {
                return ( Formatter.Modifier( NK ) );
            }
        }

        [JsonIgnore]
        public string FKString
        {
            get
            {
                return ( Formatter.Modifier( FK ) );
            }
        }

        [JsonIgnore]
        public string WNString
        {
            get
            {
                return ( Formatter.Modifier( WN ) );
            }
        }

        [JsonIgnore]
        public string EHString
        {
            get
            {
                return ( Formatter.Modifier( EH ) );
            }
        }

        #endregion attribute_strings
    }
}