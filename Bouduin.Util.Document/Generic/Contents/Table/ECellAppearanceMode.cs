namespace Bouduin.Util.Document.Generic.Contents.Table
{
    public enum ECellAppearanceMode
    {
        /// <summary>
        /// if a cell has no own appearance and both column and row have one,
        /// the column's appearance is used
        /// </summary>
        ColumnOverRow,
        /// <summary>
        /// if a cell has no own appearance and both column and row have one,
        /// the rows's appearance is used
        /// </summary>
        RowOverVolumn
    }
}