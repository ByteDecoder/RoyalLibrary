using ByteDecoder.RoyalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class SortingExtensionTests
  {
    // Arrange
    private readonly List<string> _unsortedInputList = new List<string>()
      {
          "Ai Bi Bu",
          "Ai Bi Az",
          "Na Za",
          "Xa Ma Co",
          "AA bb"
      };
    private readonly List<string> _expectedOutputList = new List<string>()
      {
          "Ai Bi Az",
          "AA bb",
          "Ai Bi Bu",
          "Xa Ma Co",
          "Na Za",
      };

    [Fact]
    public async void SortByLastNameAsync_ThrowArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      // Act
      // Assert
      await Assert.ThrowsAsync<ArgumentNullException>(() => ((IList<string>) null).SortByLastNameAsync());
    }

    [Fact]
    public async void SortByLastNameAsync_ReturnsSourceCollections_WhenSourceSizeIsZero()
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
      // Act
      var actual = await _unsortedInputList.SortByLastNameAsync();

      // Assert
      Assert.True(_expectedOutputList[1] == actual.ElementAt(1));
    }

    [Fact]
    public async void SortByLastNameAsyncWithAction_ReturnsTheRightSortedList_WhenCorrectSourceIsProvided()
    {
      // Arrange
      var count = 0;

      // Act
      var actual = await _unsortedInputList.SortByLastNameAsync(_ => count++);

      // Assert
      Assert.True(_expectedOutputList[1] == actual.ElementAt(1));
      Assert.Equal(5, count);
    }
  }
}