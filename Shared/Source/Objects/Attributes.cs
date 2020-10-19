
using System;

namespace Universalis
{
    public class Attributes
    {
        public Attributes()
        {
            AGI = 4;
            KO = 4;
            NK = 4;
            FK = 4;
            WN = 4;
            EH = 4;
        }

        public Attributes( Attributes attributes )
        {
            Set( attributes );
        }

        public void Set( Attributes attributes )
        {
            AGI = attributes.AGI;
            KO = attributes.KO;
            NK = attributes.NK;
            FK = attributes.FK;
            WN = attributes.WN;
            EH = attributes.EH;
        }

        public bool Equals( Attributes attributes )
        {
            if( AGI != attributes.AGI
                ||
                KO != attributes.KO
                ||
                NK != attributes.NK
                ||
                FK != attributes.FK
                ||
                WN != attributes.WN
                ||
                EH != attributes.EH )
            {
                return( false );
            }

            return( true );
        }

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

        public int ModAGI( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( AGI + modifier.AGI );
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
