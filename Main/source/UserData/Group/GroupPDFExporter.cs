using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Universalis
{
    public static class GroupPDFExporter
    {
        private const int dpi = 72;

        private static readonly float s_cardWidth = CmToPixel( CardPainter.CardWidthCm );
        private static readonly float s_cardHeight = CmToPixel( CardPainter.CardHeightCm );

        #region fonts
        private static readonly BaseFont s_baseFontUniversalis = BaseFont.CreateFont( UniversalisFont.FileName, BaseFont.CP1252, BaseFont.EMBEDDED, BaseFont.CACHED, Shared.Properties.Resources.NovaRound_Regular, null );

        private static readonly Font s_pageTitleFont = new Font( s_baseFontUniversalis, CmToPixel( 1 ), Font.BOLD, Color.WHITE );
        private static readonly Font s_versionInfoFont = new Font( Font.HELVETICA, CmToPixel( 0.25f ), Font.NORMAL, Color.GRAY );

        private static readonly Font s_actorFont = new Font( s_baseFontUniversalis, CmToPixel( 0.5f ) );
        private static readonly Font s_actorFontHeader = new Font( s_baseFontUniversalis, CmToPixel( 0.5f ), Font.BOLD );

        private static readonly Font s_groupTraitFontHeader = new Font( s_baseFontUniversalis, CmToPixel( 0.5f ), Font.BOLD );

        private static readonly Font s_flipsideHeaderFont = new Font( s_baseFontUniversalis, CmToPixel( 0.35f ), Font.NORMAL, Color.WHITE );
        private static readonly Font s_nameFlipsideFont = new Font( s_baseFontUniversalis, CmToPixel( 0.2f ), Font.BOLD );
        private static readonly Font s_rulesFlipsideFont = new Font( Font.HELVETICA, CmToPixel( 0.2f ) );

        private static readonly Font s_damageEffectFont = new Font( s_baseFontUniversalis, CmToPixel( 0.5f ) );
        private static readonly Font s_damageEffectFontHeader = new Font( s_baseFontUniversalis, CmToPixel( 0.5f ), Font.BOLD );
        #endregion

        #region flipside
        private static readonly float s_flipsideHeaderHeight = CmToPixel( 0.5f );

        private static readonly System.Drawing.Image s_flipsideHeader = SectionHeader.Create( CardPainter.CmToPixel( CardPainter.CardWidthCm ), CardPainter.CmToPixel( 0.5 ), System.Drawing.Color.Gray );

        private static readonly float s_flipsideMargin = CmToPixel( 0.1f );
        private static readonly float s_flipsideColumnWidth = ( s_cardWidth - ( 4 * s_flipsideMargin ) ) / 3;

        private static readonly float s_flipsideHeight = s_cardHeight - s_flipsideHeaderHeight;

        private static readonly float[][] s_flipsideColumns = new float[][]
                {
                    new [] { s_flipsideMargin,                                         s_flipsideMargin, s_flipsideMargin + s_flipsideColumnWidth,                 s_flipsideHeight - s_flipsideMargin },
                    new [] { ( 2 * s_flipsideMargin ) + s_flipsideColumnWidth,         s_flipsideMargin, ( 2 * s_flipsideMargin ) + ( 2 * s_flipsideColumnWidth ), s_flipsideHeight - s_flipsideMargin },
                    new [] { ( 3 * s_flipsideMargin ) + ( 2 * s_flipsideColumnWidth ), s_flipsideMargin, ( 3 * s_flipsideMargin ) + ( 3 * s_flipsideColumnWidth ), s_flipsideHeight - s_flipsideMargin }
                };

        private const string s_flipsideHeaderTitle = "Sonderregeln";

        private static readonly float s_flipsideHeaderTitleAscent = s_baseFontUniversalis.GetAscentPoint( s_flipsideHeaderTitle, s_flipsideHeaderFont.Size );
        private static readonly float s_flipsideHeaderTitleDescent = s_baseFontUniversalis.GetDescentPoint( s_flipsideHeaderTitle, s_flipsideHeaderFont.Size );
        #endregion

        private static readonly string s_versionInfo = "Am " + DateTime.Now.ToShortDateString() + " mit \"Universalis\" Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString( 2 ) + " erzeugt";

        private static float CmToPixel( float cm )
        {
            return( cm / 2.54f * dpi );
        }

        private static float PixelToCm( float pixel )
        {
            return ( pixel * 2.54f / dpi );
        }

        public static void GeneratePDF( Universe p_universe, Group p_group, string p_fileName )
        {
            if( null == p_group )
            {
                throw new ArgumentNullException( nameof( p_group ) );
            }

            Cursor.Current = Cursors.WaitCursor;

            float marginDocument = CmToPixel( 1 );

            Document document = new Document( PageSize.A4, marginDocument, marginDocument, marginDocument, marginDocument );

            using( FileStream fs = new FileStream( p_fileName, FileMode.Create, FileAccess.Write ) )
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance( document, fs );

                document.AddTitle( p_group.Name );
                document.AddAuthor( "Markus Lobedann & Sandro Sapienza" );
                document.AddCreator( s_versionInfo );
                document.AddKeywords( "Einheitenkarten für das Universalis Tabletop Spiel" );
                document.AddSubject( p_group.Description );
                document.AddCreationDate();

                document.Open();

                CreateMainPage( document, pdfWriter, p_universe, p_group );
                CreateCardPages( document, pdfWriter, p_group );
                CreateDamageEffectsPage( document, pdfWriter, p_group );

                document.Close();
            }

            System.Diagnostics.Process.Start( p_fileName );

            Cursor.Current = Cursors.Arrow;
        }

        private static void CreateMainPage( Document document, PdfWriter pdfWriter, Universe universe, Group group )
        {
            document.SetPageSize( PageSize.A4 );

            document.NewPage();

            float printableWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;

            float headerBarHeightCm = 1.2f;

            float headerBarHeight = CmToPixel( headerBarHeightCm );

            PdfContentByte cb = pdfWriter.DirectContent;
            
            PdfTemplate headerBarTemplate = cb.CreateTemplate( printableWidth, headerBarHeight );

            using( System.Drawing.Image img = SectionHeader.Create( CardPainter.CmToPixel( PixelToCm( printableWidth ) ), CardPainter.CmToPixel( headerBarHeightCm ), System.Drawing.Color.Gray ) )
            {
                Image headerBarImage = Image.GetInstance( img, System.Drawing.Imaging.ImageFormat.Jpeg );
                headerBarImage.ScaleToFit( printableWidth, headerBarHeight );
                headerBarImage.SetAbsolutePosition( 0, 0 );
                headerBarTemplate.AddImage( headerBarImage );
            }
            
            float margin = CmToPixel( 0.1f );
            float factionImgWidth = CmToPixel( 1.0f );
            float groupImgWidth = CmToPixel( 1.0f );
            
            Image factionImg = Image.GetInstance( group.Faction.Icon, System.Drawing.Imaging.ImageFormat.Png );
            factionImg.ScaleToFit( factionImgWidth, factionImgWidth );
            factionImg.SetAbsolutePosition( margin, margin );
            headerBarTemplate.AddImage( factionImg );

            Image groupImg = Image.GetInstance( group.Icon, System.Drawing.Imaging.ImageFormat.Png );
            groupImg.ScaleToFit( groupImgWidth, groupImgWidth );
            groupImg.SetAbsolutePosition( 2 * margin + factionImgWidth, margin );
            headerBarTemplate.AddImage( groupImg );
            
            float s_headerTitleAscent = s_baseFontUniversalis.GetAscentPoint( group.Name, s_pageTitleFont.Size );
            float s_headerTitleDescent = s_baseFontUniversalis.GetDescentPoint( group.Name, s_pageTitleFont.Size );
            ColumnText.ShowTextAligned( headerBarTemplate, Element.ALIGN_LEFT, new Phrase( group.Name, s_pageTitleFont ), 3 * margin + factionImgWidth + groupImgWidth, ( headerBarHeight - s_headerTitleAscent - s_headerTitleDescent ) / 2, 0 );
            
            document.Add( Image.GetInstance( headerBarTemplate ) );

            float columnWidth = ( document.PageSize.Width - document.LeftMargin - document.RightMargin ) / 2.0f;

            PdfPTable infoTable = new PdfPTable( new float[ 2 ] { columnWidth, columnWidth } )
            {
                WidthPercentage = 100,
                SpacingBefore = 0f,
                SpacingAfter = CmToPixel( 0.5f ),
            };

            infoTable.AddCell( new PdfPCell( new Phrase( $"Für das Universum \"{universe.NameWithVersionAndHash()}\"", s_versionInfoFont ) )
            {
                Border = Rectangle.NO_BORDER,
                BackgroundColor = universe.Modified ? Color.RED : null
            } );

            infoTable.AddCell( new PdfPCell( new Phrase( s_versionInfo, s_versionInfoFont ) )
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                BackgroundColor = universe.Modified ? Color.RED : null
            } );

            document.Add( infoTable );

            if( !String.IsNullOrEmpty( group.Description ) )
            {
                document.Add( new Paragraph( group.Description ) );
            }

            ShowActors( document, group );

            if( group.GroupTrait != null )
            {
                document.Add( new LineSeparator( 0.3f, 100, Color.BLACK, Element.ALIGN_LEFT, -2 ) );
                document.Add( new Paragraph( group.GroupTrait.Name, s_groupTraitFontHeader ) );
                document.Add( new Paragraph( group.GroupTrait.Rules ) );
            }
        }

        private static void ShowActors( Document document, Group group )
        {
            float printableWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            float actorImgWidth = CmToPixel( 1 );
            float pointsWidth = CmToPixel( 2 );
            float modelNameWidth = printableWidth - ( actorImgWidth + pointsWidth );

            const int columnCount = 3;

            PdfPTable overviewTable = new PdfPTable( new float[ columnCount ] { actorImgWidth, modelNameWidth, pointsWidth } )
            {
                WidthPercentage = 100,
                SpacingBefore = CmToPixel( 1.0f ),
                SpacingAfter = CmToPixel( 1.0f ),
            };

            // TableHeader
            overviewTable.AddCell( new PdfPCell( new Phrase( "Modell", s_actorFontHeader ) )
            {
                Border = Rectangle.NO_BORDER,
                Colspan = 2
            } );
            overviewTable.AddCell( new PdfPCell( new Phrase( "Punkte", s_actorFontHeader ) )
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            } );

            foreach( var actor in group.Models.Where( x => x.Active )
                                                 .OrderBy( x => x.Name ) )
            {
                Image actorImg = Image.GetInstance( actor.Icon ?? group.Faction.Icon, System.Drawing.Imaging.ImageFormat.Png );
                actorImg.ScaleToFit( CmToPixel( 0.9f ), CmToPixel( 0.9f ) );
                overviewTable.AddCell( new PdfPCell( actorImg )
                {
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    MinimumHeight = CmToPixel( 1 )
                } );

                overviewTable.AddCell( new PdfPCell( new Phrase( actor.Name, s_actorFont ) )
                {
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                } );

                overviewTable.AddCell( new PdfPCell( new Phrase( actor.Points.ToString() ) )
                {
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                } );
            }

            if( group.GroupTrait != null )
            {
                overviewTable.AddCell( new PdfPCell( new Phrase( $"Gruppeneigenschaft: {group.GroupTrait.Name} / {group.GroupTrait.PointsPerModel.ToString()} Punkte pro Modell" ) )
                {
                    Colspan = columnCount - 1,
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    MinimumHeight = CmToPixel( 1 )
                } );
                overviewTable.AddCell( new PdfPCell( new Phrase( group.GroupTrait.Points( group.Models.Count() ).ToString() ) )
                {
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                } );
            }

            overviewTable.AddCell( new PdfPCell( new Phrase( "Gesamtpunkte", s_actorFontHeader ) )
            {
                Colspan = columnCount - 1,
                Border = Rectangle.TOP_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            } );
            overviewTable.AddCell( new PdfPCell( new Phrase( group.Points.ToString(), s_actorFontHeader ) )
            {
                Border = Rectangle.TOP_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            } );

            document.Add( overviewTable );
        }

        private struct flipsideBlock
        {
            public string Name;
            public string Rules;
        };

        private static void CreateCardPages( Document document, PdfWriter pdfWriter, Group group )
        {
            document.SetPageSize( PageSize.A4.Rotate() );

            float distanceX = ( document.PageSize.Width - ( 2 * s_cardWidth ) ) / 3;
            float distanceY = ( document.PageSize.Height - ( 2 * s_cardHeight ) ) / 2;

            System.Drawing.PointF[] positions = new System.Drawing.PointF[ 2 ];
            positions[ 0 ].X = distanceX;
            positions[ 0 ].Y = distanceY + s_cardHeight;
            positions[ 1 ].X = ( 2 * distanceX ) + s_cardWidth;
            positions[ 1 ].Y = distanceY + s_cardHeight;

            List<Actor> sortedActorList = group.Models.Where( x => x.Active )
                                                         .OrderBy( x => x.Name )
                                                         .ToList();

            for( int i = 0; i < sortedActorList.Count; i++ )
            {
                if( i % 2 == 0 )
                {
                    document.NewPage();
                }

                Actor actor = sortedActorList[ i ];

                using( System.Drawing.Image img = CardPainter.GetBitmap( actor ) )
                {
                    Image imgCard = Image.GetInstance( img, System.Drawing.Imaging.ImageFormat.Jpeg );
                    imgCard.ScaleToFit( s_cardWidth, s_cardHeight );
                    imgCard.SetAbsolutePosition( positions[ i % 2 ].X, positions[ i % 2 ].Y );

                    document.Add( imgCard );
                }

                List<flipsideBlock> flipsideBlocks = new List<flipsideBlock>();

                foreach( var entry in actor.Traits.Select( x => new { x.Trait, x.Level } )
                                                     .Distinct()
                                                     .Select( x => new { Name = x.Trait.FormattedName( x.Level ), Rules = x.Trait.FormattedRules( x.Level ) } )
                                                     .Where( x => !String.IsNullOrEmpty( x.Rules ) ) )
                {
                    flipsideBlocks.Add( new flipsideBlock() { Name = entry.Name, Rules = entry.Rules } );
                }

                if( ( actor.Armor != null )
                    &&
                    ( !String.IsNullOrEmpty( actor.Armor.Rules ) ) )
                {
                    flipsideBlocks.Add( new flipsideBlock() { Name = actor.Armor.Name, Rules = actor.Armor.Rules } );
                }

                foreach( Weapon weapon in actor.Weapons.Select( x => x.Weapon )
                                                          .Distinct()
                                                          .Where( x => !String.IsNullOrEmpty( x.Rules ) ) )
                {
                    flipsideBlocks.Add( new flipsideBlock() { Name = weapon.Name, Rules = weapon.Rules } );
                }

                foreach( Equipment equipment in actor.Equipments.Select( x => x.Equipment )
                                                                   .Distinct()
                                                                   .Where( x => !String.IsNullOrEmpty( x.Rules ) ) )
                {
                    flipsideBlocks.Add( new flipsideBlock() { Name = equipment.Name, Rules = equipment.Rules } );
                }

                if( flipsideBlocks.Count > 0 )
                {
                    PdfContentByte cb = pdfWriter.DirectContent;

                    {
                        PdfTemplate flipsideHeaderTemplate = cb.CreateTemplate( s_cardWidth, s_flipsideHeaderHeight );

                        Image imgFlipsideHeaderImg = Image.GetInstance( s_flipsideHeader, System.Drawing.Imaging.ImageFormat.Jpeg );
                        imgFlipsideHeaderImg.ScaleToFit( s_cardWidth, s_flipsideHeaderHeight );

                        imgFlipsideHeaderImg.SetAbsolutePosition( 0, 0 );

                        flipsideHeaderTemplate.AddImage( imgFlipsideHeaderImg );

                        ColumnText.ShowTextAligned( flipsideHeaderTemplate, Element.ALIGN_LEFT, new Phrase( s_flipsideHeaderTitle, s_flipsideHeaderFont ), s_flipsideMargin, ( s_flipsideHeaderHeight - s_flipsideHeaderTitleAscent - s_flipsideHeaderTitleDescent ) / 2, 0 );

                        Image flipsideHeaderImg = Image.GetInstance( flipsideHeaderTemplate );
                        flipsideHeaderImg.RotationDegrees = 180;
                        flipsideHeaderImg.SetAbsolutePosition( positions[ i % 2 ].X, positions[ i % 2 ].Y - s_cardHeight );

                        document.Add( flipsideHeaderImg );
                    }

                    {
                        // create the Template for the information for the back of the card
                        PdfTemplate flipsideTemplate = cb.CreateTemplate( s_cardWidth, s_cardHeight - s_flipsideHeaderHeight );

                        {
                            int columnIndex = 0;

                            ColumnText columnText = new ColumnText( flipsideTemplate );
                            columnText.SetSimpleColumn( s_flipsideColumns[ columnIndex ][ 0 ], s_flipsideColumns[ columnIndex ][ 1 ], s_flipsideColumns[ columnIndex ][ 2 ], s_flipsideColumns[ columnIndex ][ 3 ] );

                            foreach( var block in flipsideBlocks.OrderBy( x => x.Name ) )
                            {
                                NewFlipsideEntryBlock( columnText, ref columnIndex, block );
                            }
                        }

                        {
                            // image-wrapper for the template which we can rotate
                            Image flipsideImg = Image.GetInstance( flipsideTemplate );
                            flipsideImg.ScaleAbsolute( s_cardWidth, s_cardHeight - s_flipsideHeaderHeight );
                            flipsideImg.RotationDegrees = 180;
                            flipsideImg.SetAbsolutePosition( positions[ i % 2 ].X, positions[ i % 2 ].Y - s_cardHeight + s_flipsideHeaderHeight );

                            document.Add( flipsideImg );
                        }
                    }

                    // draw a bounding-rectangle over the card and for the information on the back
                    cb.SaveState();
                    cb.SetColorStroke( Color.BLACK );
                    cb.Rectangle( positions[ i % 2 ].X, positions[ i % 2 ].Y, s_cardWidth, s_cardHeight );
                    cb.Rectangle( positions[ i % 2 ].X, positions[ i % 2 ].Y - s_cardHeight, s_cardWidth, s_cardHeight );
                    cb.Stroke();
                    cb.RestoreState();
                }
            }
        }

        private static void NewFlipsideEntryBlock( ColumnText columnText, ref int columnIndex, flipsideBlock block )
        {
            PdfPTable table = new PdfPTable( 1 )
            {
                WidthPercentage = 100,
                SpacingBefore = 0f,
                SpacingAfter = 0f,
                KeepTogether = true
            };

            PdfPCell cell = new PdfPCell()
            {
                Border = Rectangle.NO_BORDER
            };

            cell.AddElement( new Phrase( block.Name, s_nameFlipsideFont ) );
            cell.AddElement( new LineSeparator( 0.3f, 100, Color.BLACK, Element.ALIGN_LEFT, -2 ) );
            cell.AddElement( new Phrase( block.Rules, s_rulesFlipsideFont ) );

            table.AddCell( cell );

            float yLine = columnText.YLine;

            columnText.AddElement( table );

            int status = columnText.Go( simulate: true );

            if( ColumnText.HasMoreText( status ) )
            {
                columnIndex += 1;

                columnText.SetSimpleColumn( s_flipsideColumns[ columnIndex ][ 0 ], s_flipsideColumns[ columnIndex ][ 1 ], s_flipsideColumns[ columnIndex ][ 2 ], s_flipsideColumns[ columnIndex ][ 3 ] );
                yLine = s_flipsideColumns[ columnIndex ][ 3 ];
            }

            columnText.YLine = yLine;
            columnText.SetText( null );

            columnText.AddElement( table );

            columnText.Go();
        }

        private static void CreateDamageEffectsPage( Document document, PdfWriter pdfWriter, Group p_group )
        {
            var damageEffectsToPrint = new List<DamageEffect>();

            foreach( var damageEffect in MasterDataStorage.DamageEffect.DamageEffects.OrderBy( x => x.Name ) )
            {
                if( p_group.Models.Exists( x => x.Active && ( x.Weapons.Exists( y => y.Weapon.DamageEffects.Any( z => z.ID == damageEffect.ID ) )
                                                               ||
                                                               ( ( x.Armor != null ) && x.Armor.DamageEffects.Any( y => y.ID == damageEffect.ID ) ) ) ) )
                {
                    damageEffectsToPrint.Add( damageEffect );
                }
            }

            if( damageEffectsToPrint.Count > 0 )
            {
                document.SetPageSize( PageSize.A4 );

                document.NewPage();

                float printableWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                float damageEffectImgWidth = CmToPixel( 1 );
                float nameWidth = CmToPixel( 4 );
                float rulesWidth = printableWidth - ( damageEffectImgWidth + nameWidth );

                const int columnCount = 3;

                PdfPTable damageEffectsTable = new PdfPTable( new float[ columnCount ] { damageEffectImgWidth, nameWidth, rulesWidth } )
                {
                    WidthPercentage = 100,
                    SpacingBefore = 0f,
                    SpacingAfter = 0f,
                };

                // TableHeader
                damageEffectsTable.AddCell( new PdfPCell( new Phrase( "Schadenseffekt", s_damageEffectFontHeader ) )
                {
                    Border = Rectangle.NO_BORDER,
                    Colspan = 2
                } );

                damageEffectsTable.AddCell( new PdfPCell( new Phrase( "Regeln", s_damageEffectFontHeader ) )
                {
                    Border = Rectangle.NO_BORDER
                } );

                foreach( var damageEffect in damageEffectsToPrint )
                {
                    Image damageEffectImg = Image.GetInstance( damageEffect.Icon, System.Drawing.Imaging.ImageFormat.Png );
                    damageEffectImg.ScaleToFit( CmToPixel( 0.9f ), CmToPixel( 0.9f ) );
                    damageEffectsTable.AddCell( new PdfPCell( damageEffectImg )
                    {
                        Border = Rectangle.TOP_BORDER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        MinimumHeight = CmToPixel( 1 )
                    } );

                    damageEffectsTable.AddCell( new PdfPCell( new Phrase( damageEffect.Name, s_damageEffectFont ) )
                    {
                        Border = Rectangle.TOP_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    } );

                    damageEffectsTable.AddCell( new PdfPCell( new Phrase( damageEffect.Rules, s_damageEffectFont ) )
                    {
                        Border = Rectangle.TOP_BORDER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    } );
                }

                document.Add( damageEffectsTable );
            }
        }
    }
}
