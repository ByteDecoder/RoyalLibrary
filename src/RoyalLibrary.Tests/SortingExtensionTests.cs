using ByteDecoder.RoyalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class SortingExtensionTests
  {
    [Fact]
    public async void SortByLastNameAsync_ThrowArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      IList<string> words = null;

      // Act
      // Assert
      await Assert.ThrowsAsync<ArgumentNullException>(() => words.SortByLastNameAsync());
    }

    [Fact]
    public async void SortByLastNameAsync_ReturnsSourceCOllections_WhenSourceSizeIsZero()
    {
      // Arrange
      IList<string> words = new List<string>();

      // Act
      var result = await words.SortByLastNameAsync();

      // Assert
      Assert.Same(words, result);
    }

    [Fact]
    public async void SortByLastNameAsync_ReturnsTheRightSortedList_WhenCorrectSourceIsProvided()
    {
      // Arrange
      var unSortedlist = new List<string>()
            {
                "Ai Bi Bu",
                "Ai Bi Az",
                "Na Za",
                "Xa Ma Co",
                "AA bb"
            };
      var expected = new List<string>()
            {
                "Ai Bi Az",
                "AA bb",
                "Ai Bi Bu",
                "Xa Ma Co",
                "Na Za",

            };

      // Act
      var actual = await unSortedlist.SortByLastNameAsync();

      // Assert
      Assert.True(expected[1] == actual.ElementAt(1));
    }
  }
}