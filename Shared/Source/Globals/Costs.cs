using System;

namespace Universalis
{
    static class Costs
    {
        // Attributes
        public const int AGI = 10;
        public const int BW = 10;
        public const int KO = 10;
        public const int FK = 10;
        public const int WN = 10;
        public const int EH = 10;

        // Actor
        public const int Hitpoints = 15;

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

        // Weapon
        public const int WeaponStrength = 20;
        public const int WeaponDamage = 20;

        public const float WeaponUseOnceMultiplicator = 0.35f;
        public const float WeaponUnwieldyMultiplicator = 0.8f;
        public const float WeaponIndirectFireMultiplicator = 1.4f;

        public const float WeaponDamageEffectMultiplicator = 1.2f;
        public const float WeaponAFMultiplicator = 1.1f;
        public const float WeaponAdditiveStrengthMultiplicator = 1.2f;

        // Armor
        public const int ArmorProtection = 20;

        public const float ArmorDamageEffectMultiplicator = 1.2f;

        // Equipment
        public const float EquipmentUseOnceMultiplicator = 0.35f;
    }
}
