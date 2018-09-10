using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Soap;

namespace FileSlynchy
{
  /// <summary>
  /// Summary description for frmDirectoryDiff.
  /// </summary>
  public class FileSlynchy : System.Windows.Forms.Form
  {
    private System.Windows.Forms.TreeView tvRightTree;
    private System.Windows.Forms.TreeView tvLeftTree;
    private System.Windows.Forms.FolderBrowserDialog fbDialog;
    private System.Windows.Forms.Label labLoadProject;
    private System.Windows.Forms.ComboBox cbProject;
    private System.Windows.Forms.Label labLeftDirCount;
    private System.Windows.Forms.Label labRightDirCount;
    private System.Windows.Forms.Button butDeleteProject;
    private System.Windows.Forms.Button butReport;
    private System.Windows.Forms.Label labStatus;
    private System.Windows.Forms.Label labRightFileCount;
    private System.Windows.Forms.Label labLeftFileCount;
    private System.Windows.Forms.ImageList ilFolders;
    private System.ComponentModel.IContainer components;
    private System.Windows.Forms.Label labLeftDir;
    private System.Windows.Forms.Label labRightDir;

    private ArrayList m_Projects = new ArrayList();
    private frmExclusions m_frmExclusions;
    private frmReport m_frmReport;
    private Button butCreateProject;
    private ComboBox cboSelectLeftTree;
    private Label labLoadLeftTree;
    private Label labLoadRightTree;
    private ComboBox cboSelectRightTree;
    private Label labSelectComparison;
    private ComboBox cboSelectComparison;
    private Button butDeleteComparison;
    private Button butManageComparisons;
    private Button butSynch;

    #region "Form Properties"

    public ArrayList Projects
    {
      get { return m_Projects; }
      set { m_Projects = value; }
    }

    public string ProjectName
    {
      get
      {
        return cbProject.Text;
      }
      set
      {
        CurrProject = value;
        SetCurrentProject(CurrProject);
      }
    }

    public string CurrentComparisonName { get; set; }
    public Comparison CurrentComparison { get; set; }

    public SlynchyDirectoryTree CurrentLeftDirectoryTree { get; set; }
    public SlynchyDirectoryTree CurrentRightDirectoryTree { get; set; }

    #endregion

    private string CurrProject = "";
    private SlynchyProject Project;
    private List<Analysis> AnalysisList;

    public FileSlynchy()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

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

    private void FileSlynchy_Load(object sender, System.EventArgs e)
    {
      LoadProjectCombo();
    }

    private void FileSlynchy_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      SaveProject();
    }

