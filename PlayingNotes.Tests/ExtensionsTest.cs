using System;
using System.Numerics;
using Xunit;

namespace PlayingNotes.Tests {
  public class ExtensionsTest {
    [Fact]
    public void SafetyCastToIntFactTest1() {
      const int validResult = 30;
      BigInteger bigNumber = 30;
      var result = bigNumber.SafetyCastToInt();
      Assert.Equal(result, validResult);
    }

    [Theory]
    [InlineData(long.MaxValue)]
    [InlineData(long.MinValue)]
    public void IsNoteValidTheoryTest1(BigInteger value) {
      Assert.Throws<Exception>(()=>value.SafetyCastToInt());
    }
  }
}
