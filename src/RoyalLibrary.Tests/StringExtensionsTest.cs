using ByteDecoder.RoyalLibrary;
using Xunit;

namespace RoyalLibrary.Tests
{
    public class StringExtensionsTest
    {
        [Fact]
        public void ToDouble_ReturnsValidDouble_WhenInputIsValid()
        {
            // Arrange
            // Act
            var result = "123.45".ToDouble();

            // Assert
            Assert.Equal(123.45, result);
        }

        [Fact]
        public void ToDouble_ReturnsNaN_WhenInputIsInvalid()
        {
            // Arrange
            // Act
            var result = "Dracul".ToDouble();

            // Assert
            Assert.Equal(double.NaN, result);
        }
    }
}