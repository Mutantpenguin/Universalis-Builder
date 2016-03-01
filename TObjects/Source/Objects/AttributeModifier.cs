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

        public string ToToolTipString()
        {
            string text = String.Empty;

            if( AGI != 0 )
            {
                text += $"AGI: {Format( AGI )}{Environment.NewLine}";
            }

            if( BW != 0 )
            {
                text += $"BW: {Format( BW )}{Environment.NewLine}";
            }

            if( KK != 0 )
            {
                text += $"KK: {Format( KK )}{Environment.NewLine}";
            }

            if( HAK != 0 )
            {
                text += $"HAK: {Format( HAK )}{Environment.NewLine}";
            }

            if( AFG != 0 )
            {
                text += $"AFG: {Format( AFG )}{Environment.NewLine}";
            }

            if( SH != 0 )
            {
                text += $"SH: {Format( SH )}{Environment.NewLine}";
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
    }
}