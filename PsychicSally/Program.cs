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
      // Change maxTries to how many tries you want
      var maxTries = 10;
      foreach (var argument in args)
      {
        var argumentParts = argument.Split('=');
        if (argument.ToLower().StartsWith("-maxTries"))
        {
          var argumentName = argumentParts[0];
          var argumentValue = argumentParts[1];
          maxTries = int.Parse(argumentValue);
        }
      }
      var random = new Random();
      var numberToGuess = random.Next(0, 100);
      var numberNotGuessed = true;

      for (var tries = 0; numberNotGuessed && tries < maxTries; tries++)
      {
        int guessedNumber = ReadNumber();

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

    private static int ReadNumber()
    {
      Console.Write("Skriv inn et tall mellom 1 og 100: ");
      var input = Console.ReadLine();
      int guessedNumber;

      if (int.TryParse(input, out guessedNumber))
      {
        return guessedNumber;
      }
      else
      {
        Console.WriteLine("Du må skrive inn et gyldig heltall");
        return ReadNumber();
      }

    }
  }
}
