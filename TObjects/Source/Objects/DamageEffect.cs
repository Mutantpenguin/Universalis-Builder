using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;

namespace Tesserakt
{
    public class DamageEffect
    {
        public EType Type
        {
            get;
            set;
        }

        [JsonIgnore]
        public Image GetOriginalImage
        {
            get
            {
                return ( GetImage( DamageColor.EType.Original ) );
            }
        }

        private static Image s_effekt_desintegrator_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_desintegrator, DamageColor.EType.Green );
        private static Image s_effekt_durchschlag_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_durchschlag, DamageColor.EType.Green );
        private static Image s_effekt_elektro_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_elektro, DamageColor.EType.Green );
        private static Image s_effekt_emp_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_emp, DamageColor.EType.Green );
        private static Image s_effekt_explosiv_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_explosiv, DamageColor.EType.Green );
        private static Image s_effekt_fusion_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_fusion, DamageColor.EType.Green );
        private static Image s_effekt_hitze_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_hitze, DamageColor.EType.Green );
        private static Image s_effekt_paralyse_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_paralyse, DamageColor.EType.Green );
        private static Image s_effekt_kälte_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_kälte, DamageColor.EType.Green );
        private static Image s_effekt_mikrowelle_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_mikrowelle, DamageColor.EType.Green );
        private static Image s_effekt_monomolekular_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_monomolekular, DamageColor.EType.Green );
        private static Image s_effekt_panzerbrechend_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_panzerbrechend, DamageColor.EType.Green );
        private static Image s_effekt_rail_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_rail, DamageColor.EType.Green );
        private static Image s_effekt_schrapnell_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_schrapnell, DamageColor.EType.Green );
        private static Image s_effekt_vibro_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_vibro, DamageColor.EType.Green );
        private static Image s_effekt_komposit_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_komposit, DamageColor.EType.Green );
        private static Image s_effekt_struktur_green = DamageColor.Colorize( TObjects.Properties.Resources.effekt_struktur, DamageColor.EType.Green );

        private static Image s_effekt_desintegrator_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_desintegrator, DamageColor.EType.Red );
        private static Image s_effekt_durchschlag_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_durchschlag, DamageColor.EType.Red );
        private static Image s_effekt_elektro_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_elektro, DamageColor.EType.Red );
        private static Image s_effekt_emp_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_emp, DamageColor.EType.Red );
        private static Image s_effekt_explosiv_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_explosiv, DamageColor.EType.Red );
        private static Image s_effekt_fusion_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_fusion, DamageColor.EType.Red );
        private static Image s_effekt_hitze_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_hitze, DamageColor.EType.Red );
        private static Image s_effekt_paralyse_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_paralyse, DamageColor.EType.Red );
        private static Image s_effekt_kälte_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_kälte, DamageColor.EType.Red );
        private static Image s_effekt_mikrowelle_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_mikrowelle, DamageColor.EType.Red );
        private static Image s_effekt_monomolekular_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_monomolekular, DamageColor.EType.Red );
        private static Image s_effekt_panzerbrechend_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_panzerbrechend, DamageColor.EType.Red );
        private static Image s_effekt_rail_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_rail, DamageColor.EType.Red );
        private static Image s_effekt_schrapnell_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_schrapnell, DamageColor.EType.Red );
        private static Image s_effekt_vibro_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_vibro, DamageColor.EType.Red );
        private static Image s_effekt_komposit_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_komposit, DamageColor.EType.Red );
        private static Image s_effekt_struktur_red = DamageColor.Colorize( TObjects.Properties.Resources.effekt_struktur, DamageColor.EType.Red );

        public Image GetImage( DamageColor.EType color )
        {
            switch( color )
            {
                case DamageColor.EType.Original:
                    switch( Type )
                    {
                        case EType.Desintegrator:
                            return ( TObjects.Properties.Resources.effekt_desintegrator );

                        case EType.Durchschlag:
                            return ( TObjects.Properties.Resources.effekt_durchschlag );

                        case EType.Elektro:
                            return ( TObjects.Properties.Resources.effekt_elektro );

                        case EType.EMP:
                            return ( TObjects.Properties.Resources.effekt_emp );

                        case EType.Explosiv:
                            return ( TObjects.Properties.Resources.effekt_explosiv );

                        case EType.Fusion:
                            return ( TObjects.Properties.Resources.effekt_fusion );

                        case EType.Hitze:
                            return ( TObjects.Properties.Resources.effekt_hitze );

                        case EType.Paralyse:
                            return ( TObjects.Properties.Resources.effekt_paralyse );

                        case EType.Kälte:
                            return ( TObjects.Properties.Resources.effekt_kälte );

                        case EType.Mikrowelle:
                            return ( TObjects.Properties.Resources.effekt_mikrowelle );

                        case EType.Monomolekular:
                            return ( TObjects.Properties.Resources.effekt_monomolekular );

                        case EType.Panzerbrechend:
                            return ( TObjects.Properties.Resources.effekt_panzerbrechend );

                        case EType.Rail:
                            return ( TObjects.Properties.Resources.effekt_rail );

                        case EType.Schrapnell:
                            return ( TObjects.Properties.Resources.effekt_schrapnell );

                        case EType.Vibro:
                            return ( TObjects.Properties.Resources.effekt_vibro );

                        case EType.Komposit:
                            return ( TObjects.Properties.Resources.effekt_komposit );

                        case EType.Struktur:
                            return ( TObjects.Properties.Resources.effekt_struktur );

                        default:
                            throw new InvalidOperationException( "unkown DamageEffect.EType" );
                    }

                case DamageColor.EType.Green:
                    switch( Type )
                    {
                        case EType.Desintegrator:
                            return ( s_effekt_desintegrator_green );

                        case EType.Durchschlag:
                            return ( s_effekt_durchschlag_green );

                        case EType.Elektro:
                            return ( s_effekt_elektro_green );

                        case EType.EMP:
                            return ( s_effekt_emp_green );

                        case EType.Explosiv:
                            return ( s_effekt_explosiv_green );

                        case EType.Fusion:
                            return ( s_effekt_fusion_green );

                        case EType.Hitze:
                            return ( s_effekt_hitze_green );

                        case EType.Paralyse:
                            return ( s_effekt_paralyse_green );

                        case EType.Kälte:
                            return ( s_effekt_kälte_green );

                        case EType.Mikrowelle:
                            return ( s_effekt_mikrowelle_green );

                        case EType.Monomolekular:
                            return ( s_effekt_monomolekular_green );

                        case EType.Panzerbrechend:
                            return ( s_effekt_panzerbrechend_green );

                        case EType.Rail:
                            return ( s_effekt_rail_green );

                        case EType.Schrapnell:
                            return ( s_effekt_schrapnell_green );

                        case EType.Vibro:
                            return ( s_effekt_vibro_green );

                        case EType.Komposit:
                            return ( s_effekt_komposit_green );

                        case EType.Struktur:
                            return ( s_effekt_struktur_green );

                        default:
                            throw new InvalidOperationException( "unkown DamageEffect.EType" );
                    }

                case DamageColor.EType.Red:
                    switch( Type )
                    {
                        case EType.Desintegrator:
                            return ( s_effekt_desintegrator_red );

                        case EType.Durchschlag:
                            return ( s_effekt_durchschlag_red );

                        case EType.Elektro:
                            return ( s_effekt_elektro_red );

                        case EType.EMP:
                            return ( s_effekt_emp_red );

                        case EType.Explosiv:
                            return ( s_effekt_explosiv_red );

                        case EType.Fusion:
                            return ( s_effekt_fusion_red );

                        case EType.Hitze:
                            return ( s_effekt_hitze_red );

                        case EType.Paralyse:
                            return ( s_effekt_paralyse_red );

                        case EType.Kälte:
                            return ( s_effekt_kälte_red );

                        case EType.Mikrowelle:
                            return ( s_effekt_mikrowelle_red );

                        case EType.Monomolekular:
                            return ( s_effekt_monomolekular_red );

                        case EType.Panzerbrechend:
                            return ( s_effekt_panzerbrechend_red );

                        case EType.Rail:
                            return ( s_effekt_rail_red );

                        case EType.Schrapnell:
                            return ( s_effekt_schrapnell_red );

                        case EType.Vibro:
                            return ( s_effekt_vibro_red );

                        case EType.Komposit:
                            return ( s_effekt_komposit_red );

                        case EType.Struktur:
                            return ( s_effekt_struktur_red );

                        default:
                            throw new InvalidOperationException( "unkown DamageEffect.EType" );
                    }

                default:
                    throw new ArgumentException( "unkown DamageColor.EType", nameof( color ) );
            }
        }

        public enum EType
        {
            Desintegrator = 1,
            Durchschlag = 2,
            Elektro = 3,
            EMP = 4,
            Explosiv = 5,
            Fusion = 6,
            Hitze = 7,
            Paralyse = 8,
            Kälte = 9,
            Mikrowelle = 10,
            Monomolekular = 11,
            Panzerbrechend = 12,
            Rail = 13,
            Schrapnell = 14,
            Vibro = 15,
            Komposit = 16,
            Struktur = 17
        }

        public static IList<EType> ETypelList
        {
            get
            {
                return ( Enum.GetValues( typeof( EType ) ).Cast<EType>().ToList().AsReadOnly() );
            }
        }

        private const int s_effectImageSize = 100;

        public static Image GetEffectListImage( IList<DamageEffect> damageEffectList, DamageColor.EType color )
        {
            if( ( null != damageEffectList ) && ( damageEffectList.Count > 0 ) )
            {
                Bitmap tempImage = new Bitmap( damageEffectList.Count * s_effectImageSize, s_effectImageSize );

                using( Graphics drawing = Graphics.FromImage( tempImage ) )
                {
                    int i = 0;
                    foreach( DamageEffect damageEffect in damageEffectList.OrderBy( x => x.Type.ToString() ) )
                    {
                        drawing.DrawImage( damageEffect.GetImage( color ), new Rectangle( i * s_effectImageSize, 0, s_effectImageSize, s_effectImageSize ) );
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

        public static string GetEffectListString( IList<DamageEffect> damageEffectList )
        {
            if( ( null != damageEffectList ) && ( damageEffectList.Count > 0 ) )
            {
                string effectsString = string.Join( ", ", damageEffectList.OrderBy( x => x.Type.ToString() ).Select( x => x.Type ) );

                return ( effectsString );
            }
            else
            {
                return ( null );
            }
        }

        private static Bitmap s_emptyImage = new Bitmap( 1, 1 );
    }
}