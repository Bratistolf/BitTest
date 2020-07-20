using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bit.Api.Helpers.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception inner) : base(message, inner) { }

        private NotFoundException(System.Runtime.Serialization.SerializationInfo info,
                                  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
