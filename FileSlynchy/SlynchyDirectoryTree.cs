using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSlynchy
{
  public class SlynchyDirectoryTree
  {
    public DirectorySpec Spec { get; set; }
    public string Name { get; set; }
    public string RootDirectoryPath { get; set; }

    public SlynchyDirectory RootSlynchyDirectory { get; set; }

    public SlynchyDirectoryTree() { }

    public SlynchyDirectoryTree(string name, string rootPath)
    {
      Spec = new DirectorySpec();
      Name = name;
      RootDirectoryPath = rootPath;
      if (!String.IsNullOrEmpty(RootDirectoryPath))ScanTree();
    }

    public void ScanTree()
    {
      //This scans files and directories, includes them in tree
      RootSlynchyDirectory = new SlynchyDirectory(Spec, RootDirectoryPath, RootDirectoryPath);
      RootSlynchyDirectory.ExcludeFilesInExcludedDirs();
    }

    public void ReScanExclusions()
    {
      //This refreshes exclusion flags in nodes of the tree by the spec, no nodes deleted
      RootSlynchyDirectory.SetNoExclusions();
      RootSlynchyDirectory.RescanExclusions();
      RootSlynchyDirectory.ExcludeFilesInExcludedDirs();
    }

    public bool RelDirectoryExists(string relDirPath)
    {
      var DirNames = Utility.DirectoryParts(relDirPath);
      int index = 1;
      var result = SubDirectoryExists(RootSlynchyDirectory, DirNames, index);
      return result;
    }

    public bool SubDirectoryExists(SlynchyDirectory node, string[] dirNames, int index)
    {
      if (index > dirNames.Length - 1) return true;
      foreach (var dirInfo in node.SubDirectoryInfoList)
      {
        var LastDirectoryPart = dirInfo.LastDirectoryPart();
        var dirLevelName = dirNames[index];
        if (LastDirectoryPart.Equals(dirLevelName)
          && !dirInfo.Exclude)
          return SubDirectoryExists(dirInfo, dirNames, index + 1);
      }
      return false;
    }

    public SlynchyDirectory GetDirectoryNode(string relDirPath)
    {
      var DirNode = new SlynchyDirectory();

      if (RelDirectoryExists(relDirPath))
      {
        var DirNames = Utility.DirectoryParts(relDirPath);
        int index = 1;
        DirNode = GetSubDirectoryNode(RootSlynchyDirectory, DirNames, index);
      }

      return DirNode;
    }

    public SlynchyDirectory GetSubDirectoryNode(SlynchyDirectory node, string[] dirNames, int index)
    {
      if (index > dirNames.Length - 1) return node;
      foreach (var dirInfo in node.SubDirectoryInfoList)
      {
        var LastDirectoryPart = dirInfo.LastDirectoryPart();
        var dirLevelName = dirNames[index];
        if (LastDirectoryPart.Equals(dirLevelName)
          && !dirInfo.Exclude)
          return GetSubDirectoryNode(dirInfo, dirNames, index + 1);
      }
      return null;
    }

    public string GetFilePathName(string relDir, string fileName)
    {
      var node = GetDirectoryNode(relDir);
      var nodePath = RootDirectoryPath + node.RelativeDirectory();
      return Path.Combine(nodePath, fileName);
    }

    public SlynchyFile GetFileInfo(string relDir, string fileName)
    {
      var node = GetDirectoryNode(relDir);
      var fileInfo = new SlynchyFile();
      foreach (var fInfo in node.DirectoryFileInfoList)
      {
        if (fInfo.Info.Name.Equals(fileName)) fileInfo = fInfo;
      }
      return fileInfo;
    }

    public void CopyNodeTree(SlynchyDirectory sNode, string destCopyPath)
    {
      //Copy files
      var fullSourcePath = sNode.RootDirectory + sNode.RelativeDirectory();
      foreach (var info in sNode.DirectoryFileInfoList)
      {
        if (!info.Exclude)
        {
          var sourceFilePath = Path.Combine(fullSourcePath, info.Info.Name);
          var destFilePath = Path.Combine(destCopyPath, info.Info.Name);
          if (!File.Exists(destFilePath)) File.Copy(sourceFilePath, destFilePath);
        }
      }

      //Make subdirectories and call CopyNodeTree on those nodes
      foreach (var dir in sNode.SubDirectoryInfoList)
      {
        if (!dir.Exclude)
        {
          var subDirPath = destCopyPath + dir.Info.Name;
          Directory.CreateDirectory(subDirPath);
          CopyNodeTree(dir, subDirPath);
        }
      }
    }

    public void CopyToTreeControl(TreeView tv, bool fullTree)
    {
      FileTreeNode aNode = new FileTreeNode(false, RootDirectoryPath, 0, 1);
      tv.Nodes.Add(aNode);

      PopulateFiles(aNode, RootSlynchyDirectory, fullTree);

      PopulateSubDirs(aNode, RootSlynchyDirectory, fullTree);
      tv.Nodes[0].ExpandAll();
    }

    public void CopyToTreeControl(TreeView tv, 
      Label treeName, Label dirCount, Label fileCount, bool fullTree)
    {
      treeName.Text = Name;
      int CountDir = 1;
      int CountFiles = 0;

      FileTreeNode aNode = new FileTreeNode(false, RootDirectoryPath, 0, 1);
      tv.Nodes.Add(aNode);

      PopulateFiles(aNode, RootSlynchyDirectory, fileCount, ref CountFiles, fullTree);

      PopulateSubDirs(aNode, RootSlynchyDirectory, dirCount, ref CountDir,
        fileCount, ref CountFiles, fullTree);
      tv.Nodes[0].ExpandAll();
    }

    private void PopulateSubDirs(FileTreeNode aNode, 
      SlynchyDirectory sDir, Label dirCountDisplay, ref int dirCount,
      Label fileCountDisplay, ref int fileCount, bool fullTree)
    {
      foreach (var subDir in sDir.SubDirectoryInfoList)
      {
        if (!subDir.Exclude)
        {
          var SubDirName = "\\" + subDir.LastDirectoryPart(subDir.Info.Name);
          FileTreeNode ChildNode = new FileTreeNode(false, SubDirName, 0, 1);
          aNode.Nodes.Add(ChildNode);
          dirCount++;
          dirCountDisplay.Text = dirCount.ToString() + " Directories";

          PopulateFiles(ChildNode, subDir, fileCountDisplay, ref fileCount, fullTree);

          Application.DoEvents();
          PopulateSubDirs(ChildNode, subDir, dirCountDisplay, ref dirCount,
            fileCountDisplay, ref fileCount, fullTree);
        }
      }
      Application.DoEvents();
    }

    private void PopulateSubDirs(FileTreeNode aNode, SlynchyDirectory sDir, bool fullTree)
    {
      foreach (var subDir in sDir.SubDirectoryInfoList)
      {
        if (!subDir.Exclude)
        {
          var SubDirName = "\\" + subDir.LastDirectoryPart(subDir.Info.Name);
          FileTreeNode ChildNode = new FileTreeNode(false, SubDirName, 0, 1);
          aNode.Nodes.Add(ChildNode);

          PopulateFiles(ChildNode, subDir, fullTree);

          Application.DoEvents();
          PopulateSubDirs(ChildNode, subDir, fullTree);
        }
      }
      Application.DoEvents();
    }

    private void PopulateFiles(FileTreeNode aNode, 
      SlynchyDirectory sDir, Label countDisplay, ref int count, bool fullTree)
    {
      count += sDir.DirectoryFileInfoList.Count;
      countDisplay.Text = count.ToString() + " Files";
      foreach (var fileInfo in sDir.DirectoryFileInfoList)
      {
        if (fullTree)
        {
          var FileName = fileInfo.Info.Name;
          aNode.Nodes.Add(new FileTreeNode(true, FileName, fileInfo.Info, 2));
        }
        else
        {
          if (!fileInfo.Exclude)
          {
            var FileName = fileInfo.Info.Name;
            aNode.Nodes.Add(new FileTreeNode(true, FileName, fileInfo.Info, 2));
          }
        }
      }
      Application.DoEvents();
    }

    private void PopulateFiles(FileTreeNode aNode, SlynchyDirectory sDir, bool fullTree)
    {
      foreach (var fileInfo in sDir.DirectoryFileInfoList)
      {
        var FileName = fileInfo.Info.Name;
        if (fullTree)
        {
          aNode.Nodes.Add(new FileTreeNode(true, FileName, fileInfo.Info, 2));
        }
        else
        {
          if (!fileInfo.Exclude) aNode.Nodes.Add(new FileTreeNode(true, FileName, fileInfo.Info, 2));
        }
      }
      Application.DoEvents();
    }

  }
}
