using System.Drawing;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Image;

namespace Bouduin.Util.Document.Factories
{
    public class ImageFactory : IImageFactory
    {
        #region fields --------------------------------------------------------
        private readonly ITwipConverter _twipConverter;
        #endregion

        #region IImageFactory -------------------------------------------------
        public IDocumentImage CreateDocumentImage(Bitmap bitmap)
        {
            return new DocumentImage(_twipConverter, bitmap);
        }

        /// <param name="bitmap"></param>
        /// <param name="format">Image format</param>
        public IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format)
        {
            return new DocumentImage(_twipConverter, bitmap, format);
        }

        /// <param name="format"></param>
        /// <param name="dpiX">Horizontal resolution</param>
        /// <param name="dpiY">Vertical resolution</param>
        /// <param name="bitmap"></param>
        public IDocumentImage CreateDocumentImage(Bitmap bitmap, EImageFormat format, float dpiX, float dpiY)
        {
            return new DocumentImage(_twipConverter, bitmap, format, dpiX, dpiY);
        }
        #endregion

        #region constructor ---------------------------------------------------

        public ImageFactory(ITwipConverter twipConverter)
        {
            _twipConverter = twipConverter;
        }
        #endregion
    }
}