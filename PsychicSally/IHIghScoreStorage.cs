﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychicSally
{
  public interface IHighScoreStorage
  {
    void Save(List<Scoring> scores);
    List<Scoring> Load();
  }
}
