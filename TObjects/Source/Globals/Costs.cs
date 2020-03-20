using System;

namespace Universalis
{
    static class Costs
    {
        public const int AGI = 10;
        public const int BW = 10;
        public const int KO = 10;
        public const int FK = 10;
        public const int WN = 10;
        public const int EH = 10;

        public const int TP = 15;

        public const int FOV = 2;

        public static int movementCost( EMovementType movementType )
        {
            switch( movementType )
            {
                case EMovementType.Antigrav:
                    return ( 500 );

                case EMovementType.Flug:
                    return ( 400 );

                case EMovementType.Fuss:
                    return ( 300 );

                case EMovementType.Kette:
                    return ( 200 );

                case EMovementType.Rad:
                    return ( 100 );

                case EMovementType.Stationär:
                    return ( 0 );

                default:
                    throw new ArgumentException( "unkown movementType", nameof( movementType ) );
            }
        }
    }
}
