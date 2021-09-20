using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Universalis
{
    public class Trait
    {
        public Trait() { }

        public Trait( Trait trait )
        {
            Set( trait );
        }

        public void Set( Trait trait )
        {
            if( null == trait )
            {
                throw new ArgumentNullException( nameof( trait ) );
            }

            Active = trait.Active;

            Name = trait.Name;
            Description = trait.Description;
            Rules = trait.Rules;
            AdditionalPoints = trait.AdditionalPoints;
            UseOnce = trait.UseOnce;
            AP = trait.AP;
            MaxLevel = trait.MaxLevel;

            if( null != trait.ProfileModifier )
            {
                ProfileModifier = new ProfileModifier( trait.ProfileModifier );
            }
            else
            {
                ProfileModifier = null;
            }
        }

        public bool Equals( Trait trait )
        {
            if( null == trait )
            {
                throw new ArgumentNullException( nameof( trait ) );
            }

            if( Active != trait.Active
                ||
                Name != trait.Name
                ||
                Description != trait.Description
                ||
                Rules != trait.Rules
                ||
                AdditionalPoints != trait.AdditionalPoints
                ||
                UseOnce != trait.UseOnce
                ||
                AP != trait.AP
                ||
                MaxLevel != trait.MaxLevel )
            {
                return ( false );
            }

            if( ( null != ProfileModifier ) && ( null == trait.ProfileModifier ) )
            {
                return ( false );
            }

            if( ( null == ProfileModifier ) && ( null != trait.ProfileModifier ) )
            {
                return ( false );
            }

            if( ( null != ProfileModifier ) && ( null != trait.ProfileModifier ) )
            {
                if( !ProfileModifier.Equals( trait.ProfileModifier ) )
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
        } = "Bitte Regeln eingeben";

        public int AdditionalPoints
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

        public uint MaxLevel
        {
            get;
            set;
        } = 1;

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
                string profileModifierString = this.ProfileModifier.ToString();

                if( !String.IsNullOrEmpty( profileModifierString ) )
                {
                    if( this.UseOnce )
                    {
                        text += "Bei Verwendung: " + profileModifierString;
                    }
                    else
                    {
                        text += "Dauerhaft: " + profileModifierString;
                    }
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
        public string Type
        {
            get
            {
                var points = Points;

                if( points > 0 )
                {
                    return "+";
                }
                else if( points < 0 )
                {
                    return "-";
                }
                else
                {
                    return "=";
                }
            }
        }

        [JsonIgnore]
        public int MinPoints => CalculatedPoints( 0 );

        [JsonIgnore]
        public int MaxPoints => CalculatedPoints( MaxLevel );

        private int CalculatedPoints( uint level )
        {
            float points = 0;

            if( level == 0 )
            {
                points += AdditionalPoints;
            }
            else
            {
                points += level * AdditionalPoints;
            }

            // TODO calculate points with values
            // AP

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            return ( (int)points );
        }
    }
}