using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Universalis
{
    public static class ImageBase64Helper
    {
        public static Image Base64ToImage( string base64Image )
        {
            return ( Bitmap.FromStream( new MemoryStream( Convert.FromBase64String( base64Image ) ) ) );
        }

        public static string ImageToBase64( Image img )
        {
            if( img == null )
            {
                throw new ArgumentNullException( nameof( img ) );
            }

            using( MemoryStream m = new MemoryStream() )
            {
                if( ImageFormat.Jpeg.Equals( img.RawFormat ) )
                {
                    img.Save( m, ImageFormat.Jpeg );
                }
                else
                {
                    // every image that was not a jpeg before will be saved with a quality of 90%

                    ImageCodecInfo jgpEncoder = ImageCodecInfo.GetImageDecoders().First( x => x.FormatID == ImageFormat.Jpeg.Guid );

                    using( EncoderParameters encoderParameters = new EncoderParameters( 1 ) )
                    {
                        encoderParameters.Param[ 0 ] = new EncoderParameter( Encoder.Quality, 90L );

                        img.Save( m, jgpEncoder, encoderParameters );
                    }
                }                

                return ( Convert.ToBase64String( m.ToArray() ) );
            }
        }
    }
}