    private void SaveProject()
    {
      SlynchyProjectFiles.SaveProject(SlynchyTrack.Project, SlynchyTrack.ProjectFileName);
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSlynchy));
      this.tvRightTree = new System.Windows.Forms.TreeView();
      this.ilFolders = new System.Windows.Forms.ImageList(this.components);
      this.tvLeftTree = new System.Windows.Forms.TreeView();
      this.fbDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.labLoadProject = new System.Windows.Forms.Label();
      this.cbProject = new System.Windows.Forms.ComboBox();
      this.labLeftDirCount = new System.Windows.Forms.Label();
      this.labRightDirCount = new System.Windows.Forms.Label();
      this.butDeleteProject = new System.Windows.Forms.Button();
      this.butReport = new System.Windows.Forms.Button();
      this.labStatus = new System.Windows.Forms.Label();
      this.labRightFileCount = new System.Windows.Forms.Label();
      this.labLeftFileCount = new System.Windows.Forms.Label();
      this.labLeftDir = new System.Windows.Forms.Label();
      this.labRightDir = new System.Windows.Forms.Label();
      this.butCreateProject = new System.Windows.Forms.Button();
      this.cboSelectLeftTree = new System.Windows.Forms.ComboBox();
      this.labLoadLeftTree = new System.Windows.Forms.Label();
      this.labLoadRightTree = new System.Windows.Forms.Label();
      this.cboSelectRightTree = new System.Windows.Forms.ComboBox();
      this.labSelectComparison = new System.Windows.Forms.Label();
      this.cboSelectComparison = new System.Windows.Forms.ComboBox();
      this.butDeleteComparison = new System.Windows.Forms.Button();
      this.butManageComparisons = new System.Windows.Forms.Button();
      this.butSynch = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tvRightTree
      // 
      this.tvRightTree.ImageIndex = 0;
      this.tvRightTree.ImageList = this.ilFolders;
      this.tvRightTree.Location = new System.Drawing.Point(712, 299);
      this.tvRightTree.Name = "tvRightTree";
      this.tvRightTree.SelectedImageIndex = 0;
      this.tvRightTree.Size = new System.Drawing.Size(674, 495);
      this.tvRightTree.TabIndex = 0;
      // 
      // ilFolders
      // 
      this.ilFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFolders.ImageStream")));
      this.ilFolders.TransparentColor = System.Drawing.Color.Transparent;
      this.ilFolders.Images.SetKeyName(0, "");
      this.ilFolders.Images.SetKeyName(1, "");
      this.ilFolders.Images.SetKeyName(2, "");
      // 
      // tvLeftTree
      // 
      this.tvLeftTree.ImageIndex = 0;
      this.tvLeftTree.ImageList = this.ilFolders;
      this.tvLeftTree.Location = new System.Drawing.Point(17, 299);
      this.tvLeftTree.Name = "tvLeftTree";
      this.tvLeftTree.SelectedImageIndex = 0;
      this.tvLeftTree.Size = new System.Drawing.Size(677, 495);
      this.tvLeftTree.TabIndex = 1;
      // 
      // labLoadProject
      // 
      this.labLoadProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labLoadProject.Location = new System.Drawing.Point(13, 18);
      this.labLoadProject.Name = "labLoadProject";
      this.labLoadProject.Size = new System.Drawing.Size(144, 28);
      this.labLoadProject.TabIndex = 8;
      this.labLoadProject.Text = "Load Project";
      // 
      // cbProject
      // 
      this.cbProject.Location = new System.Drawing.Point(154, 18);
      this.cbProject.Name = "cbProject";
      this.cbProject.Size = new System.Drawing.Size(371, 28);
      this.cbProject.TabIndex = 9;
      this.cbProject.SelectedIndexChanged += new System.EventHandler(this.cbProject_SelectedIndexChanged);
      // 
      // labLeftDirCount
      // 
      this.labLeftDirCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labLeftDirCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labLeftDirCount.Location = new System.Drawing.Point(17, 252);
      this.labLeftDirCount.Name = "labLeftDirCount";
      this.labLeftDirCount.Size = new System.Drawing.Size(140, 35);
      this.labLeftDirCount.TabIndex = 11;
      this.labLeftDirCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labRightDirCount
      // 
      this.labRightDirCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labRightDirCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labRightDirCount.Location = new System.Drawing.Point(712, 252);
      this.labRightDirCount.Name = "labRightDirCount";
      this.labRightDirCount.Size = new System.Drawing.Size(141, 35);
      this.labRightDirCount.TabIndex = 12;
      this.labRightDirCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // butDeleteProject
      // 
      this.butDeleteProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteProject.Location = new System.Drawing.Point(755, 13);
      this.butDeleteProject.Name = "butDeleteProject";
      this.butDeleteProject.Size = new System.Drawing.Size(179, 35);
      this.butDeleteProject.TabIndex = 13;
      this.butDeleteProject.Text = "Delete Project ";
      this.butDeleteProject.Click += new System.EventHandler(this.butDeleteProject_Click);
      // 
      // butReport
      // 
      this.butReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butReport.Location = new System.Drawing.Point(323, 67);
      this.butReport.Name = "butReport";
      this.butReport.Size = new System.Drawing.Size(128, 35);
      this.butReport.TabIndex = 17;
      this.butReport.Text = "Report... ";
      this.butReport.Click += new System.EventHandler(this.butReport_Click);
      // 
      // labStatus
      // 
      this.labStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labStatus.Location = new System.Drawing.Point(940, 13);
      this.labStatus.Name = "labStatus";
      this.labStatus.Size = new System.Drawing.Size(446, 35);
      this.labStatus.TabIndex = 18;
      this.labStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labRightFileCount
      // 
      this.labRightFileCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labRightFileCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labRightFileCount.Location = new System.Drawing.Point(859, 252);
      this.labRightFileCount.Name = "labRightFileCount";
      this.labRightFileCount.Size = new System.Drawing.Size(142, 35);
      this.labRightFileCount.TabIndex = 21;
      this.labRightFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labLeftFileCount
      // 
      this.labLeftFileCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labLeftFileCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labLeftFileCount.Location = new System.Drawing.Point(163, 252);
      this.labLeftFileCount.Name = "labLeftFileCount";
      this.labLeftFileCount.Size = new System.Drawing.Size(144, 35);
      this.labLeftFileCount.TabIndex = 22;
      this.labLeftFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labLeftDir
      // 
      this.labLeftDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labLeftDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labLeftDir.Location = new System.Drawing.Point(17, 205);
      this.labLeftDir.Name = "labLeftDir";
      this.labLeftDir.Size = new System.Drawing.Size(677, 35);
      this.labLeftDir.TabIndex = 27;
      this.labLeftDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labRightDir
      // 
      this.labRightDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labRightDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labRightDir.Location = new System.Drawing.Point(712, 205);
      this.labRightDir.Name = "labRightDir";
      this.labRightDir.Size = new System.Drawing.Size(674, 35);
      this.labRightDir.TabIndex = 28;
      this.labRightDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // butCreateProject
      // 
      this.butCreateProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butCreateProject.Location = new System.Drawing.Point(551, 13);
      this.butCreateProject.Name = "butCreateProject";
      this.butCreateProject.Size = new System.Drawing.Size(179, 35);
      this.butCreateProject.TabIndex = 30;
      this.butCreateProject.Text = "Create Project...";
      this.butCreateProject.Click += new System.EventHandler(this.butCreateProject_Click);
      // 
      // cboSelectLeftTree
      // 
      this.cboSelectLeftTree.Location = new System.Drawing.Point(184, 161);
      this.cboSelectLeftTree.Name = "cboSelectLeftTree";
      this.cboSelectLeftTree.Size = new System.Drawing.Size(510, 28);
      this.cboSelectLeftTree.TabIndex = 34;
      this.cboSelectLeftTree.SelectedIndexChanged += new System.EventHandler(this.cboSelectLeftTree_SelectedIndexChanged);
      // 
      // labLoadLeftTree
      // 
      this.labLoadLeftTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labLoadLeftTree.Location = new System.Drawing.Point(13, 161);
      this.labLoadLeftTree.Name = "labLoadLeftTree";
      this.labLoadLeftTree.Size = new System.Drawing.Size(161, 28);
      this.labLoadLeftTree.TabIndex = 35;
      this.labLoadLeftTree.Text = "Load Left Tree";
      // 
      // labLoadRightTree
      // 
      this.labLoadRightTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labLoadRightTree.Location = new System.Drawing.Point(707, 162);
      this.labLoadRightTree.Name = "labLoadRightTree";
      this.labLoadRightTree.Size = new System.Drawing.Size(169, 28);
      this.labLoadRightTree.TabIndex = 38;
      this.labLoadRightTree.Text = "Load Right Tree";
      // 
      // cboSelectRightTree
      // 
      this.cboSelectRightTree.Location = new System.Drawing.Point(882, 162);
      this.cboSelectRightTree.Name = "cboSelectRightTree";
      this.cboSelectRightTree.Size = new System.Drawing.Size(504, 28);
      this.cboSelectRightTree.TabIndex = 37;
      this.cboSelectRightTree.SelectedIndexChanged += new System.EventHandler(this.cboSelectRightTree_SelectedIndexChanged);
      // 
      // labSelectComparison
      // 
      this.labSelectComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labSelectComparison.Location = new System.Drawing.Point(9, 116);
      this.labSelectComparison.Name = "labSelectComparison";
      this.labSelectComparison.Size = new System.Drawing.Size(205, 28);
      this.labSelectComparison.TabIndex = 39;
      this.labSelectComparison.Text = "Select Comparison";
      // 
      // cboSelectComparison
      // 
      this.cboSelectComparison.Location = new System.Drawing.Point(227, 117);
      this.cboSelectComparison.Name = "cboSelectComparison";
      this.cboSelectComparison.Size = new System.Drawing.Size(371, 28);
      this.cboSelectComparison.TabIndex = 40;
      this.cboSelectComparison.SelectedIndexChanged += new System.EventHandler(this.cboSelectComparison_SelectedIndexChanged);
      // 
      // butDeleteComparison
      // 
      this.butDeleteComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteComparison.Location = new System.Drawing.Point(624, 111);
      this.butDeleteComparison.Name = "butDeleteComparison";
      this.butDeleteComparison.Size = new System.Drawing.Size(229, 35);
      this.butDeleteComparison.TabIndex = 42;
      this.butDeleteComparison.Text = "Delete Comparison";
      // 
      // butManageComparisons
      // 
      this.butManageComparisons.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butManageComparisons.Location = new System.Drawing.Point(18, 67);
      this.butManageComparisons.Name = "butManageComparisons";
      this.butManageComparisons.Size = new System.Drawing.Size(281, 35);
      this.butManageComparisons.TabIndex = 43;
      this.butManageComparisons.Text = "Manage Comparisons...";
      this.butManageComparisons.Click += new System.EventHandler(this.butManageComparisons_Click);
      // 
      // butSynch
      // 
      this.butSynch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butSynch.Location = new System.Drawing.Point(476, 67);
      this.butSynch.Name = "butSynch";
      this.butSynch.Size = new System.Drawing.Size(232, 35);
      this.butSynch.TabIndex = 44;
      this.butSynch.Text = "Synchronize... ";
      this.butSynch.Click += new System.EventHandler(this.butSynch_Click);
      // 
      // FileSlynchy
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
      this.ClientSize = new System.Drawing.Size(1402, 807);
      this.Controls.Add(this.butSynch);
      this.Controls.Add(this.butManageComparisons);
      this.Controls.Add(this.butDeleteComparison);
      this.Controls.Add(this.cboSelectComparison);
      this.Controls.Add(this.labSelectComparison);
      this.Controls.Add(this.labLoadRightTree);
      this.Controls.Add(this.cboSelectRightTree);
      this.Controls.Add(this.labLoadLeftTree);
      this.Controls.Add(this.cboSelectLeftTree);
      this.Controls.Add(this.butCreateProject);
      this.Controls.Add(this.labRightDir);
      this.Controls.Add(this.labLeftDir);
      this.Controls.Add(this.labLeftFileCount);
      this.Controls.Add(this.labRightFileCount);
      this.Controls.Add(this.labStatus);
      this.Controls.Add(this.butReport);
      this.Controls.Add(this.butDeleteProject);
      this.Controls.Add(this.labRightDirCount);
      this.Controls.Add(this.labLeftDirCount);
      this.Controls.Add(this.cbProject);
      this.Controls.Add(this.labLoadProject);
      this.Controls.Add(this.tvLeftTree);
      this.Controls.Add(this.tvRightTree);
      this.Name = "FileSlynchy";
      this.Text = "FileSlynchy - Compare and Sync Directories";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.FileSlynchy_Closing);
      this.Load += new System.EventHandler(this.FileSlynchy_Load);
      this.ResumeLayout(false);

    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.Run(new FileSlynchy());
    }

    private bool SetCurrentProject(string projectFileName)
    {
      int ItemIndex = cbProject.FindStringExact(projectFileName, -1);
      if (ItemIndex > -1)
      {
        cbProject.SelectedIndex = ItemIndex;
        SetProjectFields();
        return true;
      }
      return false;
    }

    private void SetProjectFields()
    {
      ClearFormFields();

      //Load comparison combo
      cboSelectComparison.Items.Clear();
      foreach (var comp in SlynchyTrack.Project.Comparisons)
      {
        cboSelectComparison.Items.Add(comp.Name);
      }
    }

    private void butCreateProject_Click(object sender, EventArgs e)
    {
      var frmCreateProject = new CreateProject();
      frmCreateProject.ShowDialog();
      var ProjectName = frmCreateProject.ProjectName;
      var ProjectFileName = frmCreateProject.ProjectFile + ".slynchy";
      frmCreateProject.Dispose();
      LoadProjectCombo();
      SetCurrentProject(ProjectFileName);
    }

    private void ClearFormFields()
    {
      labStatus.Text = "";

      labLeftDir.Text = "";
      labLeftDirCount.Text = "";
      labLeftFileCount.Text = "";
      tvLeftTree.Nodes.Clear();

      labRightDir.Text = "";
      labRightDirCount.Text = "";
      labRightFileCount.Text = "";
      tvRightTree.Nodes.Clear();
    }

    public void LoadProjectCombo()
    {
      cbProject.SelectedIndex = -1;
      cbProject.Items.Clear();
      SlynchyProjectFiles.GetFiles();
      for (int i = 0; i < SlynchyProjectFiles.ProjectFiles.Count; i++)
      {
        cbProject.Items.Add(SlynchyProjectFiles.ProjectFiles[i]);
      }
    }

    private void cbProject_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      //This will always be an existing project on the list, populate associated fields
      SlynchyProjectFiles.SaveProject(SlynchyTrack.Project, SlynchyTrack.ProjectFileName);
      if (!String.IsNullOrEmpty(cbProject.Text))
      {
        SlynchyProjectFiles.LoadProject(cbProject.Text);
        CurrProject = cbProject.Text;
        Project = SlynchyTrack.Project;
        SetProjectFields();
      }
    }

    private void LoadComparisonControls()
    {
      if (CurrentComparison != null)
      {
        cboSelectLeftTree.Items.Clear();
        foreach (var tree in CurrentComparison.Directories)
        {
          cboSelectLeftTree.Items.Add(tree.Name);
        }
        cboSelectRightTree.Items.Clear();
        foreach (var tree in CurrentComparison.Directories)
        {
          cboSelectRightTree.Items.Add(tree.Name);
        }
      }
    }

    private void butDeleteProject_Click(object sender, System.EventArgs e)
    {
      var ProjectFileName = cbProject.Text;

      var DidDelete = SlynchyProjectFiles.DeleteProjectFile(ProjectFileName);
      if (DidDelete)
      {
        SlynchyTrack.Project = null;
        SlynchyTrack.ProjectFileName = "";
        ClearFormFields();
        LoadProjectCombo();
      }
    }

    private void butReport_Click(object sender, System.EventArgs e)
    {
      m_frmReport = new frmReport();
      m_frmReport.ShowDialog();
      m_frmReport.Dispose();
    }

    private void cboSelectComparison_SelectedIndexChanged(object sender, EventArgs e)
    {
      CurrentComparisonName = cboSelectComparison.Text;
      CurrentComparison = SlynchyTrack.Project.FindComparison(CurrentComparisonName);
      LoadComparisonControls();
    }

    private void cboSelectLeftTree_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      tvLeftTree.Nodes.Clear();
      Application.DoEvents();
      var CurrentLeftTreeName = cboSelectLeftTree.Text;
      CurrentLeftDirectoryTree = CurrentComparison.FindTree(CurrentLeftTreeName);
      CurrentLeftDirectoryTree.CopyToTreeControl(tvLeftTree, labLeftDir, labLeftDirCount, labLeftDirCount, false);
      this.Cursor = Cursors.Arrow;
      Application.DoEvents();
    }

    private void cboSelectRightTree_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      tvRightTree.Nodes.Clear();
      Application.DoEvents();
      var CurrentRightTreeName = cboSelectRightTree.Text;
      CurrentRightDirectoryTree = CurrentComparison.FindTree(CurrentRightTreeName);
      CurrentRightDirectoryTree.CopyToTreeControl(tvRightTree, 
        labRightDir, labRightDirCount, labRightDirCount, false);
      this.Cursor = Cursors.Arrow;
      Application.DoEvents();
    }

    private void butManageComparisons_Click(object sender, EventArgs e)
    {
      var frmManage = new EditComparisons();
      frmManage.ShowDialog();
      frmManage.Dispose();
    }

    private void butSynch_Click(object sender, EventArgs e)
    {
      if (AnalysisList == null) AnalysisList = new List<Analysis>();
      var frmSynchDash = new SynchWorkbench();
      frmSynchDash.ShowDialog();
      frmSynchDash.Dispose();

      //Clear the analysis, since sync probably changed the trees
      AnalysisList = new List<Analysis>();
    }
  }
}
