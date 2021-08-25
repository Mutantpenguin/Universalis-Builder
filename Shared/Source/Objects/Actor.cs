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

        public Actor( Archetype archetype )
        {
            Archetype = archetype;
        }

        public Actor( Actor actor )
        {
            Set( actor );
        }

        public Actor Copy()
        {
            var newActor = new Actor();

            newActor.Set( this, withID: false );

            return ( newActor );
        }

        public bool Equals( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            if( ID != actor.ID )
            {
                return ( false );
            }

            if( Name != actor.Name
                ||
                Description != actor.Description
                ||
                Disabled != actor.Disabled
                ||
                DisabledReason != actor.DisabledReason )
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

            if( WeaponsList.Except( actor.WeaponsList ).Any()
                ||
                actor.WeaponsList.Except( WeaponsList ).Any() )
            {
                return ( false );
            }

            if( EquipmentList.Except( actor.EquipmentList ).Any()
                ||
                actor.EquipmentList.Except( EquipmentList ).Any() )
            {
                return ( false );
            }

            if( TraitsList.Except( actor.TraitsList ).Any()
                ||
                actor.TraitsList.Except( TraitsList ).Any() )
            {
                return ( false );
            }

            return ( true );
        }

        public void Set( Actor actor, bool withID = true )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            if( withID )
            {
                ID = actor.ID;
            }

            Name = actor.Name;

            Description = actor.Description;

            Disabled = actor.Disabled;
            DisabledReason = actor.DisabledReason;

            Archetype = actor.Archetype;

            Icon = actor.Icon;

            Img = actor.Img;

            if( null != WeaponsList )
            {
                WeaponsList.Clear();
            }
            else
            {
                WeaponsList = new List<ActorWeapon>();
            }

            if( null != actor.WeaponsList )
            {
                WeaponsList.AddRange( actor.WeaponsList );
            }

            if( null != EquipmentList )
            {
                EquipmentList.Clear();
            }
            else
            {
                EquipmentList = new List<ActorEquipment>();
            }

            if( null != actor.EquipmentList )
            {
                EquipmentList.AddRange( actor.EquipmentList );
            }

            Armor = actor.Armor;

            if( null != TraitsList )
            {
                TraitsList.Clear();
            }
            else
            {
                TraitsList = new List<ActorTrait>();
            }

            if( null != actor.TraitsList )
            {
                TraitsList.AddRange( actor.TraitsList );
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

        public bool Disabled
        {
            get;
            set;
        } = false;

        public string DisabledReason
        {
            get;
            set;
        }

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
        } = Shared.Properties.Resources.empty_model;

        public class ActorTrait
        {
            [JsonConverter( typeof( JsonActorTraitConverter ) )]
            public Trait Trait
            {
                get;
                set;
            }
        }

        public class ActorWeapon
        {
            [JsonConverter( typeof( JsonActorWeaponConverter ) )]
            public Weapon Weapon
            {
                get;
                set;
            }
        }

        public class ActorEquipment
        {
            [JsonConverter( typeof( JsonActorEquipmentConverter ) )]
            public Equipment Equipment
            {
                get;
                set;
            }
        }

        #region members

        [JsonConverter( typeof( JsonArmorConverter ) )]
        public Armor Armor
        {
            get;
            set;
        }

        public List<ActorTrait> TraitsList
        {
            get;
            set;
        } = new List<ActorTrait>();

        public List<ActorWeapon> WeaponsList
        {
            get;
            set;
        } = new List<ActorWeapon>();

        public List<ActorEquipment> EquipmentList
        {
            get;
            set;
        } = new List<ActorEquipment>();

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

        public int ModSpeed()
        {
            return ( Archetype.Profile.ModSpeed( CurrentProfileModifier() ) - ModLoadModifier() );
        }

        public int ModHitPoints()
        {
            return ( Archetype.Profile.ModHitPoints( CurrentProfileModifier() ) );
        }

        public int ModHitZoneHitPoints()
        {
            return ( Archetype.Profile.ModHitZoneHitPoints( CurrentProfileModifier() ) );
        }

        public int? ModAGI()
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                return ( Archetype.Profile.Attributes.ModAGI( CurrentProfileModifier().AttributeModifier ) - ModLoadModifier() );
            }
        }

        public int? ModHTH()
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                return ( Archetype.Profile.Attributes.ModHTH( CurrentProfileModifier().AttributeModifier ) );
            }
        }
        public int? ModLRC()
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                return ( Archetype.Profile.Attributes.ModLRC( CurrentProfileModifier().AttributeModifier ) );
            }
        }

        public int ModPHY()
        {
            return ( Archetype.Profile.Attributes.ModPHY( CurrentProfileModifier().AttributeModifier ) );
        }

        public int ModAWA()
        {
            return ( Archetype.Profile.Attributes.ModAWA( CurrentProfileModifier().AttributeModifier ) );
        }

        public int? ModDET()
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne )
            {
                return ( null );
            }
            else
            {
                return ( Archetype.Profile.Attributes.ModDET( CurrentProfileModifier().AttributeModifier ) );
            }
        }
        #endregion profile

        #region calculated values
        public int? ModDangerArea()
        {
            return ( Archetype.Profile.DangerArea( CurrentProfileModifier().AttributeModifier ) );
        }

        public int ModAreaOfPerception()
        {
            return ( Archetype.Profile.AreaOfPerception( CurrentProfileModifier().AttributeModifier ) );
        }

        public static string ThrowRange( int attributePHY, bool unwieldy )
        {
            if( unwieldy )
            {
                return ( $"{Math.Ceiling( attributePHY * Presets.throwRangeLengthUnwieldyMultiplier )}/{Presets.throwRangeAmount}" );
            }
            else
            {
                return ( $"{attributePHY * Presets.throwRangeLengthMultiplier}/{Presets.throwRangeAmount}" );
            }
        }

        public float ModMaxLoadCapacity()
        {
            int modPHY = Archetype.Profile.Attributes.ModPHY( CurrentProfileModifier().AttributeModifier );

            switch( this.Archetype.Profile.Type )
            {
                case Profile.EType.Infanterie:
                case Profile.EType.Drohne:
                    return ( Convert.ToSingle( Math.Pow( modPHY, 2 ) ) );

                case Profile.EType.Koloss:
                    return ( Convert.ToSingle( Math.Pow( ( modPHY * Presets.ColossusLoadCapacityMultiplier ), 2 ) ) );

                default:
                    throw new InvalidOperationException( "unkown " + nameof( Profile.EType ) );
            }
        }

        public float LoadoutWeight( bool withSelfSustaining )
        {
            float loadoutWeight = 0.0f;

            loadoutWeight += WeaponsList.Sum( x => x.Weapon.Weight );
            loadoutWeight += EquipmentList.Sum( x => x.Equipment.Weight );

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

        private int ModLoadModifier()
        {
            int loadModifier = Convert.ToInt32( Math.Ceiling( LoadoutWeight( withSelfSustaining: false ) / ModMaxLoadCapacity() ) );

            if( loadModifier > 0 )
            {
                return ( loadModifier - 1 );
            }
            else
            {
                return ( 0 );
            }
        }

        public Weapon WeaponUnarmed()
        {
            if( this.Archetype.Profile.Type == Profile.EType.Drohne ) 
            {
                return ( null );
            }
            else
            {
                int modPHY = ModPHY();

                Weapon weaponUnarmed = new Weapon()
                {
                    Type = Weapon.EType.Nahkampf,
                    Name = "Unbewaffnet",
                    Strength = modPHY,
                    Damage = Convert.ToInt32( Math.Round( modPHY / 3.0f, 0 ) )
                };

                switch( this.Archetype.Profile.Type )
                {
                    case Profile.EType.Infanterie:
                        weaponUnarmed.Class = Weapon.EClass.I;
                        weaponUnarmed.DamageType = new DamageType()
                        {
                            Type = DamageType.EType.Schlag,
                            Level = DamageType.ELevel.O
                        };
                        break;

                    case Profile.EType.Koloss:
                        weaponUnarmed.Class = Weapon.EClass.II;
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

        public int Points
        {
            get
            {
                int points = 0;

                points += Archetype.Points;

                if( null != Armor )
                {
                    points += Armor.Points;
                }

                if( null != TraitsList )
                {
                    var positiveTraits = TraitsList.Where( x => x.Trait.Points >= 0 );
                    var negativeTraits = TraitsList.Where( x => x.Trait.Points < 0 );

                    float positiveTraitsPoints = positiveTraits.Sum( x => x.Trait.Points );
                    float negativeTraitsPoints = negativeTraits.Sum( x => x.Trait.Points );

                    // scale points with the amount of different traits where negative traits have an diminishing effect
                    positiveTraitsPoints *= (float)Math.Pow( Costs.TraitsModifier, positiveTraits.Count() );
                    negativeTraitsPoints /= (float)Math.Pow( Costs.TraitsModifier, negativeTraits.Count() );

                    points += (int)positiveTraitsPoints + (int)negativeTraitsPoints;
                }

                if( null != WeaponsList )
                {
                    points += WeaponsList.Sum( x => x.Weapon.Points );
                }

                if( null != EquipmentList )
                {
                    points += EquipmentList.Sum( x => x.Equipment.Points );
                }

                return ( points );
            }
        }
#endregion calculated values

        private ProfileModifier CurrentProfileModifier()
        {
            ProfileModifier modifier = new ProfileModifier();

            if( null != Armor )
            {
                modifier.Add( Armor.ProfileModifier );
            }

            foreach( ActorWeapon actorWeapon in WeaponsList.Where( x => !x.Weapon.UseOnce ) )
            {
                modifier.Add( actorWeapon.Weapon.ProfileModifier );
            }

            foreach( ActorEquipment actorEquipment in EquipmentList.Where( x => !x.Equipment.UseOnce ) )
            {
                modifier.Add( actorEquipment.Equipment.ProfileModifier );
            }

            return ( modifier );
        }

        public bool HasInactiveComposition()
        {
            if( null != Armor )
            {
                if( !Armor.Active )
                {
                    return ( true );
                }
            }

            if( null != TraitsList )
            {
                if( TraitsList.Exists( x => x.Trait.Active ) )
                {
                    return ( true );
                }
            }

            if( null != WeaponsList )
            {
                if( WeaponsList.Exists( x => x.Weapon.Active ) )
                {
                    return ( true );
                }
            }

            if( null != EquipmentList )
            {
                if( EquipmentList.Exists( x => x.Equipment.Active ) )
                {
                    return ( true );
                }
            }

            return ( false );
        }
    }
}
