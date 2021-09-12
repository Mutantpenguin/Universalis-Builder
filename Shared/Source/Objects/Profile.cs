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

        public int Points( Archetype.EType type )
        {
            var costs = Costs.Get();

            int points = 0;

            if( type != Archetype.EType.Drohne )
            {
                points += Attributes.AGI * costs.AGI;
                points += Attributes.HTH * costs.HTH;
                points += Attributes.LRC * costs.LRC;
                points += Attributes.DET * costs.DET;
            }

            points += Speed * costs.Speed;

            points += Attributes.PHY * costs.PHY;
            points += Attributes.AWA * costs.AWA;

            switch( type )
            {
                case Archetype.EType.Infanterie:
                case Archetype.EType.Drohne:
                    points += HitPoints * costs.HitPoints;
                    break;

                case Archetype.EType.Koloss:
                    points += ( HitPoints * costs.HitPoints ) + ( 3 * HitZoneHitPoints * costs.HitPoints );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
            }

            return ( points );
        }
    }
}
