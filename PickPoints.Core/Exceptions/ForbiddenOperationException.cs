using System;

namespace PickPoints.Core.Exceptions
{
    public class ForbiddenOperationException : Exception
    {
        public ForbiddenOperationException(string message) : base(message)
        {
        }
    }
}
