namespace Monads
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("None")]
    internal sealed class NoneOption<TValue> : Option<TValue>
    {
        private static readonly NoneOption<TValue> Nothing;

        static NoneOption()
        {
            Nothing = new NoneOption<TValue>();
        }

        private NoneOption()
        {
        }

        public override bool IsSome
        {
            [DebuggerStepThrough]
            get { return false; }
        }

        public override TValue Value
        {
            [DebuggerStepThrough]
            get
            {
                throw new NullReferenceException("Option does not have a value.");
            }
        }

        public override bool Equals(Option<TValue> other)
        {
            return object.ReferenceEquals(this, other);
        }

        public override string ToString()
        {
            return "None";
        }

        public static Option<TValue> Return()
        {
            return Nothing;
        }
    }
}