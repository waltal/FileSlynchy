using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSlynchy
{
  public class SlynchyDirectory
  {
    public DirectorySpec Spec { get; set; }
    public string RootDirectory { get; set; }

    public DirectoryInfo Info { get; set; }

    public List<SlynchyDirectory> SubDirectoryInfoList { get; set; }

    public List<SlynchyFile> DirectoryFileInfoList { get; set; }

    public bool IsRoot { get; set; }

    public bool Exclude { get; set; }

    private char backslash = '\\';

    public SlynchyDirectory() {
      SubDirectoryInfoList = new List<SlynchyDirectory>();
      DirectoryFileInfoList = new List<SlynchyFile>();
    }

    public SlynchyDirectory(DirectorySpec spec, string rootDirectory, string directoryPath)
    {
      //This is the root directory Info, ParentDirectoryInfo is null
      Spec = spec;
      RootDirectory = rootDirectory;
      IsRoot = true;

      if (!String.IsNullOrEmpty(directoryPath))
      {
        Info = new DirectoryInfo(directoryPath);
        GetDirectoryFiles();

        //Start recursive directory and file object tree here
        GetSubDirectoryInfo();

        //Made sure subdirectories and files of excluded directories are excluded
        ExcludeFilesInExcludedDirs();
      }
    }

    public SlynchyDirectory(DirectorySpec spec, string rootDirectory, SlynchyDirectory parent, string path)
    {
      Spec = spec;
      RootDirectory = rootDirectory;
      IsRoot = false;

      Info = new DirectoryInfo(path);
      GetDirectoryFiles();

      //recursive directory and file object tree here
      GetSubDirectoryInfo();
    }

    public void GetSubDirectoryInfo()
    {
      SubDirectoryInfoList = new List<SlynchyDirectory>();
      var dirNames = Directory.EnumerateDirectories(Info.FullName);
      foreach (string dirName in dirNames)
      {
        string path = Path.Combine(Info.FullName, dirName);
        var slynchyDirectory = new SlynchyDirectory(Spec, RootDirectory, this, path);
        if (!IsSpecDirectory(Spec, path)) slynchyDirectory.Exclude = true;
        SubDirectoryInfoList.Add(slynchyDirectory);
      }
    }

    public void GetDirectoryFiles()
    {
      DirectoryFileInfoList = new List<SlynchyFile>();
      var fileNames = Directory.EnumerateFiles(Info.FullName);
      foreach (var filePath in fileNames)
      {
        var fileInfo = new SlynchyFile(filePath);
        if (!IsSpecFile(Spec, fileInfo)) fileInfo.Exclude = true;
        DirectoryFileInfoList.Add(fileInfo);
      }
    }

    public void RescanExclusions()
    {
      //The SetNoExclusions method should be called on the directory tree before this.
      //  The ExcludeFilesInExcludedDirs method should be called afterward to enforce exclusions down the tree
      //This is recursive and is called on the root directory of the tree
      foreach (var fileInfo in DirectoryFileInfoList)
      {
        if (!IsSpecFile(Spec, fileInfo)) fileInfo.Exclude = true;
      }
      if (!IsRoot)
      {
        if (!IsSpecDirectory(Spec, Info.FullName)) Exclude = true;
      }
      foreach (var dirInfo in SubDirectoryInfoList)
      {
        dirInfo.RescanExclusions();
      }
    }

    public string RelativeDirectory()
    {
      return Info.FullName.Substring(RootDirectory.Length);
    }

    public string RelativeDirectory(string dirPath)
    {
      return dirPath.Substring(RootDirectory.Length);
    }

    public string[] DirectoryParts(string dirPath)
    {
      return dirPath.Split(backslash);
    }

    public string LastDirectoryPart()
    {
      var parts = DirectoryParts(Info.Name);
      string LastPart = "";
      if (parts.Length > 0) LastPart = parts[parts.Length - 1];
      return LastPart;
    }

    public string LastDirectoryPart(string dirPath)
    {
      var parts = DirectoryParts(dirPath);
      string LastPart = "";
      if (parts.Length > 0) LastPart = parts[parts.Length - 1];
      return LastPart;
    }

    public bool IsSpecDirectory(DirectorySpec spec, string dirPath)
    {
      if (spec.PathNameExcludes.Count > 0)
      {
        var relDir = RelativeDirectory(dirPath);
        var dirnames = DirectoryParts(relDir);
        if (dirnames.Length > 0)
        {
          for (int i = 0; i < dirnames.Length; i++)
          {
            if (spec.PathNameExcludes.Contains("\\" + dirnames[i])) return false;
          }
        }
      }
      if (spec.PathRelativeExcludes.Count > 0)
      {
        var relDir = RelativeDirectory(dirPath);
        if (spec.PathRelativeExcludes.Contains(relDir)) return false;
      }
      return true;
    }

    public bool IsSpecFile(DirectorySpec spec, SlynchyFile info)
    {
      if (spec.IncludedFileExtensions.Count > 0)
      {
        if (spec.IncludedFileExtensions.Contains(info.Info.Extension)) return true;
        else return false;
      }
      
      if (spec.FileNameExcludes.Count > 0)
      {
        if (spec.FileNameExcludes.Contains(info.Info.Name)) return false;
      }
      if (spec.FilePathExcludes.Count > 0)
      {
        if (spec.FilePathExcludes.Contains(info.Info.FullName)) return false;
      }
      if (spec.DirFileExcludes.Count > 0)
      {
        var relDir = RelativeDirectory(info.Info.DirectoryName);
        var relPathFile = Path.Combine(relDir, info.Info.Name);
        if (spec.DirFileExcludes.Contains(relPathFile)) return false;
      }

      return true;
    }

    public void SetNoExclusions()
    {
      foreach (var fileInfo in DirectoryFileInfoList) fileInfo.Exclude = false;
      foreach (var dirInfo in SubDirectoryInfoList) dirInfo.SetNoExclusions();
      Exclude = false;
    }

    public void ExcludeFilesInExcludedDirs()
    {
      if (Exclude)
      {
        foreach (var fileInfo in DirectoryFileInfoList) fileInfo.Exclude = false;
        foreach (var dirInfo in SubDirectoryInfoList)
        {
          dirInfo.Exclude = true;
          dirInfo.ExcludeFilesInExcludedDirs();
        }
      } else
      {
        foreach (var dirInfo in SubDirectoryInfoList)
        {
          dirInfo.ExcludeFilesInExcludedDirs();
        }
      }
    }

    public DateTime GetLatestFileUpdate()
    {
      //TODO: Implement this

      //Get latest file update in this directory

      //Get latest file update in all subdirectories

      return DateTime.MinValue;
    }

    public int GetTotalFileSize()
    {
      //TODO: Implement this

      //Get total file size in this directory

      //Get total file size in all subdirectories

      return 0;
    }

  }
}
