using System;
using System.Linq;
using System.Reflection;

namespace Bouduin.Util.Document.Generic.Documents
{
    
    internal abstract class AAttributeInfo
    {
        #region fields --------------------------------------------------------

        private object[] _attributes;
        private MemberInfo _memberInfo;
        private bool? _hasAnyRelevantAttribute;
        #endregion

        #region properties ----------------------------------------------------
        
        internal MemberInfo MemberInfo
        {
            get { return _memberInfo; }
            set
            {
                _memberInfo = value;
                _attributes = MemberInfo.GetCustomAttributes(false);
            }
        }

        internal bool HasAnyRelevantAttribute
        {
            get
            {
                if (_hasAnyRelevantAttribute.HasValue)
                    return _hasAnyRelevantAttribute.Value;

                var attributeProperties =
                    GetType().GetProperties().Where(property => property.PropertyType.IsSubclassOf(typeof(Attribute)));


                _hasAnyRelevantAttribute = attributeProperties.Any(property => property.GetValue(this) != null);
                return _hasAnyRelevantAttribute.Value;
            }
        }

        #endregion

        #region abstract members ----------------------------------------------
        
        #endregion

        #region constructor ---------------------------------------------------
        #endregion

        #region protected helper methods --------------------------------------
        protected T GetAttribute<T>() where T: Attribute
        {
            return _attributes.FirstOrDefault(attribute => attribute.GetType() == typeof(T)) as T;
        }
        #endregion
    }
}