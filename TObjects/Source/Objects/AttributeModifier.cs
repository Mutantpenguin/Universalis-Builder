using System;

namespace Tesserakt
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
                KK != attributeModifier.KK
                ||
                HAK != attributeModifier.HAK
                ||
                AFG != attributeModifier.AFG
                ||
                SH != attributeModifier.SH )
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

            if( KK != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"KK {Format( KK )}";
            }

            if( HAK != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"HAK {Format( HAK )}";
            }

            if( AFG != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"AFG {Format( AFG )}";
            }

            if( SH != 0 )
            {
                text += ( String.IsNullOrEmpty( text ) ? null : ", " ) + $"SH {Format( SH )}";
            }

            return ( text );
        }

        public void Add( AttributeModifier modifier )
        {
            if( null != modifier )
            {
                AGI += modifier.AGI;
                BW += modifier.BW;
                KK += modifier.KK;
                HAK += modifier.HAK;
                AFG += modifier.AFG;
                SH += modifier.SH;
            }
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

        public int KK
        {
            get;
            set;
        }

        public int HAK
        {
            get;
            set;
        }

        public int AFG
        {
            get;
            set;
        }

        public int SH
        {
            get;
            set;
        }
        #endregion attributes
    }
}