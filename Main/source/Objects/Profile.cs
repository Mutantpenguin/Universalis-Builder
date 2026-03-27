using Newtonsoft.Json;
using System;

namespace Universalis
{
    public class Profile
    {
        public bool Equals( Profile profile )
        {
            if( Speed != profile.Speed
                ||
                HitPoints != profile.HitPoints
                ||
                CritThreshold != profile.CritThreshold )
            {
                return false;
            }

            if( !Attributes.Equals( profile.Attributes ) )
            {
                return false;
            }

            return true;
        }

        public void Set( Profile profile )
        {
            Speed = profile.Speed;
            HitPoints = profile.HitPoints;
            CritThreshold = profile.CritThreshold;

            Attributes = new Attributes( profile.Attributes );
        }

        #region members

        public float Speed
        {
            get;
            set;
        } = 1.5f;

        public int HitPoints
        {
            get;
            set;
        } = 5;

        public int CritThreshold
        {
            get;
            set;
        } = 50;

        public Attributes Attributes
        {
            get;
            set;
        } = new Attributes();

        #endregion

        public float ModSpeed( ProfileModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return Speed + modifier.Speed;
        }

        [JsonIgnore]
        public int HitZoneHitPoints => ( Convert.ToInt32( Math.Ceiling( HitPoints * Presets.HitZoneHitPointsMultiplier ) ) );

        public int ModHitPoints( ProfileModifier modifier )
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return HitPoints + modifier.HitPoints;
        }

        public int ModCritThreshold( ProfileModifier modifier)
        {
            if( modifier == null )
            {
                throw new ArgumentNullException( nameof( modifier ) );
            }

            return CritThreshold + modifier.CritThreshold;
        }

        public int ModHitZoneHitPoints( ProfileModifier modifier )
        {
            return Convert.ToInt32( Math.Ceiling( ModHitPoints( modifier ) * Presets.HitZoneHitPointsMultiplier ) );
        }

        public int Points( Archetype.EType type )
        {
            int points = 0;

            if( type != Archetype.EType.Begleiter )
            {
                points += Attributes.AGI * Costs.Attribute.AGI;
                points += Attributes.HTH * Costs.Attribute.HTH;
                points += Attributes.LRC * Costs.Attribute.LRC;
                points += Attributes.DET * Costs.Attribute.DET;
            }

            points += Convert.ToInt32( Speed * 2 * Costs.Profile.Speed );

            points += Attributes.PHY * Costs.Attribute.PHY;
            points += Attributes.AWA * Costs.Attribute.AWA;

            switch( type )
            {
                case Archetype.EType.Standard:
                case Archetype.EType.Begleiter:
                    points += HitPoints * Costs.Profile.HitPoints;
                    break;

                case Archetype.EType.Koloss:
                    points += ( HitPoints * Costs.Profile.HitPoints ) + ( 3 * HitZoneHitPoints * Costs.Profile.HitPoints );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
            }

            points += (CritThreshold - 50) * Costs.Profile.CritThreshold;

            return points;
        }
    }
}
