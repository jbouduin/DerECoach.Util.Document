namespace Bouduin.Util.Document.Generic.Formatting
{
    public interface IBorder
    {
        /// <summary>
        /// Border width in twips.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Border style.
        /// </summary>
        EBorderStyle Style { get; set; }

        /// <summary>
        /// Index of entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        int ColorIndex { get; set; }

        /// <summary>
        /// Sets the properties of the current border.
        /// </summary>
        /// <param name="width">Width in points.</param>
        /// <param name="style">Border style.</param>
        /// <param name="colorIndex">Index of entry in the color table.</param>
        void SetProperties(float width, EBorderStyle style, int colorIndex);

        /// <summary>
        /// Copy all the properties of the current border to specified IBorder object.
        /// </summary>
        /// <param name="border">Border object to copy to.</param>
        void CopyTo(IBorder border);
    }
}