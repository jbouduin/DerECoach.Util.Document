using System;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Generic.Contents.Paragraphs;
using Bouduin.Util.Document.Generic.Contents.Table.Columns;
using Bouduin.Util.Document.Generic.Contents.Table.Rows;
using Bouduin.Util.Document.Generic.Contents.Text;
using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Primitives;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Table.Cells
{
    
    public interface ITableCell : IDocumentContent
    {
        IFormattedParagraph CellContent { get; }
        ITableCellDefinition TableCellDefinition { get; }
        ITableColumn Column { get; }
        ITableRow Row { get; }
        int ColumnIndex { get; }
        int RowIndex { get; }
        ITableCellAppearance CellAppearance { get; set; }
    }

    internal interface ITableCellInternal : ITableCell, IDocumentContentInternal
    {
        IFormattedParagraphInternal CellContentInternal { set; }
        ITableInternal TableInternal { get; set; }
        ITableColumnInternal ColumnInternal { set; }
        ITableRowInternal RowInternal { set; }
        string CellAppearanceKey { get; }
    }
    
    /// <summary>
    /// Represents a table cell.
    /// </summary>
    [RtfControlWord("pard"), RtfControlWordDenotingEnd("cell")]
    internal class TableCell : ADocumentContent, ITableCellInternal
    {
        #region fields --------------------------------------------------------

        private IFormattedParagraphInternal _cellContent;
        private ITableCellDefinition _definition;
        private ITableColumnInternal _columnInternal;
        private ITableRowInternal _rowInternal;
        #endregion

        #region ITableCell members --------------------------------------------

        public IFormattedParagraph CellContent
        {
            get { return _cellContent; }
        }

        [RtfIgnore]
        public ITableCellDefinition TableCellDefinition
        {
            get { return _definition; }
        }
        
        [RtfIgnore]
        public ITableColumn Column
        {
            get { return _columnInternal; }
        }

        [RtfIgnore]
        public ITableRow Row
        {
            get { return _rowInternal; }
        }

        public int ColumnIndex
        {
            get { return TableInternal.RowsInternal.IndexOf(_rowInternal); }
        }

        public int RowIndex
        {
            get { return TableInternal.ColumnsInternal.IndexOf(_columnInternal); }
        }

        public ITableCellAppearance CellAppearance
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CellAppearanceKey))
                    return null;

                return TableInternal.Appearances[CellAppearanceKey];
            }
            set
            {
                if (string.IsNullOrWhiteSpace(((ITableCellAppearanceInternal)value).AppearanceKey))
                {

                    ((ITableCellAppearanceInternal)value).AppearanceKey = Guid.NewGuid().ToString();
                    TableInternal.Appearances.Add(((ITableCellAppearanceInternal)value).AppearanceKey, value);
                }
                CellAppearanceKey = ((ITableCellAppearanceInternal)value).AppearanceKey;

            }
        }
        #endregion

        #region ITableCellInternal members ------------------------------------

        public IFormattedParagraphInternal CellContentInternal
        {
            set { _cellContent = value; }
        }

        public ITableInternal TableInternal { get; set; }
        public ITableColumnInternal ColumnInternal
        {
            set { _columnInternal = value; }
        }

        public ITableRowInternal RowInternal
        {
            set { _rowInternal = value; }
        }

        public string CellAppearanceKey { get; private set; }
        #endregion

        #region constructor ---------------------------------------------------

        public TableCell(ITwipConverter twipConverter)
        {
            CellContentInternal = new FormattedParagraph(twipConverter);
            Initialize();
        }

        /// <param name="twipConverter"></param>
        /// <param name="width">Cell width in the specified unit.</param>
        /// <param name="metricUnit">The metric unit used to express the width</param>
        public TableCell(ITwipConverter twipConverter, float width, EMetricUnit metricUnit)
        {
            CellContentInternal = new FormattedParagraph(twipConverter);
            Initialize();

            _definition.Width = twipConverter.ToTwip(width, metricUnit);
        }


        /// <param name="twipConverter"></param>
        /// <param name="text">Text displayed in the cell.</param>
        public TableCell(ITwipConverter twipConverter, string text)
        {
            _cellContent = new FormattedParagraph(twipConverter, text);
            Initialize();
        }

        /// <param name="twipConverter"></param>
        /// <param name="paragraphContent"></param>
        public TableCell(ITwipConverter twipConverter, IParagraphContent paragraphContent)
        {
            _cellContent = new FormattedParagraph(twipConverter, paragraphContent);
            Initialize();
        }


        /// <param name="twipConverter"></param>
        /// <param name="appearance">Style applied to the cell.</param>
        public TableCell(ITwipConverter twipConverter, ITableCellAppearance appearance)
        {
            CellAppearance = appearance;
            _cellContent = new FormattedParagraph(twipConverter);
            Initialize(appearance);
        }

        /// <param name="twipConverter"></param>
        /// <param name="width">Cell width in the specified unit.</param>
        /// <param name="metricUnit">The metric unit used to express the width</param>
        /// <param name="text"></param>
        public TableCell(ITwipConverter twipConverter, float width, EMetricUnit metricUnit, string text)
        {
            _cellContent = new FormattedParagraph(twipConverter, text);
            Initialize();
            _definition.Width = twipConverter.ToTwip(width, metricUnit);
        }

        /// <param name="twipConverter"></param>
        /// <param name="width">Cell width in the specified unit.</param>
        /// <param name="metricUnit">The metric unit used to express the width</param>
        /// <param name="paragraphContent"></param>
        public TableCell(ITwipConverter twipConverter, float width, EMetricUnit metricUnit,
            IParagraphContent paragraphContent)
        {
            _cellContent = new FormattedParagraph(twipConverter, paragraphContent);
            Initialize();
            _definition.Width = twipConverter.ToTwip(width, metricUnit);
        }

        // TODO overload with TableCellAppearancekey
        /// <param name="twipConverter"></param>
        /// <param name="width">Cell width in the specified unit.</param>
        /// <param name="metricUnit">The metric unit used to express the width</param>
        /// <param name="appearance"></param>
        public TableCell(ITwipConverter twipConverter, float width, EMetricUnit metricUnit, ITableCellAppearance appearance)
            
        {
            _cellContent = new FormattedParagraph(twipConverter);
            CellAppearance = appearance;

            Initialize(appearance);
            _definition.Width = twipConverter.ToTwip(width, metricUnit);
        }

        // TODO + overload with TableCellAppearancekey
        /// <param name="twipConverter"></param>
        /// <param name="text">Text displayed in the cell.</param>
        /// <param name="appearance">Style applied to the cell.</param>
        public TableCell(ITwipConverter twipConverter, string text, ITableCellAppearance appearance)
         
        {
            _cellContent = new FormattedParagraph(twipConverter, text);
            CellAppearance = appearance;
            
            Initialize(appearance);
        }

        // TODO + overload with TableCellAppearancekey
        /// <param name="twipConverter"></param>
        /// <param name="paragraphContent">Text displayed in the cell.</param>
        /// <param name="appearance">Style applied to the cell.</param>
        public TableCell(ITwipConverter twipConverter, IParagraphContent paragraphContent, ITableCellAppearance appearance)
        {
            _cellContent = new FormattedParagraph(twipConverter, paragraphContent);
            CellAppearance = appearance;
            Initialize(appearance);
        }

        // TODO + overload with TableCellAppearancekey
        /// <param name="twipConverter"></param>
        /// <param name="width">Cell width in the specified unit.</param>
        /// <param name="metricUnit">The metric unit used to express the width</param>
        /// <param name="text">Text displayed in the cell.</param>
        /// <param name="appearance">Style applied to the cell.</param>
        public TableCell(ITwipConverter twipConverter, float width, EMetricUnit metricUnit, string text,
            ITableCellAppearance appearance)
         
        {
            _cellContent = new FormattedParagraph(twipConverter, text);
            CellAppearance = appearance;
            
            Initialize(appearance);

            _definition.Width = twipConverter.ToTwip(width, metricUnit);
        }

        // TODO + overload with TableCellAppearancekey
        /// <param name="twipConverter"></param>
        /// <param name="width">Cell width in the specified unit.</param>
        /// <param name="metricUnit">The metric unit used to express the width</param>
        /// <param name="paragraphContent">Text displayed in the cell.</param>
        /// <param name="appearance">Style applied to the cell.</param>
        public TableCell(ITwipConverter twipConverter, float width, EMetricUnit metricUnit,
            IParagraphContent paragraphContent, ITableCellAppearance appearance)
        {
            _cellContent = new FormattedParagraph(twipConverter, paragraphContent);
            CellAppearance = appearance;
            Initialize(appearance);

            _definition.Width = twipConverter.ToTwip(width, metricUnit);
        }

        #endregion

        #region private methods -----------------------------------------------

        private void Initialize(ITableCellAppearance appearance = null)
        {
            _definition = new TableCellDefinition(this);
            _cellContent.IsPartOfATable = true;
            //IsFormattingIncluded =
            //    appearance.IfNotNull(
            //        notNull => notNull.DefaultParagraphFormatting.IfNotNull(formattingNotNull => true, false), false);
        }

        #endregion

        
    }
}