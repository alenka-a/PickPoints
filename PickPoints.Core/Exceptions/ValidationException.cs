using System;

namespace PickPoints.Core.Exceptions
{
    public class ValidationException: Exception
    {        
        public ValidationException(string message) : base(message)
        {            
        }
    }
}
