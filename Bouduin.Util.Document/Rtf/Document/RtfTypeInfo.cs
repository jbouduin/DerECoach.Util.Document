using System.Linq;
using System.Reflection;
using Bouduin.Util.Common.Extensions;
using Bouduin.Util.Document.Generic.Documents;
using Bouduin.Util.Document.Rtf.Attributes;

namespace Bouduin.Util.Document.Rtf.Document
{
    internal class RtfTypeInfo: ATypeInfo<RtfAttributeInfo>
    {
        /// <summary>
        /// Sort method for the properties. return 0 if sort is not important
        /// </summary>
        /// <param name="memberInfoX"></param>
        /// <param name="memberInfoY"></param>
        /// <returns>return less than 0 if x is less than y.
        /// return 0 if x equals y.
        /// return greater than 0 if x is greater than y.</returns>
        protected override int SortMemberInfo(MemberInfo memberInfoX, MemberInfo memberInfoY)
        {
            var rtfSortIndexX =
                memberInfoX.GetCustomAttributes(typeof (RtfSortIndexAttribute), true)
                    .OfType<RtfSortIndexAttribute>()
                    .FirstOrDefault()
                    .IfNotNull(notNull => notNull.SortIndex, 0);
            var rtfSortIndexY =
                memberInfoY.GetCustomAttributes(typeof (RtfSortIndexAttribute), true)
                    .OfType<RtfSortIndexAttribute>()
                    .FirstOrDefault()
                    .IfNotNull(notNull => notNull.SortIndex, 0);
            
            return rtfSortIndexX - rtfSortIndexY;
        }
        
    }
}