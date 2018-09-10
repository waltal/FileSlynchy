using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FileSlynchy
{
  public static class SlynchyProjectFiles
  {
    public static List<string> ProjectFiles { get; set; }

    public static void GetFiles()
    {
      string path = GetProjectFilesPath();
      //On my machine: C:\Users\Allen\OneDrive\Documents\FileSlynchy
      if (!Directory.Exists(path)) Directory.CreateDirectory(path);
      var ProjectFilesArr = Directory.GetFiles(path,"*.slynchy");
      for (int i = 0; i < ProjectFilesArr.Length; i++)
      {
        ProjectFilesArr[i] = ProjectFilesArr[i].Substring(path.Length + 1);
      }
      ProjectFiles = new List<string>(ProjectFilesArr);
    }

    public static bool DeleteProjectFile(string projectFileName)
    {
      var DidDelete = false;
      var pathFile = Path.Combine(GetProjectFilesPath(), projectFileName);

      if (File.Exists(pathFile))
      {
        File.Delete(pathFile);
        DidDelete = true;
      }
      return DidDelete;
    }

    public static string GetProjectFilesPath()
    {
      string RootPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "FileSlynchy");
      return RootPath;
    }

    public static void LoadProject(string projectFileName)
    {
      var pathFile = Path.Combine(GetProjectFilesPath(), projectFileName);
      if (File.Exists(pathFile))
      {
        var fileText = File.ReadAllText(pathFile);
        SlynchyTrack.Project = JsonConvert.DeserializeObject<SlynchyProject>(fileText);
        SlynchyTrack.ProjectFileName = projectFileName;
        SlynchyTrack.AnalysisList = new List<Analysis>();
      }
    }

    public static void SaveProject(SlynchyProject project, string projectFileName)
    {
      if (project != null)
      {
        var pathFile = Path.Combine(GetProjectFilesPath(), projectFileName);
        var fileText = JsonConvert.SerializeObject(project);
        File.WriteAllText(pathFile, fileText);
      }
    }
  }
}
