using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Tesserakt
{
    public class DamageType
    {
        public DamageType() {}

        public DamageType( DamageType damageType )
        {
            Type = damageType.Type;
            Level = damageType.Level;
        }

        public bool Equals( DamageType damageType )
        {
            if( null == damageType )
            {
                throw new ArgumentNullException( nameof( damageType ) );
            }

            if( Type != damageType.Type
                ||
                Level != damageType.Level )
            {
                return ( false );
            }

            return ( true );
        }

        public EType Type
        {
            get;
            set;
        }

        public ELevel Level
        {
            get;
            set;
        }

        [JsonIgnore]
        public Image GetOriginalImage
        {
            get
            {
                return ( getTypeImage( DamageColor.EType.Original ) );
            }
        }

        private static Image s_typ_kinetik_green = DamageColor.Colorize( TObjects.Properties.Resources.typ_kinetik, DamageColor.EType.Green );
        private static Image s_typ_schlag_green = DamageColor.Colorize( TObjects.Properties.Resources.typ_schlag, DamageColor.EType.Green );
        private static Image s_typ_schnitt_green = DamageColor.Colorize( TObjects.Properties.Resources.typ_schnitt, DamageColor.EType.Green );
        private static Image s_typ_strahl_green = DamageColor.Colorize( TObjects.Properties.Resources.typ_strahl, DamageColor.EType.Green );
        
        private static Image s_typ_kinetik_red = DamageColor.Colorize( TObjects.Properties.Resources.typ_kinetik, DamageColor.EType.Red );
        private static Image s_typ_schlag_red = DamageColor.Colorize( TObjects.Properties.Resources.typ_schlag, DamageColor.EType.Red );
        private static Image s_typ_schnitt_red = DamageColor.Colorize( TObjects.Properties.Resources.typ_schnitt, DamageColor.EType.Red );
        private static Image s_typ_strahl_red = DamageColor.Colorize( TObjects.Properties.Resources.typ_strahl, DamageColor.EType.Red );

        private static Image s_type_plus_green = DamageColor.Colorize( TObjects.Properties.Resources.typ_plus, DamageColor.EType.Green );
        private static Image s_type_plus_red = DamageColor.Colorize( TObjects.Properties.Resources.typ_plus, DamageColor.EType.Red );

        private Image getTypeImage( DamageColor.EType color )
        {
            switch( color )
            {
                case DamageColor.EType.Original:
                    switch( Type )
                    {
                        case EType.Kinetisch:
                            return ( TObjects.Properties.Resources.typ_kinetik );

                        case EType.Schlag:
                            return ( TObjects.Properties.Resources.typ_schlag );

                        case EType.Schnitt:
                            return ( TObjects.Properties.Resources.typ_schnitt );

                        case EType.Strahl:
                            return ( TObjects.Properties.Resources.typ_strahl );

                        default:
                            throw new InvalidOperationException( "unkown DamageType.EType" );
                    }

                case DamageColor.EType.Green:
                    switch( Type )
                    {
                        case EType.Kinetisch:
                            return ( s_typ_kinetik_green );

                        case EType.Schlag:
                            return ( s_typ_schlag_green );

                        case EType.Schnitt:
                            return ( s_typ_schnitt_green );

                        case EType.Strahl:
                            return ( s_typ_strahl_green );

                        default:
                            throw new InvalidOperationException( "unkown DamageType.EType" );
                    }

                case DamageColor.EType.Red:
                    switch( Type )
                    {
                        case EType.Kinetisch:
                            return ( s_typ_kinetik_red );

                        case EType.Schlag:
                            return ( s_typ_schlag_red );

                        case EType.Schnitt:
                            return ( s_typ_schnitt_red );

                        case EType.Strahl:
                            return ( s_typ_strahl_red );

                        default:
                            throw new InvalidOperationException( "unkown DamageType.EType" );
                    }

                default:
                    throw new ArgumentException( "unkown DamageColor.EType", nameof( color ) );
            }

        }

        public Image GetImage( DamageColor.EType color )
        {
            Bitmap tempImage = new Bitmap( s_typeImageWidth, s_typeImageHeight );

            using( Graphics drawing = Graphics.FromImage( tempImage ) )
            {
                Rectangle typeRect = new Rectangle( Point.Empty, new Size( s_typeImageWidth - s_levelWidth, s_typeImageHeight ) );

                drawing.DrawImage( getTypeImage( color ), typeRect );

                Image img_plus = null;
                switch( color )
                {
                    case DamageColor.EType.Original:
                        img_plus = TObjects.Properties.Resources.typ_plus;
                        break;

                    case DamageColor.EType.Green:
                        img_plus = s_type_plus_green;
                        break;

                    case DamageColor.EType.Red:
                        img_plus = s_type_plus_red;
                        break;

                    default:
                        throw new ArgumentException( "unkown DamageColor.EType", nameof( color ) );
                }

                // draw "pluses"
                drawing.DrawImage( img_plus, new Rectangle( s_typeImageWidth - s_levelWidth, 0, s_levelWidth, s_levelHeight ) );
                if( ( ELevel.II == Level ) || ( ELevel.III == Level ) )
                {
                    drawing.DrawImage( img_plus, new Rectangle( s_typeImageWidth - s_levelWidth, s_levelHeight, s_levelWidth, s_levelHeight ) );

                    if( ELevel.III == Level )
                    {
                        drawing.DrawImage( img_plus, new Rectangle( s_typeImageWidth - s_levelWidth, 2 * s_levelHeight, s_levelWidth, s_levelHeight ) );
                    }
                }
            }

            return ( tempImage );
        }

        private const int s_levelWidth = 100 / 3;
        private const int s_levelHeight = 100 / 3;
        private const int s_typeImageWidth = 100 + s_levelWidth;
        private const int s_typeImageHeight = 100;

        public static Image GetTypeListImage( IList<DamageType> damageTypeList, DamageColor.EType color )
        {
            if( ( null != damageTypeList ) && ( damageTypeList.Count > 0 ) )
            {
                Bitmap tempImage = new Bitmap( damageTypeList.Count * s_typeImageWidth, s_typeImageHeight );

                using( Graphics drawing = Graphics.FromImage( tempImage ) )
                {
                    int i = 0;
                    foreach( DamageType damageType in damageTypeList.OrderBy( x => x.Type.ToString() ) )
                    {
                        drawing.DrawImageUnscaled( damageType.GetImage( color ), i * s_typeImageWidth, 0 );
                        i++;
                    }
                }

                return ( tempImage );
            }
            else
            {
                return ( s_emptyImage );
            }
        }

        public enum EType
        {
            Kinetisch = 1,
            Schlag = 2,
            Schnitt = 3,
            Strahl = 4
        }

        public static IList<EType> ETypeList
        {
            get
            {
                return ( Enum.GetValues( typeof( EType ) ).Cast<EType>().ToList().AsReadOnly() );
            }
        }

        public enum ELevel
        {
            I = 1,
            II = 2,
            III = 3
        }

        public static IList<ELevel> ELevelList
        {
            get
            {
                return ( Enum.GetValues( typeof( ELevel ) ).Cast<ELevel>().ToList().AsReadOnly() );
            }
        }

        private static Bitmap s_emptyImage = new Bitmap( 1, 1 );
    }
}