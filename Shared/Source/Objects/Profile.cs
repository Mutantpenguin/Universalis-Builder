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
        } = EMovementType.Beine;

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
            Koloss = 3,
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

        [JsonIgnore]
        public int HitZoneHitPoints => ( Convert.ToInt32( Math.Ceiling( HitPoints * Presets.HitZoneHitPointsMultiplier ) ) );

        public int ModHitPoints( ProfileModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return ( HitPoints + modifier.HitPoints );
        }

        public int ModHitZoneHitPoints( ProfileModifier modifier )
        {
            return ( Convert.ToInt32( Math.Ceiling( ModHitPoints( modifier ) * Presets.HitZoneHitPointsMultiplier ) ) );
        }

        [JsonIgnore]
        public int Points
        {
            get
            {
                int points = 0;

                if( Type != Profile.EType.Drohne )
                {
                    points += Attributes.AGI * Costs.AGI;
                    points += Attributes.HTH * Costs.HTH;
                    points += Attributes.LRC * Costs.LRC;
                    points += Attributes.DET * Costs.DET;
                }

                points += Speed * Costs.Speed;

                points += Attributes.PHY * Costs.PHY;
                points += Attributes.AWA * Costs.AWA;

                switch( Type )
                {
                    case Profile.EType.Infanterie:
                    case Profile.EType.Drohne:
                        points += HitPoints * Costs.HitPoints;
                        break;

                    case Profile.EType.Koloss:
                        points += ( HitPoints * Costs.HitPoints ) + ( 3 * HitZoneHitPoints * Costs.HitPoints );
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
                }

                points += Costs.movementCost( MovementType );

                return ( points );
            }
        }

        [JsonIgnore]
        public float Weight
        {
            get
            {
                float typeMultiplicator = 0.0f;

                switch( Type )
                {
                    case EType.Infanterie:
                        typeMultiplicator = 17.5f;
                        break;

                    case EType.Koloss:
                        typeMultiplicator = 30.0f;
                        break;

                    case EType.Drohne:
                        typeMultiplicator = 10.0f;
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( EType ) );
                }

                float sizeMultiplicator = 0.0f;

                switch( Size )
                {
                    case ESize.Klein:
                        sizeMultiplicator = 0.7f;
                        break;

                    case ESize.Mittel:
                        sizeMultiplicator = 1.0f;
                        break;

                    case ESize.Groß:
                        sizeMultiplicator = 2.0f;
                        break;

                    case ESize.Riesig:
                        sizeMultiplicator = 3.0f;
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Profile.ESize ) );
                }

                return ( Attributes.PHY * typeMultiplicator * sizeMultiplicator );
            }
        }

        [JsonIgnore]
        public float MaxLoadCapacity
        {
            get
            {
                return ( LoadCapacity.Max( Type, Attributes.PHY ) );
            }
        }

        public int? DangerArea( AttributeModifier modifier )
        {
            if( Type == EType.Drohne )
            {
                return ( null );
            }
            else
            {
                int lengthDangerArea = Presets.MaxLengthDangerArea - Attributes.ModDET( modifier );

                if( lengthDangerArea < 0 )
                {
                    return ( 0 );
                }
                else
                {
                    return ( lengthDangerArea );
                }
            }
        }

        public int AreaOfPerception( AttributeModifier modifier )
        {
            return ( Presets.AreaOfPerceptionMultiplier * Attributes.ModAWA( modifier ) );
        }
    }
}
