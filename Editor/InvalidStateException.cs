using System;

namespace TNRD.Constraints
{
    public class InvalidStateException : Exception
    {
        public InvalidStateException()
            : base("The Constrained Rect that you're trying to modify has already been pooled and is no longer available for usage")
        {
        }
    }
}
