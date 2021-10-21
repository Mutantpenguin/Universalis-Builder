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

            Active = equipment.Active;

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

            if( Active != equipment.Active
                ||
                Name != equipment.Name
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
        public string FormattedAP => ( AP == 0 ) ? String.Empty : AP.ToString();
        
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

        [JsonIgnore]
        public int Points => CalculatedPoints() + AdditionalPoints;

        private int CalculatedPoints()
        {
            var equipmentCosts = Costs.Get().Equipments;

            float points = 0;

            // TODO calculate points with values
            // Weight - especially since it can be negative

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            if( UseOnce )
            {
                points *= equipmentCosts.UseOnceMultiplicator;
            }

            if( Unwieldy )
            {
                points *= equipmentCosts.UnwieldyMultiplicator;
            }

            // the lower the needed AP the higher the points
            points *= ( 1 + ( 6 - AP ) * 0.25f );

            return ( (int)points );
        }
    }
}