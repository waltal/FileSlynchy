using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSlynchy
{
  public class Analysis
  {
    public Comparison Comp { get; set; }

    public List<UncommonDirectory> UDirs { get; set; }
    public DirDateRank DirsByDate { get; set; }

    public List<UncommonFile> UFiles { get; set; }

    public List<DifferentFiles> DFiles { get; set; }

    public bool IsSynced { get; set; }

    public Analysis()
    {
      Clear();
    }

    public Analysis(Comparison comparison)
    {
      Comp = comparison;

      Clear();
    }

    public void Clear()
    {
      UDirs = new List<UncommonDirectory>();
      UFiles = new List<UncommonFile>();
      DFiles = new List<DifferentFiles>();
    }

    public void DoAnalysis()
    {
      if (Comp.Directories.Count < 2) return;

      foreach (var dir in Comp.Directories)
      {
        dir.ScanTree();
      }

      GetDirFileScan();

      IsSynced = (UDirs.Count == 0) && (UFiles.Count == 0) && (DFiles.Count == 0);
    }

    public void GetDirFileScan()
    {
      //Directories that don't appear in all trees
      foreach (var PickedTree in Comp.Directories)
      {
        var OtherTrees = OtherDirTrees(PickedTree);
        GetUncommonSubDirs(PickedTree.RootSlynchyDirectory, OtherTrees);
        GetUncommonUnmatchedFiles(PickedTree.RootSlynchyDirectory, OtherTrees);
      }
      SetCommonDirectories();
      SetCommonFiles();
    }

    public List<SlynchyDirectoryTree> OtherDirTrees(SlynchyDirectoryTree treePicked)
    {
      var OtherTrees = new List<SlynchyDirectoryTree>();
      foreach(var tree in Comp.Directories)
      {
        if (tree != treePicked) OtherTrees.Add(tree);
      }
      return OtherTrees;
    }

    public void GetUncommonSubDirs(SlynchyDirectory node, List<SlynchyDirectoryTree> otherTrees)
    {
      foreach (var snode in node.SubDirectoryInfoList)
      {
        if (!snode.Exclude)
        {
          var DirName = snode.RelativeDirectory();
          var IsUnCommon = false;
          foreach (var tree in otherTrees)
          {
            if (!tree.RelDirectoryExists(DirName)) IsUnCommon = true;
          }
          if (IsUnCommon)
          {
            //Make sure directory isn't already in list
            if (!IsInUncommonDirList(DirName))
            {
              //If not in list, add
              var uDir = new UncommonDirectory();
              uDir.RelDir = DirName;
              UDirs.Add(uDir);
              foreach (var tree in otherTrees)
              {
                if (tree.RelDirectoryExists(DirName)) uDir.InTrees.Add(tree);
                else uDir.NotInTrees.Add(tree);
              }
            }
          }
          GetUncommonSubDirs(snode, otherTrees);
        }
      }

      //Get the uncommon and unmatched files
      GetUncommonUnmatchedFiles(node, otherTrees);
    }

    public bool IsInUncommonDirList(string relDir)
    {
      bool result = false;
      foreach (var uDir in UDirs)
      {
        if (uDir.RelDir.Equals(relDir)) result = true;
      }
      return result;
    }

    public void GetDateRankedDirs()
    {
      //List of directories with the same path, sorted by date
    }

    public void GetUncommonUnmatchedFiles(SlynchyDirectory node, List<SlynchyDirectoryTree> otherTrees)
    {
      //Files that don't appear in all trees (in the same relative directory)
      //Files that are not the same in trees they appear (in the same relative directory)
      //  This is integrated with the directory tree scan, it just compares the files
      //  in a directory node of a tree with the same relative path node of different
      //  trees.  The directory scans drive the round-robin comparison.
      var DirName = node.RelativeDirectory();
      var BaseFiles = node.DirectoryFileInfoList;
      foreach (var tree in otherTrees)
      {
        var BaseNode = node;
        var CompNode = tree.RootSlynchyDirectory;

        if (!node.IsRoot)
        {
          CompNode = tree.GetDirectoryNode(DirName);
          if (CompNode != null && CompNode.Spec != null)
          {
            foreach (var fileInfo in BaseNode.DirectoryFileInfoList)
            {
              if (!fileInfo.Exclude)
              {
                var FileName = fileInfo.Info.Name;
                if (!FileNameInFileList(CompNode, fileInfo))
                {
                  //add to uncommon list
                  SetUncommonFile(DirName, FileName, tree);
                } 
              }
            }
          }
        } 
      }
    }

    public bool FileNameInFileList(SlynchyDirectory node, SlynchyFile fileInfo)
    {
      var result = false;
      var FileName = fileInfo.Info.Name;

      foreach (var compInfo in node.DirectoryFileInfoList)
      {
        if (!compInfo.Exclude)
        {
          if (compInfo.Info.Name.Equals(FileName)) {
            result = true;

            //Is it different?
            if (compInfo.Info.Length != fileInfo.Info.Length)
            {
              var rootDirPath = node.RootDirectory;
              var Tree = GetRootDirectoryTree(rootDirPath);
              var relDir = node.RelativeDirectory();
              AddDifferentFile(relDir, Tree, compInfo);
            }
          } 
        }
      }

      return result;
    }

    //tree is the directory tree without the file
    public void SetUncommonFile(string relDir, string fileName, SlynchyDirectoryTree tree)
    {
      var FoundFile = false;
      foreach (var UFile in UFiles)
      {
        if (UFile.RelDir.Equals(relDir) && UFile.FileName.Equals(fileName))
        {
          FoundFile = true;
          if (!UFile.NotInTrees.Contains(tree)) UFile.NotInTrees.Add(tree);
        }
      }
      if (!FoundFile)
      {
        var UFile = new UncommonFile();
        UFile.RelDir = relDir;
        UFile.FileName = fileName;
        UFiles.Add(UFile);
        UFile.NotInTrees.Add(tree);
      }
    }

    //A final touch up method to set the InTrees list for uncommon files
    public void SetCommonFiles()
    {
      foreach (var UFile in UFiles)
      {
        if (UFile.InTrees == null) UFile.InTrees = new List<SlynchyDirectoryTree>();
        foreach (var tree in Comp.Directories)
        {
          var IsInNotTree = false;
          foreach (var notInTree in UFile.NotInTrees)
          {
            if (tree.RootDirectoryPath.Equals(notInTree.RootDirectoryPath)) IsInNotTree = true;
          }
          if (!IsInNotTree) UFile.InTrees.Add(tree);
        }
      }
    }

    //A final touch up method to set the InTrees list for uncommon directories
    public void SetCommonDirectories()
    {
      foreach (var UDir in UDirs)
      {
        if (UDir.InTrees == null) UDir.InTrees = new List<SlynchyDirectoryTree>();
        foreach (var tree in Comp.Directories)
        {
          var IsInNotTree = false;
          foreach (var notInTree in UDir.NotInTrees)
          {
            if (tree.RootDirectoryPath.Equals(notInTree.RootDirectoryPath)) IsInNotTree = true;
          }
          if (!IsInNotTree)
          {
            if (!UDir.InTrees.Contains(tree)) UDir.InTrees.Add(tree);
          }
        }
      }
    }

    public SlynchyDirectoryTree GetRootDirectoryTree(string rootDirPath)
    {
      var FoundTree = new SlynchyDirectoryTree();

      foreach(var tree in Comp.Directories)
      {
        if (tree.RootDirectoryPath.Equals(rootDirPath)) FoundTree = tree;
      }

      return FoundTree;
    }

    //tree is the tree for the comparison file, with data "info"
    public void AddDifferentFile(string relDirectoryPath, SlynchyDirectoryTree tree, SlynchyFile info)
    {
      var FoundRelDir = false;
      foreach (var dFile in DFiles)
      {
        if (dFile.RelDir.Equals(relDirectoryPath) && dFile.FileName.Equals(info.Info.Name))
        {
          FoundRelDir = true;
          dFile.AddDifferentFileSpec(tree, info);
        }
      }
      if (!FoundRelDir)
      {
        var newDiffFiles = new DifferentFiles();
        newDiffFiles.RelDir = relDirectoryPath;
        newDiffFiles.FileName = info.Info.Name;
        newDiffFiles.AddDifferentFileSpec(tree, info);
        DFiles.Add(newDiffFiles);
      }
    }

  }

  public class UncommonDirectory
  {
    public string RelDir { get; set; }
    public List<SlynchyDirectoryTree> InTrees { get; set; }
    public List<SlynchyDirectoryTree> NotInTrees { get; set; }

    public UncommonDirectory()
    {
      InTrees = new List<SlynchyDirectoryTree>();
      NotInTrees = new List<SlynchyDirectoryTree>();
    }
  }

  public class DirDateRank
  {
    public List<SlynchyDirectory> DirsByDate { get; set; }
  }

  public class UncommonFile
  {
    public string RelDir { get; set; }
    public string FileName { get; set; }

    public List<SlynchyDirectoryTree> InTrees { get; set; }
    public List<SlynchyDirectoryTree> NotInTrees { get; set; }

    public UncommonFile()
    {
      InTrees = new List<SlynchyDirectoryTree>();
      NotInTrees = new List<SlynchyDirectoryTree>();
    }
  }

  public class DifferentFiles
  {
    public string RelDir { get; set; }
    public string FileName { get; set; }

    public List<FileSpecs> Specs { get; set; }

    public DifferentFiles()
    {
      Specs = new List<FileSpecs>();
    }

    public void AddDifferentFileSpec(SlynchyDirectoryTree tree, SlynchyFile info)
    {
      var IsInList = false;
      foreach (var spec in Specs)
      {
        if (spec.Tree.RootDirectoryPath.Equals(tree.RootDirectoryPath)) IsInList = true;
      }
      if (!IsInList)
      {
        var spec = new FileSpecs(tree, info);
        Specs.Add(spec);
      }
    }
  }

  public class FileSpecs
  {
    public SlynchyDirectoryTree Tree { get; set; }
    public SlynchyFile Info { get; set; }

    public FileSpecs(SlynchyDirectoryTree tree, SlynchyFile info)
    {
      Tree = tree;
      Info = info;
    }
  }
}
