using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace FileSlynchy
{
  /// <summary>
  /// Summary description for frmReport.
  /// </summary>
  public class frmReport : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Label labSaveReport;
    private System.Windows.Forms.TextBox tbSaveReport;
    private System.Windows.Forms.SaveFileDialog sfDialog;
    private System.Windows.Forms.Button butDone;
    private System.Windows.Forms.TextBox tbReport;
    private System.Windows.Forms.Button butSave;
    private System.Windows.Forms.Button butSaveFileName;

    private System.Windows.Forms.Button butCreatePackage;

    private string nl = Environment.NewLine;
    private Button butMakeReport;
    private Label labStatus;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public frmReport()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      SlynchyTrack.AnalysisList = new List<Analysis>();
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tbReport = new System.Windows.Forms.TextBox();
      this.tbSaveReport = new System.Windows.Forms.TextBox();
      this.labSaveReport = new System.Windows.Forms.Label();
      this.butSaveFileName = new System.Windows.Forms.Button();
      this.sfDialog = new System.Windows.Forms.SaveFileDialog();
      this.butDone = new System.Windows.Forms.Button();
      this.butSave = new System.Windows.Forms.Button();
      this.butCreatePackage = new System.Windows.Forms.Button();
      this.butMakeReport = new System.Windows.Forms.Button();
      this.labStatus = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // tbReport
      // 
      this.tbReport.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbReport.Location = new System.Drawing.Point(12, 105);
      this.tbReport.Multiline = true;
      this.tbReport.Name = "tbReport";
      this.tbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbReport.Size = new System.Drawing.Size(1346, 546);
      this.tbReport.TabIndex = 0;
      // 
      // tbSaveReport
      // 
      this.tbSaveReport.Location = new System.Drawing.Point(197, 657);
      this.tbSaveReport.Name = "tbSaveReport";
      this.tbSaveReport.Size = new System.Drawing.Size(1016, 26);
      this.tbSaveReport.TabIndex = 4;
      // 
      // labSaveReport
      // 
      this.labSaveReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labSaveReport.Location = new System.Drawing.Point(13, 657);
      this.labSaveReport.Name = "labSaveReport";
      this.labSaveReport.Size = new System.Drawing.Size(168, 23);
      this.labSaveReport.TabIndex = 6;
      this.labSaveReport.Text = "Report File: ";
      this.labSaveReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // butSaveFileName
      // 
      this.butSaveFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butSaveFileName.Location = new System.Drawing.Point(1229, 657);
      this.butSaveFileName.Name = "butSaveFileName";
      this.butSaveFileName.Size = new System.Drawing.Size(128, 35);
      this.butSaveFileName.TabIndex = 7;
      this.butSaveFileName.Text = "Select...";
      this.butSaveFileName.Click += new System.EventHandler(this.butSaveFileName_Click);
      // 
      // butDone
      // 
      this.butDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDone.Location = new System.Drawing.Point(1242, 702);
      this.butDone.Name = "butDone";
      this.butDone.Size = new System.Drawing.Size(115, 35);
      this.butDone.TabIndex = 8;
      this.butDone.Text = "Done ";
      this.butDone.Click += new System.EventHandler(this.butDone_Click);
      // 
      // butSave
      // 
      this.butSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butSave.Location = new System.Drawing.Point(1037, 689);
      this.butSave.Name = "butSave";
      this.butSave.Size = new System.Drawing.Size(176, 48);
      this.butSave.TabIndex = 9;
      this.butSave.Text = "Save Report ";
      this.butSave.Click += new System.EventHandler(this.butSave_Click);
      // 
      // butCreatePackage
      // 
      this.butCreatePackage.Enabled = false;
      this.butCreatePackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butCreatePackage.Location = new System.Drawing.Point(239, 16);
      this.butCreatePackage.Name = "butCreatePackage";
      this.butCreatePackage.Size = new System.Drawing.Size(347, 48);
      this.butCreatePackage.TabIndex = 10;
      this.butCreatePackage.Text = "Create Change Package... ";
      this.butCreatePackage.Click += new System.EventHandler(this.butCreatePackage_Click);
      // 
      // butMakeReport
      // 
      this.butMakeReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butMakeReport.Location = new System.Drawing.Point(28, 16);
      this.butMakeReport.Name = "butMakeReport";
      this.butMakeReport.Size = new System.Drawing.Size(176, 48);
      this.butMakeReport.TabIndex = 12;
      this.butMakeReport.Text = "Make Report ";
      this.butMakeReport.Click += new System.EventHandler(this.butMakeReport_Click);
      // 
      // labStatus
      // 
      this.labStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labStatus.Location = new System.Drawing.Point(28, 67);
      this.labStatus.Name = "labStatus";
      this.labStatus.Size = new System.Drawing.Size(1224, 35);
      this.labStatus.TabIndex = 19;
      this.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // frmReport
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
      this.ClientSize = new System.Drawing.Size(1371, 745);
      this.Controls.Add(this.labStatus);
      this.Controls.Add(this.butMakeReport);
      this.Controls.Add(this.butCreatePackage);
      this.Controls.Add(this.butSave);
      this.Controls.Add(this.butDone);
      this.Controls.Add(this.butSaveFileName);
      this.Controls.Add(this.labSaveReport);
      this.Controls.Add(this.tbSaveReport);
      this.Controls.Add(this.tbReport);
      this.Name = "frmReport";
      this.Text = "Directory Comparison Report";
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion

    private void butSaveFileName_Click(object sender, System.EventArgs e)
    {
      if (tbSaveReport.Text.Length > 0) sfDialog.FileName = tbSaveReport.Text;
      DialogResult result = sfDialog.ShowDialog();
      if (result == DialogResult.OK)
      {
        tbSaveReport.Text = sfDialog.FileName;
      }
    }

    private void DoReport()
    {
      this.Cursor = Cursors.WaitCursor;

      ProjectReport();

      this.Cursor = Cursors.Arrow;
      Application.DoEvents();
    }

    private void ProjectReport()
    {
      tbReport.Clear();
      tbReport.AppendText("Directory and File Difference Report - " + DateTime.Now.ToLongDateString() + nl);
      tbReport.AppendText("                                       " + DateTime.Now.ToLongTimeString() + nl);
      tbReport.AppendText(" " + nl);
      tbReport.AppendText("   Project: " + SlynchyTrack.Project.Name + nl);
      tbReport.AppendText(" " + nl);

      foreach (var comp in SlynchyTrack.Project.Comparisons)
      {
        ComparisonHeader(comp);

        foreach (var tree in comp.Directories)
        {
          DirectoryTree(tree);
        }

        var anal = GetAnalysisForComp(comp);

        UncommonDirs(anal);
        UncommonFiles(anal);
        DifferentFiles(anal);
      }
    }

    private void ComparisonHeader(Comparison comp)
    {
      tbReport.AppendText("   -----------------------------------------------------------------------" + nl);
      tbReport.AppendText("   Comparison: " + comp.Name + nl);
      tbReport.AppendText(" " + nl);
    }

    private void DirectoryTree(SlynchyDirectoryTree tree)
    {
      tbReport.AppendText("   -----------------------------------------------------------------------" + nl);
      tbReport.AppendText("   Directory Tree name: " + tree.Name + nl);
      tbReport.AppendText("   Root Directory path: " + tree.RootDirectoryPath + nl);
      tbReport.AppendText(" " + nl);
    }

    private void UncommonDirs(Analysis anal)
    {
      tbReport.AppendText("     -----------------------------------------------------------------------" + nl);
      tbReport.AppendText("     Uncommon Directories" + nl);
      tbReport.AppendText("     --------------------" + nl);
      foreach (var uDir in anal.UDirs)
      {
        tbReport.AppendText(" " + nl);
        tbReport.AppendText("     Relative Directory: " + uDir.RelDir + nl);
        tbReport.AppendText(" " + nl);

        tbReport.AppendText("     In Trees " + nl);
        tbReport.AppendText("     -------- " + nl);
        foreach (var inTree in uDir.InTrees)
        {
          tbReport.AppendText("       Tree Name: " + inTree.Name + nl);
        }
        tbReport.AppendText(" " + nl);
        tbReport.AppendText("     Not In Trees " + nl);
        tbReport.AppendText("     ------------ " + nl);
        foreach (var notInTree in uDir.NotInTrees)
        {
          tbReport.AppendText("       Tree Name: " + notInTree.Name + nl);
        }
      }
      tbReport.AppendText(" " + nl);
    }

    private void UncommonFiles(Analysis anal)
    {
      tbReport.AppendText("     -----------------------------------------------------------------------" + nl);
      tbReport.AppendText("     Uncommon Files" + nl);
      tbReport.AppendText("     --------------------" + nl);
      tbReport.AppendText(" " + nl);
      foreach (var uFile in anal.UFiles)
      {
        tbReport.AppendText("     --------------------" + nl);
        tbReport.AppendText("     Relative Directory: " + uFile.RelDir + nl);
        tbReport.AppendText("     File Name: " + uFile.FileName + nl);
        tbReport.AppendText(" " + nl);

        tbReport.AppendText("     In Trees " + nl);
        tbReport.AppendText("     -------- " + nl);
        foreach (var inTree in uFile.InTrees)
        {
          tbReport.AppendText("       Tree Name: " + inTree.Name + nl);
        }
        tbReport.AppendText(" " + nl);
        tbReport.AppendText("     Not In Trees " + nl);
        tbReport.AppendText("     ------------ " + nl);
        foreach (var notInTree in uFile.NotInTrees)
        {
          tbReport.AppendText("       Tree Name: " + notInTree.Name + nl);
        }
        tbReport.AppendText(" " + nl);
      }
      tbReport.AppendText(" " + nl);
    }

    private void DifferentFiles(Analysis anal)
    {
      tbReport.AppendText("     -----------------------------------------------------------------------" + nl);
      tbReport.AppendText("     Different Files" + nl);
      tbReport.AppendText("     --------------------" + nl);
      tbReport.AppendText(" " + nl);
      foreach (var dFile in anal.DFiles)
      {
        tbReport.AppendText("     --------------------" + nl);
        tbReport.AppendText("     Relative Directory: " + dFile.RelDir + nl);
        tbReport.AppendText("     File Name: " + dFile.FileName + nl);
        tbReport.AppendText(" " + nl);

        foreach (var spec in dFile.Specs)
        {
          tbReport.AppendText("       Tree Name: " + spec.Tree.Name + nl);
          tbReport.AppendText("       File Size: " + spec.Info.Info.Length.ToString() + nl);
          tbReport.AppendText("       File Date: " 
            + spec.Info.Info.LastWriteTime.ToShortDateString()
            + " :: " + spec.Info.Info.LastWriteTime.ToShortTimeString() + nl);
          tbReport.AppendText(" " + nl);
        }
      }
      tbReport.AppendText(" " + nl);
    }

    private Analysis GetAnalysisForComp(Comparison comp)
    {
      var anal = new Analysis();

      foreach (var analCheck in SlynchyTrack.AnalysisList)
      {
        if (analCheck.Comp.Name.Equals(comp.Name)) anal = analCheck;
      }

      return anal;
    }

    private void RootDisplay(string Title, string RootDirectory,
      ArrayList NameExcludeList, ArrayList PathExcludeList, ArrayList FileNameExcludeList,
      bool SelectedFileTypes, ArrayList FileTypeList, ArrayList FilePathExcludeList, ArrayList DirFileExcludeList)
    {
      tbReport.AppendText("  ================================================================" + nl);
      tbReport.AppendText(Title + RootDirectory + nl);
      tbReport.AppendText(" " + nl);
      ListDisplay(" Directory Name Exclusions - ", NameExcludeList);
      ListDisplay(" Directory Exclusions - ", PathExcludeList);
      ListDisplay(" File Name Exclusions - ", FileNameExcludeList);
      if (SelectedFileTypes)
        ListDisplay(" Reference Only These File Extensions - ", FileTypeList);
      else
        ListDisplay(" File Extension Exclusions - ", FileTypeList);
      ListDisplay(" File Path/Name Exclusions - ", FilePathExcludeList);
      ListDisplay(" Directory File Exclusions - ", DirFileExcludeList);
    }

    private void ListDisplay(string Title, ArrayList aList)
    {
      if (aList.Count > 0)
      {
        tbReport.AppendText("  ----------------------------------------------------------------" + nl);
        tbReport.AppendText(Title + nl);
        tbReport.AppendText(" " + nl);
        for (int i = 0; i < aList.Count; i++)
        {
          tbReport.AppendText("   " + (string)aList[i] + nl);
        }
        tbReport.AppendText(" " + nl);
        Application.DoEvents();
      }
    }

    private void ListDisplay(string Title, ArrayList aList, int Skip)
    {
      if (aList.Count > 0)
      {
        tbReport.AppendText("  ----------------------------------------------------------------" + nl);
        tbReport.AppendText(Title + nl);
        tbReport.AppendText(" " + nl);
        for (int i = 0; i < aList.Count; i++)
        {
          tbReport.AppendText("   " + ((string)aList[i]).Substring(Skip) + nl);
        }
        tbReport.AppendText(" " + nl);
        Application.DoEvents();
      }
    }

    private void butDone_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }

    private void butSave_Click(object sender, System.EventArgs e)
    {
      if (tbReport.Lines.Length > 0 && tbSaveReport.Text.Length > 0)
      {
        StreamWriter sr = File.CreateText(tbSaveReport.Text);
        foreach (string aLine in tbReport.Lines)
        {
          sr.WriteLine(aLine);
        }
        sr.Close();
      }
    }


    private void butSynch_Click(object sender, System.EventArgs e)
    {
      var frmSynchDash = new SynchWorkbench();
      frmSynchDash.ShowDialog();
      frmSynchDash.Dispose();
    }

    private void butCreatePackage_Click(object sender, System.EventArgs e)
    {
      //m_frmPackage = new frmPackage(m_Project, DirNotRefDir, DirNotCheckDir, FileNotRefDir, FileNotCheckDir, FileInBoth);
      //m_frmPackage.ShowDialog();
      //m_frmPackage.Dispose();
    }

    private void butMakeReport_Click(object sender, EventArgs e)
    {
      //Do analysis
      foreach (var comp in SlynchyTrack.Project.Comparisons)
      {
        labStatus.Text = "Analyzing Comparison: " + comp.Name;
        Application.DoEvents();
        var anal = new Analysis(comp);
        SlynchyTrack.AnalysisList.Add(anal);
        anal.DoAnalysis();
        labStatus.Text = "Done Analyzing Comparison: " + comp.Name;
        Application.DoEvents();
      }
      labStatus.Text = "Finished Analysis";
      Application.DoEvents();

      DoReport();
    }

  }
}
