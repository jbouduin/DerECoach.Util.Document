using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Image
{
    /// <summary>
    /// Represents an image.
    /// </summary>
    [RtfControlWord("pict"), RtfEnclosingBraces]
    internal class DocumentImage : ParagraphContent, IDocumentImage
    {
        private readonly ITwipConverter _twipConverter;
        private const int MillimetersInInch = 2540;

        private Bitmap _bitmap;
        
        private float _dpiX;
        private float _dpiY;

        private int _wmfWidth;
        private int _wmfHeight;
        
        private int _scaleX = 100;
        private int _scaleY = 100;

        private string _hexData;

        private EImageFormat _format = EImageFormat.Wmf;


        /// <summary>
        /// Gets the horizontal resolution of the output image.
        /// </summary>
        public float DpiX
        {
            get { return _dpiX; }
        }

        /// <summary>
        /// Gets the vertical resolution of the output image.
        /// </summary>
        public float DpiY
        {
            get { return _dpiY; }
        }

        /// <summary>
        /// Gets horizontal scale. Default is 100.
        /// </summary>
        [RtfControlWord("picscalex")]
        public int ScaleX
        {
            get { return _scaleX; }
            set { _scaleX = value; }
        }

        /// <summary>
        /// Gets vertical scale. Default is 100.
        /// </summary>
        [RtfControlWord("picscaley")]
        public int ScaleY
        {
            get { return _scaleY; }
            set { _scaleY= value; }
        }

        /// <summary>
        /// Gets width of the original picture in pixels for bitmaps and millimeters for WMF. Used by RtfWriter.
        /// </summary>
        [RtfControlWord("picw")]
        public int OriginalWidth
        {
            get 
            {
                if (_format == EImageFormat.Wmf)
                {
                    return _wmfWidth;
                }

                return _bitmap.Width; 
            }
        }

        /// <summary>
        /// Gets height of the original picture in pixels for bitmaps and millimeters for WMF. Used by RtfWriter.
        /// </summary>
        [RtfControlWord("pich")]
        public int OriginalHeight
        {
            get
            {
                if (_format == EImageFormat.Wmf)
                {
                    return _wmfHeight;
                }

                return _bitmap.Height;
            }
        }

        /// <summary>
        /// Base width of the output image in twips.
        /// </summary>
        [RtfControlWord("picwgoal")]
        public int Width { get; set; }

        /// <summary>
        /// Base height of the output image in twips.
        /// </summary>
        [RtfControlWord("pichgoal")]
        public int Height { get; set; }

        /// <summary>
        /// Format of the output image. Default is Wmf.
        /// </summary>
        [RtfControlWord]
        public EImageFormat Format
        {
            get { return _format; }
            set 
            {
                if (_format != value)
                {
                    _hexData = string.Empty;
                }

                _format = value; 
            }
        }

        /// <summary>
        /// Gets hexadecimal string representation of the image.
        /// </summary>
        [RtfTextData(RtfTextDataType.Raw)]
        public string HexData
        {
            get 
            {
                if (string.IsNullOrEmpty(_hexData))
                {
                    MakeHexData();
                }

                return _hexData;
            }
        }

        #region constructor ---------------------------------------------------

        /// <param name="twipConverter"></param>
        /// <param name="bitmap">Bitmap</param>
        public DocumentImage(ITwipConverter twipConverter, Bitmap bitmap)
        {
            _twipConverter = twipConverter;
            var format = EImageFormat.Wmf;

            if (bitmap.RawFormat.Equals(ImageFormat.Jpeg))
            {
                format = EImageFormat.Jpeg;
            }
            else if (bitmap.RawFormat.Equals(ImageFormat.Png))
            {
                format = EImageFormat.Png;
            }
            
            Initialize(bitmap, format);
        }

        /// <param name="twipConverter"></param>
        /// <param name="bitmap"></param>
        /// <param name="format">Image format</param>
        public DocumentImage(ITwipConverter twipConverter, Bitmap bitmap, EImageFormat format)
        {
            _twipConverter = twipConverter;
            Initialize(bitmap, format);
        }

        /// <param name="format"></param>
        /// <param name="dpiX">Horizontal resolution</param>
        /// <param name="dpiY">Vertical resolution</param>
        /// <param name="twipConverter"></param>
        /// <param name="bitmap"></param>
        public DocumentImage(ITwipConverter twipConverter, Bitmap bitmap, EImageFormat format, float dpiX, float dpiY)
        {
            _twipConverter = twipConverter;
            Initialize(bitmap, format, dpiX, dpiY);
        }
        #endregion
        
        private void Initialize(Bitmap bitmap, EImageFormat format)
        {
            float dpiX;
            float dpiY;

            using (var graphics = Graphics.FromImage(bitmap))
            {
                dpiX = graphics.DpiX;
                dpiY = graphics.DpiY;
            }

            Initialize(bitmap, format, dpiX, dpiY);
        }

        private void Initialize(Bitmap bitmap, EImageFormat format, float dpiX, float dpiY)
        {
            _bitmap = bitmap;
            _format = format;

            SetDpi(dpiX, dpiY);
        }
        
        /// <summary>
        /// Resets the size of the bitmap according to DPI value.
        /// </summary>
        public void SetDpi(float dpiX, float dpiY)
        {
            _dpiX = dpiX;
            _dpiY = dpiY;

            Width = (int)Math.Round(_bitmap.Width * _twipConverter.TwipsInInch / dpiX);
            Height = (int)Math.Round(_bitmap.Height * _twipConverter.TwipsInInch / dpiY);

            _wmfWidth = (int)Math.Round(_bitmap.Width * MillimetersInInch / dpiX);
            _wmfHeight = (int)Math.Round(_bitmap.Height * MillimetersInInch / dpiY);
        }
        
        private void MakeHexData()
        {
            byte[] data = null;

            if (_format == EImageFormat.Wmf)
            {
                data = GetWmfBytes(_bitmap);
            }
            else
            {

                try
                {
                    using (var stream = new MemoryStream())
                    {
                        switch (_format)
                        {
                            case EImageFormat.Png:
                            {
                                _bitmap.Save(stream, ImageFormat.Png);
                                break;
                            }
                            case EImageFormat.Jpeg:
                            {
                                _bitmap.Save(stream, ImageFormat.Jpeg);
                                break;
                            }
                        }
                        data = stream.ToArray();
                    }
                }
                catch
                {
                    // left intentionally empty
                }
            }

            if (data != null)
            {
                var sb = new StringBuilder(data.Length * 2);
                var i = 0;
                
                foreach (var b in data)
                {
                    i++;
                    sb.Append(string.Format("{0:x2}", b));
                    
                    if (i == 64)
                    {
                        sb.AppendLine();
                        i = 0;
                    }
                }

                _hexData = sb.ToString();
            }
        }
        
        /// <summary>
        /// Use the EmfToWmfBits function in the GDI+ specification to convert a
        /// Enhanced Metafile to a Windows Metafile
        /// </summary>
        /// <param name="hEmf"></param>
        /// <param name="uBufferSize">
        /// The size of the buffer used to store the Windows Metafile bits returned
        /// </param>
        /// <param name="bBuffer">
        /// An array of bytes used to hold the Windows Metafile bits returned
        /// </param>
        /// <param name="iMappingMode">
        /// The mapping mode of the image.  This control uses MM_ANISOTROPIC.
        /// </param>
        /// <param name="flags">
        /// Flags used to specify the format of the Windows Metafile returned
        /// </param>
        [DllImport("gdiplus.dll", SetLastError = true)]
        static extern uint GdipEmfToWmfBits(IntPtr hEmf, uint uBufferSize, byte[] bBuffer, int iMappingMode, EmfToWmfBitsFlags flags);

        /// <summary>
        /// Releases metafile handle.
        /// </summary>
        /// <param name="hEmf">
        /// A handle to the Enhanced Metafile to be released.
        /// </param>
        [DllImport("gdi32.dll")]
        private static extern void DeleteEnhMetaFile(IntPtr hEmf);
        
        private static byte[] GetWmfBytes(Bitmap bitmap)
        {
            MemoryStream stream = null;
            Graphics graphics = null;
            Metafile metaFile = null;
            var hEmf = IntPtr.Zero;
            byte[] data;

            try
            {
                using (stream = new MemoryStream())
                {
                    using (graphics = Graphics.FromImage(bitmap))
                    {
                        // Get the device context from the graphics context
                        var hdc = graphics.GetHdc();

                        // Create a new Enhanced Metafile from the device context
                        metaFile = new Metafile(stream, hdc);

                        // Release the device context
                        graphics.ReleaseHdc(hdc);
                    }

                    // Get a graphics context from the Enhanced Metafile
                    using (graphics = Graphics.FromImage(metaFile))
                    {
                        // Draw the image on the Enhanced Metafile
                        graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                    }

                    using (metaFile)
                    {
                        hEmf = metaFile.GetHenhmetafile();

                        var bufferSize = GdipEmfToWmfBits(hEmf, 0, null, 8, EmfToWmfBitsFlags.Default);

                        data = new byte[bufferSize];

                        GdipEmfToWmfBits(hEmf, bufferSize, data, 8, EmfToWmfBitsFlags.Default);
                    }
                }
            }
            catch
            {
                data = null;
            }
            finally
            {
                if (hEmf != IntPtr.Zero)
                {
                    DeleteEnhMetaFile(hEmf);
                }

                if (stream != null)
                {
                    stream.Flush();
                    stream.Close();
                }

                if (metaFile != null)
                {
                    metaFile.Dispose();
                }

                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }

            return data;
        }

        private enum EmfToWmfBitsFlags
        {
            // Use the default conversion
            Default = 0x00000000,

            // Embedded the source of the EMF metafiel within the resulting WMF
            // metafile
            // ReSharper disable once UnusedMember.Local
            EmbedEmf = 0x00000001,

            // Place a 22-byte header in the resulting WMF file.  The header is
            // required for the metafile to be considered placeable.
            // ReSharper disable once UnusedMember.Local
            IncludePlaceable = 0x00000002,

            // Don't simulate clipping by using the XOR operator.
            // ReSharper disable once InconsistentNaming
            // ReSharper disable once UnusedMember.Local
            NoXORClip = 0x00000004
        } ;
    }
}