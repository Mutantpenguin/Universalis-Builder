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
        {
            DamageEffectList = new List<DamageEffect>();
        }

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

            Name = weapon.Name;
            Description = weapon.Description;
            Rules = weapon.Rules;
            Weight = weapon.Weight;
            AdditionalPoints = weapon.AdditionalPoints;
            WK = weapon.WK;
            Type = weapon.Type;
            Strength = weapon.Strength;
            AdditiveStrength = weapon.AdditiveStrength;
            Damage = weapon.Damage;
            DamageType = new DamageType( weapon.DamageType );

            DamageEffectList.Clear();
            DamageEffectList.AddRange( weapon.DamageEffectList );

            if( null != weapon.ProfileModifier )
            {
                ProfileModifier = new ProfileModifier( weapon.ProfileModifier );
            }
            else
            {
                ProfileModifier = null;
            }

            if( null != weapon.WeaponRange )
            {
                WeaponRange = new WeaponRange
                {
                    Length = weapon.WeaponRange.Length,
                    Amount = weapon.WeaponRange.Amount
                };
            }
            else
            {
                WeaponRange = null;
            }

            UseOnce = weapon.UseOnce;

            IndirectFire = weapon.IndirectFire;

            AF = weapon.AF;
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

            if( Name != weapon.Name
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

            if( WK != weapon.WK
                ||
                Type != weapon.Type
                ||
                Strength != weapon.Strength
                ||
                AdditiveStrength != weapon.AdditiveStrength
                ||
                Damage != weapon.Damage
                ||
                AF != weapon.AF
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

            foreach( DamageEffect damageEffect in DamageEffectList )
            {
                if( weapon.DamageEffectList.Find( x => x.Equals( damageEffect ) ) == null )
                {
                    return ( false );
                }
            }

            foreach( DamageEffect damageEffect in weapon.DamageEffectList )
            {
                if( DamageEffectList.Find( x => x.Equals( damageEffect ) ) == null )
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

            if( WeaponRange.Amount != weapon.WeaponRange.Amount
                ||
                WeaponRange.Length != weapon.WeaponRange.Length )
            {
                return( false );
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

        public EClass WK
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

        public int AF
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

        [JsonConverter( typeof( JsonDamageEffectListConverter ) ) ]
        public List<DamageEffect> DamageEffectList
        {
            get;
            set;
        }

        public ProfileModifier ProfileModifier
        {
            get;
            set;
        }

        public WeaponRange WeaponRange
        {
            get;
            set;
        } = new WeaponRange()
        {
            Length = 10,
            Amount = 1
        };

        public bool UseOnce
        {
            get;
            set;
        } = false;

        [JsonIgnore]
        public Image DamageTypeImage => DamageType.GetImage( DamageColor.EType.Red );

        [JsonIgnore]
        public Image EffectsImage => DamageEffect.GetEffectListImage( DamageEffectList, DamageColor.EType.Red );

        [JsonIgnore]
        public string EffectsString => DamageEffect.GetEffectListString( DamageEffectList );

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
        public string FormattedAF => ( 0 == AF ) ? "-" : AF.ToString();

        [JsonIgnore]
        public string FormattedRange
        {
            get
            {
                switch( Type )
                {
                    case EType.Fernkampf:
                        if( WeaponRange.Length == 0
                            ||
                            WeaponRange.Amount == 0 )
                        {
                            return ( "-" );
                        }
                        else
                        {
                            return ( WeaponRange.Length + "/" + WeaponRange.Amount );
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
                    case EType.Nahkampf:
                        return ( -1 );

                    default:
                        return ( WeaponRange.Length * WeaponRange.Amount );
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
                        return( ( WeaponRange.Length * WeaponRange.Amount ) + "cm" );

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
            float points = 0;

            // TODO calculate points with values
            // Radius
            // Range
            // Weight

            points += Strength * Costs.WeaponStrength;
            points += Damage * Costs.WeaponDamage;

            if( AdditiveStrength )
            {
                points *= Costs.WeaponAdditiveStrengthMultiplicator;
            }

            for( int i = 0; i < (int)DamageType.Level; i++ )
            {
                points *= Costs.WeaponDamageTypeLevelMultiplicator;
            }

            for( int i = 0; i < AF; i++ )
            {
                points *= Costs.WeaponAFMultiplicator;
            }

            // TODO each DamageEffect has its own points
            if( DamageEffectList != null )
            {
                foreach( var damageEffect in DamageEffectList )
                {
                    points += damageEffect.Points;
                }

                // scale points with the amount of different damage effects
                points *= (float)Math.Pow( Costs.WeaponDamageEffectMultiplicator, DamageEffectList.Count );
            }

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            if( Unwieldy )
            {
                points *= Costs.WeaponUnwieldyMultiplicator;
            }

            if( Reloadable )
            {
                points *= Costs.WeaponReloadMultiplicator;
            }

            if( IndirectFire )
            {
                points *= Costs.WeaponIndirectFireMultiplicator;
            }

            if( UseOnce )
            {
                points *= Costs.WeaponUseOnceMultiplicator;
            }

            points *= ( 1 + Math.Abs( 5 - (int)WK ) * 0.25f );

            return ( (int)points );
        }

        public override string ToString()
        {
            string text = String.Empty;

            if( null != this.ProfileModifier )
            {
                string attributeModifierString = this.ProfileModifier.ToString();

                if( !String.IsNullOrEmpty( attributeModifierString ) )
                {
                    text += attributeModifierString;
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