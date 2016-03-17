using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bouduin.Util.Common.Extensions;

namespace Bouduin.Util.Common.Primitives
{
    public class APropertyChangedNotifierWithTracking : APropertyChangedNotifier
    {
        #region change management -------------------------------------------------
        private readonly Dictionary<string, object> _dictionaryOfChanges = new Dictionary<string, object>();

        /// <summary>
        /// the method triggering the PropertyChangedEventhandler indirectly and tracking value changes
        /// </summary>
        /// <param name="selectorExpression">An expression used to extract the name of the property
        /// e.g. () => Name</param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected virtual void OnPropertyChanged<TValue, TProperty>(
            Expression<Func<TProperty>> selectorExpression,
            TValue oldValue,
            TValue newValue)
        {

            var lambda = selectorExpression.ThrowOnNull(selectorExpression as LambdaExpression);
            var call = selectorExpression.ThrowOnNull(lambda.Body as MemberExpression);
            selectorExpression.CheckIsProperty(call);

            if (Equals(oldValue, newValue))
                return;

            if (!_dictionaryOfChanges.ContainsKey(call.Member.Name))
            {
                _dictionaryOfChanges.Add(call.Member.Name, oldValue);
            }
            else
            {
                if (call.Type == typeof (string))
                {
                    var originalStringValue = _dictionaryOfChanges[call.Member.Name] == null
                        ? string.Empty
                        : _dictionaryOfChanges[call.Member.Name].ToString();

                    var newStringValue = newValue == null ? string.Empty : newValue.ToString();

                    if (originalStringValue.Equals(newStringValue))
                    {
                        _dictionaryOfChanges.Remove(call.Member.Name);
                    }
                }
                else
                {
                    if (_dictionaryOfChanges[call.Member.Name].EqualsConsideringNull(newValue))
                    {
                        _dictionaryOfChanges.Remove(call.Member.Name);
                    }
                }
            }
            OnPropertyChanged(selectorExpression);
            OnPropertyChanged(() => HasChanges);
        }

        public virtual void ClearChangeFlag()
        {
            _dictionaryOfChanges.Clear();
        }

        public virtual bool HasChanges
        {
            get { return _dictionaryOfChanges.Any(); }
        }
        #endregion
    }
    
}