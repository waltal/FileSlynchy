using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSlynchy
{
  public partial class SynchWorkbench : Form
  {
    private string nl = Environment.NewLine;

    public string CurrentComparisonName { get; set; }
    public Comparison CurrentComparison { get; set; }

    public SlynchyDirectoryTree CurrentDirectoryTree { get; set; }

    public SynchWorkbench()
    {
      InitializeComponent();

      labProjectName.Text = SlynchyTrack.Project.Name;

      //Load comparison combo
      cboSelectComparison.Items.Clear();
      foreach (var comp in SlynchyTrack.Project.Comparisons)
      {
        cboSelectComparison.Items.Add(comp.Name);
      }
    }

    private void LoadComparisonControls()
    {
      if (CurrentComparison != null)
      {
        cboSelectTree.Items.Clear();
        foreach (var tree in CurrentComparison.Directories)
        {
          cboSelectTree.Items.Add(tree.Name);
        }
      }
    }

    private void cboSelectTree_SelectedIndexChanged(object sender, EventArgs e)
    {
      LoadTree();
    }

    private void LoadTree()
    {
      this.Cursor = Cursors.WaitCursor;
      tvTree.Nodes.Clear();
      Application.DoEvents();
      var CurrentTreeName = cboSelectTree.Text;
      CurrentDirectoryTree = CurrentComparison.FindTree(CurrentTreeName);
      CurrentDirectoryTree.CopyToTreeControl(tvTree, false);
      this.Cursor = Cursors.Arrow;
      Application.DoEvents();
    }

    private void cboSelectComparison_SelectedIndexChanged(object sender, EventArgs e)
    {
      CurrentComparisonName = cboSelectComparison.Text;
      CurrentComparison = SlynchyTrack.Project.FindComparison(CurrentComparisonName);
      CurrentComparison.Rescan();
      var anal = GetAnalysisForComp(CurrentComparison);

      LoadUncommonDirs(anal);
      LoadUncommonDirReport(anal);

      LoadUncommonFileDirs(anal);
      LoadDifferentFileDirs(anal);
    }

    private void LoadUncommonDirs(Analysis anal)
    {
      cboUncommonDirs.Items.Clear();
      foreach (var UDir in anal.UDirs)
      {
        cboUncommonDirs.Items.Add(UDir.RelDir);
      }
    }

    private Analysis GetAnalysisForComp(Comparison comp)
    {
      var anal = new Analysis();

      foreach (var analCheck in SlynchyTrack.AnalysisList)
      {
        if (analCheck.Comp.Name.Equals(comp.Name)) anal = analCheck;
      }

      if (anal.Comp == null)
      {
        anal = new Analysis(comp);
        SlynchyTrack.AnalysisList.Add(anal);
        anal.DoAnalysis();
      }

      return anal;
    }

    private void LoadUncommonDirReport(Analysis anal)
    {
      tbDirReport.Clear();

      if (anal.UDirs.Count == 0)
      {
        tbDirReport.AppendText(" No Uncommon Directories" + nl);
        return;
      }

      tbDirReport.AppendText("     -----------------------------------------------------------------------" + nl);
      tbDirReport.AppendText("     Uncommon Directories" + nl);
      tbDirReport.AppendText("     --------------------" + nl);
      foreach (var uDir in anal.UDirs)
      {
        tbDirReport.AppendText(" " + nl);
        tbDirReport.AppendText("     Relative Directory: " + uDir.RelDir + nl);
        tbDirReport.AppendText(" " + nl);

        tbDirReport.AppendText("     In Trees " + nl);
        tbDirReport.AppendText("     -------- " + nl);
        foreach (var inTree in uDir.InTrees)
        {
          tbDirReport.AppendText("       Tree Name: " + inTree.Name + nl);
        }
        tbDirReport.AppendText(" " + nl);
        tbDirReport.AppendText("     Not In Trees " + nl);
        tbDirReport.AppendText("     ------------ " + nl);
        foreach (var notInTree in uDir.NotInTrees)
        {
          tbDirReport.AppendText("       Tree Name: " + notInTree.Name + nl);
        }
      }
      tbDirReport.AppendText(" " + nl);
    }

    private void butCopyUncommonDir_Click(object sender, EventArgs e)
    {
      //If a directory is selected and a source tree is selected, copy the directory, its files 
      //  and all subdirs and their files to the trees where this subdir does not exist.
      //Exclusions apply
      var anal = GetAnalysisForComp(CurrentComparison);
      var relDir = cboUncommonDirs.Text;
      UncommonDirectory UDir = null;
      foreach (var uDir in anal.UDirs)
      {
        if (uDir.RelDir.Equals(relDir)) UDir = uDir;
      }

      if (UDir != null)
      {
        if (String.IsNullOrEmpty(cboSelectTree.Text))
        {
          //TODO: notify that source tree must be selected
          return;
        }
        var sourceTree = CurrentComparison.FindTree(cboSelectTree.Text);
        var sNode = sourceTree.GetDirectoryNode(relDir);

        foreach (var tree in UDir.NotInTrees)
        {
          //Make sure starting directory exists
          var destPath = tree.RootDirectoryPath + relDir;
          Directory.CreateDirectory(destPath);

          //Copy the tree
          sourceTree.CopyNodeTree(sNode, destPath);
        }
      }
      ReScanReAnalyzeReload();

      //Clear the report, reload the file directories
      tbDirReport.Clear();
      anal = GetAnalysisForComp(CurrentComparison);
      LoadUncommonDirs(anal);
      LoadUncommonDirReport(anal);
    }

    private void butRemoveUncommonDir_Click(object sender, EventArgs e)
    {
      //If a directory is selected, delete the directory, its files 
      //  and all subdirs and their files in the trees where this subdir exists.
      var anal = GetAnalysisForComp(CurrentComparison);
      var relDir = cboUncommonDirs.Text;
      UncommonDirectory UDir = null;
      foreach (var uDir in anal.UDirs)
      {
        if (uDir.RelDir.Equals(relDir)) UDir = uDir;
      }

      if (UDir != null)
      {
        foreach (var tree in UDir.InTrees)
        {
          //Make sure directory exists
          var fullPath = tree.RootDirectoryPath + relDir;
          if (Directory.Exists(fullPath))
          {
            Directory.Delete(fullPath, true);
          }
        }
      }
      ReScanReAnalyzeReload();

      //Clear the report, reload the file directories
      tbDirReport.Clear();
      anal = GetAnalysisForComp(CurrentComparison);
      LoadUncommonDirs(anal);
      LoadUncommonDirReport(anal);
    }

    private void ClearTree()
    {
      cboSelectTree.Items.Clear();
      tvTree.Nodes.Clear();
    }

    private void LoadUncommonFileDirs(Analysis anal)
    {
      cboUncommonFileDirs.SelectedIndex = -1;
      cboUncommonDirs.Text = null;
      cboUncommonFileDirs.Items.Clear();

      var UDirs = new List<string>();
      foreach (var uFile in anal.UFiles)
      {
        var dir = uFile.RelDir;
        if (!UDirs.Contains(dir)) UDirs.Add(dir);
      }
      foreach (var dir in UDirs)
      {
        cboUncommonFileDirs.Items.Add(dir);
      }
    }

    private void LoadSyncDirTrees()
    {
      ClearTree();

      foreach (var tree in CurrentComparison.Directories)
      {
        cboSelectTree.Items.Add(tree.Name);
      }
    }

    private void ReScanReAnalyzeReload()
    {
      var anal = GetAnalysisForComp(CurrentComparison);
      SlynchyTrack.AnalysisList.Remove(anal);
      CurrentComparison.Rescan();
      anal = GetAnalysisForComp(CurrentComparison);

      //Reload the form
      LoadUncommonDirs(anal);
      LoadUncommonDirReport(anal);

      //Other tabs need special treatment

      LoadTree();
    }

    private void LoadUncommonFilesReport(ComboBox relDirCombo, TextBox reportBox, bool clearBox)
    {
      CurrentComparisonName = cboSelectComparison.Text;
      CurrentComparison = SlynchyTrack.Project.FindComparison(CurrentComparisonName);
      var anal = GetAnalysisForComp(CurrentComparison);

      if (clearBox) reportBox.Clear();
      if (relDirCombo.SelectedIndex < 0) return;
      var RelDir = relDirCombo.Text;

      reportBox.AppendText("     -----------------------------------------------------------------------" + nl);
      reportBox.AppendText("     Uncommon Files" + nl);
      reportBox.AppendText("     Relative Directory: " + relDirCombo.Text + nl);
      reportBox.AppendText("     -------------------------------------------------------------------" + nl);
      reportBox.AppendText(" " + nl);

      var UFiles = new List<UncommonFile>();
      foreach (var uFile in anal.UFiles)
      {
        if (uFile.RelDir.Equals(RelDir)) UFiles.Add(uFile);
      }

      foreach (var uFile in UFiles)
      {
        reportBox.AppendText("     --------------------" + nl);
        reportBox.AppendText("     File Name: " + uFile.FileName + nl);
        reportBox.AppendText(" " + nl);

        reportBox.AppendText("     In Trees " + nl);
        reportBox.AppendText("     -------- " + nl);
        foreach (var inTree in uFile.InTrees)
        {
          reportBox.AppendText("       Tree Name: " + inTree.Name + nl);
        }
        reportBox.AppendText(" " + nl);
        reportBox.AppendText("     Not In Trees " + nl);
        reportBox.AppendText("     ------------ " + nl);
        foreach (var notInTree in uFile.NotInTrees)
        {
          reportBox.AppendText("       Tree Name: " + notInTree.Name + nl);
        }
        reportBox.AppendText(" " + nl);
      }
    }

    private void LoadDifferentFileDirs(Analysis anal)
    {
      cboDifferentFileDirs.SelectedIndex = -1;
      cboDifferentFileDirs.Text = null;
      cboDifferentFileDirs.Items.Clear();

      var DDirs = new List<string>();
      foreach (var uFile in anal.DFiles)
      {
        var dir = uFile.RelDir;
        if (!DDirs.Contains(dir)) DDirs.Add(dir);
      }
      foreach (var dir in DDirs)
      {
        cboDifferentFileDirs.Items.Add(dir);
      }
    }

    private void LoadDifferentFilesReport(ComboBox relDirCombo, TextBox reportBox, bool clearBox)
    {
      CurrentComparisonName = cboSelectComparison.Text;
      CurrentComparison = SlynchyTrack.Project.FindComparison(CurrentComparisonName);
      var anal = GetAnalysisForComp(CurrentComparison);

      if (clearBox) reportBox.Clear();
      if (relDirCombo.SelectedIndex < 0) return;
      var RelDir = relDirCombo.Text;

      reportBox.AppendText("     -----------------------------------------------------------------------" + nl);
      reportBox.AppendText("     Different Files" + nl);
      reportBox.AppendText("     Relative Directory: " + relDirCombo.Text + nl);
      reportBox.AppendText("     -------------------------------------------------------------------" + nl);
      reportBox.AppendText(" " + nl);

      var DFiles = new List<DifferentFiles>();
      foreach (var dFiles in anal.DFiles)
      {
        if (dFiles.RelDir.Equals(RelDir)) DFiles.Add(dFiles);
      }

      foreach (var dFile in DFiles)
      {
        reportBox.AppendText("     --------------------" + nl);
        reportBox.AppendText("     File Name: " + dFile.FileName + nl);
        reportBox.AppendText(" " + nl);

        foreach (var spec in dFile.Specs)
        {
          reportBox.AppendText("       Tree Name: " + spec.Tree.Name + nl);
          reportBox.AppendText("       File Size: " + spec.Info.Info.Length.ToString() + nl);
          reportBox.AppendText("       File Date: "
            + spec.Info.Info.LastWriteTime.ToShortDateString()
            + " :: " + spec.Info.Info.LastWriteTime.ToShortTimeString() + nl);
          reportBox.AppendText(" " + nl);
        }

        reportBox.AppendText(" " + nl);
      }
    }

    private void LoadUncommonDirTrees()
    {
      ClearTree();
      var anal = GetAnalysisForComp(CurrentComparison);
      var relDir = cboUncommonDirs.Text;
      foreach (var UDir in anal.UDirs)
      {
        if (UDir.RelDir.Equals(relDir))
        {
          foreach (var tree in UDir.InTrees)
          {
            if (!cboSelectTree.Items.Contains(tree.Name))
              cboSelectTree.Items.Add(tree.Name);
          }
        }
      }
    }

    private void LoadUncommonFileTrees()
    {
      ClearTree();

      foreach (var tree in CurrentComparison.Directories)
      {
        cboSelectTree.Items.Add(tree.Name);
      }
    }

    private void LoadDifferentFileTrees()
    {
      ClearTree();

      foreach (var tree in CurrentComparison.Directories)
      {
        cboSelectTree.Items.Add(tree.Name);
      }
    }

    private void cboUncommonDirs_SelectedIndexChanged(object sender, EventArgs e)
    {
      //Reload the tree selection for trees with selected uncommon dir
      LoadUncommonDirTrees();

      //Display the report
      var anal = GetAnalysisForComp(CurrentComparison);
      LoadUncommonDirReport(anal);
    }

    private void cboUncommonFileDirs_SelectedIndexChanged(object sender, EventArgs e)
    {
      //Reload the tree selection for trees with selected uncommon file directory
      LoadUncommonFileTrees();

      //Display the report
      LoadUncommonFilesReport(cboUncommonFileDirs, tbUncommonFilesinDir, true);
    }

    private void cboDifferentFileDirs_SelectedIndexChanged(object sender, EventArgs e)
    {
      //Reload the tree selection for tree with selected different file directory
      LoadDifferentFileTrees();

      //Display the report
      LoadDifferentFilesReport(cboDifferentFileDirs, tbDifferentFilesInDir, true);
    }

    private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
    {
      FileTreeNode node = (FileTreeNode)tvTree.SelectedNode;
      if (node != null)
      {
        var info = node.NodeFileInfo;
        tbSelectedFile.Text = info.Name;
      }
    }

    private void butDeleteSelectedFile_Click(object sender, EventArgs e)
    {
      FileTreeNode node = (FileTreeNode)tvTree.SelectedNode;
      if (node != null)
      {
        var info = node.NodeFileInfo;
        File.Delete(info.FullName);
        LoadTree();
      }
    }

    private void butCopyUncommonFiles_Click(object sender, EventArgs e)
    {
      var anal = GetAnalysisForComp(CurrentComparison);
      var relDir = cboUncommonFileDirs.Text;
      //TODO: Notify if a source tree needs to be selected
      if (String.IsNullOrEmpty(cboSelectTree.Text)) return;
      var sourceTree = CurrentComparison.FindTree(cboSelectTree.Text);

      //If an uncommon file is in the source tree, copy it to other trees
      foreach (var UFile in anal.UFiles)
      {
        if (UFile.RelDir.Equals(relDir))
        {
          var fileName = UFile.FileName;
          if (UFile.InTrees.Contains(sourceTree))
          {
            var sourceFullPathName = sourceTree.GetFilePathName(relDir, fileName);
            foreach (var DestTree in UFile.NotInTrees)
            {
              var destPath = DestTree.RootDirectoryPath + relDir + "\\";
              var destFullPathName = Path.Combine(destPath, fileName);
              File.Copy(sourceFullPathName, destFullPathName);
            }
          }
        }
      }
      ReScanReAnalyzeReload();

      //Clear the report, reload the file directories
      tbUncommonFilesinDir.Clear();
      anal = GetAnalysisForComp(CurrentComparison);
      LoadUncommonFileDirs(anal);
    }

    private void butRemoveUncommonFiles_Click(object sender, EventArgs e)
    {
      var anal = GetAnalysisForComp(CurrentComparison);
      var relDir = cboUncommonFileDirs.Text;
      //TODO: Notify if a source tree needs to be selected
      if (String.IsNullOrEmpty(cboSelectTree.Text)) return;
      var sourceTree = CurrentComparison.FindTree(cboSelectTree.Text);

      //If an uncommon file is in the source tree, remove it from all trees
      foreach (var UFile in anal.UFiles)
      {
        if (UFile.RelDir.Equals(relDir))
        {
          var fileName = UFile.FileName;
          if (UFile.InTrees.Contains(sourceTree))
          {
            var sourceRelPathName = sourceTree.GetFilePathName(relDir, fileName);
            var sourceFullPathName = sourceTree.RootDirectoryPath + sourceRelPathName;
            foreach (var tree in CurrentComparison.Directories)
            {
              //does file exist in this tree?
              var checkFullPathName = tree.RootDirectoryPath + sourceRelPathName;
              if (File.Exists(checkFullPathName))
              {
                File.Delete(checkFullPathName);
              }
            }
          }
        }
      }
      ReScanReAnalyzeReload();

      //Clear the report, reload the file directories
      tbUncommonFilesinDir.Clear();
      anal = GetAnalysisForComp(CurrentComparison);
      LoadUncommonFileDirs(anal);
    }

    private void butCopyDifferentFiles_Click(object sender, EventArgs e)
    {
      var anal = GetAnalysisForComp(CurrentComparison);
      var relDir = cboDifferentFileDirs.Text;
      //TODO: Notify if a source tree needs to be selected
      if (String.IsNullOrEmpty(cboSelectTree.Text)) return;
      var sourceTree = CurrentComparison.FindTree(cboSelectTree.Text);

      foreach (var DFile in anal.DFiles)
      {
        if (DFile.RelDir.Equals(relDir))
        {
          var fileName = DFile.FileName;
          foreach (var spec in DFile.Specs)
          {
            if (spec.Tree.Equals(sourceTree))
            {
              var sourceFullPathName = sourceTree.GetFilePathName(relDir, fileName);
              var sourceFileInfo = sourceTree.GetFileInfo(relDir, fileName);
              foreach (var tree in CurrentComparison.Directories)
              {
                if (!tree.Equals(sourceTree))
                {
                  var destPath = tree.RootDirectoryPath + relDir;
                  var destFullPathName = Path.Combine(destPath, fileName);
                  File.Copy(sourceFullPathName, destFullPathName, true);
                }
              }
            }
          }
        }
      }

      ReScanReAnalyzeReload();

      //Clear the report, reload the file directories
      tbDifferentFilesInDir.Clear();
      anal = GetAnalysisForComp(CurrentComparison);
      LoadDifferentFileDirs(anal);
    }
  }
}
