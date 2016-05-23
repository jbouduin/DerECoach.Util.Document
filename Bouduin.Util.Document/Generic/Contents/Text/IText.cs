namespace Bouduin.Util.Document.Generic.Contents.Text
{
    public interface IText: IParagraphContent
    {
        /// <summary>
        /// Appends text to the current object.
        /// </summary>
        /// <param name="text">Text to append.</param>
        void AppendText(string text);
    }
}