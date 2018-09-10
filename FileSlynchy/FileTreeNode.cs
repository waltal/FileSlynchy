using System;
using System.IO;
using System.Windows.Forms;

namespace FileSlynchy
{
  /// <summary>
  /// Summary description for FileTreeNode.
  /// </summary>
  public class FileTreeNode : TreeNode
  {
    private bool m_IsFile;
    private FileInfo m_NodeFileInfo = null;

    public bool IsFile
    {
      get { return m_IsFile; }
      set { m_IsFile = value; }
    }

    public FileInfo NodeFileInfo
    {
      get { return m_NodeFileInfo; }
      set { m_NodeFileInfo = value; }
    }

    public FileTreeNode()
    {
    }

    public FileTreeNode(bool IsFile, string Text)
    {
      m_IsFile = IsFile;
      this.Text = Text;
    }

    public FileTreeNode(bool IsFile, string Text, int ImageIndex, int SelectedImageIndex)
    {
      m_IsFile = IsFile;
      this.Text = Text;
      this.ImageIndex = ImageIndex;
      this.SelectedImageIndex = SelectedImageIndex;
    }

    public FileTreeNode(bool IsFile, string Text, FileInfo FileStuff, int ImageIndex)
    {
      m_IsFile = IsFile;
      this.Text = Text;
      m_NodeFileInfo = FileStuff;
      this.ImageIndex = ImageIndex;
      this.SelectedImageIndex = ImageIndex;
    }

    public FileTreeNode FTClone()
    {
      FileTreeNode aNode = (FileTreeNode)base.Clone();
      aNode.IsFile = this.IsFile;
      return aNode;
    }
  }
}
