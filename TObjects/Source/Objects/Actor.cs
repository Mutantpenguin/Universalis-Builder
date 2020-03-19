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
                Size != actor.Size
                ||
                Type != actor.Type
                ||
                Weight != actor.Weight
                ||
                SZ != actor.SZ
                ||
                MovementType != actor.MovementType
                ||
                Fov != actor.Fov
                ||
                Faction != actor.Faction )
            {
                return ( false );
            }
            
            if( Attributes.AGI != actor.Attributes.AGI
                ||
                Attributes.BW != actor.Attributes.BW
                ||
                Attributes.KO != actor.Attributes.KO
                ||
                Attributes.FK != actor.Attributes.FK
                ||
                Attributes.WN != actor.Attributes.WN
                ||
                Attributes.EH != actor.Attributes.EH )
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

            Attributes = new Attributes
            {
                AGI = actor.Attributes.AGI,
                BW = actor.Attributes.BW,
                KO = actor.Attributes.KO,
                FK = actor.Attributes.FK,
                WN = actor.Attributes.WN,
                EH = actor.Attributes.EH
            };

            Weight = actor.Weight;

            SZ = actor.SZ;

            Size = actor.Size;

            Type = actor.Type;

            MovementType = actor.MovementType;

            Fov = actor.Fov;

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

        public enum ESize
        {
            Klein = 1,
            Mittel = 2,
            Groß = 3,
            Riesig = 4
        }

        public static readonly IList<ESize> ESizeList = Enum.GetValues( typeof( ESize ) ).Cast<ESize>().ToList().AsReadOnly();

        public enum EType
        {
            Infanterie = 1,
            Mech = 2,
            Koloss = 3,
            Fahrzeug = 4
        }

        public static readonly IList<EType> ETypeList = Enum.GetValues( typeof( EType ) ).Cast<EType>().ToList().AsReadOnly();

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

        public float Weight
        {
            get;
            set;
        } = 75.0f;

        public int SZ
        {
            get;
            set;
        } = 5;

        [JsonIgnore]
        public int HitZoneSZ => ( Convert.ToInt32( Math.Ceiling( SZ * Presets.MIKEHitZoneSZMultiplier ) ) );

        [JsonConverter( typeof( JsonImageConverter ) )]
        public Bitmap Icon
        {
            get;
            set;
        } = TObjects.Properties.Resources.empty;

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
        public ESize Size
        {
            get;
            set;
        } = ESize.Mittel;

        public EType Type
        {
            get;
            set;
        } = EType.Infanterie;

        [JsonConverter( typeof( JsonFactionConverter ) )]
        public Faction Faction
        {
            get;
            set;
        }

        public EMovementType MovementType
        {
            get;
            set;
        } = EMovementType.Fuss;

        public EFieldOfView Fov
        {
            get;
            set;
        } = EFieldOfView._90;

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

        public Attributes Attributes
        {
            get;
            set;
        } = new Attributes
        {
            AGI = 4,
            BW = 4,
            KO = 4,
            FK = 4,
            WN = 4,
            EH = 4
        };

        [ JsonConverter( typeof( JsonImageConverter ) )]
        public Bitmap Img
        {
            get;
            set;
        } = null;
#endregion members

#region attributes
        public int ModAGI( ActorOutfit actorOutfit )
        {
            return ( Attributes.ModAGI( CurrentAttributeModifier( actorOutfit ) ) - ModLoadModifier( actorOutfit ) );
        }

        public int ModBW( ActorOutfit actorOutfit )
        {
            return ( Attributes.ModBW( CurrentAttributeModifier( actorOutfit ) ) - ModLoadModifier( actorOutfit ) );
        }

        public int ModKO( ActorOutfit actorOutfit )
        {
            return ( Attributes.ModKO( CurrentAttributeModifier( actorOutfit ) ) );
        }

        public int ModFK( ActorOutfit actorOutfit )
        {
            return ( Attributes.ModFK( CurrentAttributeModifier( actorOutfit ) ) );
        }

        public int ModWN( ActorOutfit actorOutfit )
        {
            return ( Attributes.ModWN( CurrentAttributeModifier( actorOutfit ) ) );
        }

        public int ModEH( ActorOutfit actorOutfit )
        {
            return ( Attributes.ModEH( CurrentAttributeModifier( actorOutfit ) ) );
        }
#endregion attributes

