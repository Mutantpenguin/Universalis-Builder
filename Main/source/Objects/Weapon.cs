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
            MaxModelQuantity = weapon.MaxModelQuantity;
            MaxGroupQuantity = weapon.MaxGroupQuantity;
            Rules = weapon.Rules;
            Weight = weapon.Weight;
            AdditionalPoints = weapon.AdditionalPoints;
            Class = weapon.Class;
            Type = weapon.Type;
            Strength = weapon.Strength;
            AdditiveStrength = weapon.AdditiveStrength;
            Damage = weapon.Damage;

            DamageEffects.Clear();
            DamageEffects.UnionWith( weapon.DamageEffects );

            if( null != weapon.ProfileModifier )
            {
                ProfileModifier = new ProfileModifier( weapon.ProfileModifier );
            }
            else
            {
                ProfileModifier = null;
            }

            if( null != weapon.Permissions )
            {
                Permissions = new Permissions( weapon.Permissions );
            }
            else
            {
                Permissions = null;
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
                MaxModelQuantity != weapon.MaxModelQuantity
                ||
                MaxGroupQuantity != weapon.MaxGroupQuantity
                ||
                Rules != weapon.Rules
                ||
                AdditionalPoints != weapon.AdditionalPoints
                ||
                Weight != weapon.Weight )
            {
                return false;
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
                return false;
            }

            if( !DamageEffects.SetEquals( weapon.DamageEffects ) )
            {
                return false;
            }

            if( ( ( null != ProfileModifier ) && ( null == weapon.ProfileModifier ) )
                ||
                ( ( null == ProfileModifier ) && ( null != weapon.ProfileModifier ) ) )
            {
                return false;
            }
            else if( ( null != ProfileModifier ) && ( null != weapon.ProfileModifier ) )
            {
                if( !ProfileModifier.Equals( weapon.ProfileModifier ) )
                {
                    return false;
                }
            }

            if( ( ( null != Permissions ) && ( null == weapon.Permissions ) )
                ||
                ( ( null == Permissions ) && ( null != weapon.Permissions ) ) )
            {
                return false;
            }
            else if( ( null != Permissions ) && ( null != weapon.Permissions ) )
            {
                if( !Permissions.Equals( weapon.Permissions ) )
                {
                    return false;
                }
            }

            if( ( Range != null ) && ( weapon.Range == null ) )
            {
                return false;
            }

            if( ( Range == null ) && ( weapon.Range != null ) )
            {
                return false;
            }

            if( ( Range != null ) && ( weapon.Range != null ) )
            {
                if( Range.Amount != weapon.Range.Amount
                ||
                Range.Length != weapon.Range.Length )
                {
                    return false;
                }
            }

            if( UseOnce != weapon.UseOnce )
            {
                return false;
            }

            if( IndirectFire != weapon.IndirectFire )
            {
                return false;
            }

            return true;
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

        public uint MaxModelQuantity
        {
            get;
            set;
        } = 0;

        public uint MaxGroupQuantity
        {
            get;
            set;
        } = 0;

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

        [JsonConverter( typeof( JsonDamageEffectSetConverter ) ) ]
        public HashSet<DamageEffect> DamageEffects
        {
            get;
            set;
        } = new HashSet<DamageEffect>();

        public ProfileModifier ProfileModifier
        {
            get;
            set;
        }

        public Permissions Permissions
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
        public Image EffectsImage => DamageEffect.GetEffectsImage( DamageEffects, DamageColor.EType.Red );

        [JsonIgnore]
        public string EffectsString => DamageEffect.GetEffectsString( DamageEffects );

        [JsonIgnore]
        public string FormattedStrength
        {
            get
            {
                if( 0 == Strength )
                {
                    return "-";
                }
                else
                {
                    if( AdditiveStrength )
                    {
                        return "+" + Strength.ToString();
                    }
                    else
                    {
                        return Strength.ToString();
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
                            return "-";
                        }
                        else
                        {
                            return Range.Length + "/" + Range.Amount;
                        }

                    case EType.Nahkampf:
                        return "NK";

                    case EType.Wurf:
                        return "Wurf";

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
                        return -1;

                    case EType.Fernkampf:
                        return Range.Length * Range.Amount;

                    // throwable last
                    case EType.Wurf:
                        return 999999;

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
                        return ( Range.Length * Range.Amount ) + "cm";

                    case EType.Nahkampf:
                        return "NK";

                    case EType.Wurf:
                        return "-";

                    default:
                        throw new InvalidOperationException( "unkown Weapon.EType" );
                }
            }
        }

        [JsonIgnore]
        public string FormattedRadius => ( 0 == Radius ) ? "-" : Radius.ToString();

        [ JsonIgnore]
        public int Points => CalculatedPoints();

        private int CalculatedPoints()
        {
            var weaponCosts = Costs.Get().Weapons;

            float points = 0;

            points += AdditionalPoints;

            points += Strength * weaponCosts.Strength;
            points += Damage * weaponCosts.Damage;

            if( AdditiveStrength )
            {
                points *= weaponCosts.AdditiveStrengthMultiplicator;
            }

            for( int i = 0; i < SustainedFire; i++ )
            {
                points *= weaponCosts.SustainedFireMultiplicator;
            }

            if( DamageEffects != null )
            {
                points += DamageEffects.Sum( x => x.Points );

                // scale points with the amount of different damage effects
                points *= (float)Math.Pow( weaponCosts.DamageEffectMultiplicator, DamageEffects.Count );
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

            if( Type == EType.Fernkampf )
            {
                float rangeMultiplikator = 0.0f;

                // each cm adds 1% to the costs
                // but for each range-band the costs diminish
                // 1st is full, 2nd is half, 3rd a third and so on
                for( int i = 0; i < Range.Amount; i++ )
                {
                    rangeMultiplikator += (float)Range.Length / (i+1);
                }

                points *= 1 + ( rangeMultiplikator / 100.0f );
            }

            // each cm in radius adds 5%
            points *= 1 + ( ( Radius * 5 ) / 100.0f );

            // the lower the class the higher the points
            points *= ( 1 + ( 5 - (int)Class ) * 0.25f );

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            return (int)points;
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

            if( null != this.Permissions )
            {
                string permissionsSummary = Permissions.Summary();

                if( !String.IsNullOrEmpty( permissionsSummary ) )
                {
                    if( !String.IsNullOrEmpty( text ) )
                    {
                        text += Environment.NewLine + Environment.NewLine;
                    }

                    text += "Berechtigungen:" + Environment.NewLine + permissionsSummary;
                }
            }

            return text;
        }

        [JsonIgnore]
        public string FormattedMaxQuantity
        {
            get
            {
                if( ( MaxModelQuantity == 0 ) && ( MaxGroupQuantity == 0 ) )
                {
                    return String.Empty;
                }
                else
                {
                    return ( MaxModelQuantity == 0 ? "-" : MaxModelQuantity.ToString() ) + " / " + ( MaxGroupQuantity == 0 ? "-" : MaxGroupQuantity.ToString() );
                }
            }
        }
    }
}