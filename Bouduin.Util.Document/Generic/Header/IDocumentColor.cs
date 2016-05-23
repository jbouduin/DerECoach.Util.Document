namespace Bouduin.Util.Document.Generic.Header
{
    internal interface IDocumentColor
    {
        int Red { get; }
        int Green { get; }
        int Blue { get; }

        /// <summary>
        /// Condition member used by RtfWriter.
        /// </summary>
        bool IsNotAuto { get; }

        bool Equals(object obj);
        int GetHashCode();
    }
}