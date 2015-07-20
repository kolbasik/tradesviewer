namespace Monads.Tests
{
    using System;
    using System.Globalization;

    using Xunit;

    public class SomeOptionTests
    {
        [Fact]
        public void SomeOption_Always_IsAssignableFromOption()
        {
            // act
            var actual = SomeOption<object>.Return(null);

            // assert
            Assert.IsAssignableFrom<Option>(actual);
        }

        [Theory]
        [InlineData(42)]
        [InlineData("TEST_VALUE")]
        [InlineData(false)]
        public void Return_Always_ReturnsSomeOption(object value)
        {
            // act
            var actual = SomeOption<object>.Return(value);

            // assert
            Assert.IsAssignableFrom<SomeOption<object>>(actual);
        }

        [Theory]
        [InlineData(42)]
        [InlineData("TEST_VALUE")]
        [InlineData(false)]
        public void IsSome_Always_ReturnsTrue(object value)
        {
            // arrange
            var sut = SomeOption<object>.Return(value);

            // act
            var actual = sut.IsSome;

            // assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData(42)]
        [InlineData("TEST_VALUE")]
        [InlineData(false)]
        public void Value_Always_ReturnsValue(object value)
        {
            // arrange
            var expected = value;
            var sut = SomeOption<object>.Return(value);

            // act
            var actual = sut.Value;

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(42)]
        [InlineData("TEST_VALUE")]
        [InlineData(false)]
        public void Equals_ComparesToSameOption_ReturnsTrue(object value)
        {
            // arrange
            var sut = SomeOption<object>.Return(value);

            // act
            var actual = sut.Equals(SomeOption<object>.Return(value));

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void Equals_Compares42To53_ReturnsFalse()
        {
            // arrange
            var one = SomeOption<int>.Return(42);
            var two = SomeOption<int>.Return(53);

            // act
            var actual = one.Equals(two);

            // assert
            Assert.False(actual);
        }

        [Theory]
        [InlineData(42)]
        [InlineData("TEST_VALUE")]
        [InlineData(false)]
        public void ToString_Always_ContainsTheValue(object value)
        {
            // arrange
            var expected = Convert.ToString(value, CultureInfo.InvariantCulture);
            var sut = SomeOption<object>.Return(value);

            // act
            var actual = sut.ToString();

            // assert
            Assert.Contains(expected, actual);
        }

        [Theory]
        [InlineData(42)]
        [InlineData("TEST_VALUE")]
        [InlineData(false)]
        public void GetHashCode_Always_EqualsToHashCodeOfValue(object value)
        {
            // arrange
            var sut = SomeOption<object>.Return(value);
            var expected = value.GetHashCode();

            // act
            var actual = sut.GetHashCode();

            // assert
            Assert.Equal(expected, actual);
        }
    }
}