using System;

namespace Bouduin.Util.Document.Generic.Contents.Table
{
    /// <summary>
    /// Specifies border setting.
    /// </summary>
    [Flags]
    public enum EBorderSetting
    {
        None = 0,
        Top = 1,
        Left = 2,
        Bottom = 4,
        Right = 8,
        All = Top | Left | Bottom | Right
    }
}