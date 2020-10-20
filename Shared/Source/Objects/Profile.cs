using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
                ( Type != profile.Type )
                ||
                ( Fov != profile.Fov ) )
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
            Fov = profile.Fov;

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

        public EFieldOfView Fov
        {
            get;
            set;
        } = EFieldOfView._90;

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

        [JsonIgnore]
        public int HitZoneHitPoints => ( Convert.ToInt32( Math.Ceiling( HitPoints * Presets.HitZoneHitPointsMultiplier ) ) );

        public int Points()
        {
            int points = 0;

            if( Type != Profile.EType.Drohne )
            {
                points += Attributes.AGI * Costs.AGI;
                points += Attributes.NK * Costs.NK;
                points += Attributes.FK * Costs.FK;
                points += Attributes.EH * Costs.EH;
            }

            // TODO no BW anymore, just Speed
            // points += Attributes.BW * Costs.Speed;

            points += Attributes.KO * Costs.KO;
            points += Attributes.WN * Costs.WN;

            switch( Type )
            {
                case Profile.EType.Infanterie:
                case Profile.EType.Drohne:
                case Profile.EType.Fahrzeug: // TODO implement completely different HitZones for vehicles? like chassis, engine and so on?
                    points += HitPoints * Costs.HitPoints;
                    break;

                case Profile.EType.Mech:
                case Profile.EType.Koloss:
                    points += ( HitPoints * Costs.HitPoints ) + ( 3 * HitZoneHitPoints * Costs.HitPoints );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
            }

            points += (int)Fov * Costs.FOV;

            points += Costs.movementCost( MovementType );

            return ( points );
        }
    }
}
