using System;
using System.Drawing;

namespace Universalis
{
    class SizeHelper
    {
        public static Image GetImage( Archetype.ESize size )
        {
            switch( size )
            {
                case Archetype.ESize.Klein:
                    return Properties.ResourcesActorCard.klein;

                case Archetype.ESize.Mittel:
                    return Properties.ResourcesActorCard.mittel;

                case Archetype.ESize.Groß:
                    return Properties.ResourcesActorCard.groß;

                case Archetype.ESize.Riesig:
                    return Properties.ResourcesActorCard.riesig;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Archetype.ESize ) );
            }
        }
    }
}