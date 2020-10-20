using System;
using System.Numerics;

namespace PlayingNotes {
  public static class Extensions {
    public static int SafetyCastToInt(this BigInteger value) {
      if (value > int.MaxValue || value < int.MinValue) {
        throw new Exception("Invalid cast to int");
      }
      return (int) value;
    }
  }
}
