using System.Collections.Generic;
using System.Linq;


namespace System
{
    public static class AggregateExceptionHelper
    {
        public static void ThrowIfAny(IEnumerable<Exception> exceptions)
        {
            if(exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
