using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Bouduin.Util.Common.Extensions
{
    public static class NotifyPropertyChangedExtensions
    {
        #region INotifyPropertyChanged ----------------------------------------
        /// <summary>
        /// Fire the propertychanged event handler if set.
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="notifyPropertyChanged"></param>
        /// <param name="propertyChanged"></param>
        /// <param name="selectorExpression"></param>
        public static void FirePropertyChanged<TProperty>(this INotifyPropertyChanged notifyPropertyChanged,
                                     PropertyChangedEventHandler propertyChanged,
                                     Expression<Func<TProperty>> selectorExpression)
        {
            if (propertyChanged == null)
                return;

            DoFirePropertyChanged(propertyChanged, notifyPropertyChanged, selectorExpression);
        }
        #endregion

        #region PropertyChangedEventHandler -----------------------------------
        public static void FirePropertyChanged<TSender, TProperty>(
            this PropertyChangedEventHandler handler,
            TSender sender,
            Expression<Func<TSender, TProperty>> property)
        {
            if (handler == null)
            {
                return;
            }
            DoFirePropertyChanged(handler, sender, property);
        }

        public static void FirePropertyChanged<TProperty>(
            this PropertyChangedEventHandler handler,
            object sender,
            Expression<Func<TProperty>> property)
        {
            if (handler == null)
            {
                return;
            }
            DoFirePropertyChanged(handler, sender, property);
        }
        #endregion

        #region helper methods ------------------------------------------------

        private static void DoFirePropertyChanged<TSender>(
            PropertyChangedEventHandler handler, 
            TSender sender,
            Expression property)
        {
            var lambda = property.ThrowOnNull(property as LambdaExpression);
            var call = property.ThrowOnNull(lambda.Body as MemberExpression);
            property.CheckIsProperty(call);
            handler(sender, new PropertyChangedEventArgs(call.Member.Name));
        }

        #endregion

    }
}