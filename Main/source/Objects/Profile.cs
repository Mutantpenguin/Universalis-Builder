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
                HitPoints != profile.HitPoints )
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

            Attributes = new Attributes( profile.Attributes );
        }

        #region members

        public int Speed
        {
            get;
            set;
        } = 4;

        public int HitPoints
        {
            get;
            set;
        } = 5;

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

        public int ModHitZoneHitPoints( ProfileModifier modifier )
        {
            return Convert.ToInt32( Math.Ceiling( ModHitPoints( modifier ) * Presets.HitZoneHitPointsMultiplier ) );
        }

        public int Points( Archetype.EType type )
        {
            int points = 0;

            if( type != Archetype.EType.Telematon )
            {
                points += Attributes.AGI * Costs.Attribute.AGI;
                points += Attributes.HTH * Costs.Attribute.HTH;
                points += Attributes.LRC * Costs.Attribute.LRC;
                points += Attributes.DET * Costs.Attribute.DET;
            }

            points += Speed * Costs.Profile.Speed;

            points += Attributes.PHY * Costs.Attribute.PHY;
            points += Attributes.AWA * Costs.Attribute.AWA;

            switch( type )
            {
                case Archetype.EType.Standard:
                case Archetype.EType.Telematon:
                    points += HitPoints * Costs.Profile.HitPoints;
                    break;

                case Archetype.EType.Koloss:
                    points += ( HitPoints * Costs.Profile.HitPoints ) + ( 3 * HitZoneHitPoints * Costs.Profile.HitPoints );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
            }

            return points;
        }
    }
}
