using System;

namespace Bouduin.Util.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception GetMostInnerException(this Exception exception)
        {
            var innerException = exception.InnerException;
            return innerException == null ? exception : innerException.GetMostInnerException();
        }
    }
}