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

        public class AttributeCosts
        {
            // Agility / "Agilität"
            [JsonProperty( Required = Required.Always )]
            public int AGI
            {
                get;
                private set;
            }

            // Hand-To-Hand / "Nahkampf"
            [JsonProperty( Required = Required.Always )]
            public int HTH
            {
                get;
                private set;
            }

            // Long-Range-Combat / "Fernkampf"
            [JsonProperty( Required = Required.Always )]
            public int LRC
            {
                get;
                private set;
            }

            // Physique / "Konstitution"
            [JsonProperty( Required = Required.Always )]
            public int PHY
            {
                get;
                private set;
            }

            // Awareness / "Wahrnehmung"
            [JsonProperty( Required = Required.Always )]
            public int AWA
            {
                get;
                private set;
            }

            // Determination / "Entschlossenheit"
            [JsonProperty( Required = Required.Always )]
            public int DET
            {
                get;
                private set;
            }
        }

        public class ProfileCosts
        {
            [JsonProperty( Required = Required.Always )]
            public int Speed
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public int HitPoints
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public int CritThreshold
            {
                get;
                private set;
            }
        }

        public class ModifierCosts
        {
            [JsonProperty( Required = Required.Always )]
            public float Surcharge
            {
                get;
                private set;
            }
        }

        public class MovementCosts
        {
            [JsonProperty( Required = Required.Always )]
            public int Hover
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public int Fly
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public int Walk
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public int Tracks
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public int Wheels
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public int Stationary
            {
                get;
                private set;
            }

            public int movementCost( Archetype.EMovementType movementType ) 
            {
                switch( movementType )
                {
                    case Archetype.EMovementType.Schweben:
                        return ( Hover );

                    case Archetype.EMovementType.Flug:
                        return ( Fly );

                    case Archetype.EMovementType.Beine:
                        return ( Walk );

                    case Archetype.EMovementType.Kette:
                        return ( Tracks );

                    case Archetype.EMovementType.Rad:
                        return ( Wheels );

                    case Archetype.EMovementType.Stationär:
                        return ( Stationary );

                    default:
                        throw new ArgumentException( "unkown movementType", nameof( movementType ) );
                }
            }
        }

        public class WeaponCosts
        {
            [JsonProperty( Required = Required.Always )]
            public int Strength
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public int Damage
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float DamageTypeLevelMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float UseOnceMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float UnwieldyMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float ReloadMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float IndirectFireMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float DamageEffectMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float SustainedFireMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float AdditiveStrengthMultiplicator
            {
                get;
                private set;
            }
        }

        public class ArmorCosts
        {
            [JsonProperty( Required = Required.Always )]
            public int Protection
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float DamageTypeLevelMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float DamageEffectMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float SelfSustainingMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float AdditiveProtectionMultiplicator
            {
                get;
                private set;
            }
        }

        public class EquipmentCosts
        {
            [JsonProperty( Required = Required.Always )]
            public float UseOnceMultiplicator
            {
                get;
                private set;
            }

            [JsonProperty( Required = Required.Always )]
            public float UnwieldyMultiplicator
            {
                get;
                private set;
            }
        }

        public class TraitCosts
        {
            [JsonProperty( Required = Required.Always )]
            public float UseOnceMultiplicator
            {
                get;
                private set;
            }
        }

        [JsonProperty( Required = Required.Always )]
        public AttributeCosts Attributes
        {
            get;
            private set;
        } = new AttributeCosts();
        
        [JsonProperty( Required = Required.Always )]
        public ProfileCosts Profiles
        {
            get;
            private set;
        } = new ProfileCosts();
        
        [JsonProperty( Required = Required.Always )]
        public ModifierCosts Modifier
        {
            get;
            private set;
        } = new ModifierCosts();
        
        [JsonProperty( Required = Required.Always )]
        public MovementCosts Movement
        {
            get;
            private set;
        } = new MovementCosts();
        
        [JsonProperty( Required = Required.Always )]
        public WeaponCosts Weapons
        {
            get;
            private set;
        } = new WeaponCosts();
        
        [JsonProperty( Required = Required.Always )]
        public ArmorCosts Armors
        {
            get;
            private set;
        } = new ArmorCosts();
        
        [JsonProperty( Required = Required.Always )]
        public EquipmentCosts Equipment
        {
            get;
            private set;
        } = new EquipmentCosts();
        
        [JsonProperty( Required = Required.Always )]
        public TraitCosts Traits
        {
            get;
            private set;
        } = new TraitCosts();
    }
}
