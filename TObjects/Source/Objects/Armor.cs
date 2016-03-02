using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tesserakt
{
    public class Armor
    {
        public Armor() { }

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

            Name = armor.Name;
            Description = armor.Description;
            Rules = armor.Rules;
            Weight = armor.Weight;
            Points = armor.Points;
            Potential = armor.Potential;
            SelfSustaining = armor.SelfSustaining;

            Camouflage = armor.Camouflage;
            CamouflageLevel = armor.CamouflageLevel;

            if( null != armor.AttributeModifier )
            {
                AttributeModifier = new AttributeModifier
                {
                    AGI = armor.AttributeModifier.AGI,
                    BW = armor.AttributeModifier.BW,
                    KK = armor.AttributeModifier.KK,
                    HAK = armor.AttributeModifier.HAK,
                    AFG = armor.AttributeModifier.AFG,
                    SH = armor.AttributeModifier.SH
                };
            }
            else
            {
                AttributeModifier = null;
            }

            if( null != DamageTypeList )
            {
                DamageTypeList.Clear();
            }
            else
            {
                DamageTypeList = new List<DamageType>();
            }

            if( null != armor.DamageTypeList )
            {
                foreach( DamageType danageType in armor.DamageTypeList )
                {
                    DamageTypeList.Add( new DamageType( danageType ) );
                }
            }
            
            if( null != armor.DamageEffectList )
            {
                DamageEffectList = new List<DamageEffect>( armor.DamageEffectList );
            }
            else
            {
                DamageEffectList = null;
            }
        }

        public bool Equals( Armor armor )
        {
            if( null == armor )
            {
                throw new ArgumentNullException( nameof( armor ) );
            }

            if( Name != armor.Name
                ||
                Description != armor.Description
                ||
                Rules != armor.Rules
                ||
                Points != armor.Points
                ||
                Weight != armor.Weight )
            {
                return ( false );
            }

            if( ( null != AttributeModifier ) && ( null == armor.AttributeModifier ) )
            {
                return ( false );
            }

            if( ( null == AttributeModifier ) && ( null != armor.AttributeModifier ) )
            {
                return ( false );
            }

            if( ( null != AttributeModifier ) && ( null != armor.AttributeModifier ) )
            {
                if( !AttributeModifier.Equals( armor.AttributeModifier ) )
                {
                    return ( false );
                }
            }

            if( Potential != armor.Potential
                ||
                SelfSustaining != armor.SelfSustaining )
            {
                return ( false );
            }

            if( Camouflage != armor.Camouflage
                ||
                CamouflageLevel != armor.CamouflageLevel )
            {
                return ( false );
            }

            if( ( ( null == DamageTypeList ) && ( null != armor.DamageTypeList ) )
                ||
                ( ( null != DamageTypeList ) && ( null == armor.DamageTypeList ) ) )
            {
                return ( false );
            }
            else
            {
                foreach( DamageType damageType in DamageTypeList )
                {
                    if( armor.DamageTypeList.Find( x => x.Equals( damageType ) ) == null )
                    {
                        return ( false );
                    }
                }

                foreach( DamageType damageType in armor.DamageTypeList )
                {
                    if( DamageTypeList.Find( x => x.Equals( damageType ) ) == null )
                    {
                        return ( false );
                    }
                }
            }

            if( ( ( null == DamageEffectList ) && ( null != armor.DamageEffectList ) )
                     ||
                     ( ( null != DamageEffectList ) && ( null == armor.DamageEffectList ) ) )
            {
                return ( false );
            }
            else
            {
                if( ( null != DamageEffectList ) && ( null != armor.DamageEffectList ) )
                {
                    if( DamageEffectList.Except( armor.DamageEffectList ).Any()
                        ||
                        armor.DamageEffectList.Except( DamageEffectList ).Any() )
                    {
                        return ( false );
                    }
                }
            }

            return ( true );
        }

        public enum ECamouflage
        {
            Keine = 0,
            Passiv = 1,
            Aktiv = 2
        }

        public static List<ECamouflage> ECamouflageList
        {
            get
            {
                return ( Enum.GetValues( typeof( ECamouflage ) ).Cast<ECamouflage>().ToList() );
            }
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

        public int Points
        {
            get;
            set;
        } = 0;

        public float Weight
        {
            get;
            set;
        } = 0;

        public AttributeModifier AttributeModifier
        {
            get;
            set;
        }

        public int Potential
        {
            get;
            set;
        } = 1;

        public ECamouflage Camouflage
        {
            get;
            set;
        } = Armor.ECamouflage.Keine;

        public int CamouflageLevel
        {
            get;
            set;
        } = 0;

        public List<DamageType> DamageTypeList
        {
            get;
            set;
        }

        public List<DamageEffect> DamageEffectList
        {
            get;
            set;
        }

        public bool SelfSustaining
        {
            get;
            set;
        } = false;

        #region Attributes
        [JsonIgnore]
        public string ModAGI
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.AGI ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public string ModBW
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.BW ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public string ModKK
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.KK ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public string ModHAK
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.HAK ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public string ModAFG
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.AFG ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public string ModSH
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.SH ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        #endregion Attributes

        [JsonIgnore]
        public Image TypesImage
        {
            get
            {
                return ( DamageType.GetTypeListImage( DamageTypeList, DamageColor.EType.Green ) );
            }
        }

        [JsonIgnore]
        public Image EffectsImage
        {
            get
            {
                return ( DamageEffect.GetEffectListImage( DamageEffectList, DamageColor.EType.Green ) );
            }
        }

        [JsonIgnore]
        public string EffectsString
        {
            get
            {
                return ( DamageEffect.GetEffectListString( DamageEffectList ) );
            }
        }
    }
}