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
    private int max = 100;
    private DateTime startTime;
    private DateTime endTime;
    private bool guessedCorrectly;
    private HighScore highScore;

    public int MaxTries { get; set; }

    public PsychicSally()
    {
      //var storage = new InMemoryStorage();
      var storage = new FileStorage("highscore.dat");
      MaxTries = 10;
      highScore = new HighScore(storage);
    }

    public void Start()
    {
      startTime = DateTime.Now;
      numberToGuess = random.Next(0, max);
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
      var score = GetScore();
      Console.WriteLine($"Gratulerer, du gjettet riktig på {score.Guesses} forsøk og brukte {score.TotalTime} sekunder!");

      if (highScore.IsScoreHighEnough(score))
      {
        Console.Write("Skriv inn navnet ditt for å legges til i hall of fame: ");
        string playerName = Console.ReadLine();
        highScore.AddScore(playerName, score);
        highScore.Print();
      }
      
    }

    private Score GetScore()
    {
      TimeSpan duration = endTime - startTime;
      var score = new Score(guesses, duration.TotalSeconds);
      return score;
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
