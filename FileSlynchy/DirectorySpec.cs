using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSlynchy
{
  public class DirectorySpec
  {
    public List<string> PathNameExcludes { get; set; }  //Excludes any directory with this name
    public List<string> PathRelativeExcludes { get; set; }  //Excludes this directory path from root

    public List<string> IncludedFileExtensions { get; set; }  //List of file extensions for comparison

    public List<string> FileNameExcludes { get; set; } //List of file names to exclude
    public List<string> FilePathExcludes { get; set; } //List of path.files to exclude (redundant?). Under files tab in form
    public List<string> DirFileExcludes { get; set; } //List of root relative path.files to exclude. Under file type and files in directory tab in form


    public DirectorySpec()
    {
      PathNameExcludes = new List<string>();
      PathRelativeExcludes = new List<string>();

      IncludedFileExtensions = new List<string>();

      FileNameExcludes = new List<string>();
      FilePathExcludes = new List<string>();
      DirFileExcludes = new List<string>();
    }

  }
}
