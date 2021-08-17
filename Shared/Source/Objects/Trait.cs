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
                AP != trait.AP )
            {
                return ( false );
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

        [JsonIgnore]
        public string FormattedAP => ( AP == 0 ) ? "" : AP.ToString();

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
                else if ( points < 0 )
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
        public int Points => AdditionalPoints;
    }
}