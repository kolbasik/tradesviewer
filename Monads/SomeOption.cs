namespace Monads
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    [DebuggerDisplay("Some({Value})")]
    internal sealed class SomeOption<TValue> : Option<TValue>
    {
        private readonly TValue value;

        private SomeOption(TValue value)
        {
            this.value = value;
        }

        public override bool IsSome
        {
            [DebuggerStepThrough]
            get { return true; }
        }

        public override TValue Value
        {
            [DebuggerStepThrough]
            get { return this.value; }
        }

        public override string ToString()
        {
            return string.Concat("Some(", Convert.ToString(this.value, CultureInfo.InvariantCulture), ")");
        }

        public static Option<TValue> Return(TValue value)
        {
            return new SomeOption<TValue>(value);
        }
    }
}