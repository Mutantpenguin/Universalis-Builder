using System;

namespace Universalis
{
    static class Costs
    {
        // Attributes
        public const int AGI = 10; // Agility           / "Agilität"
        public const int HTH = 10; // Hand-To-Hand      / "Nahkampf"
        public const int LRC = 10; // Long-Range-Combat / "Fernkampf"
        public const int PHY = 15; // Physique          / "Konstitution"
        public const int AWA = 10; // Awareness         / "Wahrnehmung"
        public const int DET = 10; // Determination     / "Entschlossenheit"

        // Actor
        public const int Speed = 10;
        public const int HitPoints = 15;

        public const int FOV = 2;

        public static int movementCost( EMovementType movementType )
        {
            switch( movementType )
            {
                case EMovementType.Schweben:
                    return ( 100 );

                case EMovementType.Flug:
                    return ( 80 );

                case EMovementType.Beine:
                    return ( 50 );

                case EMovementType.Kette:
                    return ( 70 );

                case EMovementType.Rad:
                    return ( 70 );

                case EMovementType.Stationär:
                    return ( 0 );

                default:
                    throw new ArgumentException( "unkown movementType", nameof( movementType ) );
            }
        }

        // Weapon
        public const int WeaponStrength = 10;
        public const int WeaponDamage = 20;

        public const float WeaponDamageTypeLevelMultiplicator = 1.4f;

        public const float WeaponUseOnceMultiplicator = 0.35f;
        public const float WeaponUnwieldyMultiplicator = 0.8f;
        public const float WeaponReloadMultiplicator = 0.7f;
        public const float WeaponIndirectFireMultiplicator = 1.4f;

        public const float WeaponDamageEffectMultiplicator = 1.1f;
        public const float WeaponSustainedFireMultiplicator = 1.1f;
        public const float WeaponAdditiveStrengthMultiplicator = 1.2f;

        // Armor
        public const int ArmorProtection = 10;

        public const float ArmorDamageTypeLevelMultiplicator = 1.3f;

        public const float ArmorDamageEffectMultiplicator = 1.1f;

        public const float ArmorSelfSustainingMultiplicator = 1.3f;

        public const float ArmorAdditiveProtectionMultiplicator = 1.2f;

        // Equipment
        public const float EquipmentUseOnceMultiplicator = 0.35f;
        public const float EquipmentUnwieldyMultiplicator = 0.8f;

        // Traits
        public const float TraitsModifier = 1.1f;
    }
}
