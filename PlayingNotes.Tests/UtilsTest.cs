using System;
using Fractions;
using Xunit;

namespace PlayingNotes.Tests {
  public class UtilsTest {

    [Fact]
    public void IsNoteValidFactTest1() {
      var result = Utils.IsNoteValid(new Fraction(1, 4));
      Assert.True(result);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 0)]
    [InlineData(2, 3)]
    [InlineData(1, 3)]
    [InlineData(1, 30)]
    public void IsNoteValidTheoryTest1(int numerator, int denominator) {
      var result = Utils.IsNoteValid(new Fraction(numerator, denominator));
      Assert.False(result);
    }


    [Fact]
    public void ReadSizeFactTest1() {
      var result = Utils.ReadSize("3/4");
      Assert.Equal(result,new Fraction(3,4));
    }

    [Fact]
    public void ReadSizeFactTest2() {
      var result = Utils.ReadSize("6/6");
      Assert.Equal(result,new Fraction(1,1));
    }

    [Theory]
    [InlineData("0")]
    [InlineData("fsd")]
    [InlineData("0/0")]
    [InlineData("1/0")]
    [InlineData("0/2")]
    [InlineData(null)]
    [InlineData("")]
    public void ReadSizeTheory1(string value) {
      Assert.Throws<Exception>(()=>Utils.ReadSize(value));
    }

    [Fact]
    public void ReadNotesFactTest1() {
      var result = Utils.ReadNotes("2 4 8");
      var validResult = new[] {
        new Fraction(1, 2),
        new Fraction(1, 4),
        new Fraction(1, 8),
      };
      Assert.Equal(result,validResult);
    }

    [Fact]
    public void ReadNotesFactTest2() {
      var result = Utils.ReadNotes(" 1 2 8 ");
      var validResult = new[] {
        new Fraction(1, 1),
        new Fraction(1, 2),
        new Fraction(1, 8),
      };
      Assert.Equal(result,validResult);
    }

    [Theory]
    [InlineData("1 2 3")]
    [InlineData("adsada")]
    [InlineData(null)]
    [InlineData("")]
    public void ReadNotesTheory1(string value) {
      Assert.Throws<Exception>(()=>Utils.ReadNotes(value));
    }

  }
}
