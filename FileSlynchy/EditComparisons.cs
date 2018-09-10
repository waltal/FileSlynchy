using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSlynchy
{
  public partial class EditComparisons : Form
  {

    public EditComparisons()
    {
      InitializeComponent();
    }

    private void EditComparisons_Load(object sender, EventArgs e)
    {
      labProjectName.Text = SlynchyTrack.Project.Name;
      LoadComparisons();
    }

    private void LoadComparisons()
    {
      cboSelectComparison.Items.Clear();
      foreach (var comp in SlynchyTrack.Project.Comparisons)
      {
        cboSelectComparison.Items.Add(comp.Name);
      }
    }

    private void butDeleteComparison_Click(object sender, EventArgs e)
    {
      var CurrentComparisonName = cboSelectComparison.Text;
      var SelectedComparison = SlynchyTrack.Project.FindComparison(CurrentComparisonName);
      if (SelectedComparison != null) SlynchyTrack.Project.Comparisons.Remove(SelectedComparison);
      LoadComparisons();
    }

    private void butAddComparison_Click(object sender, EventArgs e)
    {
      if (!String.IsNullOrEmpty(tbAddComparisonName.Text))
      {
        if (!IsInComparisonList(tbAddComparisonName.Text))
        {
          var newComparison = new Comparison();
          newComparison.Name = tbAddComparisonName.Text;
          SlynchyTrack.Project.Comparisons.Add(newComparison);
          LoadComparisons();
          tbAddComparisonName.Text = "";
        }
      }
    }

    private bool IsInComparisonList(string name)
    {
      //TODO: This should be a method in SlynchyTrack
      var result = false;
      foreach (var comp in SlynchyTrack.Project.Comparisons)
      {
        if (comp.Name.Equals(name)) result = true;
      }
      return result;
    }

    private void butSelectAddTreeRootDirectory_Click(object sender, EventArgs e)
    {
      fbSelectRootDir.ShowNewFolderButton = false;
      if (tbAddTreeRootDirectory.Text.Length > 0) fbSelectRootDir.SelectedPath = tbAddTreeRootDirectory.Text;
      DialogResult result = fbSelectRootDir.ShowDialog();
      if (result == DialogResult.OK)
      {
        tbAddTreeRootDirectory.Text = fbSelectRootDir.SelectedPath;
      }
    }

    private void butAddTree_Click(object sender, EventArgs e)
    {
      if (!String.IsNullOrEmpty(tbAddTreeName.Text) 
         && !String.IsNullOrEmpty(tbAddTreeRootDirectory.Text)
         && !IsInTreeNameList(tbAddTreeName.Text)
         && !IsInTreeDirList(tbAddTreeRootDirectory.Text))
      {
        var newTree = new SlynchyDirectoryTree(tbAddTreeName.Text, tbAddTreeRootDirectory.Text);
        var CurrentComparison = SlynchyTrack.Project.FindComparison(cboSelectComparison.Text);
        CurrentComparison.Directories.Add(newTree);

        LoadDirTrees();
        tbAddTreeName.Text = "";
        tbAddTreeRootDirectory.Text = "";
        SlynchyProjectFiles.SaveProject(SlynchyTrack.Project,SlynchyTrack.ProjectFileName);
        Application.DoEvents();
      }
    }

    private bool IsInTreeNameList(string name)
    {
      //TODO: This should be a method in SlynchyTrack
      var result = false;
      var CurrentComparison = SlynchyTrack.Project.FindComparison(cboSelectComparison.Text);

      foreach (var tree in CurrentComparison.Directories)
      {
        if (tree.Name.Equals(name)) result = true;
      }

      return result;
    }

    private bool IsInTreeDirList(string dirName)
    {
      //TODO: This should be a method in SlynchyTrack
      var result = false;
      var CurrentComparison = SlynchyTrack.Project.FindComparison(cboSelectComparison.Text);

      foreach (var tree in CurrentComparison.Directories)
      {
        if (tree.RootDirectoryPath.Equals(dirName)) result = true;
      }

      return result;
    }

    private SlynchyDirectoryTree FindDirTree(string name)
    {
      //TODO: This should be a method in SlynchyTrack
      var CurrentComparison = SlynchyTrack.Project.FindComparison(cboSelectComparison.Text);
      SlynchyDirectoryTree CurrentTree = null;
      if (!String.IsNullOrEmpty(name))
      {
        foreach (var tree in CurrentComparison.Directories)
        {
          if (tree.Name.Equals(name)) CurrentTree = tree;
        }
      }
      return CurrentTree;
    }

    private void butExclusions_Click(object sender, EventArgs e)
    {
      var CurrentComparisonName = cboSelectComparison.Text;
      var SelectedComparison = SlynchyTrack.Project.FindComparison(CurrentComparisonName);
      var TreeName = cboDirTree.Text;
      var SelectedTree = FindDirTree(TreeName);

      var ExclusionsForm = new frmExclusions(SlynchyTrack.Project, SelectedComparison, SelectedTree);
      ExclusionsForm.ShowDialog();
    }

    private void butDeleteDirTree_Click(object sender, EventArgs e)
    {
      var CurrentComparison = SlynchyTrack.Project.FindComparison(cboSelectComparison.Text);
      var CurrentTree = CurrentComparison.FindTree(cboDirTree.Text);
      CurrentComparison.Directories.Remove(CurrentTree);
      LoadDirTrees();
    }

    private void cboSelectComparison_SelectedIndexChanged(object sender, EventArgs e)
    {
      LoadDirTrees();
    }

    private void LoadDirTrees()
    {
      cboDirTree.Items.Clear();
      var CurrentComparison = SlynchyTrack.Project.FindComparison(cboSelectComparison.Text);
      foreach (var tree in CurrentComparison.Directories)
      {
        cboDirTree.Items.Add(tree.Name);
      }
    }

    private void cboDirTree_SelectedIndexChanged(object sender, EventArgs e)
    {
      //Nothing needs to happen here...leaving for now 20180910
    }
  }
}
