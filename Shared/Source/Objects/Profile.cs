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
            var attributeCosts = costs.Attributes;
            var profileCosts = costs.Profiles;

            int points = 0;

            if( type != Archetype.EType.Drohne )
            {
                points += Attributes.AGI * attributeCosts.AGI;
                points += Attributes.HTH * attributeCosts.HTH;
                points += Attributes.LRC * attributeCosts.LRC;
                points += Attributes.DET * attributeCosts.DET;
            }

            points += Speed * profileCosts.Speed;

            points += Attributes.PHY * attributeCosts.PHY;
            points += Attributes.AWA * attributeCosts.AWA;

            switch( type )
            {
                case Archetype.EType.Infanterie:
                case Archetype.EType.Drohne:
                    points += HitPoints * profileCosts.HitPoints;
                    break;

                case Archetype.EType.Koloss:
                    points += ( HitPoints * profileCosts.HitPoints ) + ( 3 * HitZoneHitPoints * profileCosts.HitPoints );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
            }

            return ( points );
        }
    }
}
