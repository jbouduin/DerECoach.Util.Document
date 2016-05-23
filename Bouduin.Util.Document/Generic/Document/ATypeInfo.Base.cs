using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bouduin.Util.Document.Generic.Document
{
    internal abstract class ATypeInfo
    {
        #region fields --------------------------------------------------------
        private Type _type;
        private List<MemberInfo> _members;
        #endregion

        #region properties ----------------------------------------------------
        internal Type Type
        {
            get { return _type; }
            set
            {
                _type = value;
                _members = _type.FindMembers(MemberTypes.Field | MemberTypes.Property,
                BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public, FilterHasAttributes, null).ToList();
                _members.Sort(SortMemberInfo);
            }
        }

        internal IList<MemberInfo> Members
        {
            get { return _members; }
        }

        #endregion

        #region abstract members ----------------------------------------------
        /// <summary>
        /// Sort method for the properties. return 0 if sort is not important
        /// </summary>
        /// <param name="memberInfoX"></param>
        /// <param name="memberInfoY"></param>
        /// <returns>return less than 0 if x is less than y.
        /// return 0 if x equals y.
        /// return greater than 0 if x is greater than y.</returns>
        protected abstract int SortMemberInfo(MemberInfo memberInfoX, MemberInfo memberInfoY);

        protected abstract bool FilterHasAttributes(MemberInfo m, object filterCriteria);

        #endregion
    }
}