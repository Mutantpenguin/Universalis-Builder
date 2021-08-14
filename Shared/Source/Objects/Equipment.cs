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

            Unwieldy = equipment.Unwieldy;

            if( null != equipment.ProfileModifier )
            {
                ProfileModifier = new ProfileModifier( equipment.ProfileModifier );
            }
            else
            {
                ProfileModifier = null;
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
                Unwieldy != equipment.Unwieldy
                ||
                AP != equipment.AP )
            {
                return ( false );
            }

            if( ( null != ProfileModifier ) && ( null == equipment.ProfileModifier ) )
            {
                return ( false );
            }

            if( ( null == ProfileModifier ) && ( null != equipment.ProfileModifier ) )
            {
                return ( false );
            }

            if( ( null != ProfileModifier ) && ( null != equipment.ProfileModifier ) )
            {
                if( !ProfileModifier.Equals( equipment.ProfileModifier ) )
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

        public bool Unwieldy
        {
            get;
            set;
        } = false;

        public uint AP
        {
            get;
            set;
        } = 0;

        public ProfileModifier ProfileModifier
        {
            get;
            set;
        } = null;

        [JsonIgnore]
        public string FormattedAP => ( AP == 0 ) ? "" : AP.ToString();
        
        public override string ToString()
        {
            string text = String.Empty;

            if( null != this.ProfileModifier )
            {
                string attributeModifierString = this.ProfileModifier.ToString();

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
        public int Points => CalculatedPoints() + AdditionalPoints;

        private int CalculatedPoints()
        {
            float points = 0;

            // TODO calculate points with values
            // AP
            // Weight - especially since it can be negative

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            if( UseOnce )
            {
                points *= Costs.EquipmentUseOnceMultiplicator;
            }

            if( Unwieldy )
            {
                points *= Costs.EquipmentUnwieldyMultiplicator;
            }

            return ( (int)points );
        }
    }
}