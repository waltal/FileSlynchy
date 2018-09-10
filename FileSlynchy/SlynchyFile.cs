using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSlynchy
{
  public class SlynchyFile
  {
    public FileInfo Info { get; set; } 
    public bool Exclude { get; set; }

    public SlynchyFile() { }

    public SlynchyFile(string pathFile) {
      Info = new FileInfo(pathFile);
      Exclude = false;
    }

  }
}
