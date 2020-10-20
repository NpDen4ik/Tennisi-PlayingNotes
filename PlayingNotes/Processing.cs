using System;
using Fractions;

namespace PlayingNotes {
  public class Processing {
    public static void Start() {
      var size = Utils.ReadSize(Console.ReadLine());
      var notes = Utils.ReadNotes(Console.ReadLine());
      var calculation = Calculation(size, notes);
      Console.WriteLine(calculation);
    }

    public static string Calculation(Fraction size, Fraction[] notes) {
      if (size == 0) {
        throw new Exception("Invalid size is zero");
      }

      var result = "";
      var element = notes[0];
      CheckNote(element);

      var tact = $"{element.Denominator}";
      var temp = element;

      for (var i = 1; i < notes.Length; i++) {
        var currentNote = notes[i];
        CheckNote(currentNote);

        temp = temp.Add(currentNote);

        if (temp > size) {
          result += " <Ошибка>";
          return result;
        }

        tact += $" {currentNote.Denominator}";

        if (temp != size) {
          continue;
        }

        var separator = i != notes.Length - 1
          ? " |"
          : string.Empty;

        result += $"{tact}{separator}";
        if (notes.Length - 1 <= i + 1) {
          continue;
        }

        element = notes[i + 1];
        temp = element;
        tact = $" {element.Denominator}";
        i += 1;
      }

      return result;
    }

    private static void CheckNote(Fraction note) {
      if (!Utils.IsNoteValid(note)) {
        throw new Exception("Note is Invalid");
      }
    }
  }
}
