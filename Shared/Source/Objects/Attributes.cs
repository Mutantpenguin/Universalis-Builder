
using System;

namespace Universalis
{
    public class Attributes
    {
        public Attributes()
        {
            AGI = 4;
            HTH = 4;
            LRC = 4;
            PHY = 4;
            AWA = 4;
            DET = 4;
        }

        public Attributes( Attributes attributes )
        {
            Set( attributes );
        }

        public void Set( Attributes attributes )
        {
            AGI = attributes.AGI;
            HTH = attributes.HTH;
            LRC = attributes.LRC;
            PHY = attributes.PHY;
            AWA = attributes.AWA;
            DET = attributes.DET;
        }

        public bool Equals( Attributes attributes )
        {
            if( AGI != attributes.AGI
                ||
                HTH != attributes.HTH
                ||
                LRC != attributes.LRC
                ||
                PHY != attributes.PHY
                ||
                AWA != attributes.AWA
                ||
                DET != attributes.DET )
            {
                return( false );
            }

            return( true );
        }

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

        #region modified

        public int ModAGI( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( AGI + modifier.AGI );
        }

        public int ModHTH( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( HTH + modifier.HTH );
        }

        public int ModLRC( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( LRC + modifier.LRC );
        }

        public int ModPHY( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( PHY + modifier.PHY );
        }

        public int ModAWA( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( AWA + modifier.AWA );
        }

        public int ModDET( AttributeModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( DET + modifier.DET );
        }

        #endregion modified
    }
}
