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
        public static Option<TValue> AsOption<TValue>(this TValue value)
        {
            return object.Equals(value, default(TValue)) ? Option.None<TValue>() : Option.Some(value);
        }

        public static Option<TResult> Bind<TInput, TResult>(this Option<TInput> option, Func<TInput, Option<TResult>> binder)
        {
            return option.IsSome ? binder(option.Value) : Option.None<TResult>();
        }

        public static Option<TResult> Map<TInput, TResult>(this Option<TInput> option, Func<TInput, TResult> mapper)
        {
            return option.IsSome ? Option.Some(mapper(option.Value)) : Option.None<TResult>();
        }

        public static Option<TValue> Do<TValue>(this Option<TValue> option, Action<TValue> action)
        {
            if (option.IsSome)
            {
                action(option.Value);
            }

            return option;
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