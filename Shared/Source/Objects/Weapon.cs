using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Universalis
{
    public class Weapon
    {
        public Weapon()
        { }

        public Weapon( Weapon weapon )
            : this()
        {
            Set( weapon );
        }

        public void Set( Weapon weapon )
        {
            if( null == weapon )
            {
                throw new ArgumentNullException( nameof( weapon ) );
            }

            Active = weapon.Active;

            Name = weapon.Name;
            Description = weapon.Description;
            Rules = weapon.Rules;
            Weight = weapon.Weight;
            AdditionalPoints = weapon.AdditionalPoints;
            Class = weapon.Class;
            Type = weapon.Type;
            Strength = weapon.Strength;
            AdditiveStrength = weapon.AdditiveStrength;
            Damage = weapon.Damage;
            DamageType = new DamageType( weapon.DamageType );

            DamageEffectSet.Clear();
            DamageEffectSet.UnionWith( weapon.DamageEffectSet );

            if( null != weapon.ProfileModifier )
            {
                ProfileModifier = new ProfileModifier( weapon.ProfileModifier );
            }
            else
            {
                ProfileModifier = null;
            }

            if( null != weapon.Range )
            {
                Range = new WeaponRange
                {
                    Length = weapon.Range.Length,
                    Amount = weapon.Range.Amount
                };
            }
            else
            {
                Range = null;
            }

            UseOnce = weapon.UseOnce;

            IndirectFire = weapon.IndirectFire;

            SustainedFire = weapon.SustainedFire;
            Radius = weapon.Radius;

            Unwieldy = weapon.Unwieldy;

            Reloadable = weapon.Reloadable;
        }

        public bool Equals( Weapon weapon )
        {
            if( null == weapon )
            {
                throw new ArgumentNullException( nameof( weapon ) );
            }

            if( Active != weapon.Active
                ||
                Name != weapon.Name
                ||
                Description != weapon.Description
                ||
                Rules != weapon.Rules
                ||
                AdditionalPoints != weapon.AdditionalPoints
                ||
                Weight != weapon.Weight )
            {
                return ( false );
            }

            if( Class != weapon.Class
                ||
                Type != weapon.Type
                ||
                Strength != weapon.Strength
                ||
                AdditiveStrength != weapon.AdditiveStrength
                ||
                Damage != weapon.Damage
                ||
                SustainedFire != weapon.SustainedFire
                ||
                Radius != weapon.Radius
                ||
                Unwieldy != weapon.Unwieldy
                ||
                Reloadable != weapon.Reloadable )
            {
                return ( false );
            }

            if( DamageType.Type != weapon.DamageType.Type
                ||
                DamageType.Level != weapon.DamageType.Level )
            {
                return ( false );
            }

            foreach( DamageEffect damageEffect in DamageEffectSet )
            {
                if( !weapon.DamageEffectSet.Any( x => x.Equals( damageEffect ) ) )
                {
                    return ( false );
                }
            }

            foreach( DamageEffect damageEffect in weapon.DamageEffectSet )
            {
                if( !DamageEffectSet.Any( x => x.Equals( damageEffect ) ) )
                {
                    return ( false );
                }
            }

            if( ( null != ProfileModifier ) && ( null == weapon.ProfileModifier ) )
            {
                return ( false );
            }

            if( ( null == ProfileModifier ) && ( null != weapon.ProfileModifier ) )
            {
                return ( false );
            }

            if( ( null != ProfileModifier ) && ( null != weapon.ProfileModifier ) )
            {
                if( !ProfileModifier.Equals( weapon.ProfileModifier ) )
                {
                    return ( false );
                }
            }

            if( ( Range != null ) && ( weapon.Range == null ) )
            {
                return ( false );
            }

            if( ( Range == null ) && ( weapon.Range != null ) )
            {
                return ( false );
            }

            if( ( Range != null ) && ( weapon.Range != null ) )
            {
                if( Range.Amount != weapon.Range.Amount
                ||
                Range.Length != weapon.Range.Length )
                {
                    return ( false );
                }
            }

            if( UseOnce != weapon.UseOnce )
            {
                return( false );
            }

            if( IndirectFire != weapon.IndirectFire )
            {
                return ( false );
            }

            return ( true );
        }

        public enum EClass
        {
            I = 1,
            II = 2,
            III = 3,
            IV = 4,
            V = 5
        }

        public enum EType
        {
            Fernkampf = 1,
            Nahkampf = 2,
            Wurf = 3
        }

        public static readonly IList<EClass> EClassList = Enum.GetValues( typeof( EClass ) ).Cast<EClass>().ToList().AsReadOnly();

        public static readonly IList<EType> ETypeList = Enum.GetValues( typeof( EType ) ).Cast<EType>().ToList().AsReadOnly();

        public Guid ID
        {
            get;
            set;
        } = Guid.NewGuid();

        public bool Active
        {
            get;
            set;
        } = true;

        public string Name
        {
            get;
            set;
        } = "Bitte Namen eingeben";

        public string Description
        {
            get;
            set;
        } = String.Empty;

        public string Rules
        {
            get;
            set;
        } = String.Empty;

        public float Weight
        {
            get;
            set;
        } = 0;

        public int AdditionalPoints
        {
            get;
            set;
        } = 0;

        public EClass Class
        {
            get;
            set;
        } = EClass.I;

        public EType Type
        {
            get;
            set;
        } = EType.Fernkampf;

        public int Strength
        {
            get;
            set;
        } = 1;

        public bool AdditiveStrength
        {
            get;
            set;
        } = false;

        public int Damage
        {
            get;
            set;
        } = 1;

        public int SustainedFire
        {
            get;
            set;
        } = 0;

        public int Radius
        {
            get;
            set;
        } = 0;

        public bool Unwieldy
        {
            get;
            set;
        } = false;

        public bool Reloadable
        {
            get;
            set;
        } = false;

        public bool IndirectFire
        {
            get;
            set;
        } = false;

        public DamageType DamageType
        {
            get;
            set;
        } = new DamageType
        {
            Type = DamageType.EType.Kinetisch,
            Level = DamageType.ELevel.I
        };

        [JsonConverter( typeof( JsonDamageEffectSetConverter ) ) ]
        public HashSet<DamageEffect> DamageEffectSet
        {
            get;
            set;
        } = new HashSet<DamageEffect>();

        public ProfileModifier ProfileModifier
        {
            get;
            set;
        }

        public WeaponRange Range
        {
            get;
            set;
        } = new WeaponRange();

        public bool UseOnce
        {
            get;
            set;
        } = false;

        [JsonIgnore]
        public Image DamageTypeImage => DamageType.GetImage( DamageColor.EType.Red );

        [JsonIgnore]
        public Image EffectsImage => DamageEffect.GetEffectSetImage( DamageEffectSet, DamageColor.EType.Red );

        [JsonIgnore]
        public string EffectsString => DamageEffect.GetEffectSetString( DamageEffectSet );

        [JsonIgnore]
        public string FormattedStrength
        {
            get
            {
                if( 0 == Strength )
                {
                    return ( "-" );
                }
                else
                {
                    if( AdditiveStrength )
                    {
                        return ( "+" + Strength.ToString() );
                    }
                    else
                    {
                        return ( Strength.ToString() );
                    }
                }
            }
        }

        [JsonIgnore]
        public string FormattedDamage => ( 0 == Damage ) ? "-" : Damage.ToString();

        [JsonIgnore]
        public string FormattedSustainedFire => ( 0 == SustainedFire ) ? "-" : SustainedFire.ToString();

        [JsonIgnore]
        public string FormattedRange
        {
            get
            {
                switch( Type )
                {
                    case EType.Fernkampf:
                        if( Range.Length == 0
                            ||
                            Range.Amount == 0 )
                        {
                            return ( "-" );
                        }
                        else
                        {
                            return ( Range.Length + "/" + Range.Amount );
                        }

                    case EType.Nahkampf:
                        return ( "NK" );

                    case EType.Wurf:
                        return ( "Wurf" );

                    default:
                        throw new InvalidOperationException( "unkown Weapon.EType" );
                }
            }
        }

        [JsonIgnore]
        public int RangeSort
        {
            get
            {
                switch( Type )
                {
                    // close combat first
                    case EType.Nahkampf:
                        return ( -1 );

                    case EType.Fernkampf:
                        return ( Range.Length * Range.Amount );

                    // throwable last
                    case EType.Wurf:
                        return ( 999999 );

                    default:
                        throw new InvalidOperationException( "unkown Weapon.EType" );
                }
            }
        }

        [JsonIgnore]
        public string MaxRange
        {
            get
            {
                switch( Type )
                {
                    case EType.Fernkampf:
                        return( ( Range.Length * Range.Amount ) + "cm" );

                    case EType.Nahkampf:
                        return( "NK" );

                    case EType.Wurf:
                        return( "-" );

                    default:
                        throw new InvalidOperationException( "unkown Weapon.EType" );
                }
            }
        }

        [JsonIgnore]
        public string FormattedRadius => ( 0 == Radius ) ? "-" : Radius.ToString();

        [ JsonIgnore]
        public int Points => CalculatedPoints() + AdditionalPoints;

        private int CalculatedPoints()
        {
            var weaponCosts = Costs.Get().Weapons;

            float points = 0;

            // TODO calculate points with values
            // Radius
            // Range
            // Weight

            points += Strength * weaponCosts.Strength;
            points += Damage * weaponCosts.Damage;

            if( AdditiveStrength )
            {
                points *= weaponCosts.AdditiveStrengthMultiplicator;
            }

            for( int i = 0; i < (int)DamageType.Level; i++ )
            {
                points *= weaponCosts.DamageTypeLevelMultiplicator;
            }

            for( int i = 0; i < SustainedFire; i++ )
            {
                points *= weaponCosts.SustainedFireMultiplicator;
            }

            if( DamageEffectSet != null )
            {
                points += DamageEffectSet.Sum( x => x.Points );

                // scale points with the amount of different damage effects
                points *= (float)Math.Pow( weaponCosts.DamageEffectMultiplicator, DamageEffectSet.Count );
            }

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            if( Unwieldy )
            {
                points *= weaponCosts.UnwieldyMultiplicator;
            }

            if( Reloadable )
            {
                points *= weaponCosts.ReloadMultiplicator;
            }

            if( IndirectFire )
            {
                points *= weaponCosts.IndirectFireMultiplicator;
            }

            if( UseOnce )
            {
                points *= weaponCosts.UseOnceMultiplicator;
            }

            // the lower the class the higher the points
            points *= ( 1 + ( 5 - (int)Class ) * 0.25f );

            return ( (int)points );
        }

        public string Summary()
        {
            string text = String.Empty;

            if( null != this.ProfileModifier )
            {
                string profileModifierSummary = ProfileModifier.Summary();

                if( !String.IsNullOrEmpty( profileModifierSummary ) )
                {
                    text += profileModifierSummary;
                }
            }

            if( !String.IsNullOrEmpty( this.Rules ) )
            {
                if( !String.IsNullOrEmpty( text ) )
                {
                    text += Environment.NewLine;
                }

                text += this.Rules;
            }

            return ( text );
        }
    }
}