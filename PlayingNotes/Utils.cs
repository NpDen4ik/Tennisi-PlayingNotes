using System;
using System.Linq;
using Fractions;

namespace PlayingNotes {
  public static class Utils {
    public static Fraction ReadSize(string userInput) {
      var normalizeInput = userInput?.Trim();
      if (string.IsNullOrEmpty(normalizeInput) || !userInput.Contains('/')) {
        throw new Exception($"Invalid input: {userInput}");
      }

      var numbers = InputRowToNumbers(normalizeInput, "/");
      if (numbers.Length != 2) {
        throw new Exception($"Invalid input: {userInput}");
      }

      if (numbers[1] == 0 || numbers[0] == 0) {
        throw new Exception($"Invalid input zero: {userInput}");
      }

      return new Fraction(numbers[0], numbers[1]);
    }

    public static Fraction[] ReadNotes(string userInput) {
      var normalizeInput = userInput?.Trim();
      if (string.IsNullOrEmpty(normalizeInput)) {
        throw new Exception($"Invalid input: {userInput}");
      }

      var numbers = InputRowToNumbers(normalizeInput);
      if (numbers.Length < 1) {
        throw new Exception($"Invalid input: {userInput}");
      }

      return numbers
        .Select(x => {
          var note = new Fraction(1, x);
          if (!IsNoteValid(note)) {
            throw new Exception($"Invalid Note: {note}");
          }
          return note;
        })
        .ToArray();
    }

    public static bool IsNoteValid(Fraction note) {
      return note != 0
             && note.Numerator == 1
             && new[] { 1, 2, 4, 8, 16 }
               .Contains(note.Denominator.SafetyCastToInt());
    }

    private static int[] InputRowToNumbers(string input, string separator = " ") =>
      input.Split(separator)
        .Select(x => {
          if (!int.TryParse(x, out var value)) {
            throw new Exception($"Invalid number: {value}");
          }
          return value;
        }).ToArray();
  }
}
