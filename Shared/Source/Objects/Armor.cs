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

            DamageTypeList.Clear();

            if( null != armor.DamageTypeList )
            {
                foreach( DamageType damageType in armor.DamageTypeList )
                {
                    DamageTypeList.Add( new DamageType( damageType ) );
                }
            }

            DamageEffectSet.Clear();
            DamageEffectSet.UnionWith( armor.DamageEffectSet );
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

            foreach( DamageType damageType in DamageTypeList )
            {
                if( !armor.DamageTypeList.Any( x => x.Equals( damageType ) ) )
                {
                    return ( false );
                }
            }

            foreach( DamageType damageType in armor.DamageTypeList )
            {
                if( !DamageTypeList.Any( x => x.Equals( damageType ) ) )
                {
                    return ( false );
                }
            }

            foreach( DamageEffect damageEffect in DamageEffectSet )
            {
                if( !armor.DamageEffectSet.Any( x => x.Equals( damageEffect ) ) )
                {
                    return ( false );
                }
            }

            foreach( DamageEffect damageEffect in armor.DamageEffectSet )
            {
                if( !DamageEffectSet.Any( x => x.Equals( damageEffect ) ) )
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

        public List<DamageType> DamageTypeList
        {
            get;
            set;
        } = new List<DamageType>();

        [JsonConverter( typeof( JsonDamageEffectSetConverter ) )]
        public HashSet<DamageEffect> DamageEffectSet
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

            if( DamageTypeList != null )
            {
                foreach( var damageType in DamageTypeList )
                {
                    for( int i = 0; i < (int)damageType.Level; i++ )
                    {
                        points *= armorCosts.DamageTypeLevelMultiplicator;
                    }
                }
            }

            if( DamageEffectSet != null )
            {
                points += DamageEffectSet.Sum( x => x.Points );

                // scale points with the amount of different damage effects
                points *= (float)Math.Pow( armorCosts.DamageEffectMultiplicator, DamageEffectSet.Count );
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
        public Image TypesImage => DamageType.GetTypeListImage( DamageTypeList, DamageColor.EType.Green );

        [JsonIgnore]
        public Image EffectsImage => DamageEffect.GetEffectSetImage( DamageEffectSet, DamageColor.EType.Green );

        [JsonIgnore]
        public string EffectsString => DamageEffect.GetEffectSetString( DamageEffectSet );

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