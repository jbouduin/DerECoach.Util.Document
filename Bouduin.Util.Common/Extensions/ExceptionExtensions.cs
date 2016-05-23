﻿using System;

namespace Bouduin.Util.Common.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exception GetMostInnerException(this Exception exception)
        {
            while (true)
            {
                var innerException = exception.InnerException;
                if (innerException == null) return exception;
                exception = innerException;
            }
        }
    }
}