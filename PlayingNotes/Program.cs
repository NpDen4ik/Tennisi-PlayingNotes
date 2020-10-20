using System;

namespace PlayingNotes {
  class Program {
    public static void Main(string[] args) {
      var game = new Processing();
      try {
        Processing.Start();
      } catch (Exception e) {
        Console.WriteLine(e);
        throw;
      }
    }
  }
}
