using System.Linq;
using Xunit;
using ByteDecoder.RoyalLibrary;
using System;

namespace RoyalLibrary.Tests
{
    public class PagingExtensionsTests
    {
        private readonly string[] _words = new string[]
        {
            "news",
            "wandering",
            "crack",
            "lunch",
            "fiction",
            "sweater",
            "stoop",
            "hideous",
            "awake",
            "grandmother"
        };

        [Fact]
        public void Page_ThrowsArgumentNullException_WhenSourceIsNull()
        {
            // Arrange
            IQueryable<string> words = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => words!.Page(1, 1));
        }

        [Fact]
        public void Page_ThrowsArgumentOutOfRangeException_WhenPageSizeIsZero()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _words.AsQueryable().Page(1, 0));
        }

        [Fact]
        public void Page_GetFiveWords_WhenParamsAreCorrect()
        {
            // Arrange
            // Act
            var result = _words.AsQueryable().Page(0, 5);

            // Assert
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Page_GetCorrectWords_WhenParamsAreCorrect()
        {
            // Arrange
            // Act
            var result = _words.AsQueryable().Page(1, 5);

            // Assert
            Assert.True(_words.Skip(5).All(word => result.Contains(word)));
        }

        [Fact]
        public void Page_ReturnsZeroRecords_WhenPageNumberExceedDataAvailable()
        {
            // Arrange
            // Act
            var result = _words.AsQueryable().Page(2, 5);

            // Assert
            Assert.Equal(0, result.Count());
        }
    }
}
