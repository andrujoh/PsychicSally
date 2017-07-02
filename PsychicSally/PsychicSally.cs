using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicSally
{
  public class PsychicSally
  {
    public enum GuessResult
    {
      TooLow = -1,
      TooHigh = 1,
      Correct = 0
    }

    private static readonly Random random = new Random();

    private int numberToGuess;
    private int guesses;
    private DateTime startTime;
    private DateTime endTime;
    private bool guessedCorrectly;

    public int MaxTries { get; set; }
    public PsychicSally()
    {
      MaxTries = 10;
    }

    public void Start()
    {
      startTime = DateTime.Now;
      numberToGuess = random.Next(0, 100);
      guessedCorrectly = false;
      for (var tries = 0; tries < MaxTries; tries++)
      {
        MakeNewGuess();
        if (guessedCorrectly)
        {
          break;
        }
      }
    }

    public void MakeNewGuess()
    {
      guesses++;

      var result = Guess();
      HandleResult(result);
    }

    private int ReadNumber()
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

    public void HandleResult(GuessResult result)
    {
      switch (result)
      {
        case GuessResult.TooLow:
          Console.WriteLine("Feil, du gjettet for lavt");
          break;
        case GuessResult.TooHigh:
          Console.WriteLine("Feil, du gjettet for høyt");
          break;
        case GuessResult.Correct:
          guessedCorrectly = true;
          Stop();
          HandleCorrectGuess();
          break;
      }
    }

    private void HandleCorrectGuess()
    {
      var totalTime = endTime.Subtract(startTime).TotalSeconds;
      Console.WriteLine($"Gratulerer, du gjettet riktig på {guesses} forsøk og brukte {totalTime} sekunder!");
    }

    private void Stop()
    {
      endTime = DateTime.Now;
    }

    public GuessResult Guess()
    {
      int guessedNumber = ReadNumber();
      int guessResult = guessedNumber.CompareTo(numberToGuess);

      var result = (GuessResult)guessResult;

      return result;
    }
  }
}
