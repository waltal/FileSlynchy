using System;

namespace FileSlynchy
{
  /// <summary>
  /// Summary description for Utility.
  /// </summary>
  public static class Utility
  {

    public static void CloneFileTreeView(System.Windows.Forms.TreeView tvSource, System.Windows.Forms.TreeView tvDest)
    {
      FileTreeNode RootNodeSource = (FileTreeNode)tvSource.Nodes[0];
      tvDest.Nodes.Add(RootNodeSource.FTClone());
      FileTreeNode RootNodeDest = (FileTreeNode)tvDest.Nodes[0];
      FileTreeNode aNode = null;

      for (int i = 0; i < RootNodeSource.Nodes.Count; i++)
      {
        aNode = (FileTreeNode)RootNodeSource.Nodes[i];
        FileTreeNode aClone = aNode.FTClone();
        RootNodeDest.Nodes.Add(aClone);

        if (aNode.Nodes.Count > 0) CloneChildFileNodes(aNode, aClone);
      }
    }

    private static void CloneChildFileNodes(FileTreeNode ParentSourceNode, FileTreeNode ParentDestNode)
    {
      FileTreeNode aNode = null;

      for (int i = 0; i < ParentSourceNode.Nodes.Count; i++)
      {
        aNode = (FileTreeNode)ParentSourceNode.Nodes[i];
        FileTreeNode aClone = aNode.FTClone();
        ParentDestNode.Nodes.Add(aClone);

        if (aNode.Nodes.Count > 0) CloneChildFileNodes(aNode, aClone);
      }
    }

    public static string[] DirectoryParts(string dirPath)
    {
      return dirPath.Split('\\');
    }

    public static string RelativeDirectory(string rootDirPath, string dirPath)
    {
      return dirPath.Substring(rootDirPath.Length);
    }

    public static string LastDirectoryPart(string dirPath)
    {
      var parts = DirectoryParts(dirPath);
      string LastPart = "";
      if (parts.Length > 0) LastPart = parts[parts.Length - 1];
      return LastPart;
    }

  }
}
