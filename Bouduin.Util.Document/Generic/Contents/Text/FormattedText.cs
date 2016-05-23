using System;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Generic.Contents.Text
{
    
    /// <summary>
    /// Represents text with formatting.
    /// </summary>
    [RtfEnclosingBraces]
    internal class FormattedText : AText, IFormattedText
    {
        #region fields --------------------------------------------------------
        private int _fontIndex = -1;
        private float _fontSize;
        private int _colorIndex = -1;
        private int _backgroundColorIndex = -1;
        
        private bool _superScript;
        private bool _subScript;
        #endregion

        #region IFormattedText members ----------------------------------------
        /// <summary>
        /// Index of an entry in the font table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        [RtfControlWord("f"), RtfIndex]
        public int FontIndex
        {
            get { return _fontIndex; }
            set { _fontIndex = value; }
        }

        /// <summary>
        /// Gets the font size in half points. Used by RtfWriter.
        /// </summary>
        [RtfControlWord("fs"), RtfInclude(ConditionMember="FontSizeSet")]
        public int HalfPointFontSize
        {
            get { return (int)Math.Round(_fontSize * 2); }
        }

        /// <summary>
        /// Index of an entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        [RtfControlWord("cf"), RtfIndex]
        public int TextColorIndex
        {
            get { return _colorIndex; }
            set { _colorIndex = value; }
        }

        /// <summary>
        /// Index of an entry in the color table. Default is -1 and is ignored by RtfWriter.
        /// </summary>
        [RtfControlWord("cb"), RtfIndex]
        public int BackgroundColorIndex
        {
            get { return _backgroundColorIndex; }
            set { _backgroundColorIndex = value; }
        }

        [RtfControlWord("b")]
        public bool Bold { get; set; }

        [RtfControlWord("i")]
        public bool Italic { get; set; }

        [RtfControlWord("ul")]
        public bool Underline { get; set; }

        [RtfControlWord("sub")]
        public bool Subscript
        {
            get { return _subScript; }
            set 
            {
                if (value)
                {
                    _superScript = false;
                }

                _subScript = value;
            }
        }
        
        [RtfControlWord("super")]
        public bool Superscript
        {
            get { return _superScript; }
            set
            {
                if (value)
                {
                    _subScript = false;
                }

                _superScript = value;
            }
        }

        [RtfControlWord("caps")]
        public bool Caps { get; set; }

        [RtfControlWord("scaps")]
        public bool SmallCaps { get; set; }
                
        
        /// <summary>
        /// Gets string value of the text.
        /// </summary>
        [RtfTextData]
        public string Text
        {
            get { return Sb.ToString(); }
        }
        


        /// <summary>
        /// Font size in points. Default value 0 is ignored by RtfWriter.
        /// </summary>
        public float FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        /// <summary>
        /// ConditionMember used by RtfWriter.
        /// </summary>
        public bool FontSizeSet
        {
            get { return !_fontSize.Equals(0); }
        }

        /// <summary>
        /// Applies specified formatting to the text.
        /// </summary>
        /// <param name="formatting">Character formatting to apply.</param>
        public void SetFormatting(ECharacterFormatting formatting)
        {
            Bold = (formatting & ECharacterFormatting.Bold) == ECharacterFormatting.Bold;
            Italic = (formatting & ECharacterFormatting.Italic) == ECharacterFormatting.Italic;
            Underline = (formatting & ECharacterFormatting.Underline) == ECharacterFormatting.Underline;
            Subscript = (formatting & ECharacterFormatting.Subscript) == ECharacterFormatting.Subscript;
            Superscript = (formatting & ECharacterFormatting.Superscript) == ECharacterFormatting.Superscript;
            Caps = (formatting & ECharacterFormatting.Caps) == ECharacterFormatting.Caps;
            SmallCaps = (formatting & ECharacterFormatting.SmallCaps) == ECharacterFormatting.SmallCaps;
        }
        #endregion

        #region constructor ------------------------------------------
        /// <param name="text">String value to set as text.</param>
        public FormattedText(string text = null) : base(text)
        {
        }
        
        /// <param name="text">String value to set as text.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        public FormattedText(int colorIndex, string text = null ) : base(text)
        {
            _colorIndex = colorIndex;
        }

        

        /// <param name="text">String value to set as text.</param>
        /// <param name="formatting">Character formatting to apply to the text.</param>
        public FormattedText(ECharacterFormatting formatting, string text = null) : base(text)
        {
            SetFormatting(formatting);
        }

        /// <param name="formatting">Character formatting to apply to the text.</param>
        /// <param name="colorIndex">Index of an entry in the color table.</param>
        /// <param name="text">String value to set as text.</param>
        public FormattedText(ECharacterFormatting formatting, int colorIndex, string text = null): base(text)
        {
            SetFormatting(formatting);
            _colorIndex = colorIndex;
        }

        /// <param name="text">String value to set as text.</param>
        /// <param name="fontIndex">Index of an entry in the font table.</param>
        /// <param name="fontSize"></param>
        public FormattedText(int fontIndex, float fontSize, string text = null)
            : base(text)
        {
            _fontIndex = fontIndex;
            _fontSize = fontSize;
        }

        /// <param name="formatting">Character formatting to apply to the text.</param>
        /// <param name="fontIndex">Index of an entry in the font table.</param>
        /// <param name="fontSize"></param>
        /// <param name="text">String value to set as text.</param>
        public FormattedText(ECharacterFormatting formatting, int fontIndex, float fontSize, string text = null):base(text)
        {
            SetFormatting(formatting);
            _fontSize = fontSize;
            _fontIndex = fontIndex;
        }
        #endregion
        
    }
}