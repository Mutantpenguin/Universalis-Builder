using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tesserakt
{
    public static class GroupPDFExporter
    {
        private const int dpi = 72;

        private static float s_cardWidth = CmToPixel( CardPainter.cardWidthCm );
        private static float s_cardHeight = CmToPixel( CardPainter.cardHeightCm );

        #region fonts
        private static readonly BaseFont s_baseFontNovaSquare = BaseFont.CreateFont( TesseraktFonts.NovaSquareFileName, BaseFont.CP1252, BaseFont.EMBEDDED, BaseFont.CACHED, TObjects.Properties.Resources.NovaSquare, null );

        private static readonly Font s_pageTitleFont = new Font( s_baseFontNovaSquare, CmToPixel( 1 ), Font.BOLD );
        private static readonly Font s_nameFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.5f ) );
        private static readonly Font s_rulesFont = new Font( Font.HELVETICA, CmToPixel( 0.4f ) );
        private static readonly Font s_usedByFont = new Font( Font.HELVETICA, CmToPixel( 0.25f ), Font.NORMAL, Color.GRAY );
        private static readonly Font s_versionInfo = new Font( Font.HELVETICA, CmToPixel( 0.25f ), Font.NORMAL, Color.GRAY );

        private static readonly Font s_flipsideHeaderFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.35f ), Font.NORMAL, Color.WHITE );
        private static readonly Font s_nameFlipsideFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.2f ), Font.BOLD );
        private static readonly Font s_rulesFlipsideFont = new Font( Font.HELVETICA, CmToPixel( 0.2f ) );
        #endregion

        #region flipside
        private static readonly float s_flipsideHeaderHeight = CmToPixel( 0.5f );

        private static readonly System.Drawing.Image s_flipsideHeader = SectionHeader.Create( CardPainter.CmToPixel( CardPainter.cardWidthCm ), CardPainter.CmToPixel( 0.5 ) );

        private static readonly float s_flipsideMargin = CmToPixel( 0.1f );
        private static readonly float s_flipsideColumnWidth = ( s_cardWidth - ( 4 * s_flipsideMargin ) ) / 3;

        private static readonly float s_flipsideHeight = s_cardHeight - s_flipsideHeaderHeight;

        private static readonly float[][] s_flipsideColumns = new float[][]
                {
                    new float[] { s_flipsideMargin,                                         s_flipsideMargin, s_flipsideMargin + s_flipsideColumnWidth,                 s_flipsideHeight - s_flipsideMargin },
                    new float[] { ( 2 * s_flipsideMargin ) + s_flipsideColumnWidth,         s_flipsideMargin, ( 2 * s_flipsideMargin ) + ( 2 * s_flipsideColumnWidth ), s_flipsideHeight - s_flipsideMargin },
                    new float[] { ( 3 * s_flipsideMargin ) + ( 2 * s_flipsideColumnWidth ), s_flipsideMargin, ( 3 * s_flipsideMargin ) + ( 3 * s_flipsideColumnWidth ), s_flipsideHeight - s_flipsideMargin }
                };

        private const string s_headerTitle = "Sonderregeln";

        private static readonly float s_ascent = s_baseFontNovaSquare.GetAscentPoint( s_headerTitle, s_flipsideHeaderFont.Size );
        private static readonly float s_descent = s_baseFontNovaSquare.GetDescentPoint( s_headerTitle, s_flipsideHeaderFont.Size );
        #endregion

        private static string m_versionInfo
        {
            get
            {
                return( "Am " + DateTime.Now.ToString() + " mit der \"Tesserakt Program Suite\" Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " erzeugt" );
            }
        }

        private static float CmToPixel( float cm )
        {
            return( cm / 2.54f * dpi );
        }

        public static void Export( Group p_group, string p_fileName )
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
                document.AddCreator( m_versionInfo );
                document.AddKeywords( "Einheitenkarten für das Tesserakt Tabletop Spiel" );
                document.AddSubject( p_group.Description );
                document.AddCreationDate();

                document.Open();

                CreateMainPage( document, p_group );
                CreateCardsPage( document, pdfWriter, p_group );

                document.Close();
            }

            System.Diagnostics.Process.Start( p_fileName );

            Cursor.Current = Cursors.Arrow;
        }

        private static void CreateMainPage( Document document, Group group )
        {
            document.SetPageSize( PageSize.A4 );

            document.NewPage();

            float printableWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            float spacerWidth = CmToPixel( 0.1f );
            float factionImgWidth = CmToPixel( 1.2f );
            float groupImgWidth = CmToPixel( 1.2f );
            float pointsWidth = CmToPixel( 2 );
            float nameWidth = printableWidth - ( factionImgWidth + spacerWidth+ groupImgWidth + spacerWidth + pointsWidth );

            PdfPTable headerTable = new PdfPTable( new float[ 6 ] { factionImgWidth, spacerWidth, groupImgWidth, spacerWidth, nameWidth, pointsWidth } )
            {
                WidthPercentage = 100
            };

            Image factionImg = Image.GetInstance( group.FactionIcon, System.Drawing.Imaging.ImageFormat.Png );
            factionImg.ScaleToFit( factionImgWidth, factionImgWidth );
            headerTable.AddCell( new PdfPCell( factionImg )
            {
                Border = Rectangle.NO_BORDER,
                VerticalAlignment = Element.ALIGN_MIDDLE
            } );

            headerTable.AddCell( new PdfPCell()
            {
                Border = Rectangle.NO_BORDER,
            } );

            Image groupImg = Image.GetInstance( group.Icon, System.Drawing.Imaging.ImageFormat.Png );
            groupImg.ScaleToFit( groupImgWidth, groupImgWidth );
            headerTable.AddCell( new PdfPCell( groupImg )
            {
                Border = Rectangle.NO_BORDER,
                VerticalAlignment = Element.ALIGN_MIDDLE
            } );

            headerTable.AddCell( new PdfPCell()
            {
                Border = Rectangle.NO_BORDER,
            } );

            headerTable.AddCell( new PdfPCell( new Phrase( group.Name, s_pageTitleFont ) )
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Border = Rectangle.BOTTOM_BORDER
            } );

            headerTable.AddCell( new PdfPCell( new Phrase( $"{group.Points}pkt" ) )
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Border = Rectangle.BOTTOM_BORDER
            } );

            document.Add( headerTable );

            document.Add( new Paragraph( m_versionInfo, s_versionInfo ) );

            document.Add( new Paragraph( group.Description ) );

            document.Add( Chunk.NEWLINE );

            ShowActors( document, group );
        }

        private static void ShowActors( Document document, Group group )
        {
            float printableWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            float actorImgWidth = CmToPixel( 1 );
            float pointsWidth = CmToPixel( 2 );
            float totalPointsWidth = CmToPixel( 2 );
            float outfitWidth = CmToPixel( 5 );
            float nameWidth = printableWidth - ( actorImgWidth + pointsWidth + totalPointsWidth + outfitWidth );

            Font actorFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.5f ) );
            Font actorCustomNameFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.2f ), Font.NORMAL, Color.GRAY );

            const int columnCount = 5;

            PdfPTable actorTable = new PdfPTable( new float[ columnCount ] { actorImgWidth, nameWidth, outfitWidth, pointsWidth, totalPointsWidth } )
            {
                WidthPercentage = 100,
                SpacingBefore = 0f,
                SpacingAfter = 0f,
            };

            // TableHeader
            actorTable.AddCell( new PdfPCell()
            {
                Border = Rectangle.NO_BORDER
            } );
            actorTable.AddCell( new PdfPCell( new Phrase( "Name", actorFont ) )
            {
                Border = Rectangle.NO_BORDER
            } );
            actorTable.AddCell( new PdfPCell( new Phrase( "Outfit", actorFont ) )
            {
                Border = Rectangle.NO_BORDER
            } );
            actorTable.AddCell( new PdfPCell( new Phrase( "Punkte", actorFont ) )
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            } );
            actorTable.AddCell( new PdfPCell( new Phrase( "Gesamt", actorFont ) )
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            } );

            foreach( var entry in group.GroupActorList.GroupBy( x => x.ActorOutfit.ID )
                                                      .Select( x => new { actor = ActorStorage.Instance.Actors.First( y => y.ActorOutfitsList.Exists( z => z.ID == x.Key ) ), actorOutfit = ActorStorage.Instance.Actors.SelectMany( y => y.ActorOutfitsList ).First( z => z.ID == x.Key ), count = x.Count() } )
                                                      .OrderBy( x => x.actorOutfit.Name )
                                                      .OrderBy( x => x.actor.Name ) )
            {
                Image actorImg = Image.GetInstance( ( null != entry.actor.Icon ) ? entry.actor.Icon : group.FactionIcon, System.Drawing.Imaging.ImageFormat.Png );
                actorImg.ScaleToFit( CmToPixel( 1 ), CmToPixel( 1 ) );
                actorTable.AddCell( new PdfPCell( actorImg )
                {
                    Border = Rectangle.TOP_BORDER
                } );

                actorTable.AddCell( new PdfPCell( new Phrase( entry.actor.Name, actorFont ) )
                {
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                } );

                actorTable.AddCell( new PdfPCell( new Phrase( entry.count.ToString() + "x " + entry.actorOutfit.Name, actorFont ) )
                {
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                } );

                actorTable.AddCell( new PdfPCell( new Phrase( entry.actor.Points( entry.actorOutfit ).ToString() ) )
                {
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                } );

                actorTable.AddCell( new PdfPCell( new Phrase( ( entry.count * entry.actor.Points( entry.actorOutfit ) ).ToString() ) )
                {
                    Border = Rectangle.TOP_BORDER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                } );

                var groupActorsWithCustomNames = group.GroupActorList.Where( x => x.Actor == entry.actor && x.ActorOutfit == entry.actorOutfit )
                                                                     .Where( x => !String.IsNullOrEmpty( x.CustomName ) )
                                                                     .OrderBy( x => x.CustomName );
                if( groupActorsWithCustomNames.Count() > 0 )
                {
                    actorTable.AddCell( new PdfPCell()
                    {
                        Border = Rectangle.NO_BORDER
                    } );

                    string models = String.Join( ", ", groupActorsWithCustomNames.Select( x => x.CustomName ) );
                    
                    actorTable.AddCell( new PdfPCell( new Phrase( "Modelle: " + models, actorCustomNameFont ) )
                    {
                        Colspan = columnCount - 1,
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    } );
                }
            }

            document.Add( actorTable );
        }

        private struct flipsideBlock
        {
            public string Name;
            public string Rules;
        };

        private static void CreateCardsPage( Document document, PdfWriter pdfWriter, Group group )
        {
            document.SetPageSize( PageSize.A4.Rotate() );

            float distanceX = ( document.PageSize.Width - ( 2 * s_cardWidth ) ) / 3;
            float distanceY = ( document.PageSize.Height - ( 2 * s_cardHeight ) ) / 2;

            System.Drawing.PointF[] positions = new System.Drawing.PointF[ 2 ];
            positions[ 0 ].X = distanceX;
            positions[ 0 ].Y = distanceY + s_cardHeight;
            positions[ 1 ].X = ( 2 * distanceX ) + s_cardWidth;
            positions[ 1 ].Y = distanceY + s_cardHeight;

            List<Group.GroupActor> sortedGroupActorList = group.GroupActorList.OrderBy( x => x.Name )
                                                                              .OrderBy( x => x.ActorOutfit.Name )
                                                                              .OrderBy( x => x.CustomName )
                                                                              .ToList();

            for( int i = 0; i < sortedGroupActorList.Count; i++ )
            {
                if( i % 2 == 0 )
                {
                    document.NewPage();
                }

                Group.GroupActor groupActor = sortedGroupActorList[ i ];

                {
                    Image imgCard = Image.GetInstance( CardPainter.getBitmap( groupActor ), System.Drawing.Imaging.ImageFormat.Jpeg );
                    imgCard.ScaleToFit( s_cardWidth, s_cardHeight );
                    imgCard.SetAbsolutePosition( positions[ i % 2 ].X, positions[ i % 2 ].Y );

                    document.Add( imgCard );
                }

                List<flipsideBlock> flipsideBlocks = new List<flipsideBlock>();

                foreach( Actor.ActorTrait actorTrait in groupActor.Actor.ActorTraitsList.Select( x => x )
                                                                                        .Where( x => !String.IsNullOrEmpty( x.Trait.Rules ) )
                                                                                        .OrderBy( x => x.Name ) )
                {
                    if( actorTrait.Level != TraitLevel.ELevel.Kein )
                    {
                        flipsideBlocks.Add( new flipsideBlock() { Name = actorTrait.Name + " " + actorTrait.Level, Rules = actorTrait.Trait.RulesWithLevel( actorTrait.Level ) } );
                    }
                    else
                    {
                        flipsideBlocks.Add( new flipsideBlock() { Name = actorTrait.Name, Rules = actorTrait.Trait.RulesWithLevel( actorTrait.Level ) } );
                    }
                }

                if( ( groupActor.Actor.Armor != null )
                    &&
                    ( !String.IsNullOrEmpty( groupActor.Actor.Armor.Rules ) ) )
                {
                    flipsideBlocks.Add( new flipsideBlock() { Name = groupActor.Actor.Armor.Name, Rules = groupActor.Actor.Armor.Rules } );
                }

                foreach( Weapon weapon in groupActor.ActorOutfit.ActorWeaponsList.Select( x => x.Weapon )
                                                                                 .Distinct()
                                                                                 .Where( x => !String.IsNullOrEmpty( x.Rules ) )
                                                                                 .OrderBy( x => x.Name ) )
                {
                    flipsideBlocks.Add( new flipsideBlock() { Name = weapon.Name, Rules = weapon.Rules } );
                }

                foreach( Equipment equipment in groupActor.ActorOutfit.ActorEquipmentList.Select( x => x.Equipment )
                                                                                         .Distinct()
                                                                                         .Where( x => ( !String.IsNullOrEmpty( x.Rules ) )
                                                                                                      ||
                                                                                                      ( x.UseOnce && ( !String.IsNullOrEmpty( x.AttributeModifier.ToString() ) ) ) )
                                                                                         .OrderBy( x => x.Name ) )
                {
                    flipsideBlocks.Add( new flipsideBlock() { Name = equipment.Name, Rules = equipment.ToString() } );
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

                        ColumnText.ShowTextAligned( flipsideHeaderTemplate, Element.ALIGN_LEFT, new Phrase( s_headerTitle, s_flipsideHeaderFont ), s_flipsideMargin, ( s_flipsideHeaderHeight - s_ascent - s_descent ) / 2, 0 );

                        Image flipsideHeaderImg = Image.GetInstance( flipsideHeaderTemplate );
                        flipsideHeaderImg.Interpolation = true;
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

                            foreach( var block in flipsideBlocks )
                            {
                                NewFlipsideEntryBlock( columnText, ref columnIndex, s_flipsideColumns, block.Name, block.Rules );
                            }
                        }

                        {
                            // image-wrapper for the template which we can rotate
                            Image flipsideImg = Image.GetInstance( flipsideTemplate );
                            flipsideImg.Interpolation = true;
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

        private static void AddPageTitle( Document document, string title )
        {
            Paragraph p = new Paragraph();
            p.Add( new Phrase( title, s_pageTitleFont ) );
            p.Add( new LineSeparator( 0.3f, 100, Color.BLACK, Element.ALIGN_LEFT, -2 ) );

            document.Add( p );
        }

        private static PdfPTable NewEntryBlock( string Name, string Rules, string usedBy )
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

            cell.AddElement( new Phrase( Name, s_nameFont ) );
            cell.AddElement( new LineSeparator( 0.3f, 100, Color.BLACK, Element.ALIGN_LEFT, -2 ) );
            cell.AddElement( new Phrase( Rules, s_rulesFont ) );

            cell.AddElement( new Phrase( $"Verwendet von: {usedBy}", s_usedByFont ) );

            table.AddCell( cell );

            return ( table );
        }

        private static void NewFlipsideEntryBlock( ColumnText columnText, ref int column, float[][] columns, string Name, string Rules )
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

            cell.AddElement( new Phrase( Name, s_nameFlipsideFont ) );
            cell.AddElement( new LineSeparator( 0.3f, 100, Color.BLACK, Element.ALIGN_LEFT, -2 ) );
            cell.AddElement( new Phrase( Rules, s_rulesFlipsideFont ) );

            table.AddCell( cell );

            float yLine = columnText.YLine;

            columnText.AddElement( table );

            int status = columnText.Go( simulate: true );

            if( ColumnText.HasMoreText( status ) )
            {
                column += 1;

                columnText.SetSimpleColumn( columns[ column ][ 0 ], columns[ column ][ 1 ], columns[ column ][ 2 ], columns[ column ][ 3 ] );
                yLine = columns[ column ][ 3 ];
            }

            columnText.YLine = yLine;
            columnText.SetText( null );

            columnText.AddElement( table );

            columnText.Go();
        }
    }
}
