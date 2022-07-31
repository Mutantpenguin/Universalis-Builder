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
            MaxModelQuantity = equipment.MaxModelQuantity;
            MaxGroupQuantity = equipment.MaxGroupQuantity;
            Rules = equipment.Rules;
            BasePoints = equipment.BasePoints;
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

            if( null != equipment.Permissions )
            {
                Permissions = new Permissions( equipment.Permissions );
            }
            else
            {
                Permissions = null;
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
                MaxModelQuantity != equipment.MaxModelQuantity
                ||
                MaxGroupQuantity != equipment.MaxGroupQuantity
                ||
                Rules != equipment.Rules
                ||
                BasePoints != equipment.BasePoints
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

            if( ( ( null != ProfileModifier ) && ( null == equipment.ProfileModifier ) )
                ||
                ( ( null == ProfileModifier ) && ( null != equipment.ProfileModifier ) ) )
            {
                return ( false );
            }
            else if( ( null != ProfileModifier ) && ( null != equipment.ProfileModifier ) )
            {
                if( !ProfileModifier.Equals( equipment.ProfileModifier ) )
                {
                    return ( false );
                }
            }

            if( ( ( null != Permissions ) && ( null == equipment.Permissions ) )
                ||
                ( ( null == Permissions ) && ( null != equipment.Permissions ) ) )
            {
                return ( false );
            }
            else if( ( null != Permissions ) && ( null != equipment.Permissions ) )
            {
                if( !Permissions.Equals( equipment.Permissions ) )
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

        public uint MaxModelQuantity
        {
            get;
            set;
        } = 0;

        public uint MaxGroupQuantity
        {
            get;
            set;
        } = 0;

        public string Rules
        {
            get;
            set;
        } = String.Empty;

        public int BasePoints
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

        public Permissions Permissions
        {
            get;
            set;
        }

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
        public int Points => CalculatedPoints();

        private int CalculatedPoints()
        {
            float points = BasePoints;

            if( ProfileModifier != null )
            {
                points += ProfileModifier.Points();
            }

            return ( (int)points );
        }

        [JsonIgnore]
        public string FormattedMaxQuantity
        {
            get
            {
                if( ( MaxModelQuantity == 0 ) && ( MaxGroupQuantity == 0 ) )
                {
                    return String.Empty;
                }
                else
                {
                    return ( MaxModelQuantity == 0 ? "-" : MaxModelQuantity.ToString() ) + " / " + ( MaxGroupQuantity == 0 ? "-" : MaxGroupQuantity.ToString() );
                }
            }
        }
    }
}