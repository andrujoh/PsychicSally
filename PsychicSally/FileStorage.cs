using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicSally
{
  public class FileStorage : IHighScoreStorage
  {
    private string filename;
    string filePath = "highscore.dat";

    public FileStorage(string filename)
    {
      this.filename = filename;
    }

    public List<Scoring> Load()
    {
      string[] highScoresInFile = File.ReadAllLines(filePath);
      List<Scoring> scores = new List<Scoring>();
      for (int i = 0; i < highScoresInFile.Length; i++)
      {
        var scoring = Scoring.Parse(highScoresInFile[i]);
        scores.Add(new Scoring(scoring.Name, scoring.Score));
      }
      return scores;
    }

    public void Save(List<Scoring> scores)
    {
      string[] highScores = new string[scores.Count];
      for (int i = 0; i < scores.Count; i++)
      {
        highScores[i] = scores[i].ToString();
        File.WriteAllLines(filePath, highScores);
      }
    }
  }
}
