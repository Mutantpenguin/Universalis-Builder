using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Universalis
{
    public class Armor
    {
        public Armor()
        { }

        public Armor( Armor armor )
        {
            Set( armor );
        }

        public void Set( Armor armor )
        {
            if( null == armor )
            {
                throw new ArgumentNullException( nameof( armor ) );
            }

            Active = armor.Active;

            Name = armor.Name;
            Description = armor.Description;
            Rules = armor.Rules;
            Weight = armor.Weight;
            AdditionalPoints = armor.AdditionalPoints;
            Protection = armor.Protection;
            AdditiveProtection = armor.AdditiveProtection;
            SelfSustaining = armor.SelfSustaining;

            if( null != armor.ProfileModifier )
            {
                ProfileModifier = new ProfileModifier( armor.ProfileModifier );
            }
            else
            {
                ProfileModifier = null;
            }

            DamageEffects.Clear();
            DamageEffects.UnionWith( armor.DamageEffects );
        }

        public bool Equals( Armor armor )
        {
            if( null == armor )
            {
                throw new ArgumentNullException( nameof( armor ) );
            }

            if( Active != armor.Active
                ||
                Name != armor.Name
                ||
                Description != armor.Description
                ||
                Rules != armor.Rules
                ||
                AdditionalPoints != armor.AdditionalPoints
                ||
                Weight != armor.Weight )
            {
                return ( false );
            }

            if( Protection != armor.Protection
                ||
                AdditiveProtection != armor.AdditiveProtection
                ||
                SelfSustaining != armor.SelfSustaining )
            {
                return ( false );
            }

            if( ( null != ProfileModifier ) && ( null == armor.ProfileModifier ) )
            {
                return ( false );
            }

            if( ( null == ProfileModifier ) && ( null != armor.ProfileModifier ) )
            {
                return ( false );
            }

            if( ( null != ProfileModifier ) && ( null != armor.ProfileModifier ) )
            {
                if( !ProfileModifier.Equals( armor.ProfileModifier ) )
                {
                    return ( false );
                }
            }

            foreach( DamageEffect damageEffect in DamageEffects )
            {
                if( !armor.DamageEffects.Any( x => x.Equals( damageEffect ) ) )
                {
                    return ( false );
                }
            }

            foreach( DamageEffect damageEffect in armor.DamageEffects )
            {
                if( !DamageEffects.Any( x => x.Equals( damageEffect ) ) )
                {
                    return ( false );
                }
            }

            return ( true );
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

        public string Rules
        {
            get;
            set;
        } = String.Empty;

        public int AdditionalPoints
        {
            get;
            set;
        } = 0;

        public float Weight
        {
            get;
            set;
        } = 0;

        public ProfileModifier ProfileModifier
        {
            get;
            set;
        }

        public int Protection
        {
            get;
            set;
        } = 1;

        public bool AdditiveProtection
        {
            get;
            set;
        } = false;

        [JsonConverter( typeof( JsonDamageEffectSetConverter ) )]
        public HashSet<DamageEffect> DamageEffects
        {
            get;
            set;
        } = new HashSet<DamageEffect>();

        public bool SelfSustaining
        {
            get;
            set;
        } = false;

        [JsonIgnore]
        public int Points => CalculatedPoints() + AdditionalPoints;

        [JsonIgnore]
        public string FormattedProtection
        {
            get
            {
                if( 0 == Protection )
                {
                    return ( "-" );
                }
                else
                {
                    if( AdditiveProtection )
                    {
                        return ( "+" + Protection.ToString() );
                    }
                    else
                    {
                        return ( Protection.ToString() );
                    }
                }
            }
        }

        private int CalculatedPoints()
        {
            var armorCosts = Costs.Get().Armors;
            
            float points = 0;

            // TODO calculate points with values
            // Weight

            points += Protection * armorCosts.Protection;

            if( AdditiveProtection )
            {
                points *= armorCosts.AdditiveProtectionMultiplicator;
            }

            if( DamageEffects != null )
            {
                points += DamageEffects.Sum( x => x.Points );

                // scale points with the amount of different damage effects
                points *= (float)Math.Pow( armorCosts.DamageEffectMultiplicator, DamageEffects.Count );
            }

            if( SelfSustaining )
            {
                points *= armorCosts.SelfSustainingMultiplicator;
            }

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            return ( (int)points );
        }

        [JsonIgnore]
        public Image EffectsImage => DamageEffect.GetEffectsImage( DamageEffects, DamageColor.EType.Green );

        [JsonIgnore]
        public string EffectsString => DamageEffect.GetEffectsString( DamageEffects );

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