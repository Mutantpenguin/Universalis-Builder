using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Universalis
{
    public class DamageEffect
    {
        public DamageEffect() { }

        public DamageEffect( DamageEffect damageEffect )
        {
            Set( damageEffect );
        }

        public void Set( DamageEffect damageEffect )
        {
            if( null == damageEffect )
            {
                throw new ArgumentNullException( nameof( damageEffect ) );
            }

            Active = damageEffect.Active;

            Name = damageEffect.Name;
            Description = damageEffect.Description;
            UsageType = damageEffect.UsageType;
            Rules = damageEffect.Rules;
            Points = damageEffect.Points;
            Icon = damageEffect.Icon;
        }

        public bool Equals( DamageEffect damageEffect )
        {
            if( null == damageEffect )
            {
                throw new ArgumentNullException( nameof( damageEffect ) );
            }

            if( Active != damageEffect.Active
                ||
                Name != damageEffect.Name
                ||
                Description != damageEffect.Description
                ||
                UsageType != damageEffect.UsageType
                ||
                Rules != damageEffect.Rules
                ||
                Points != damageEffect.Points )
            {
                return false;
            }

            if( Icon != damageEffect.Icon )
            {
                return false;
            }

            return true;
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

        [JsonConverter( typeof( JsonPngConverter ) )]
        public Bitmap Icon
        {
            get
            {
                return OriginalIcon;
            }
            set
            {
                OriginalIcon = value;

                if( OriginalIcon != null )
                {
                    IconGreen = DamageColor.Colorize( OriginalIcon, DamageColor.EType.Green );
                    IconRed = DamageColor.Colorize( OriginalIcon, DamageColor.EType.Red );
                }
                else
                {
                    IconGreen = null;
                    IconRed = null;
                }
            }
        }

        [JsonIgnore]
        private Bitmap OriginalIcon;
        [JsonIgnore]
        private Bitmap IconGreen;
        [JsonIgnore]
        private Bitmap IconRed;


        public string Description
        {
            get;
            set;
        } = String.Empty;

        public EUsageType UsageType
        {
            get;
            set;
        } = EUsageType.Alle;

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

        public Image GetColoredIcon( DamageColor.EType color )
        {
            switch( color )
            {
                case DamageColor.EType.Green:
                    return IconGreen;

                case DamageColor.EType.Red:
                    return IconRed;

                default:
                    throw new ArgumentException( "unkown " + nameof( DamageColor.EType ), nameof( color ) );
            }
        }

        private const int s_effectImageSize = 100;

        public static Image GetEffectsImage( HashSet<DamageEffect> damageEffectSet, DamageColor.EType color )
        {
            if( ( null != damageEffectSet ) && ( damageEffectSet.Count > 0 ) )
            {
                Bitmap tempImage = new Bitmap( damageEffectSet.Count * s_effectImageSize, s_effectImageSize );
                tempImage.MakeTransparent();
                using( Graphics drawing = Graphics.FromImage( tempImage ) )
                {
                    int i = 0;
                    foreach( DamageEffect damageEffect in damageEffectSet.OrderBy( x => x.Name ) )
                    {
                        drawing.DrawImage( damageEffect.GetColoredIcon( color ), new Rectangle( i * s_effectImageSize, 0, s_effectImageSize, s_effectImageSize ) );
                        i++;
                    }
                }

                return tempImage;
            }
            else
            {
                return s_emptyImage;
            }
        }

        public static string GetEffectsString( HashSet<DamageEffect> damageEffectSet )
        {
            if( ( null != damageEffectSet ) && ( damageEffectSet.Count > 0 ) )
            {
                string effectsString = string.Join( ", ", damageEffectSet.OrderBy( x => x.Name ).Select( x => x.Name ) );

                return effectsString;
            }
            else
            {
                return null;
            }
        }

        private static readonly Bitmap s_emptyImage = new Bitmap( 1, 1 );

        public enum EUsageType
        {
            Alle = 1,
            Waffe = 2,
            Rüstung = 3
        }
    }
}