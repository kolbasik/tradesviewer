namespace Monads.Tests
{
    using System;

    using Xunit;

    public class NoneOptionTests
    {
        [Fact]
        public void NoneOption_Always_IsAssignableFromOption()
        {
            // act
            var actual = NoneOption<object>.Return();

            // assert
            Assert.IsAssignableFrom<Option>(actual);
        }

        [Fact]
        public void Return_Always_ReturnsNoneOption()
        {
            // act
            var actual = NoneOption<object>.Return();

            // assert
            Assert.IsAssignableFrom<NoneOption<object>>(actual);
        }

        [Fact]
        public void Return_Always_ReturnsTheSameOption()
        {
            // arrange
            var one = NoneOption<object>.Return();
            var two = NoneOption<object>.Return();

            // act && assert
            Assert.Same(one, two);
        }

        [Fact]
        public void IsSome_Always_ReturnsFalse()
        {
            // arrange
            var sut = NoneOption<object>.Return();

            // act
            var actual = sut.IsSome;

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void Value_Always_RaisesNullReferenceException()
        {
            // arrange
            var sut = NoneOption<object>.Return();

            // act && assert
            Assert.Throws<NullReferenceException>(() => sut.Value);
        }

        [Theory]
        [InlineData(42)]
        [InlineData("TEST_VALUE")]
        [InlineData(false)]
        public void Equals_ComparesToSomeOption_ReturnsFalse(object value)
        {
            // arrange
            var sut = NoneOption<object>.Return();

            // act
            var actual = sut.Equals(SomeOption<object>.Return(value));

            // assert
            Assert.False(actual);
        }

        [Fact]
        public void ToString_Always_ReturnsNone()
        {
            // arrange
            var sut = NoneOption<object>.Return();
            var expected = "None";

            // act
            var actual = sut.ToString();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetHashCode_Always_EqualsTo1()
        {
            // arrange
            var sut = NoneOption<object>.Return();
            var expected = 0;

            // act
            var actual = sut.GetHashCode();

            // assert
            Assert.Equal(expected, actual);
        }
    }
}