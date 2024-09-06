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

            return newActor;
        }

        public bool Equals( Actor actor )
        {
            if( null == actor )
            {
                throw new ArgumentNullException( nameof( actor ) );
            }

            if( ID != actor.ID )
            {
                return false;
            }

            if( Name != actor.Name
                ||
                Biography != actor.Biography
                ||
                Active != actor.Active
                ||
                InactiveReason != actor.InactiveReason
                ||
                InactiveType  != actor.InactiveType )
            {
                return false;
            }
            
            if( Archetype != actor.Archetype )
            {
                return false;
            }

            if( Icon != actor.Icon
                ||
                Img != actor.Img )
            {
                return false;
            }

            if( Armor != actor.Armor )
            {
                return false;
            }

            if( Weapons.Except( actor.Weapons ).Any()
                ||
                actor.Weapons.Except( Weapons ).Any() )
            {
                return false;
            }

            if( Equipments.Except( actor.Equipments ).Any()
                ||
                actor.Equipments.Except( Equipments ).Any() )
            {
                return false;
            }

            foreach( ActorTrait actorTrait in Traits )
            {
                if( !actor.Traits.Any( x => x.Equals( actorTrait ) ) )
                {
                    return false;
                }
            }

            foreach( ActorTrait actorTrait in actor.Traits )
            {
                if( !Traits.Any( x => x.Equals( actorTrait ) ) )
                {
                    return false;
                }
            }

            foreach( ActorDiscipline actorDiscipline in Disciplines )
            {
                if( !actor.Disciplines.Any( x => x.Equals( actorDiscipline ) ) )
                {
                    return false;
                }
            }

            foreach( ActorDiscipline actorDiscipline in actor.Disciplines )
            {
                if( !Disciplines.Any( x => x.Equals( actorDiscipline ) ) )
                {
                    return false;
                }
            }

            return true;
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

            Biography = actor.Biography;

            Active = actor.Active;
            InactiveReason = actor.InactiveReason;
            InactiveType = actor.InactiveType;

            Archetype = actor.Archetype;

            Icon = actor.Icon;

            Img = actor.Img;

            if( null != Weapons )
            {
                Weapons.Clear();
            }
            else
            {
                Weapons = new List<ActorWeapon>();
            }

            if( null != actor.Weapons )
            {
                Weapons.AddRange( actor.Weapons );
            }

            if( null != Equipments )
            {
                Equipments.Clear();
            }
            else
            {
                Equipments = new List<ActorEquipment>();
            }

            if( null != actor.Equipments )
            {
                Equipments.AddRange( actor.Equipments );
            }

            Armor = actor.Armor;

            if( null != Traits )
            {
                Traits.Clear();
            }
            else
            {
                Traits = new List<ActorTrait>();
            }

            if( null != actor.Traits )
            {
                foreach( ActorTrait actorTrait in actor.Traits )
                {
                    Traits.Add( new ActorTrait( actorTrait ) );
                }
            }

            if( null != Disciplines )
            {
                Disciplines.Clear();
            }
            else
            {
                Disciplines = new List<ActorDiscipline>();
            }

            if( null != actor.Disciplines )
            {
                foreach( ActorDiscipline actorDiscipline in actor.Disciplines )
                {
                    Disciplines.Add( new ActorDiscipline( actorDiscipline ) );
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

        public bool Active
        {
            get;
            set;
        } = true;

        public string InactiveReason
        {
            get;
            set;
        }

        public EInactiveType InactiveType
        {
            get;
            set;
        }

        public string Biography
        {
            get;
            set;
        }

        [JsonConverter( typeof( JsonJpegConverter ) )]
        public Bitmap Icon
        {
            get;
            set;
        } = Properties.Resources.empty_model;

        public class ActorDiscipline
        {
            public ActorDiscipline() {}

            public ActorDiscipline( ActorDiscipline actorDiscipline )
            {
                if( null == actorDiscipline )
                {
                    throw new ArgumentNullException( nameof( actorDiscipline ) );
                }

                ID = actorDiscipline.ID;

                Discipline = actorDiscipline.Discipline;
                Level = actorDiscipline.Level;
            }

            public bool Equals( ActorDiscipline actorDiscipline )
            {
                if( null == actorDiscipline )
                {
                    throw new ArgumentNullException( nameof( actorDiscipline ) );
                }

                if( ID != actorDiscipline.ID
                    ||
                    Discipline != actorDiscipline.Discipline
                    ||
                    Level != actorDiscipline.Level )
                {
                    return false;
                }

                return true;
            }

            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            [JsonConverter( typeof( JsonDisciplineConverter ) )]
            public Discipline Discipline
            {
                get;
                set;
            }

            public uint Level
            {
                get;
                set;
            } = 1;

            [JsonIgnore]
            public int Points
            {
                get
                {
                    return Discipline.Points( Level );
                }
            }
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

                ID = actorTrait.ID;

                Trait = actorTrait.Trait;
                Level = actorTrait.Level;
            }

            public bool Equals( ActorTrait actorTrait )
            {
                if( null == actorTrait )
                {
                    throw new ArgumentNullException( nameof( actorTrait ) );
                }

                if( ID != actorTrait.ID
                    ||
                    Trait != actorTrait.Trait
                    ||
                    Level != actorTrait.Level )
                {
                    return false;
                }

                return true;
            }

            public Guid ID
            {
                get;
                set;
            } = Guid.NewGuid();

            [JsonConverter( typeof( JsonTraitConverter ) )]
            public Trait Trait
            {
                get;
                set;
            }

            public uint Level
            {
                get;
                set;
            } = 1;

            [JsonIgnore]
            public int Points
            {
                get
                {
                    return Trait.Points( Level );
                }
            }
        }

        public class ActorWeapon
        {
            [JsonConverter( typeof( JsonWeaponConverter ) )]
            public Weapon Weapon
            {
                get;
                set;
            }
        }

        public class ActorEquipment
        {
            [JsonConverter( typeof( JsonEquipmentConverter ) )]
            public Equipment Equipment
            {
                get;
                set;
            }
        }

        public enum EInactiveType
        {
            Kein = 0,
            Tot = 1,
            Zerstört = 2,
            Ruhestand = 3,
            Desertiert = 4,
            Vermisst = 5,
            Gefangen = 6,
            Defekt = 7,
            Urlaub = 8
        }

        #region members

        [JsonConverter( typeof( JsonArmorConverter ) )]
        public Armor Armor
        {
            get;
            set;
        }

        public List<ActorTrait> Traits
        {
            get;
            set;
        } = new List<ActorTrait>();

        public List<ActorWeapon> Weapons
        {
            get;
            set;
        } = new List<ActorWeapon>();

        public List<ActorEquipment> Equipments
        {
            get;
            set;
        } = new List<ActorEquipment>();

        public List<ActorDiscipline> Disciplines
        {
            get;
            set;
        } = new List<ActorDiscipline>();

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
            return Archetype.Profile.ModSpeed( CurrentProfileModifier() ) - ModLoadModifier();
        }

        public int ModHitPoints()
        {
            return Archetype.Profile.ModHitPoints( CurrentProfileModifier() );
        }

        public int ModHitZoneHitPoints()
        {
            return Archetype.Profile.ModHitZoneHitPoints( CurrentProfileModifier() );
        }

        public int ModCritThreshold()
        {
            return 50 + CurrentProfileModifier().CritThreshold;
        }

        public int? ModAGI()
        {
            if( this.Archetype.Type == Archetype.EType.Telematon )
            {
                return null;
            }
            else
            {
                return Archetype.Profile.Attributes.ModAGI( CurrentProfileModifier().AttributeModifier ) - ModLoadModifier();
            }
        }

        public int? ModHTH()
        {
            if( this.Archetype.Type == Archetype.EType.Telematon )
            {
                return null;
            }
            else
            {
                return Archetype.Profile.Attributes.ModHTH( CurrentProfileModifier().AttributeModifier );
            }
        }
        public int? ModLRC()
        {
            if( this.Archetype.Type == Archetype.EType.Telematon )
            {
                return null;
            }
            else
            {
                return Archetype.Profile.Attributes.ModLRC( CurrentProfileModifier().AttributeModifier );
            }
        }

        public int ModPHY()
        {
            return Archetype.Profile.Attributes.ModPHY( CurrentProfileModifier().AttributeModifier );
        }

        public int ModAWA()
        {
            return Archetype.Profile.Attributes.ModAWA( CurrentProfileModifier().AttributeModifier );
        }

        public int? ModDET()
        {
            if( this.Archetype.Type == Archetype.EType.Telematon )
            {
                return null;
            }
            else
            {
                return Archetype.Profile.Attributes.ModDET( CurrentProfileModifier().AttributeModifier );
            }
        }
        #endregion profile

        #region calculated values
        public float? ModDangerArea()
        {
            return Archetype.DangerArea( CurrentProfileModifier().AttributeModifier );
        }

        public int ModAreaOfPerception()
        {
            return Archetype.AreaOfPerception( CurrentProfileModifier().AttributeModifier );
        }

        public static string ThrowRange( int attributePHY, bool unwieldy )
        {
            if( unwieldy )
            {
                return $"{Math.Ceiling( attributePHY * Presets.throwRangeLengthUnwieldyMultiplier )}/{Presets.throwRangeAmount}";
            }
            else
            {
                return $"{attributePHY}/{Presets.throwRangeAmount}";
            }
        }

        public float ModMaxLoadCapacity()
        {
            int modPHY = Archetype.Profile.Attributes.ModPHY( CurrentProfileModifier().AttributeModifier );

            return LoadCapacity.Max( Archetype.Type, modPHY );
        }

        public float LoadoutWeight( bool withSelfSustaining )
        {
            float loadoutWeight = 0.0f;

            loadoutWeight += Weapons.Sum( x => x.Weapon.Weight );
            loadoutWeight += Equipments.Sum( x => x.Equipment.Weight );

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

            return loadoutWeight;
        }

        private int ModLoadModifier()
        {
            int loadModifier = Convert.ToInt32( Math.Ceiling( LoadoutWeight( withSelfSustaining: false ) / ModMaxLoadCapacity() ) );

            if( loadModifier > 0 )
            {
                return loadModifier - 1;
            }
            else
            {
                return 0;
            }
        }

        public Weapon WeaponUnarmed()
        {
            if( this.Archetype.Type == Archetype.EType.Telematon ) 
            {
                return null;
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

                switch( this.Archetype.Type )
                {
                    case Archetype.EType.Standard:
                        weaponUnarmed.Class = Weapon.EClass.I;
                        break;

                    case Archetype.EType.Koloss:
                        weaponUnarmed.Class = Weapon.EClass.II;
                        break;

                    default:
                        throw new InvalidOperationException( "unkown " + nameof( Archetype.EType ) );
                }

                return weaponUnarmed;
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

                if( null != Traits )
                {
                    points += Traits.Sum( x => x.Points );
                }

                if( null != Weapons )
                {
                    points += Weapons.Sum( x => x.Weapon.Points );
                }

                if( null != Equipments )
                {
                    points += Equipments.Sum( x => x.Equipment.Points );
                }

                if( null != Disciplines )
                {
                    points += Disciplines.Sum( x => x.Points );
                }

                return points;
            }
        }
#endregion calculated values

        public ProfileModifier CurrentProfileModifier()
        {
            ProfileModifier modifier = new ProfileModifier();

            if( null != Armor )
            {
                modifier.Add( Armor.ProfileModifier );
            }

            foreach( ActorWeapon actorWeapon in Weapons.Where( x => !x.Weapon.UseOnce ) )
            {
                modifier.Add( actorWeapon.Weapon.ProfileModifier );
            }

            foreach( ActorEquipment actorEquipment in Equipments.Where( x => !x.Equipment.UseOnce ) )
            {
                modifier.Add( actorEquipment.Equipment.ProfileModifier );
            }

            foreach( ActorTrait actorTrait in Traits.Where( x => !x.Trait.UseOnce ) )
            {
                modifier.Add( actorTrait.Trait.ProfileModifier );
            }

            return modifier;
        }

        public (bool valid, String reason) IsValid()
        {
            string reasonString = String.Empty;

            if( HasInactiveComposition() )
            {
                reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) + "Inaktive Ausstattung vorhanden.";
            }

            if( OutfitExceedsMaxQuantity() )
            {
                reasonString += ( String.IsNullOrEmpty( reasonString ) ? String.Empty : ( Environment.NewLine + Environment.NewLine ) ) + "Maximale Menge an Ausstattung pro Modell überschritten.";
            }

            return (String.IsNullOrEmpty( reasonString ), reasonString);
        }

        public bool HasInactiveComposition()
        {
            if( null != Armor )
            {
                if( !Armor.Active )
                {
                    return true;
                }
            }

            if( null != Traits )
            {
                if( Traits.Exists( x => !x.Trait.Active ) )
                {
                    return true;
                }
            }

            if( null != Weapons )
            {
                if( Weapons.Exists( x => !x.Weapon.Active ) )
                {
                    return true;
                }
            }

            if( null != Equipments )
            {
                if( Equipments.Exists( x => !x.Equipment.Active ) )
                {
                    return true;
                }
            }

            if( null != Disciplines )
            {
                if( Disciplines.Exists( x => !x.Discipline.Active ) )
                {
                    return true;
                }
            }

            return false;
        }

        public bool OutfitExceedsMaxQuantity()
        {
            if( null != Weapons )
            {
                if( Weapons.GroupBy( x => x.Weapon )
                           .Select( x => new { weapon = x.Key, count = x.Count() } )
                           .Where( x => x.weapon.MaxModelQuantity > 0 && x.count > x.weapon.MaxModelQuantity )
                           .Count() > 0 )
                {
                    return true;
                }
            }

            if( null != Equipments )
            {
                if( Equipments.GroupBy( x => x.Equipment )
                              .Select( x => new { equipment = x.Key, count = x.Count() } )
                              .Where( x => x.equipment.MaxModelQuantity > 0 && x.count > x.equipment.MaxModelQuantity )
                              .Count() > 0 )
                {
                    return true;
                }
            }

            return false;
        }
    }
}
