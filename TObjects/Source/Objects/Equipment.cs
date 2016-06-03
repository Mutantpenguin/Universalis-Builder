using Newtonsoft.Json;
using System;

namespace Tesserakt
{
    public class Equipment
    {
        public Equipment() { }

        public Equipment( Equipment equipment )
        {
            Set( equipment );
        }

        public void Set( Equipment equipment )
        {
            if( null == equipment )
            {
                throw new ArgumentNullException( nameof( equipment ) );
            }

            Name = equipment.Name;
            Description = equipment.Description;
            Rules = equipment.Rules;
            Points = equipment.Points;
            Weight = equipment.Weight;

            AP = equipment.AP;

            UseOnce = equipment.UseOnce;

            if( null != equipment.AttributeModifier )
            {
                AttributeModifier = new AttributeModifier
                {
                    AGI = equipment.AttributeModifier.AGI,
                    BW = equipment.AttributeModifier.BW,
                    KK = equipment.AttributeModifier.KK,
                    HAK = equipment.AttributeModifier.HAK,
                    AFG = equipment.AttributeModifier.AFG,
                    SH = equipment.AttributeModifier.SH
                };
            }
            else
            {
                AttributeModifier = null;
            }
        }

        public bool Equals( Equipment equipment )
        {
            if( null == equipment )
            {
                throw new ArgumentNullException( nameof( equipment ) );
            }

            if( Name != equipment.Name
                ||
                Description != equipment.Description
                ||
                Rules != equipment.Rules
                ||
                Points != equipment.Points
                ||
                Weight != equipment.Weight
                ||
                UseOnce != equipment.UseOnce
                ||
                AP != equipment.AP )
            {
                return ( false );
            }

            if( ( null != AttributeModifier ) && ( null == equipment.AttributeModifier ) )
            {
                return ( false );
            }

            if( ( null == AttributeModifier ) && ( null != equipment.AttributeModifier ) )
            {
                return ( false );
            }

            if( ( null != AttributeModifier ) && ( null != equipment.AttributeModifier ) )
            {
                if( !AttributeModifier.Equals( equipment.AttributeModifier ) )
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

        public bool UseOnce
        {
            get;
            set;
        } = false;

        public uint AP
        {
            get;
            set;
        } = 0;

        public AttributeModifier AttributeModifier
        {
            get;
            set;
        } = null;

        [JsonIgnore]
        public string FormattedAP
        {
            get
            {
                if( 0 == AP )
                {
                    return ( "" );
                }
                else
                {
                    return ( AP.ToString() );
                }
            }
        }

        public override string ToString()
        {
            string text = String.Empty;

            if( null != this.AttributeModifier )
            {
                string attributeModifierString = this.AttributeModifier.ToString();

                if( !String.IsNullOrEmpty( attributeModifierString ) )
                {
                    if( this.UseOnce )
                    {
                        text += "Bei Verwendung: " + attributeModifierString;
                    }
                    else
                    {
                        text += "Dauerhaft: " + attributeModifierString;
                    }
                }
            }

            if( !String.IsNullOrEmpty( this.Rules ) )
            {
                if( !String.IsNullOrEmpty( text  ) )
                { 
                    text += Environment.NewLine;
                }

                text += ToolTipHelper.FormatMaxWidth( this.Rules );
            }

            return ( text );
        }

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
    }
}