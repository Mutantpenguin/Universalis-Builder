using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Universalis
{
    internal class PowersPDFExporter
    {
        private const int dpi = 72;

        private static readonly float s_cardWidth = CmToPixel( PowerCardPainter.CardWidthCm );
        private static readonly float s_cardHeight = CmToPixel( PowerCardPainter.CardHeightCm );

        private static readonly string s_versionInfo = "Am " + DateTime.Now.ToShortDateString() + " mit \"Universalis\" Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString( 2 ) + " erzeugt";

        private static float CmToPixel( float cm )
        {
            return cm / 2.54f * dpi;
        }

        private static float PixelToCm( float pixel )
        {
            return pixel * 2.54f / dpi;
        }

        public static void GeneratePDF( Discipline p_discipline, List<Power> p_powerList, string p_fileName )
        {
            if( null == p_discipline )
            {
                throw new ArgumentNullException( nameof( p_discipline ) );
            }

            Cursor.Current = Cursors.WaitCursor;

            float marginDocument = CmToPixel( 1 );

            Document document = new Document( PageSize.A4, marginDocument, marginDocument, marginDocument, marginDocument );

            using( FileStream fs = new FileStream( p_fileName, FileMode.Create, FileAccess.Write ) )
            {
                PdfWriter pdfWriter = PdfWriter.GetInstance( document, fs );

                document.AddTitle( p_discipline.Name );
                document.AddAuthor( "Universalis" );
                document.AddCreator( s_versionInfo );
                document.AddKeywords( "Kraftkarten für das Universalis Tabletop Spiel" );
                document.AddCreationDate();

                document.Open();

                CreateCardPages( document, pdfWriter, p_discipline, p_powerList );

                document.Close();
            }

            System.Diagnostics.Process.Start( p_fileName );

            Cursor.Current = Cursors.Arrow;
        }

        private static void CreateCardPages( Document document, PdfWriter pdfWriter, Discipline p_discipline, List<Power> p_powerList )
        {
            document.SetPageSize( PageSize.A4 );

            float horizontalMargin = (document.PageSize.Width % s_cardWidth) / 2.0f;
            float verticalMargin = (document.PageSize.Height % s_cardHeight) / 2.0f;

            int columnCount = (int)(document.PageSize.Width / s_cardWidth);
            int rowCount = (int)(document.PageSize.Height / s_cardHeight);

            int cardsPerPage = columnCount * rowCount;

            System.Drawing.PointF[] positions = new System.Drawing.PointF[cardsPerPage];

            int positionIndex = 0;
            for ( int row = 0; row < rowCount; row++ )
            {
                for( int col = 0; col < columnCount; col++ )
                {
                    positions[positionIndex].X = horizontalMargin + (col * s_cardWidth);
                    positions[positionIndex].Y = document.PageSize.Height - verticalMargin - ((row+1) * s_cardHeight);

                    positionIndex++;
                }
            }            

            for( int i = 0; i < p_powerList.Count; i++ )
            {
                if( i % cardsPerPage == 0 )
                {
                    document.NewPage();
                }

                Power power = p_powerList[i];

                using( System.Drawing.Image img = PowerCardPainter.GetBitmap( p_discipline, power, monochrome: false ) )
                {
                    Image imgCard = Image.GetInstance( img, System.Drawing.Imaging.ImageFormat.Jpeg );
                    imgCard.ScaleToFit( s_cardWidth, s_cardHeight );
                    imgCard.SetAbsolutePosition( positions[i % cardsPerPage].X, positions[i % cardsPerPage].Y );

                    document.Add( imgCard );
                }
            }
        }
    }
}
