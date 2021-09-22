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
        [JsonProperty(Required = Required.Always)]
        public int AGI
        {
            get;
            private set;
        }

        // Hand-To-Hand / "Nahkampf"
        [JsonProperty(Required = Required.Always)]
        public int HTH
        {
            get;
            private set;
        }

        // Long-Range-Combat / "Fernkampf"
        [JsonProperty(Required = Required.Always)]
        public int LRC
        {
            get;
            private set;
        }

        // Physique / "Konstitution"
        [JsonProperty(Required = Required.Always)]
        public int PHY
        {
            get;
            private set;
        }

        // Awareness / "Wahrnehmung"
        [JsonProperty(Required = Required.Always)]
        public int AWA
        {
            get;
            private set;
        }

        // Determination / "Entschlossenheit"
        [JsonProperty(Required = Required.Always)]
        public int DET
        {
            get;
            private set;
        }
#endregion attributes

#region profile and attribute
        [JsonProperty(Required = Required.Always)]
        public float ModifierSurcharge
        {
            get;
            private set;
        }
#endregion profile and attribute

#region profile
        [JsonProperty(Required = Required.Always)]
        public int Speed
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public int HitPoints
        {
            get;
            private set;
        }
#endregion profile

#region archetype
        [JsonProperty(Required = Required.Always)]
        public int CritThreshold
        {
            get;
            private set;
        }
#endregion archetype

#region movement
        [JsonProperty(Required = Required.Always)]
        public int MovementHover
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public int MovementFly
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public int MovementWalk
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public int MovementTracks
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public int MovementWheels
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public int MovementStationary
        {
            get;
            private set;
        }
#endregion movement

#region weapon
        [JsonProperty(Required = Required.Always)]
        public int WeaponStrength
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public int WeaponDamage
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float WeaponDamageTypeLevelMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float WeaponUseOnceMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float WeaponUnwieldyMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float WeaponReloadMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float WeaponIndirectFireMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float WeaponDamageEffectMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float WeaponSustainedFireMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float WeaponAdditiveStrengthMultiplicator
        {
            get;
            private set;
        }
#endregion weapon

#region armor
        [JsonProperty(Required = Required.Always)]
        public int ArmorProtection
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float ArmorDamageTypeLevelMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float ArmorDamageEffectMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float ArmorSelfSustainingMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float ArmorAdditiveProtectionMultiplicator
        {
            get;
            private set;
        }
#endregion armor

#region equipment
        [JsonProperty(Required = Required.Always)]
        public float EquipmentUseOnceMultiplicator
        {
            get;
            private set;
        }

        [JsonProperty(Required = Required.Always)]
        public float EquipmentUnwieldyMultiplicator
        {
            get;
            private set;
        }
        #endregion equipment

#region trait
        [JsonProperty(Required = Required.Always)]
        public float TraitUseOnceMultiplicator
        {
            get;
            private set;
        }
#endregion

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
