// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Basic operations on options.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Monads
{
    using System;

    public static class Maybe
    {
        public static Option<TValue> AsOption<TValue>(this TValue value) where TValue : class
        {
            return value == null ? Option.None<TValue>() : Option.Some(value);
        }

        public static Option<TResult> Bind<TInput, TResult>(this Option<TInput> option, Func<TInput, TResult> map)
        {
            return option.IsSome ? Option.Some(map(option.Value)) : Option.None<TResult>();
        }

        public static TValue Return<TValue>(this Option<TValue> option)
        {
            return option.IsSome ? option.Value : default(TValue);
        }

        public static TValue Return<TValue>(this Option<TValue> option, TValue defaultValue)
        {
            return option.IsSome ? option.Value : defaultValue;
        }

        public static TValue Return<TValue>(this Option<TValue> option, Func<TValue> defaultValue)
        {
            return option.IsSome ? option.Value : defaultValue();
        }
    }
}