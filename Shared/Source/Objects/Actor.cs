using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Universalis
{
    public class Actor
    {
        public Actor() {}

        public Actor( Actor actor, bool withOutfitID )
            : this()
        {
            Set( actor, withOutfitID );
        }

        public bool Equals( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            if( Name != actor.Name
                ||
                Description != actor.Description
                ||
                Faction != actor.Faction )
            {
                return ( false );
            }
            
            if( Archetype != actor.Archetype )
            {
                return ( false );
            }

            if( Icon != actor.Icon
                ||
                Img != actor.Img )
            {
                return ( false );
            }

            if( Armor != actor.Armor )
            {
                return ( false );
            }

            foreach( ActorOutfit actorOutfit in ActorOutfitsList )
            {
                if( actor.ActorOutfitsList.Find( x => x.Equals( actorOutfit ) ) == null )
                {
                    return ( false );
                }
            }

            foreach( ActorOutfit actorOutfit in actor.ActorOutfitsList )
            {
                if( ActorOutfitsList.Find( x => x.Equals( actorOutfit ) ) == null )
                {
                    return ( false );
                }
            }

            foreach( ActorTrait actorTrait in ActorTraitsList )
            {
                if( actor.ActorTraitsList.Find( x => x.Equals( actorTrait ) ) == null )
                {
                    return ( false );
                }
            }

            foreach( ActorTrait actorTrait in actor.ActorTraitsList )
            {
                if( ActorTraitsList.Find( x => x.Equals( actorTrait ) ) == null )
                {
                    return ( false );
                }
            }

            return ( true );
        }

        public void SetWithOutfitID( Actor actor )
        {
            Set( actor, withOutfitID: true );
        }

        public void Set( Actor actor )
        {
            Set( actor, withOutfitID: false );
        }

        private void Set( Actor actor, bool withOutfitID )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            Name = actor.Name;

            Description = actor.Description;

            Faction = actor.Faction;

            Archetype = actor.Archetype;

            Icon = actor.Icon;

            Img = actor.Img;

            if( null != ActorOutfitsList )
            {
                ActorOutfitsList.Clear();
            }
            else
            {
                ActorOutfitsList = new List<ActorOutfit>();
            }

            if( null != actor.ActorOutfitsList )
            {
                foreach( ActorOutfit actorOutfit in actor.ActorOutfitsList )
                {
                    ActorOutfitsList.Add( new ActorOutfit( actorOutfit, withOutfitID ) );
                }
            }

            Armor = actor.Armor;

            if( null != ActorTraitsList )
            {
                ActorTraitsList.Clear();
            }
            else
            {
                ActorTraitsList = new List<ActorTrait>();
            }

            if( null != actor.ActorTraitsList )
            {
                foreach( ActorTrait actorTrait in actor.ActorTraitsList )
                {
                    ActorTraitsList.Add( new ActorTrait( actorTrait ) );
                }
            }
        }

        public Guid ID
        {
            get;
            set;
        } = Guid.NewGuid();

        public string Name
        {
            get;
            set;
        } = "Bitte Namen eingeben";

        public string Description
        {
            get;
            set;
        } = "Bitte Beschreibung eingeben";

        [JsonConverter( typeof( JsonImageConverter ) )]
        public Bitmap Icon
        {
            get;
            set;
        } = Shared.Properties.Resources.empty;

        [ JsonIgnore]
        public Bitmap FactionIcon
        {
            get
            {
                if( null != Faction )
                {
                    return ( Faction.Icon );
                }
                else
                {
                    return ( null );
                }
            }
        }

        public class ActorOutfit
        {
            public ActorOutfit() { }

            public ActorOutfit( ActorOutfit actorOutfit, bool withOutfitID )
                : this()
            {
                Set( actorOutfit, withOutfitID );
            }

            private void Set( ActorOutfit actorOutfit, bool withOutfitID )
            {
                if( null == actorOutfit )
                {
                    throw new ArgumentNullException( nameof( actorOutfit ) );
                }

                if( withOutfitID )
                {
                    ID = actorOutfit.ID;
                }

                Name = actorOutfit.Name;

                if( null != ActorWeaponsList )
                {
                    ActorWeaponsList.Clear();
                }
                else
                {
                    ActorWeaponsList = new List<ActorWeapon>();
                }

                if( null != actorOutfit.ActorWeaponsList )
                {
                    foreach( ActorWeapon actorWeapon in actorOutfit.ActorWeaponsList )
                    {
                        ActorWeaponsList.Add( actorWeapon );
                    }
                }

                if( null != ActorEquipmentList )
                {
                    ActorEquipmentList.Clear();
                }
                else
                {
                    ActorEquipmentList = new List<ActorEquipment>();
                }

                if( null != actorOutfit.ActorEquipmentList )
                {
                    foreach( ActorEquipment actorEquipment in actorOutfit.ActorEquipmentList )
                    {
                        ActorEquipmentList.Add( actorEquipment );
                    }
                }
            }

            public bool Equals( ActorOutfit actorOutfit )
            {
                if( null == actorOutfit )
                {
                    throw new ArgumentNullException( nameof( actorOutfit ) );
                }

                if( Name != actorOutfit.Name )
                {
                    return ( false );
                }

                if( ActorWeaponsList.Except( actorOutfit.ActorWeaponsList ).Any()
                    ||
                    actorOutfit.ActorWeaponsList.Except( ActorWeaponsList ).Any() )
                {
                    return ( false );
                }

                if( ActorEquipmentList.Except( actorOutfit.ActorEquipmentList ).Any()
                    ||
                    actorOutfit.ActorEquipmentList.Except( ActorEquipmentList ).Any() )
                {
                    return ( false );
                }

                return ( true );
            }

            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            public string Name
            {
                get;
                set;
            } = "Bitte Namen eingeben";

            [JsonIgnore]
            public int Points
            {
                get
                {
                    int points = 0;

                    if( null != ActorWeaponsList )
                    {
                        points += ActorWeaponsList.Sum( x => x.Points );
                    }

                    if( null != ActorEquipmentList )
                    {
                        points += ActorEquipmentList.Sum( x => x.Points );
                    }

                    return ( points );
                }
            }

            public List<ActorWeapon> ActorWeaponsList
            {
                get;
                set;
            } = new List<ActorWeapon>();

            public List<ActorEquipment> ActorEquipmentList
            {
                get;
                set;
            } = new List<ActorEquipment>();
        }

        public class ActorTrait
        {
            public ActorTrait() {}

            public ActorTrait( ActorTrait actorTrait )
            {
                if( null == actorTrait )
                {
                    throw new ArgumentNullException( nameof( actorTrait ) );
                }

                Trait = actorTrait.Trait;
                Level = actorTrait.Level;
            }

            public bool Equals( ActorTrait actorTrait )
            {
                if( null == actorTrait )
                {
                    throw new ArgumentNullException( nameof( actorTrait ) );
                }

                if( Trait != actorTrait.Trait
                    ||
                    Level != actorTrait.Level )
                {
                    return ( false );
                }

                return ( true );
            }

            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            public TraitLevel.ELevel Level
            {
                get;
                set;
            }

            [JsonConverter( typeof( JsonActorTraitConverter ) )]
            public Trait Trait
            {
                get;
                set;
            }

            [JsonIgnore]
            public string Name => ( Trait.Name );

            [JsonIgnore]
            public int Points => ( Trait.Points( Level ) );

            [JsonIgnore]
            public string Type => ( Trait.Type );
        }

        public class ActorWeapon
        {
            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            [JsonConverter( typeof( JsonActorWeaponConverter ) )]
            public Weapon Weapon
            {
                get;
                set;
            }

            [JsonIgnore]
            public string Name => ( Weapon.Name );

            [JsonIgnore]
            public float Weight => ( Weapon.Weight );

            [JsonIgnore]
            public int Points => ( Weapon.Points );
        }

        public class ActorEquipment
        {
            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            [JsonConverter( typeof( JsonActorEquipmentConverter ) )]
            public Equipment Equipment
            {
                get;
                set;
            }

            [JsonIgnore]
            public string Name => ( Equipment.Name );

            [JsonIgnore]
            public float Weight => ( Equipment.Weight );

            [JsonIgnore]
            public int Points => ( Equipment.Points );
        }

        #region members

        [JsonConverter( typeof( JsonFactionConverter ) )]
        public Faction Faction
        {
            get;
            set;
        }

        public List<ActorOutfit> ActorOutfitsList
        {
            get;
            set;
        } = new List<ActorOutfit>();

        [JsonConverter( typeof( JsonArmorConverter ) )]
        public Armor Armor
        {
            get;
            set;
        }

        public List<ActorTrait> ActorTraitsList
        {
            get;
            set;
        } = new List<ActorTrait>();
        
        public Archetype Archetype
        {
            get;
            set;
        }

        [JsonConverter( typeof( JsonImageConverter ) )]
        public Bitmap Img
        {
            get;
            set;
        } = null;
#endregion members

#region attributes
        public int? ModAGI( ActorOutfit actorOutfit )
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                return ( Archetype.Profile.Attributes.ModAGI( CurrentProfileModifier( actorOutfit ).AttributeModifier ) - ModLoadModifier( actorOutfit ) );
            }
        }

        public int ModSpeed( ActorOutfit actorOutfit )
        {
            return ( Archetype.Profile.ModSpeed( CurrentProfileModifier( actorOutfit ) ) - ModLoadModifier( actorOutfit ) );
        }

        public int ModKO( ActorOutfit actorOutfit )
        {
            return ( Archetype.Profile.Attributes.ModKO( CurrentProfileModifier( actorOutfit ).AttributeModifier ) );
        }

        public int? ModNK( ActorOutfit actorOutfit )
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                return ( Archetype.Profile.Attributes.ModNK( CurrentProfileModifier( actorOutfit ).AttributeModifier ) );
            }
        }
        public int? ModFK( ActorOutfit actorOutfit )
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                return ( Archetype.Profile.Attributes.ModFK( CurrentProfileModifier( actorOutfit ).AttributeModifier ) );
            }
        }

        public int ModWN( ActorOutfit actorOutfit )
        {
            return ( Archetype.Profile.Attributes.ModWN( CurrentProfileModifier( actorOutfit ).AttributeModifier ) );
        }

        public int? ModEH( ActorOutfit actorOutfit )
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                return ( Archetype.Profile.Attributes.ModEH( CurrentProfileModifier( actorOutfit ).AttributeModifier ) );
            }
        }
