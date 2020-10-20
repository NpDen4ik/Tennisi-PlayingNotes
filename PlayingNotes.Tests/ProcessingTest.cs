using Fractions;
using Xunit;

namespace PlayingNotes.Tests {
  public class ProcessingTest {
    private static readonly Processing Processing
      = new Processing();

    /**
     * Размер: 2/4
     * Ноты: 4 4 8 8 8 8 4 4
     * Вывод 4 4 | 8 8 8 8 | 4 4
     */
    [Fact]
    public void CalculationFactTest1() {
      const string validResult = "4 4 | 8 8 8 8 | 4 4";
      var size = Utils.ReadSize("2/4");
      var notes = Utils.ReadNotes("4 4 8 8 8 8 4 4");
      var result = Processing.Calculation(size, notes);
      Assert.Equal(result, validResult);
    }

    /**
     * Размер: 2/4
     * Ноты: 4 4 8 8 4 8 4 8
     * Вывод 4 4 | 8 8 4 | 8 4 8
     */
    [Fact]
    public void CalculationFactTest2() {
      const string validResult = "4 4 | 8 8 4 | 8 4 8";
      var size = new Fraction(2, 4);
      var notes = new[] {
        new Fraction(1, 4),
        new Fraction(1, 4),
        new Fraction(1, 8),
        new Fraction(1, 8),
        new Fraction(1, 4),
        new Fraction(1, 8),
        new Fraction(1, 4),
        new Fraction(1, 8),
      };
      var result = Processing.Calculation(size, notes);
      Assert.Equal(result, validResult);
    }

    /**
     * Размер: 2/4
     * Ноты: 8 4 8 8 8 8 4
     * Вывод 8 4 8 | <Ошибка>
     */
    [Fact]
    public void CalculationFactTest3() {
      const string validResult = "8 4 8 | <Ошибка>";
      var size = Utils.ReadSize("2/4");
      var notes = Utils.ReadNotes("8 4 8 8 8 8 4");
      var result = Processing.Calculation(size, notes);
      Assert.Equal(result, validResult);
    }
  }
}
