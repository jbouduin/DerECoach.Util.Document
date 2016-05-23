using Bouduin.Util.Document.Generic.Contents.Text;

namespace Bouduin.Util.Document.Generic.Contents.Image
{
    public interface IDocumentImage: IParagraphContent
    {
        /// <summary>
        /// Gets the horizontal resolution of the output image.
        /// </summary>
        float DpiX { get; }

        /// <summary>
        /// Gets the vertical resolution of the output image.
        /// </summary>
        float DpiY { get; }

        /// <summary>
        /// Gets horizontal scale. Default is 100.
        /// </summary>
        int ScaleX { get; set; }

        /// <summary>
        /// Gets vertical scale. Default is 100.
        /// </summary>
        int ScaleY { get; set; }

        /// <summary>
        /// Gets width of the original picture in pixels for bitmaps and millimeters for WMF. Used by RtfWriter.
        /// </summary>
        int OriginalWidth { get; }

        /// <summary>
        /// Gets height of the original picture in pixels for bitmaps and millimeters for WMF. Used by RtfWriter.
        /// </summary>
        int OriginalHeight { get; }

        /// <summary>
        /// Base width of the output image in twips.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Base height of the output image in twips.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Format of the output image. Default is Wmf.
        /// </summary>
        EImageFormat Format { get; set; }

        /// <summary>
        /// Gets hexadecimal string representation of the image.
        /// </summary>
        string HexData { get; }

        /// <summary>
        /// Resets the size of the bitmap according to DPI value.
        /// </summary>
        void SetDpi(float dpiX, float dpiY);
        
    }
}