#endregion attributes

#region calculated values
        public int? ModDangerArea( ActorOutfit actorOutfit )
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                int lengthDangerArea = Presets.MaxLengthDangerArea - Archetype.Profile.Attributes.ModEH( CurrentProfileModifier( actorOutfit ).AttributeModifier );

                if( lengthDangerArea < 0 )
                {
                    return ( 0 );
                }
                else
                {
                    return ( lengthDangerArea );
                }
            }
        }

        public int ModAreaOfPerception( ActorOutfit actorOutfit )
        {
            return ( Presets.AreaOfPerceptionMultiplier * Archetype.Profile.Attributes.ModWN( CurrentProfileModifier( actorOutfit ).AttributeModifier ) );
        }

        public static string ThrowRange( int attributeKO )
        {
            return( $"{attributeKO * Presets.throwRangeLengthMultiplier}/{Presets.throwRangeAmount}" );
        }

        public float ModMaxLoadCapacity( ActorOutfit actorOutfit )
        {
            int modKO = Archetype.Profile.Attributes.ModKO( CurrentProfileModifier( actorOutfit ).AttributeModifier );

            switch( this.Archetype.Profile.Type )
            {
                case Profile.EType.Infanterie:
                case Profile.EType.Drohne:
                    return ( Convert.ToSingle( Math.Pow( modKO, 2 ) ) );

                case Profile.EType.Mech:
                    return ( Convert.ToSingle( Math.Pow( ( modKO * Presets.MechLoadCapacityMultiplier ), 2 ) ) );

                case Profile.EType.Koloss:
                    return ( Convert.ToSingle( Math.Pow( ( modKO * Presets.ColossusLoadCapacityMultiplier ), 2 ) ) );

                case Profile.EType.Fahrzeug:
                    return ( Convert.ToSingle( Math.Pow( ( modKO * Presets.FahrzeugLoadCapacityMultiplier ), 2 ) ) );

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
            }
        }

        public float LoadoutWeight( ActorOutfit actorOutfit, bool withSelfSustaining )
        {
            float loadoutWeight = 0.0f;

            if( actorOutfit != null )
            {
                loadoutWeight += actorOutfit.ActorWeaponsList.Sum( x => x.Weight );
                loadoutWeight += actorOutfit.ActorEquipmentList.Sum( x => x.Weight );
            }

            if( null != Armor )
            {
                if( withSelfSustaining )
                {
                    loadoutWeight += Armor.Weight;
                }
                else
                {
                    if( !Armor.SelfSustaining )
                    {
                        loadoutWeight += Armor.Weight;
                    }
                }
            }

            return ( loadoutWeight );
        }

        private int ModLoadModifier( ActorOutfit actorOutfit )
        {
            int loadModifier = Convert.ToInt32( Math.Ceiling( LoadoutWeight( actorOutfit, withSelfSustaining: false ) / ModMaxLoadCapacity( actorOutfit ) ) );

            if( loadModifier > 0 )
            {
                return ( loadModifier - 1 );
            }
            else
            {
                return ( 0 );
            }
        }

        public Weapon WeaponUnarmed( ActorOutfit actorOutfit )
        {
            if( ( this.Archetype.Profile.Type == Profile.EType.Fahrzeug )
                ||
                ( this.Archetype.Profile.Type == Profile.EType.Drohne ) )
            {
                return ( null );
            }
            else
            {
                Weapon weaponUnarmed = new Weapon()
                {
                    Type = Weapon.EType.Nahkampf,
                    Name = "Unbewaffnet",
                    Strength = ModKO( actorOutfit ),
                    Damage = Convert.ToInt32( Math.Round( ModKO( actorOutfit ) / 3.0f, 0 ) )
                };

                switch( this.Archetype.Profile.Type )
                {
                    case Profile.EType.Infanterie:
                        weaponUnarmed.WK = Weapon.EClass.I;
                        weaponUnarmed.DamageType = new DamageType()
                        {
                            Type = DamageType.EType.Schlag,
                            Level = DamageType.ELevel.O
                        };
                        break;

                    case Profile.EType.Mech:
                    case Profile.EType.Koloss:
                        weaponUnarmed.WK = Weapon.EClass.II;
                        weaponUnarmed.DamageType = new DamageType()
                        {
                            Type = DamageType.EType.Schlag,
                            Level = DamageType.ELevel.II
                        };
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
                }

                return ( weaponUnarmed );
            }
        }

        public Weapon WeaponDetonation( ActorOutfit actorOutfit )
        {
            if( this.Archetype.Profile.Type != Profile.EType.Mech )
            {
                return ( null );
            }
            else
            {
                Weapon weaponDetonation = new Weapon()
                {
                    WK = Weapon.EClass.V,
                    Type = Weapon.EType.Fernkampf,
                    WeaponRange = new WeaponRange()
                    {
                        Amount = 0,
                        Length = 0
                    },
                    Name = "Bei Detonation",
                    DamageType = new DamageType()
                    {
                        Type = DamageType.EType.Schlag,
                        Level = DamageType.ELevel.II
                    },
                    DamageEffectList = new List<DamageEffect>() { new DamageEffect()
                                                                      {
                                                                          Type = DamageEffect.EType.Explosiv
                                                                      } },
                    Radius = ModKO( actorOutfit ),
                    Strength = ModKO( actorOutfit ),
                    Damage = Convert.ToInt32( Math.Round( ModKO( actorOutfit ) / 2.0f, 0 ) )
                };

                return ( weaponDetonation );
            }
        }

        [JsonIgnore]
        public string PointsRange
        {
            get
            {
                if( ActorOutfitsList.Count > 0 )
                {
                    int minPoints = ActorOutfitsList.Min( this.Points );
                    int maxPoints = ActorOutfitsList.Max( this.Points );

                    if( minPoints == maxPoints )
                    {
                        return ( minPoints.ToString() );
                    }
                    else
                    {
                        return ( minPoints + " - " + maxPoints );
                    }
                }
                else
                {
                    return ( "-" );
                }
            }
        }

        public int Points( ActorOutfit actorOutfit )
        {
            int points = 0;

            points += Archetype.Profile.Points();

            if( null != Armor )
            {
                points += Armor.Points;
            }

            if( null != ActorTraitsList )
            {
                points += ActorTraitsList.Sum( x => x.Points );
            }

            if( actorOutfit != null )
            {
                points += actorOutfit.Points;
            }

            return ( points );
        }
#endregion calculated values

        private ProfileModifier CurrentProfileModifier( ActorOutfit actorOutfit )
        {
            ProfileModifier modifier = new ProfileModifier();

            if( null != Armor )
            {
                modifier.Add( Armor.ProfileModifier );
            }

            if( actorOutfit != null )
            {
                foreach( ActorEquipment actorEquipment in actorOutfit.ActorEquipmentList.Where( x => !x.Equipment.UseOnce ) )
                {
                    modifier.Add( actorEquipment.Equipment.ProfileModifier );
                }
            }

            return ( modifier );
        }
    }
}
