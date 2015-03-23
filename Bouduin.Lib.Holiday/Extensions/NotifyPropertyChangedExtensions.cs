using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bouduin.Lib.Holidays.Extensions
{
    public static class NotifyPropertyChangedExtensions
    {
        public static void TriggerNotification<T>(this INotifyPropertyChanged notifyPropertyChanged,
                                     PropertyChangedEventHandler propertyChanged,
                                     Expression<Func<T>> selectorExpression)
        {
            if (selectorExpression == null)
                throw new ArgumentNullException(@"selectorExpression");
            var body = selectorExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException(@"The body must be a member expression");
            if (propertyChanged != null)
                propertyChanged(notifyPropertyChanged, new PropertyChangedEventArgs(body.Member.Name));
        }
    }
}
