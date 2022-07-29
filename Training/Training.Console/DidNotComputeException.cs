using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    // To Answer the Question Why does my custom exception need to be serialized,
    // Here's a good StackOverflow answer for you...
    // Because your exceptions may need to be marshalled
    // between different AppDomains and if they aren't
    // (properly) serializable you will lose precious debugging information.
    // Unlike other classes, you won't have control over
    // whether your exception will be marshalled -- it will.
    // When I mean "you won't have control" I mean that classes
    // you create generally have a finite space of existence
    // and the existence is well known. If it's a return value
    // and someone tries to call it in a different AppDomain
    // (or on a different machine) they will get a fault and
    // can just say "Don't use it that way."
    // The caller knows they have to convert it into a type that
    // can be serialized (by wrapping the method call). However
    // since exceptions are bubbled up to the very top if not caught
    // they can transcend AppDomain boundaries you didn't even know you had.
    // Your custom application exception 20 levels deep in a different AppDomain
    // might be the exception reported at Main() and nothing along the way
    // is going to convert it into a serializable exception for you.
    // Your exceptions may be passed across Web Services as well,
    // in this case the exception needs to be serializable/deserializable
    // so it can be turned into XML and transmitted by the Web Service

    [Serializable]
    public class DidNotComputeException : Exception
    {
        public DidNotComputeException() : base() { }


        public DidNotComputeException(string message) : base(message) { }

        // Pass along inner exceptions to the base class
        public DidNotComputeException(string message, Exception inner) : base(message, inner) { }

        // For serialization to remote systems
        // Without this constructor, deserialization will fail
        protected DidNotComputeException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    // More specific error to talk about the errro bubbling up
    // And how a less specific catch exception would catch this more specific exception
    public class DidNotComputeANumberException : DidNotComputeException
    {
        public DidNotComputeANumberException() : base()
        {

        }

    }
}
