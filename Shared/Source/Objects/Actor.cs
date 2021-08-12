using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Universalis
{
    public class Actor
    {
        public Actor()
        { }

        public Actor( Faction faction, Archetype archetype )
        {
            Faction = faction;
            Archetype = archetype;
        }

        public Actor( Actor actor, bool withOutfitID )
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

        [JsonConverter( typeof( JsonJpegConverter ) )]
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
                    ActorWeaponsList.AddRange( actorOutfit.ActorWeaponsList );
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
                    ActorEquipmentList.AddRange( actorOutfit.ActorEquipmentList );
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

            public float Weight()
            {
                float weight = 0.0f;

                weight += ActorWeaponsList.Sum( x => x.Weight );
                weight += ActorEquipmentList.Sum( x => x.Weight );


                return ( weight );
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

        [JsonConverter( typeof( JsonArchetypeConverter ) )]
        public Archetype Archetype
        {
            get;
            set;
        }

        [JsonConverter( typeof( JsonJpegConverter ) )]
        public Bitmap Img
        {
            get;
            set;
        } = null;

#endregion members

#region profile

        public int ModSpeed( ActorOutfit actorOutfit )
        {
            return ( Archetype.Profile.ModSpeed( CurrentProfileModifier( actorOutfit ) ) - ModLoadModifier( actorOutfit ) );
        }

        public int ModHitPoints( ActorOutfit actorOutfit )
        {
            return ( Archetype.Profile.ModHitPoints( CurrentProfileModifier( actorOutfit ) ) );
        }

        public int ModHitZoneHitPoints( ActorOutfit actorOutfit )
        {
            return ( Archetype.Profile.ModHitZoneHitPoints( CurrentProfileModifier( actorOutfit ) ) );
        }

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
        #endregion profile

        #region calculated values
        public int? ModDangerArea( ActorOutfit actorOutfit )
        {
            return ( Archetype.Profile.DangerArea( CurrentProfileModifier( actorOutfit ).AttributeModifier ) );
        }

        public int ModAreaOfPerception( ActorOutfit actorOutfit )
        {
            return ( Archetype.Profile.AreaOfPerception( CurrentProfileModifier( actorOutfit ).AttributeModifier ) );
        }

        public static string ThrowRange( int attributeKO, bool unwieldy )
        {
            if( unwieldy )
            {
                return ( $"{Math.Ceiling( attributeKO * Presets.throwRangeLengthUnwieldyMultiplier )}/{Presets.throwRangeAmount}" );
            }
            else
            {
                return ( $"{attributeKO * Presets.throwRangeLengthMultiplier}/{Presets.throwRangeAmount}" );
            }
        }

        public float ModMaxLoadCapacity( ActorOutfit actorOutfit )
        {
            int modKO = Archetype.Profile.Attributes.ModKO( CurrentProfileModifier( actorOutfit ).AttributeModifier );

            switch( this.Archetype.Profile.Type )
            {
                case Profile.EType.Infanterie:
                case Profile.EType.Drohne:
                    return ( Convert.ToSingle( Math.Pow( modKO, 2 ) ) );

                case Profile.EType.Koloss:
                    return ( Convert.ToSingle( Math.Pow( ( modKO * Presets.ColossusLoadCapacityMultiplier ), 2 ) ) );

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
            }
        }

        public float LoadoutWeight( ActorOutfit actorOutfit, bool withSelfSustaining )
        {
            float loadoutWeight = 0.0f;

            if( actorOutfit != null )
            {
                loadoutWeight += actorOutfit.Weight();
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
            if( this.Archetype.Profile.Type == Profile.EType.Drohne ) 
            {
                return ( null );
            }
            else
            {
                int modKO = ModKO( actorOutfit );

                Weapon weaponUnarmed = new Weapon()
                {
                    Type = Weapon.EType.Nahkampf,
                    Name = "Unbewaffnet",
                    Strength = modKO,
                    Damage = Convert.ToInt32( Math.Round( modKO / 3.0f, 0 ) )
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

            points += Archetype.Points;

            if( null != Armor )
            {
                points += Armor.Points;
            }

            if( null != ActorTraitsList )
            {
                var positiveTraits = ActorTraitsList.Where( x => x.Points >= 0 );
                var negativeTraits = ActorTraitsList.Where( x => x.Points < 0 );

                float positiveTraitsPoints = positiveTraits.Sum( x => x.Points );
                float negativeTraitsPoints = negativeTraits.Sum( x => x.Points );

                // scale points with the amount of different traits where negative traits have an diminishing effect
                positiveTraitsPoints *= (float)Math.Pow( Costs.TraitsModifier, positiveTraits.Count() );
                negativeTraitsPoints /= (float)Math.Pow( Costs.TraitsModifier, negativeTraits.Count() );

                points += (int)positiveTraitsPoints + (int)negativeTraitsPoints;
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
                foreach( ActorWeapon actorWeapon in actorOutfit.ActorWeaponsList.Where( x => !x.Weapon.UseOnce ) )
                {
                    modifier.Add( actorWeapon.Weapon.ProfileModifier );
                }

                foreach( ActorEquipment actorEquipment in actorOutfit.ActorEquipmentList.Where( x => !x.Equipment.UseOnce ) )
                {
                    modifier.Add( actorEquipment.Equipment.ProfileModifier );
                }
            }

            return ( modifier );
        }
    }
}
