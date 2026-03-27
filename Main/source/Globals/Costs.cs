using System;

namespace Universalis
{
    public static class Costs
    {
        public static class Attribute
        {
            // Agility / "Agilität"
            public static int AGI = 30;

            // Hand-To-Hand / "Nahkampf"
            public static int HTH = 20;

            // Long-Range-Combat / "Fernkampf"
            public static int LRC = 20;

            // Physique / "Konstitution"
            public static int PHY = 30;

            // Awareness / "Wahrnehmung"
            public static int AWA = 20;

            // Determination / "Entschlossenheit"
            public static int DET = 20;
        }

        public static class Profile
        {
            public static int Speed = 10;
            public static int HitPoints = 30;
            public static int CritThreshold = 15;
        }

        public static class Modifier
        {
            public static float Surcharge = 1.2f;
        }

        public static class Movement
        {
            public static int Hover = 100;
            public static int Fly = 80;
            public static int Walk = 50;
            public static int Tracks = 70;
            public static int Wheels = 70;
            public static int Stationary = 0;

            public static int movementCost( Archetype.EMovementType movementType ) 
            {
                switch( movementType )
                {
                    case Archetype.EMovementType.Schweben:
                        return Hover;

                    case Archetype.EMovementType.Flug:
                        return Fly;

                    case Archetype.EMovementType.Beine:
                        return Walk;

                    case Archetype.EMovementType.Kette:
                        return Tracks;

                    case Archetype.EMovementType.Rad:
                        return Wheels;

                    case Archetype.EMovementType.Stationär:
                        return Stationary;

                    default:
                        throw new ArgumentException( "unkown movementType", nameof( movementType ) );
                }
            }
        }

        public static class Weapon
        {
            public static int Strength = 10;
            public static int Damage = 20;
            public static float UseOnceMultiplicator = 0.35f;
            public static float UnwieldyMultiplicator = 0.8f;
            public static float ReloadMultiplicator = 0.7f;
            public static float IndirectFireMultiplicator = 1.4f;
            public static float DamageEffectMultiplicator = 1.1f;
            public static float SustainedFireMultiplicator = 1.4f;
            public static float AdditiveStrengthMultiplicator = 1.2f;
        }

        public static class Armor
        {
            public static int Protection = 10;
            public static int DamageReduction = 50;
            public static float DamageEffectMultiplicator = 1.1f;
            public static float SelfSustainingMultiplicator = 1.3f;
            public static float AdditiveProtectionMultiplicator = 1.2f;
        }
    }
}
