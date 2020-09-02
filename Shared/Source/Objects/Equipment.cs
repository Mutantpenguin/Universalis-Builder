using Newtonsoft.Json;
using System;

namespace Universalis
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
            AdditionalPoints = equipment.AdditionalPoints;
            Weight = equipment.Weight;

            AP = equipment.AP;

            UseOnce = equipment.UseOnce;

            if( null != equipment.AttributeModifier )
            {
                AttributeModifier = new AttributeModifier
                {
                    AGI = equipment.AttributeModifier.AGI,
                    BW = equipment.AttributeModifier.BW,
                    KO = equipment.AttributeModifier.KO,
                    FK = equipment.AttributeModifier.FK,
                    WN = equipment.AttributeModifier.WN,
                    EH = equipment.AttributeModifier.EH
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
                AdditionalPoints != equipment.AdditionalPoints
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

                text += this.Rules;
            }

            return ( text );
        }

        [JsonIgnore]
        public int Points
        {
            get
            {
                return ( CalculatedPoints() + AdditionalPoints );
            }
        }

        private int CalculatedPoints()
        {
            float points = 0;

            // TODO calculate points with values
            // AP
            // Weight - especially since it can be negative

            if( AttributeModifier != null )
            {
                points += AttributeModifier.Points();
            }

            if( UseOnce )
            {
                points *= Costs.EquipmentUseOnceMultiplicator;
            }

            return ( (int)points );
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
        public string ModKO
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.KO ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public string ModFK
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.FK ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public string ModWN
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.WN ) );
                }
                else
                {
                    return ( null );
                }
            }
        }

        [JsonIgnore]
        public string ModEH
        {
            get
            {
                if( null != AttributeModifier )
                {
                    return ( AttributeModifier.Format( AttributeModifier.EH ) );
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