
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

        public int ModKO( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( KO + modifier.KO );
        }

        public int ModNK( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( NK + modifier.NK );
        }

        public int ModFK( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( FK + modifier.FK );
        }

        public int ModWN( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( WN + modifier.WN );
        }

        public int ModEH( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( EH + modifier.EH );
        }
    }
}
