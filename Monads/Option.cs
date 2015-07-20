namespace Monads
{
    using System;

    public abstract class Option
    {
        public static Option<TValue> None<TValue>()
        {
            return NoneOption<TValue>.Return();
        }

        public static Option<TValue> Some<TValue>(TValue value)
        {
            return SomeOption<TValue>.Return(value);
        }
    }

    public abstract class Option<T> : Option, IEquatable<Option<T>>, IEquatable<T>
    {
        public abstract bool IsSome { get; }

        public abstract T Value { get; }

        public abstract bool Equals(Option<T> other);

        public virtual bool Equals(T other)
        {
            return this.IsSome && object.Equals(this.Value, other);
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Option<T>)obj);
        }

        public override int GetHashCode()
        {
            if (!this.IsSome || this.Value.Equals(default(T)))
            {
                return 0;
            }

            return this.Value.GetHashCode();
        }

        public static bool operator true (Option<T> value)
        {
            return value.IsSome;
        }

        public static bool operator false (Option<T> value)
        {
            return !value.IsSome;
        }

        public static bool operator ! (Option<T> value)
        {
            return !value.IsSome;
        }

        public static bool operator == (Option<T> left, Option<T> right)
        {
            return object.Equals(left, right);
        }

        public static bool operator != (Option<T> left, Option<T> right)
        {
            return !object.Equals(left, right);
        }

        public static Option<T> operator | (Option<T> left, Option<T> right)
        {
            if (left)
            {
                return left;
            }

            if (right)
            {
                return right;
            }

            return Option.None<T>();
        }

        public static implicit operator Option<T>(T value)
        {
            return Option.Some(value);
        }

        public static implicit operator T (Option<T> option)
        {
            return option.Value;
        }

        public static implicit operator bool (Option<T> value)
        {
            return value.IsSome;
        }
    }
}