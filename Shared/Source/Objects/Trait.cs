using Newtonsoft.Json;
using System;

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

            if( null != trait.Permissions )
            {
                Permissions = new Permissions( trait.Permissions );
            }
            else
            {
                Permissions = null;
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

            if( ( null != Permissions ) && ( null == trait.Permissions ) )
            {
                return ( false );
            }

            if( ( null == Permissions ) && ( null != trait.Permissions ) )
            {
                return ( false );
            }

            if( ( null != Permissions ) && ( null != trait.Permissions ) )
            {
                if( !Permissions.Equals( trait.Permissions ) )
                {
                    return ( false );
                }
            }

            return ( true );
        }

        public const string LevelPlaceholder = "[LVL]";

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

        public Permissions Permissions
        {
            get;
            set;
        }

        [JsonIgnore]
        public string FormattedAP => ( AP == 0 ) ? String.Empty : AP.ToString();

        public string Summary( uint level )
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

                text += FormattedRules( level );
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

            return ( text );
        }

        [JsonIgnore]
        public int MinPoints => Points( 1 );

        [JsonIgnore]
        public int MaxPoints => Points( MaxLevel );

        public int Points( uint level )
        {
            var traitCosts = Costs.Get().Traits;

            float points = 0;

            points += level * AdditionalPoints;

            if( UseOnce )
            {
                points *= traitCosts.UseOnceMultiplicator;
            }

            // the lower the needed AP the higher the points
            points *= ( 1 + ( 6 - AP ) * 0.25f );

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            return ( (int)points );
        }

        [JsonIgnore]
        public string PointsString
        {
            get
            {
                if( MaxLevel == 1 )
                {
                    return ( Points( 1 ).ToString() );
                }
                else
                {
                    return ( $"{Points( 1 )} bis {Points( MaxLevel )}" );
                }
            }
        }

        public string FormattedName( uint level )
        {
            if( MaxLevel == 1 )
            {
                return ( Name );
            }
            else
            {
                return ( $"{Name}{StringHelper.NonBreakingSpace}{StringHelper.ToRoman((int)level)}" );
            }
        }

        public string FormattedRules( uint level )
        {
            if( MaxLevel > 1 )
            {
                return Rules.Replace( LevelPlaceholder, level.ToString() );
            }
            else
            {
                return Rules;
            }
        }
    }
}