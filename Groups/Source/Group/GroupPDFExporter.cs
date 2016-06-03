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

        private static string m_versionInfo
        {
            get
            {
                return( "Am " + DateTime.Now.ToString() + " mit der \"Tesserakt Program Suite\" Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " erzeugt" );
            }
        }

        private static int CmToPixel( double cm )
        {
            return ( Convert.ToInt32( cm / 2.54f * dpi ) );
        }

        private static readonly BaseFont s_baseFontNovaSquare = BaseFont.CreateFont( TesseraktFonts.NovaSquareFileName, BaseFont.CP1252, BaseFont.EMBEDDED, BaseFont.CACHED, TObjects.Properties.Resources.NovaSquare, null );

        private static readonly Font s_pageTitleFont = new Font( s_baseFontNovaSquare, CmToPixel( 1 ), Font.BOLD );
        private static readonly Font s_nameFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.5 ) );
        private static readonly Font s_rulesFont = new Font( Font.HELVETICA, CmToPixel( 0.4 ) );
        private static readonly Font s_usedByFont = new Font( Font.HELVETICA,CmToPixel( 0.25 ), Font.NORMAL, Color.GRAY );
        private static readonly Font s_versionInfo = new Font( Font.HELVETICA,CmToPixel( 0.25 ), Font.NORMAL, Color.GRAY );

        private static readonly Font s_nameFlipsideFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.2 ), Font.BOLD );
        private static readonly Font s_rulesFlipsideFont = new Font( Font.HELVETICA, CmToPixel( 0.2 ) );

        public static void Export( Group p_group, string p_fileName, bool exportTraits, bool exportWeapons, bool exportArmor, bool exportEquipment )
        {
            if( null == p_group )
            {
                throw new ArgumentNullException( nameof( p_group ) );
            }

            Cursor.Current = Cursors.WaitCursor;

            int margin = CmToPixel( 1 );

            Document document = new Document( PageSize.A4, margin, margin, margin, margin );

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

                if( exportTraits )
                {
                    CreateTraitsPage( document, p_group.GroupActorList );
                }

                if( exportWeapons )
                {
                    CreateWeaponsPage( document, p_group.GroupActorList );
                }

                if( exportArmor )
                {
                    CreateArmorPage( document, p_group.GroupActorList );
                }

                if( exportEquipment )
                {
                    CreateEquipmentPage( document, p_group.GroupActorList );
                }

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
            float spacerWidth = CmToPixel( 0.1 );
            float factionImgWidth = CmToPixel( 1.2 );
            float groupImgWidth = CmToPixel( 1.2 );
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

            Font actorFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.5 ) );
            Font actorCustomNameFont = new Font( s_baseFontNovaSquare, CmToPixel( 0.2 ), Font.NORMAL, Color.GRAY );

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

        private static void CreateTraitsPage( Document document, List<Group.GroupActor> groupActorList )
        {
            var traitList = groupActorList.SelectMany( groupActor => groupActor.Actor.ActorTraitsList )
                                          .Select( x => x.Trait )
                                          .Distinct()
                                          .Where( x => !String.IsNullOrEmpty( x.Rules )  )
                                          .OrderBy( x => x.Name );

            if( traitList.Count() > 0 )
            {
                document.SetPageSize( PageSize.A4.Rotate() );

                document.NewPage();

                AddPageTitle( document, "Eigenschaften" );

                MultiColumnText multiColumnText = new MultiColumnText();

                multiColumnText.AddRegularColumns( document.LeftMargin, document.PageSize.Width - document.RightMargin, CmToPixel( 0.5 ), 3 );

                foreach( Trait trait in traitList )
                {
                    string usedBy = String.Join( ", ", groupActorList.Select( x => x.Actor )
                                                                     .Distinct()
                                                                     .Where( x => x.ActorTraitsList.Find( f => f.Trait.ID == trait.ID ) != null )
                                                                     .OrderBy( x => x.Name )
                                                                     .Select( x => x.Name ) );

                    multiColumnText.AddElement( NewEntryBlock( trait.Name, trait.RulesWithLevel( TraitLevel.ELevel.Kein ), usedBy ) );
                }

                document.Add( multiColumnText );
            }
        }

        private static void CreateWeaponsPage( Document document, List<Group.GroupActor> groupActorList )
        {
            var weaponList = groupActorList.SelectMany( groupActor => groupActor.ActorOutfit.ActorWeaponsList )
                                           .Distinct()
                                           .Select( x => x.Weapon )
                                           .Where( x => !String.IsNullOrEmpty( x.Rules )  )
                                           .OrderBy( x => x.Name );

            if( weaponList.Count() > 0 )
            {
                document.SetPageSize( PageSize.A4.Rotate() );

                document.NewPage();

                AddPageTitle( document, "Waffen" );

                MultiColumnText multiColumnText = new MultiColumnText();

                multiColumnText.AddRegularColumns( document.LeftMargin, document.PageSize.Width - document.RightMargin, CmToPixel( 0.5 ), 3 );

                foreach( Weapon weapon in weaponList )
                {
                    string usedBy = String.Join( ", ", groupActorList.Select( x => x.Actor )
                                                                     .Distinct()
                                                                     .Where( x => x.ActorOutfitsList.Exists( y => y.ActorWeaponsList.Exists( f => f.Weapon.ID == weapon.ID ) ) )
                                                                     .OrderBy( x => x.Name )
                                                                     .Select( x => x.Name ) );

                    multiColumnText.AddElement( NewEntryBlock( weapon.Name, weapon.Rules, usedBy ) );
                }

                document.Add( multiColumnText );
            }
        }

        private static void CreateArmorPage( Document document, List<Group.GroupActor> groupActorList )
        {
            var armorList = groupActorList.Select( groupActor => groupActor.Actor.Armor )
                                          .Distinct()
                                          .Where( x => x != null )
                                          .Where( x => !String.IsNullOrEmpty( x.Rules )  )
                                          .OrderBy( x => x.Name );

            if( armorList.Count() > 0 )
            {
                document.SetPageSize( PageSize.A4.Rotate() );

                document.NewPage();

                AddPageTitle( document, "Rüstungen" );

                MultiColumnText multiColumnText = new MultiColumnText();

                multiColumnText.AddRegularColumns( document.LeftMargin, document.PageSize.Width - document.RightMargin, CmToPixel( 0.5 ), 3 );

                foreach( Armor armor in armorList )
                {
                    string usedBy = String.Join( ", ", groupActorList.Select( x => x.Actor )
                                                                     .Distinct()
                                                                     .Where( x => x.Armor.ID == armor.ID )
                                                                     .OrderBy( x => x.Name )
                                                                     .Select( x => x.Name ) );

                    multiColumnText.AddElement( NewEntryBlock( armor.Name, armor.Rules, usedBy ) );
                }

                document.Add( multiColumnText );
            }
        }

        private static void CreateEquipmentPage( Document document, List<Group.GroupActor> groupActorList )
        {
            var equipmentList = groupActorList.SelectMany( groupActor => groupActor.ActorOutfit.ActorEquipmentList )
                                              .Select( x => x.Equipment )
                                              .Distinct()
                                              .Where( x => ( !String.IsNullOrEmpty( x.Rules ) )
                                                           ||
                                                           ( x.UseOnce && ( !String.IsNullOrEmpty( x.AttributeModifier.ToString() ) ) ) )
                                              .OrderBy( x => x.Name );

            if( equipmentList.Count() > 0 )
            {
                document.SetPageSize( PageSize.A4.Rotate() );

                document.NewPage();

                AddPageTitle( document, "Ausrüstung" );

                MultiColumnText multiColumnText = new MultiColumnText();

                multiColumnText.AddRegularColumns( document.LeftMargin, document.PageSize.Width - document.RightMargin, CmToPixel( 0.5 ), 3 );

                foreach( Equipment equipment in equipmentList )
                {
                    string usedBy = String.Join( ", ", groupActorList.Select( x => x.Actor )
                                                                     .Distinct()
                                                                     .Where( x => x.ActorOutfitsList.Exists( y => y.ActorEquipmentList.Exists( f => f.Equipment.ID == equipment.ID ) ) )
                                                                     .OrderBy( x => x.Name )
                                                                     .Select( x => x.Name ) );

                    multiColumnText.AddElement( NewEntryBlock( equipment.Name, equipment.ToString(), usedBy ) );
                }

                document.Add( multiColumnText );
            }
        }

        private static void CreateCardsPage( Document document, PdfWriter pdfWriter, Group group )
        {
            document.SetPageSize( PageSize.A4.Rotate() );

            int cardWidth = CmToPixel( CardPainter.cardWidthCm );
            int cardHeight = CmToPixel( CardPainter.cardHeightCm );

            float margin = CmToPixel( 0.2f );
            float columnWidth = ( cardWidth - ( 4 * margin ) ) / 3;

            float[][] columns = new float[][]
                {
                    new float[] { margin,                               margin, margin + columnWidth,                 cardHeight - margin },
                    new float[] { ( 2 * margin ) + columnWidth,         margin, ( 2 * margin ) + ( 2 * columnWidth ), cardHeight - margin },
                    new float[] { ( 3 * margin ) + ( 2 * columnWidth ), margin, ( 3 * margin ) + ( 3 * columnWidth ), cardHeight - margin }
                };

            float distanceX = ( document.PageSize.Width - ( 2 * cardWidth ) ) / 3;
            float distanceY = ( document.PageSize.Height - ( 2 * cardHeight ) ) / 2;

            System.Drawing.PointF[] positions = new System.Drawing.PointF[ 2 ];
            positions[ 0 ].X = distanceX;
            positions[ 0 ].Y = distanceY + cardHeight;
            positions[ 1 ].X = ( 2 * distanceX ) + cardWidth;
            positions[ 1 ].Y = distanceY + cardHeight;

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

                Image img = Image.GetInstance( CardPainter.getBitmap( groupActor ), System.Drawing.Imaging.ImageFormat.Jpeg );
                img.ScaleToFit( cardWidth, cardHeight );
                img.SetAbsolutePosition( positions[ i % 2 ].X, positions[ i % 2 ].Y );

                document.Add( img );

                PdfContentByte cb = pdfWriter.DirectContent;

                // draw a bounding-rectangle over the card and for the information on the back
                cb.SaveState();
                cb.SetColorStroke( Color.BLACK );
                cb.Rectangle( positions[ i % 2 ].X, positions[ i % 2 ].Y, cardWidth, cardHeight );
                cb.Rectangle( positions[ i % 2 ].X, positions[ i % 2 ].Y - cardHeight, cardWidth, cardHeight );
                cb.Stroke();
                cb.RestoreState();


                // create the information for the back of the card
                PdfTemplate textTemplate = cb.CreateTemplate( cardWidth, cardHeight );

                int column = 0;

                ColumnText columnText = new ColumnText( textTemplate );
                columnText.SetSimpleColumn( columns[ column ][ 0 ], columns[ column ][ 1 ], columns[ column ][ 2 ], columns[ column ][ 3 ] );

                foreach( Actor.ActorTrait actorTrait in groupActor.Actor.ActorTraitsList.Select( x => x )
                                                                                        .Where( x => !String.IsNullOrEmpty( x.Trait.Rules ) )
                                                                                        .OrderBy( x => x.Name ) )
                {
                    if( actorTrait.Level != TraitLevel.ELevel.Kein )
                    {
                        NewFlipsideEntryBlock( columnText, ref column, columns, actorTrait.Name + " " + actorTrait.Level, actorTrait.Trait.RulesWithLevel( actorTrait.Level ) );
                    }
                    else
                    {
                        NewFlipsideEntryBlock( columnText, ref column, columns, actorTrait.Name, actorTrait.Trait.RulesWithLevel( actorTrait.Level ) );
                    }
                }

                if( ( groupActor.Actor.Armor != null )
                    &&
                    ( !String.IsNullOrEmpty( groupActor.Actor.Armor.Rules ) ) )
                {
                    NewFlipsideEntryBlock( columnText, ref column, columns, groupActor.Actor.Armor.Name, groupActor.Actor.Armor.Rules );
                }

                foreach( Weapon weapon in groupActor.ActorOutfit.ActorWeaponsList.Select( x => x.Weapon )
                                                                                 .Distinct()
                                                                                 .Where( x => !String.IsNullOrEmpty( x.Rules ) )
                                                                                 .OrderBy( x => x.Name ) )
                {
                    NewFlipsideEntryBlock( columnText, ref column, columns, weapon.Name, weapon.Rules );
                }

                foreach( Equipment equipment in groupActor.ActorOutfit.ActorEquipmentList.Select( x => x.Equipment )
                                                                                         .Distinct()
                                                                                         .Where( x => ( !String.IsNullOrEmpty( x.Rules ) )
                                                                                                      ||
                                                                                                      ( x.UseOnce && ( !String.IsNullOrEmpty( x.AttributeModifier.ToString() ) ) ) )
                                                                                         .OrderBy( x => x.Name ) )
                {
                    NewFlipsideEntryBlock( columnText, ref column, columns, equipment.Name, equipment.ToString() );
                }



                // image-wrapper for the template which we can rotate
                Image flipsideImg = Image.GetInstance( textTemplate );
                flipsideImg.Interpolation = true;
                flipsideImg.ScaleAbsolute( cardWidth, cardHeight );
                flipsideImg.RotationDegrees = 180;
                flipsideImg.SetAbsolutePosition( positions[ i % 2 ].X, positions[ i % 2 ].Y - cardHeight );

                document.Add( flipsideImg );
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
