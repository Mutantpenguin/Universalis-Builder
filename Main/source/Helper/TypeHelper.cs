using System;
using System.Drawing;

namespace Universalis
{
    class TypeHelper
    {
        public static Image GetImage( Archetype.EType type )
        {
            switch( type )
            {
                case Archetype.EType.Standard:
                    return Properties.ResourcesActorCard.Standard;

                case Archetype.EType.Koloss:
                    return Properties.ResourcesActorCard.Koloss;

                case Archetype.EType.Begleiter:
                    return Properties.ResourcesActorCard.Begleiter;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
            }
        }
    }
}