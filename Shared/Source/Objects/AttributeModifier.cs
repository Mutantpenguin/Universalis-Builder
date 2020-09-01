using System;

namespace Universalis
{
    public class AttributeModifier
    {
        public static string Format( int attribute )
        {
            if( attribute == 0 )
            {
                return ( null );
            }
            else if( attribute > 0 )
            {
                return ( "+" + attribute );
            }
            else
            {
                return ( attribute.ToString() );
            }
        }

        public bool Equals( AttributeModifier attributeModifier )
        {
            if( null == attributeModifier )
            {
                throw new ArgumentNullException( nameof( attributeModifier ) );
            }

            if( AGI != attributeModifier.AGI
                ||
                BW != attributeModifier.BW
                ||
                KO != attributeModifier.KO
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
                text += $"AGI {Format( AGI )}";
            }

            if( BW != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"BW {Format( BW )}";
            }

            if( KO != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"KO {Format( KO )}";
            }

            if( FK != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"FK {Format( FK )}";
            }

            if( WN != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"WN {Format( WN )}";
            }

            if( EH != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"EH {Format( EH )}";
            }

            return ( text );
        }

        public void Add( AttributeModifier modifier )
        {
            if( null != modifier )
            {
                AGI += modifier.AGI;
                BW += modifier.BW;
                KO += modifier.KO;
                FK += modifier.FK;
                WN += modifier.WN;
                EH += modifier.EH;
            }
        }

        public int Points()
        {
            int points = 0;

            points += AGI * Costs.AGI;
            points += BW * Costs.BW;
            points += KO * Costs.KO;
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

        public int BW
        {
            get;
            set;
        }

        public int KO
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
    }
}