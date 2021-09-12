using System;

namespace Universalis
{
    class LoadCapacity
    {
        public static float Max( Archetype.EType type, int phy )
        {
            switch( type )
            {
                case Archetype.EType.Infanterie:
                case Archetype.EType.Drohne:
                    return ( Convert.ToSingle( Math.Pow( phy, 2 ) ) );

                case Archetype.EType.Koloss:
                    return ( Convert.ToSingle( Math.Pow( ( phy * Presets.ColossusLoadCapacityMultiplier ), 2 ) ) );

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
            }
        }
    }
}
