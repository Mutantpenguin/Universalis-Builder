
using System;

namespace Universalis
{
    public class Attributes
    {
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

        public int ModAGI( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( AGI + modifier.AGI );
        }

        public int ModBW( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( BW + modifier.BW );
        }

        public int ModKK( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( KK + modifier.KK );
        }

        public int ModHAK( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( HAK + modifier.HAK );
        }

        public int ModAFG( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( AFG + modifier.AFG );
        }

        public int ModSH( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( SH + modifier.SH );
        }
    }
}