#region calculated values
        public int GB( ActorOutfit actorOutfit )
        {
            int lengthGB = Presets.MaxLengthGB - Attributes.ModEH( CurrentAttributeModifier( actorOutfit ) );

            if( lengthGB < 0 )
            {
                return ( 0 );
            }
            else
            {
                return ( lengthGB );
            }
        }

        public int ModWB( ActorOutfit actorOutfit )
        {
            return ( Presets.WBMultiplier * Attributes.ModWN( CurrentAttributeModifier( actorOutfit ) ) );
        }

        public static string ThrowRange( int attributeKO )
        {
            return( $"{attributeKO * Presets.throwRangeLengthMultiplier}/{Presets.throwRangeAmount}" );
        }

        public float ModMaxLoadCapacity( ActorOutfit actorOutfit )
        {
            switch( this.Type )
            {
                case EType.Infanterie:
                    return ( Convert.ToSingle( Math.Pow( Attributes.ModKO( CurrentAttributeModifier( actorOutfit ) ), 2 ) ) );

                case EType.Mech:
                case EType.Koloss:
                    return ( Convert.ToSingle( Math.Pow( ( Attributes.ModKO( CurrentAttributeModifier( actorOutfit ) ) * Presets.MIKELoadCapacityMultiplier ), 2 ) ) );

                case EType.Fahrzeug:
                    return ( Convert.ToSingle( Math.Pow( ( Attributes.ModKO( CurrentAttributeModifier( actorOutfit ) ) * Presets.FahrzeugLoadCapacityMultiplier ), 2 ) ) );

                default:
                    throw new InvalidOperationException( "unkown " + nameof( EType ) );
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
            if( this.Type == EType.Fahrzeug )
            {
                return ( null );
            }
            else
            {
                Weapon weaponUnarmed = new Weapon()
                {
                    Type = Weapon.EType.Nahkampf,
                    Name = "Unbewaffnet",
                    Potential = ModKO( actorOutfit ),
                    Substance = Convert.ToInt32( Math.Round( ModKO( actorOutfit ) / 3.0f, 0 ) )
                };

                switch( this.Type )
                {
                    case EType.Infanterie:
                        weaponUnarmed.WK = Weapon.EClass.I;
                        weaponUnarmed.DamageType = new DamageType()
                        {
                            Type = DamageType.EType.Schlag,
                            Level = DamageType.ELevel.I
                        };
                        break;

                    case EType.Mech:
                    case EType.Koloss:
                        weaponUnarmed.WK = Weapon.EClass.II;
                        weaponUnarmed.DamageType = new DamageType()
                        {
                            Type = DamageType.EType.Schlag,
                            Level = DamageType.ELevel.II
                        };
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( EType ) );
                }

                return ( weaponUnarmed );
            }
        }

        public Weapon WeaponDetonation( ActorOutfit actorOutfit )
        {
            if( this.Type != EType.Mech )
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
                    Potential = ModKO( actorOutfit ),
                    Substance = Convert.ToInt32( Math.Round( ModKO( actorOutfit ) / 2.0f, 0 ) )
                };

                return ( weaponDetonation );
            }
        }

        [ JsonIgnore]
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

            points += Attributes.ModAGI( CurrentAttributeModifier( actorOutfit ) ) * Costs.AGI;
            points += Attributes.ModBW( CurrentAttributeModifier( actorOutfit ) ) * Costs.BW;
            points += Attributes.ModKO( CurrentAttributeModifier( actorOutfit ) ) * Costs.KO;
            points += Attributes.ModFK( CurrentAttributeModifier( actorOutfit ) ) * Costs.FK;
            points += Attributes.ModWN( CurrentAttributeModifier( actorOutfit ) ) * Costs.WN;
            points += Attributes.ModEH( CurrentAttributeModifier( actorOutfit ) ) * Costs.EH;

            switch( this.Type )
            {
                case EType.Infanterie:
                case EType.Fahrzeug: // TODO implement completely different HitZones for vehicles? like chassis, engine and so on?
                    points += SZ * Costs.SZ;
                    break;

                case EType.Mech:
                case EType.Koloss:
                    points += ( SZ * Costs.SZ ) + ( 3 * HitZoneSZ * Costs.SZ );
                    break;

                default:
                    throw new InvalidOperationException( "unkown " + nameof( EType ) );
            }

            points += (int)Fov * Costs.FOV;

            points += Costs.movementCost( MovementType );

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

        private AttributeModifier CurrentAttributeModifier( ActorOutfit actorOutfit )
        {
            AttributeModifier modifier = new AttributeModifier();

            if( null != Armor )
            {
                modifier.Add( Armor.AttributeModifier );
            }

            if( actorOutfit != null )
            {
                foreach( ActorEquipment actorEquipment in actorOutfit.ActorEquipmentList.Where( x => !x.Equipment.UseOnce ) )
                {
                    modifier.Add( actorEquipment.Equipment.AttributeModifier );
                }
            }

            return ( modifier );
        }
    }
}
