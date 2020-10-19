using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universalis
{
    public class Profile
    {
        public bool Equals( Profile profile )
        {
            if( ( Speed != profile.Speed )
                ||
                ( Size != profile.Size )
                ||
                ( HitPoints != profile.HitPoints )
                ||
                ( MovementType != profile.MovementType )
                ||
                ( Type != profile.Type ) )
            {
                return( false );
            }

            if( !Attributes.Equals( profile.Attributes ) )
            {
                return( false );
            }

            return( true );
        }

        public void Set( Profile profile )
        {
            Speed = profile.Speed;
            Size = profile.Size;
            HitPoints = profile.HitPoints;
            MovementType = profile.MovementType;
            Type = profile.Type;

            Attributes = new Attributes( profile.Attributes );
        }

        #region members

        public int Speed
        {
            get;
            set;
        } = 4;

        public ESize Size
        {
            get;
            set;
        } = ESize.Mittel;

        public int HitPoints
        {
            get;
            set;
        } = 5;

        public EMovementType MovementType
        {
            get;
            set;
        } = EMovementType.Fuss;

        public EType Type
        {
            get;
            set;
        } = EType.Infanterie;

        public enum ESize
        {
            Klein = 1,
            Mittel = 2,
            Groß = 3,
            Riesig = 4
        }

        public static readonly IList<ESize> ESizeList = Enum.GetValues( typeof( ESize ) ).Cast<ESize>().ToList().AsReadOnly();

        public enum EType
        {
            Infanterie = 1,
            Mech = 2,
            Koloss = 3,
            Fahrzeug = 4,
            Drohne = 5
        }

        public static readonly IList<EType> ETypeList = Enum.GetValues( typeof( EType ) ).Cast<EType>().ToList().AsReadOnly();


        public Attributes Attributes
        {
            get;
            set;
        } = new Attributes();

        #endregion

        public int ModSpeed( ProfileModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( Speed + modifier.Speed );
        }

        public int ModHitPoints( ProfileModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( HitPoints + modifier.HitPoints );
        }
    }
}
