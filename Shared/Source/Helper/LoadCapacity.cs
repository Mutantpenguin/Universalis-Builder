using System;

namespace Universalis
{
    class LoadCapacity
    {
        public static float Max( Profile.EType type, int phy )
        {
            switch( type )
            {
                case Profile.EType.Infanterie:
                case Profile.EType.Drohne:
                    return ( Convert.ToSingle( Math.Pow( phy, 2 ) ) );

                case Profile.EType.Koloss:
                    return ( Convert.ToSingle( Math.Pow( ( phy * Presets.ColossusLoadCapacityMultiplier ), 2 ) ) );

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
            }
        }
    }
}
