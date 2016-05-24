namespace Bouduin.Util.Document.Generic.Header
{
    internal interface IDocumentColor
    {
        int Red { get; }
        int Green { get; }
        int Blue { get; }

        /// <summary>
        /// Condition member
        /// </summary>
        bool IsNotAuto { get; }

        bool Equals(object obj);
        int GetHashCode();
    }
}