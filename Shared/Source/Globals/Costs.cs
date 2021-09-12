using Newtonsoft.Json;
using System;

namespace Universalis
{
    public class Costs
    {
        public static void Initialize( Costs costs )
        {
            if( costs == null )
            {
                throw new ArgumentNullException( nameof( costs ) );
            }

            m_costs = costs;
        }

        public static Costs Get()
        {
            if( m_costs == null )
            {
                throw new InvalidOperationException( "Die Kosten wurden noch nicht initialisiert!" );
            }

            return ( m_costs );
        }

        private static Costs m_costs = null;

#region attributes

        // Agility / "Agilität"
        [JsonProperty]
        public int AGI
        {
            get;
            private set;
        }

        // Hand-To-Hand / "Nahkampf"
        [JsonProperty]
        public int HTH
        {
            get;
            private set;
        }

        // Long-Range-Combat / "Fernkampf"
        [JsonProperty]
        public int LRC
        {
            get;
            private set;
        }

        // Physique / "Konstitution"
        [JsonProperty]
        public int PHY
        {
            get;
            private set;
        }

        // Awareness / "Wahrnehmung"
        [JsonProperty]
        public int AWA
        {
            get;
            private set;
        }

        // Determination / "Entschlossenheit"
        [JsonProperty]
        public int DET
        {
            get;
            private set;
        }
#endregion attributes

#region profile and attribute
        [JsonProperty]
        public float ModifierSurcharge
        {
            get;
            private set;
        }
#endregion profile and attribute

#region profile
        [JsonProperty]
        public int Speed
        {
            get;
            private set;
        }

        [JsonProperty]
        public int HitPoints
        {
            get;
            private set;
        }
#endregion profile

#region archetype
        [JsonProperty]
        public int CritThreshold
        {
            get;
            private set;
        }
#endregion archetype

#region movement
        [JsonProperty]
        public int MovementHover
        {
            get;
            private set;
        }

        [JsonProperty]
        public int MovementFly
        {
            get;
            private set;
        }

        [JsonProperty]
        public int MovementWalk
        {
            get;
            private set;
        }

        [JsonProperty]
        public int MovementTracks
        {
            get;
            private set;
        }

        [JsonProperty]
        public int MovementWheels
        {
            get;
            private set;
        }

        [JsonProperty]
        public int MovementStationary
        {
            get;
            private set;
        }
#endregion movement

#region weapon
        [JsonProperty]
        public int WeaponStrength
        {
            get;
            private set;
        }

        [JsonProperty]
        public int WeaponDamage
        {
            get;
            private set;
        }

        [JsonProperty]
        public float WeaponDamageTypeLevelMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float WeaponUseOnceMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float WeaponUnwieldyMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float WeaponReloadMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float WeaponIndirectFireMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float WeaponDamageEffectMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float WeaponSustainedFireMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float WeaponAdditiveStrengthMultiplicator
        {
            get;
            private set;
        }
#endregion weapon

#region armor
        [JsonProperty]
        public int ArmorProtection
        {
            get;
            private set;
        }

        [JsonProperty]
        public float ArmorDamageTypeLevelMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float ArmorDamageEffectMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float ArmorSelfSustainingMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float ArmorAdditiveProtectionMultiplicator
        {
            get;
            private set;
        }
#endregion armor

#region equipment
        [JsonProperty]
        public float EquipmentUseOnceMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty]
        public float EquipmentUnwieldyMultiplicator
        {
            get;
            private set;
        }
#endregion equipment


        public int movementCost( Archetype.EMovementType movementType )
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
    }
}
