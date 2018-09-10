using System;
using System.Collections.Generic;
using System.Text;

namespace FileSlynchy
{
  public class SlynchyProject
  {
    public List<Comparison> Comparisons { get; set; }
    public string Name { get; set; }

    public SlynchyProject(string name)
    {
      Name = name;
      Comparisons = new List<Comparison>();
    }

    public Comparison FindComparison(string comparisonName)
    {
      Comparison foundComparison = null;
      foreach (var item in Comparisons)
      {
        if (item.Name.Equals(comparisonName)) foundComparison = item;
      }
      return foundComparison;
    }

  }
}
