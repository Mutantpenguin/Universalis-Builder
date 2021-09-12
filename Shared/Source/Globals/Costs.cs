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

        // Profile and Attribute modifier
        public const float ModifierSurcharge = 1.2f;

        // Actor
        public const int Speed = 10;
        public const int HitPoints = 15;
        public const int Crit = 15;

        // Movement
        private const int MovementHover = 100;
        private const int MovementFly = 80;
        private const int MovementWalk = 50;
        private const int MovementTracks = 70;
        private const int MovementWheels = 70;
        private const int MovementStationary = 0;

        public static int movementCost( Archetype.EMovementType movementType )
        {
            switch( movementType )
            {
                case Archetype.EMovementType.Schweben:
                    return ( MovementHover );

                case Archetype.EMovementType.Flug:
                    return ( MovementFly );

                case Archetype.EMovementType.Beine:
                    return ( MovementWalk );

                case Archetype.EMovementType.Kette:
                    return ( MovementTracks );

                case Archetype.EMovementType.Rad:
                    return ( MovementWheels );

                case Archetype.EMovementType.Stationär:
                    return ( MovementStationary );

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
    }
}
