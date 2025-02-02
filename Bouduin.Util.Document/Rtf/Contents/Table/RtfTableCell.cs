﻿using System;
using Bouduin.Util.Document.Common;
using Bouduin.Util.Document.Primitives;
using Bouduin.Util.Document.Rtf.Attributes;
using Bouduin.Util.Document.Rtf.Contents.Paragraphs;
using Bouduin.Util.Document.Rtf.Contents.Text;

namespace Bouduin.Util.Document.Rtf.Contents.Table
{
    /// <summary>
    /// Specifies border setting.
    /// </summary>
    [Flags]
    public enum RtfBorderSetting { 
        None = 0,
        Top = 1,
        Left = 2,
        Bottom = 4,
        Right = 8,
        All = Top | Left | Bottom | Right
    }
    
    /// <summary>
    /// Represents a table cell.
    /// </summary>
    [RtfControlWord("pard"), RtfControlWordDenotingEnd("cell")]
    public class RtfTableCell : RtfFormattedParagraph
    {
        private RtfTableCellDefinition _definition;

        internal RtfTableColumn ColumnInternal;
        internal RtfTableRow RowInternal;
        internal int ColumnIndexInternal = -1;
        internal int RowIndexInternal = -1;

        /// <summary>
        /// Gets cell definition containing information about cell style and width.
        /// </summary>
        [RtfIgnore]
        public RtfTableCellDefinition Definition
        {
            get { return _definition; }
        }

        /// <summary>
        /// Gets owning table.
        /// </summary>
        [RtfIgnore]
        public RtfTable Table
        {
            get { return RowInternal.Table; }
        }

        /// <summary>
        /// Gets owning column.
        /// </summary>
        [RtfIgnore]
        public RtfTableColumn OwningColumn
        {
            get { return ColumnInternal; }
        }

        /// <summary>
        /// Gets owning row.
        /// </summary>
        [RtfIgnore]
        public RtfTableRow OwningRow
        {
            get { return RowInternal; }
        }

        /// <summary>
        /// Gets the index of the owning column in a table.
        /// </summary>
        public int ColumnIndex
        {
            get { return ColumnIndexInternal; }
        }

        /// <summary>
        /// Gets the index of the owning row in a table.
        /// </summary>
        public int RowIndex
        {
            get { return RowIndexInternal; }
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        public RtfTableCell()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="width">Cell width in centimeters.</param>
        public RtfTableCell(float width)
        {
            Initialize();
            
            _definition.Width = TwipConverter.ToTwip(width, EMetricUnit.Centimeter);
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="text">Text displayed in the cell.</param>
        public RtfTableCell(string text) : base(text)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="text">Text displayed in the cell.</param>
        public RtfTableCell(RtfParagraphContentBase text) : base(text)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="style">Style applied to the cell.</param>
        public RtfTableCell(RtfTableCellStyle style) : base(style.DefaultParagraphFormatting)
        {
            Initialize(style);
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="width">Cell width in centimeters.</param>
        /// <param name="text">Text displayed in the cell.</param>
        public RtfTableCell(float width, string text) : base(text)
        {
            Initialize();
            _definition.Width = TwipConverter.ToTwip(width, EMetricUnit.Centimeter);
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="width">Cell width in centimeters.</param>
        /// <param name="text">Text displayed in the cell.</param>
        public RtfTableCell(float width, RtfParagraphContentBase text) : base(text)
        {
            Initialize();
            _definition.Width = TwipConverter.ToTwip(width, EMetricUnit.Centimeter);
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="width">Cell width in centimeters.</param>
        /// <param name="style">Style applied to the cell.</param>
        public RtfTableCell(float width, RtfTableCellStyle style) : base(style.DefaultParagraphFormatting)
        {
            Initialize(style);
            _definition.Width = TwipConverter.ToTwip(width, EMetricUnit.Centimeter);
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="text">Text displayed in the cell.</param>
        /// <param name="style">Style applied to the cell.</param>
        public RtfTableCell(string text, RtfTableCellStyle style) : base(text, style.DefaultParagraphFormatting)
        {
            Initialize(style);
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="text">Text displayed in the cell.</param>
        /// <param name="style">Style applied to the cell.</param>
        public RtfTableCell(RtfParagraphContentBase text, RtfTableCellStyle style) : base(text, style.DefaultParagraphFormatting)
        {
            Initialize(style);
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="width">Cell width in centimeters.</param>
        /// <param name="text">Text displayed in the cell.</param>
        /// <param name="style">Style applied to the cell.</param>
        public RtfTableCell(float width, string text, RtfTableCellStyle style) : base(text, style.DefaultParagraphFormatting)
        {
            Initialize(style);

            _definition.Width = TwipConverter.ToTwip(width, EMetricUnit.Centimeter);
        }

        /// <summary>
        /// Initializes a new instance of ESCommon.Rtf.RtfTableCell class.
        /// </summary>
        /// <param name="width">Cell width in centimeters.</param>
        /// <param name="text">Text displayed in the cell.</param>
        /// <param name="style">Style applied to the cell.</param>
        public RtfTableCell(float width, RtfParagraphContentBase text, RtfTableCellStyle style) : base(text, style.DefaultParagraphFormatting)
        {
            Initialize(style);

            _definition.Width = TwipConverter.ToTwip(width, EMetricUnit.Centimeter);
        }


        private void Initialize(RtfTableCellStyle style = null)
        {
            _definition = new RtfTableCellDefinition(this) {Style = style};

            IsPartOfATable = true;
            IsFormattingIncluded = style != null && style.DefaultParagraphFormatting != null;
        }
    }
}