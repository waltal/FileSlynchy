using System;
using System.Collections.Generic;
using System.Text;

namespace FileSlynchy
{
  public static class SlynchyTrack
  {
    public static SlynchyProject Project { get; set; }
    public static string ProjectFileName { get; set; }

    public static List<Analysis> AnalysisList { get; set; }
  }
}
