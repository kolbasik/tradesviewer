namespace Monads.Tests
{
    using System;
    using System.Linq;

    using Xunit;

    public class OptionTests
    {
        [Fact]
        public void Some_Always_ReturnsSomeOption()
        {
            // arrange
            var expect = 42;

            // act
            var option = Option.Some(expect);

            // assert
            Assert.IsAssignableFrom<Option>(option);
            Assert.True(option.IsSome);

            var actual = option.Value;
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void None_Always_ReturnsNoneOption()
        {
            // act
            var option = Option.None<int>();

            // assert
            Assert.IsAssignableFrom<Option>(option);
            Assert.False(option.IsSome);
            Assert.ThrowsAny<Exception>(() => option.Value);
        }

        [Fact]
        public void Equals_SomeComparesToValue_ReturnsTrue()
        {
            // arrange
            var value = 1;
            var option = Option.Some(value);

            // act
            var actual = option.Equals(value);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void Equals_NoneComparesToValue_ReturnsTrue()
        {
            // arrange
            var value = 1;
            var option = Option.None<int>();

            // act
            var actual = option.Equals(value);

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void Cast_ImplicitBoolean_ReturnsIsSome()
        {
            // act
            var option = (bool)Option.Some(1);

            // assert
            Assert.True(option);
        }

        [Fact]
        public void Cast_ImplicitType_ReturnsValue()
        {
            // arrange
            var expect = 1;

            // act
            var actual = (int)Option.Some(expect);

            // assert
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Cast_ImplicitValue_ReturnsOption()
        {
            // arrange
            var expect = 1;

            // act
            var actual = (Option<int>)expect;

            // assert
            Assert.IsAssignableFrom<Option>(actual);
        }

        [Fact]
        public void Equals_ByReference_ComparesTheValues()
        {
            // arrange
            var one = Option.Some(1);
            var two = Option.Some(1);

            // act
            var actual = one == two;

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void Negative_Always_ReturnsInvertedIsSome()
        {
            // arrange
            var options = new Option<int>[] { Option.Some<int>(1), Option.None<int>() };
            var expected = options.Select(x => !x.IsSome).ToArray();

            // act
            var actual = options.Select(x => !x).ToArray();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Or_FirstIsSome_ReturnsFirst()
        {
            // arrange
            var one = Option.Some(1);
            var two = Option.Some(2);

            var expect = one;

            // act
            var actual = one | two;

            // assert
            Assert.Same(expect, actual);
        }

        [Fact]
        public void Or_SecondIsSome_ReturnsSecond()
        {
            // arrange
            var one = Option.None<int>();
            var two = Option.Some(2);

            var expect = two;

            // act
            var actual = one | two;

            // assert
            Assert.Same(expect, actual);
        }

        [Fact]
        public void Or_AllAreNone_ReturnsNone()
        {
            // arrange
            var one = Option.None<int>();
            var two = Option.None<int>();

            var expect = Option.None<int>();

            // act
            var actual = one | two;

            // assert
            Assert.Same(expect, actual);
        }
    }
}