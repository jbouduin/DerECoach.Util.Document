using System.Drawing;
using Bouduin.Util.Document.Generic.Contents.Image;

namespace Bouduin.Util.Document.Factories
{
    public interface IImageFactory
    {
        IDocumentImage CreateDocumentImage(Bitmap bitmap);

        /// <param name="bitmap"></param>
        /// <param name="format">Image format</param>
        IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format);

        /// <param name="format"></param>
        /// <param name="dpiX">Horizontal resolution</param>
        /// <param name="dpiY">Vertical resolution</param>
        /// <param name="bitmap"></param>
        IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format, float dpiX, float dpiY);
    }
}