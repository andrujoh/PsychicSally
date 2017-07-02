using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicSally
{
  class Program
  {
    static void Main(string[] args)
    {
      var maxTries = 10;
      var random = new Random();
      var numberToGuess = random.Next(0, 100);
      var numberNotGuessed = true;

      for (var tries = 0; numberNotGuessed && tries < maxTries; tries++)
      {
        Console.Write("Skriv inn et tall mellom 1 og 100: ");
        var input = Console.ReadLine();
        int guessedNumber;
        if (int.TryParse(input, out guessedNumber))
        {
          if (guessedNumber > numberToGuess)
          {
            Console.WriteLine("Feil, du gjettet for høyt");
          }
          else if (guessedNumber < numberToGuess)
          {
            Console.WriteLine("Feil, du gjettet for lavt");
          }
          else
          {
            Console.WriteLine("Gratulerer, du gjettet riktig!");
            break;
          }

        }

        Console.WriteLine("Trykk en tast for å avslutte");
      }
    }
  }
}
