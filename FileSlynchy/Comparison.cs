using System;
using System.Collections.Generic;
using System.Text;

namespace FileSlynchy
{
  public class Comparison
  {
    public string Name { get; set; }

    public List<SlynchyDirectoryTree> Directories { get; set; }

    public string MasterDirName { get; set; }
    public string LastestUpdateDirectoryName { get; set; }

    public bool IsVisualStudioProject { get; set; }  //May be used later for special processing

    public Comparison()
    {
      Directories = new List<SlynchyDirectoryTree>();
      IsVisualStudioProject = false;
    }

    public SlynchyDirectoryTree AddTree(string name, string path)
    {
      //TODO: check why this is not used
      var newTree = new SlynchyDirectoryTree(name, path);
      Directories.Add(newTree);
      return newTree;
    }

    public SlynchyDirectoryTree FindTree(string name)
    {
      SlynchyDirectoryTree foundTree = null;
      foreach(var tree in Directories)
      {
        if (tree.Name.Equals(name)) foundTree = tree;
      }
      return foundTree;
    }

    public void Rescan()
    {
      foreach (var tree in Directories)
      {
        tree.ScanTree();
      }
    }

    public SlynchyDirectoryTree RescanTree(string name)
    {
      //TODO: check why this is not used
      SlynchyDirectoryTree currentTree = null;
      string path = "";
      SlynchyDirectoryTree rescanTree = null;
      foreach (var tree in Directories)
      {
        if (tree.Name.Equals(name))
        {
          currentTree = tree;
          path = tree.RootDirectoryPath;
        }
      }
      if (currentTree != null)
      {
        currentTree.ScanTree();
      }

      return rescanTree;
    }

    public bool RemoveTree(string name)
    {
      //TOSO: check why this is not used
      //returns true if tree found
      var IsFound = false;
      SlynchyDirectoryTree foundTree = null;

      foreach (var tree in Directories)
      {
        if (tree.Name.Equals(name))
        {
          foundTree = tree;
          IsFound = true;
        }
      }
      if (IsFound) Directories.Remove(foundTree);
      return IsFound;
    }

  }
}
