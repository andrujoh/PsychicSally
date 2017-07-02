using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicSally
{
  public class InMemoryStorage : IHighScoreStorage
  {
    private static List<Scoring> Scorings = new List<Scoring>();
    public List<Scoring> Load()
    {
      return new List<Scoring>();
    }

    public void Save(List<Scoring> scores)
    {
      
    }
  }
}
