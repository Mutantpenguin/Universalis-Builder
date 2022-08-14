using Newtonsoft.Json;
using System;

namespace Universalis
{
    public class Discipline
    {
        public Discipline() { }

        public Discipline( Discipline discipline )
        {
            Set( discipline );
        }

        public void Set( Discipline discipline )
        {
            if( null == discipline )
            {
                throw new ArgumentNullException( nameof( discipline ) );
            }

            Active = discipline.Active;

            Name = discipline.Name;
            Description = discipline.Description;
            BasePoints = discipline.BasePoints;
            MaxLevel = discipline.MaxLevel;
            MaxGroupQuantity = discipline.MaxGroupQuantity;

            if( null != discipline.Permissions )
            {
                Permissions = new Permissions( discipline.Permissions );
            }
            else
            {
                Permissions = null;
            }
        }

        public bool Equals( Discipline discipline )
        {
            if( null == discipline )
            {
                throw new ArgumentNullException( nameof( discipline ) );
            }

            if( Active != discipline.Active
                ||
                Name != discipline.Name
                ||
                Description != discipline.Description
                ||
                BasePoints != discipline.BasePoints
                ||
                MaxLevel != discipline.MaxLevel
                ||
                MaxGroupQuantity != discipline.MaxGroupQuantity )
            {
                return ( false );
            }

            if( ( ( null != Permissions ) && ( null == discipline.Permissions ) )
                ||
                ( ( null == Permissions ) && ( null != discipline.Permissions ) ) )
            {
                return ( false );
            }
            else if( ( null != Permissions ) && ( null != discipline.Permissions ) )
            {
                if( !Permissions.Equals( discipline.Permissions ) )
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

        public uint BasePoints
        {
            get;
            set;
        } = 0;

        public uint MaxLevel
        {
            get;
            set;
        } = 1;

        public uint MaxGroupQuantity
        {
            get;
            set;
        } = 0;

        public Permissions Permissions
        {
            get;
            set;
        }

        public int Points( uint level )
        {
            uint points = level * BasePoints;

            return ( (int)points );
        }

        [JsonIgnore]
        public int MinPoints => Points( 1 );

        [JsonIgnore]
        public int MaxPoints => Points( MaxLevel );

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
            return ( $"{Name}{StringHelper.NonBreakingSpace}{StringHelper.ToRoman( (int)level )}" );
        }

        public string Summary()
        {
            string text = String.Empty;

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
        public string FormattedMaxQuantity
        {
            get
            {
                if( MaxGroupQuantity == 0 )
                {
                    return String.Empty;
                }
                else
                {
                    return MaxGroupQuantity.ToString();
                }
            }
        }
    }
}