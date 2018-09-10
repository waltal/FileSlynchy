using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace FileSlynchy
{
  /// <summary>
  /// Summary description for frmExclusions.
  /// </summary>
  public class frmExclusions : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Label labProjectName;
    private System.Windows.Forms.ListBox lbPathExclude;
    private System.Windows.Forms.ListBox lbDirExclude;
    private System.Windows.Forms.TreeView tvDirs;
    private System.Windows.Forms.Button butDone;
    private System.Windows.Forms.Button butAddDir;
    private System.Windows.Forms.Button butAddPath;
    private System.Windows.Forms.Button butDeleteDir;
    private System.Windows.Forms.Button butDeletePath;
    private System.Windows.Forms.Label labExcludedDirNames;
    private System.Windows.Forms.Label labExcludedRelDirPaths;
    private System.Windows.Forms.TabControl tabExclusionType;
    private System.Windows.Forms.TabPage tabDirExclusions;
    private System.Windows.Forms.TabPage tabFileExclusions;
    private System.Windows.Forms.Button butAddFileType;
    private System.Windows.Forms.Button butDeleteFileType;
    private System.Windows.Forms.ListBox lbFileExclude;
    private System.Windows.Forms.Button butAddFile;
    private System.Windows.Forms.Label labExcludedFileNames;
    private System.Windows.Forms.Button butDeleteFile;
    private System.Windows.Forms.ListBox lbFilePathExclude;
    private System.Windows.Forms.Button butAddFilePath;
    private System.Windows.Forms.Label labExcludedRelFilePaths;
    private System.Windows.Forms.Button butDeleteFilePath;
    private System.Windows.Forms.Label labSelection;
    private System.Windows.Forms.ListBox lbFileType;
    private System.Windows.Forms.TabPage tabFileType;
    private System.Windows.Forms.ImageList ilFolders;
    private System.Windows.Forms.Label labExcludeFilesInRelDirs;
    private System.Windows.Forms.ListBox lbDirFileExclude;
    private System.Windows.Forms.Button butAddDirFileExclude;
    private System.Windows.Forms.Button butDeleteDirFileExclude;
    private System.ComponentModel.IContainer components;

    private Label labComparisonName;
    private Label labTreeName;

    public SlynchyProject Project;
    public Comparison CurrentComparison;
    private Label labProject;
    private Label label1;
    private Label label2;
    public SlynchyDirectoryTree CurrentTree;

    public frmExclusions(SlynchyProject project, Comparison comparison, SlynchyDirectoryTree currentTree)
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      Project = project;
      CurrentComparison = comparison;
      CurrentTree = currentTree;
      CurrentTree.ScanTree();

      labProjectName.Text = Project.Name;
      labComparisonName.Text = CurrentComparison.Name;
      labTreeName.Text = CurrentTree.Name;

      CurrentTree.CopyToTreeControl(tvDirs, false);

      LoadDirExclusions(CurrentTree.Spec.PathNameExcludes,
        CurrentTree.Spec.PathRelativeExcludes);
      LoadFileType(CurrentTree.Spec.IncludedFileExtensions);
      LoadFileExclusions(CurrentTree.Spec.FileNameExcludes,
        CurrentTree.Spec.FilePathExcludes);
      LoadDirFileExclusions(CurrentTree.Spec.DirFileExcludes);
    }

    private void LoadDirExclusions(List<string> dirExclude, List<string> pathExclude)
    {
      lbDirExclude.Items.Clear();
      foreach (var item in dirExclude)
      {
        lbDirExclude.Items.Add(item);
      }

      lbPathExclude.Items.Clear();
      foreach (var item in pathExclude)
      {
        lbPathExclude.Items.Add(item);
      }
    }

    private void LoadFileType(List<string> fileTypeList)
    {
      lbFileType.Items.Clear();
      foreach (var item in fileTypeList)
      {
        lbFileType.Items.Add(item);
      }
    }

    private void LoadDirFileExclusions(List<string> dirFileList)
    {
      lbDirFileExclude.Items.Clear();
      foreach (var item in dirFileList)
      {
        lbDirFileExclude.Items.Add(item);
      }
    }

    private void LoadFileExclusions(List<string> fileNameExclude, List<string> filePathExclude)
    {
      lbFileExclude.Items.Clear();
      foreach(var item in fileNameExclude)
      {
        lbFileExclude.Items.Add(item);
      }

      lbFilePathExclude.Items.Clear();
      foreach(var item in filePathExclude)
      {
        lbFilePathExclude.Items.Add(item);
      }
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExclusions));
      this.tvDirs = new System.Windows.Forms.TreeView();
      this.ilFolders = new System.Windows.Forms.ImageList(this.components);
      this.labProjectName = new System.Windows.Forms.Label();
      this.lbPathExclude = new System.Windows.Forms.ListBox();
      this.lbDirExclude = new System.Windows.Forms.ListBox();
      this.butDone = new System.Windows.Forms.Button();
      this.butAddDir = new System.Windows.Forms.Button();
      this.butAddPath = new System.Windows.Forms.Button();
      this.butDeleteDir = new System.Windows.Forms.Button();
      this.butDeletePath = new System.Windows.Forms.Button();
      this.labExcludedDirNames = new System.Windows.Forms.Label();
      this.labExcludedRelDirPaths = new System.Windows.Forms.Label();
      this.tabExclusionType = new System.Windows.Forms.TabControl();
      this.tabDirExclusions = new System.Windows.Forms.TabPage();
      this.tabFileType = new System.Windows.Forms.TabPage();
      this.butDeleteDirFileExclude = new System.Windows.Forms.Button();
      this.butAddDirFileExclude = new System.Windows.Forms.Button();
      this.lbDirFileExclude = new System.Windows.Forms.ListBox();
      this.labExcludeFilesInRelDirs = new System.Windows.Forms.Label();
      this.lbFileType = new System.Windows.Forms.ListBox();
      this.labSelection = new System.Windows.Forms.Label();
      this.butAddFileType = new System.Windows.Forms.Button();
      this.butDeleteFileType = new System.Windows.Forms.Button();
      this.tabFileExclusions = new System.Windows.Forms.TabPage();
      this.butDeleteFilePath = new System.Windows.Forms.Button();
      this.labExcludedRelFilePaths = new System.Windows.Forms.Label();
      this.butAddFilePath = new System.Windows.Forms.Button();
      this.lbFilePathExclude = new System.Windows.Forms.ListBox();
      this.butDeleteFile = new System.Windows.Forms.Button();
      this.labExcludedFileNames = new System.Windows.Forms.Label();
      this.butAddFile = new System.Windows.Forms.Button();
      this.lbFileExclude = new System.Windows.Forms.ListBox();
      this.labComparisonName = new System.Windows.Forms.Label();
      this.labTreeName = new System.Windows.Forms.Label();
      this.labProject = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tabExclusionType.SuspendLayout();
      this.tabDirExclusions.SuspendLayout();
      this.tabFileType.SuspendLayout();
      this.tabFileExclusions.SuspendLayout();
      this.SuspendLayout();
      // 
      // tvDirs
      // 
      this.tvDirs.ImageIndex = 0;
      this.tvDirs.ImageList = this.ilFolders;
      this.tvDirs.Location = new System.Drawing.Point(12, 193);
      this.tvDirs.Name = "tvDirs";
      this.tvDirs.SelectedImageIndex = 0;
      this.tvDirs.Size = new System.Drawing.Size(632, 629);
      this.tvDirs.TabIndex = 0;
      // 
      // ilFolders
      // 
      this.ilFolders.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFolders.ImageStream")));
      this.ilFolders.TransparentColor = System.Drawing.Color.Transparent;
      this.ilFolders.Images.SetKeyName(0, "");
      this.ilFolders.Images.SetKeyName(1, "");
      this.ilFolders.Images.SetKeyName(2, "");
      // 
      // labProjectName
      // 
      this.labProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labProjectName.Location = new System.Drawing.Point(254, 14);
      this.labProjectName.Name = "labProjectName";
      this.labProjectName.Size = new System.Drawing.Size(992, 36);
      this.labProjectName.TabIndex = 1;
      this.labProjectName.Text = "labProjectName";
      this.labProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lbPathExclude
      // 
      this.lbPathExclude.ItemHeight = 20;
      this.lbPathExclude.Location = new System.Drawing.Point(16, 270);
      this.lbPathExclude.Name = "lbPathExclude";
      this.lbPathExclude.Size = new System.Drawing.Size(563, 204);
      this.lbPathExclude.TabIndex = 2;
      // 
      // lbDirExclude
      // 
      this.lbDirExclude.ItemHeight = 20;
      this.lbDirExclude.Location = new System.Drawing.Point(16, 51);
      this.lbDirExclude.Name = "lbDirExclude";
      this.lbDirExclude.Size = new System.Drawing.Size(456, 144);
      this.lbDirExclude.TabIndex = 3;
      // 
      // butDone
      // 
      this.butDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDone.Location = new System.Drawing.Point(1253, 784);
      this.butDone.Name = "butDone";
      this.butDone.Size = new System.Drawing.Size(115, 35);
      this.butDone.TabIndex = 5;
      this.butDone.Text = "Done ";
      this.butDone.Click += new System.EventHandler(this.butDone_Click);
      // 
      // butAddDir
      // 
      this.butAddDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butAddDir.Location = new System.Drawing.Point(16, 7);
      this.butAddDir.Name = "butAddDir";
      this.butAddDir.Size = new System.Drawing.Size(115, 35);
      this.butAddDir.TabIndex = 6;
      this.butAddDir.Text = "==> Add ";
      this.butAddDir.Click += new System.EventHandler(this.butAddDir_Click);
      // 
      // butAddPath
      // 
      this.butAddPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butAddPath.Location = new System.Drawing.Point(16, 227);
      this.butAddPath.Name = "butAddPath";
      this.butAddPath.Size = new System.Drawing.Size(115, 35);
      this.butAddPath.TabIndex = 7;
      this.butAddPath.Text = "==> Add ";
      this.butAddPath.Click += new System.EventHandler(this.butAddPath_Click);
      // 
      // butDeleteDir
      // 
      this.butDeleteDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteDir.Location = new System.Drawing.Point(464, 7);
      this.butDeleteDir.Name = "butDeleteDir";
      this.butDeleteDir.Size = new System.Drawing.Size(115, 35);
      this.butDeleteDir.TabIndex = 8;
      this.butDeleteDir.Text = "Delete ";
      this.butDeleteDir.Click += new System.EventHandler(this.butDeleteDir_Click);
      // 
      // butDeletePath
      // 
      this.butDeletePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeletePath.Location = new System.Drawing.Point(464, 480);
      this.butDeletePath.Name = "butDeletePath";
      this.butDeletePath.Size = new System.Drawing.Size(115, 35);
      this.butDeletePath.TabIndex = 10;
      this.butDeletePath.Text = "Delete ";
      this.butDeletePath.Click += new System.EventHandler(this.butDeletePath_Click);
      // 
      // labExcludedDirNames
      // 
      this.labExcludedDirNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labExcludedDirNames.Location = new System.Drawing.Point(144, 7);
      this.labExcludedDirNames.Name = "labExcludedDirNames";
      this.labExcludedDirNames.Size = new System.Drawing.Size(312, 37);
      this.labExcludedDirNames.TabIndex = 11;
      this.labExcludedDirNames.Text = "Excluded Directory Names";
      this.labExcludedDirNames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.labExcludedDirNames.Click += new System.EventHandler(this.labExcludedDirNames_Click);
      // 
      // labExcludedRelDirPaths
      // 
      this.labExcludedRelDirPaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labExcludedRelDirPaths.Location = new System.Drawing.Point(144, 227);
      this.labExcludedRelDirPaths.Name = "labExcludedRelDirPaths";
      this.labExcludedRelDirPaths.Size = new System.Drawing.Size(358, 36);
      this.labExcludedRelDirPaths.TabIndex = 12;
      this.labExcludedRelDirPaths.Text = "Excluded Relative Directory Paths";
      this.labExcludedRelDirPaths.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tabExclusionType
      // 
      this.tabExclusionType.Controls.Add(this.tabDirExclusions);
      this.tabExclusionType.Controls.Add(this.tabFileType);
      this.tabExclusionType.Controls.Add(this.tabFileExclusions);
      this.tabExclusionType.Location = new System.Drawing.Point(652, 186);
      this.tabExclusionType.Name = "tabExclusionType";
      this.tabExclusionType.SelectedIndex = 0;
      this.tabExclusionType.Size = new System.Drawing.Size(800, 592);
      this.tabExclusionType.TabIndex = 13;
      // 
      // tabDirExclusions
      // 
      this.tabDirExclusions.Controls.Add(this.butAddDir);
      this.tabDirExclusions.Controls.Add(this.labExcludedDirNames);
      this.tabDirExclusions.Controls.Add(this.butDeleteDir);
      this.tabDirExclusions.Controls.Add(this.lbDirExclude);
      this.tabDirExclusions.Controls.Add(this.lbPathExclude);
      this.tabDirExclusions.Controls.Add(this.butAddPath);
      this.tabDirExclusions.Controls.Add(this.labExcludedRelDirPaths);
      this.tabDirExclusions.Controls.Add(this.butDeletePath);
      this.tabDirExclusions.Location = new System.Drawing.Point(4, 29);
      this.tabDirExclusions.Name = "tabDirExclusions";
      this.tabDirExclusions.Size = new System.Drawing.Size(792, 559);
      this.tabDirExclusions.TabIndex = 0;
      this.tabDirExclusions.Text = "Directories";
      // 
      // tabFileType
      // 
      this.tabFileType.Controls.Add(this.butDeleteDirFileExclude);
      this.tabFileType.Controls.Add(this.butAddDirFileExclude);
      this.tabFileType.Controls.Add(this.lbDirFileExclude);
      this.tabFileType.Controls.Add(this.labExcludeFilesInRelDirs);
      this.tabFileType.Controls.Add(this.lbFileType);
      this.tabFileType.Controls.Add(this.labSelection);
      this.tabFileType.Controls.Add(this.butAddFileType);
      this.tabFileType.Controls.Add(this.butDeleteFileType);
      this.tabFileType.Location = new System.Drawing.Point(4, 29);
      this.tabFileType.Name = "tabFileType";
      this.tabFileType.Size = new System.Drawing.Size(792, 559);
      this.tabFileType.TabIndex = 2;
      this.tabFileType.Text = "File Type and Files In Directory";
      // 
      // butDeleteDirFileExclude
      // 
      this.butDeleteDirFileExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteDirFileExclude.Location = new System.Drawing.Point(653, 270);
      this.butDeleteDirFileExclude.Name = "butDeleteDirFileExclude";
      this.butDeleteDirFileExclude.Size = new System.Drawing.Size(115, 35);
      this.butDeleteDirFileExclude.TabIndex = 27;
      this.butDeleteDirFileExclude.Text = "Delete ";
      this.butDeleteDirFileExclude.Click += new System.EventHandler(this.butDeleteDirFileExclude_Click);
      // 
      // butAddDirFileExclude
      // 
      this.butAddDirFileExclude.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butAddDirFileExclude.Location = new System.Drawing.Point(24, 270);
      this.butAddDirFileExclude.Name = "butAddDirFileExclude";
      this.butAddDirFileExclude.Size = new System.Drawing.Size(115, 35);
      this.butAddDirFileExclude.TabIndex = 26;
      this.butAddDirFileExclude.Text = "==> Add ";
      this.butAddDirFileExclude.Click += new System.EventHandler(this.butAddDirFileExclude_Click);
      // 
      // lbDirFileExclude
      // 
      this.lbDirFileExclude.ItemHeight = 20;
      this.lbDirFileExclude.Location = new System.Drawing.Point(16, 314);
      this.lbDirFileExclude.Name = "lbDirFileExclude";
      this.lbDirFileExclude.Size = new System.Drawing.Size(752, 204);
      this.lbDirFileExclude.TabIndex = 25;
      // 
      // labExcludeFilesInRelDirs
      // 
      this.labExcludeFilesInRelDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labExcludeFilesInRelDirs.Location = new System.Drawing.Point(153, 269);
      this.labExcludeFilesInRelDirs.Name = "labExcludeFilesInRelDirs";
      this.labExcludeFilesInRelDirs.Size = new System.Drawing.Size(481, 36);
      this.labExcludeFilesInRelDirs.TabIndex = 24;
      this.labExcludeFilesInRelDirs.Text = "Exclude Files in These Relative Directories";
      this.labExcludeFilesInRelDirs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lbFileType
      // 
      this.lbFileType.ItemHeight = 20;
      this.lbFileType.Location = new System.Drawing.Point(200, 66);
      this.lbFileType.Name = "lbFileType";
      this.lbFileType.Size = new System.Drawing.Size(184, 144);
      this.lbFileType.TabIndex = 14;
      // 
      // labSelection
      // 
      this.labSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labSelection.Location = new System.Drawing.Point(19, 19);
      this.labSelection.Name = "labSelection";
      this.labSelection.Size = new System.Drawing.Size(398, 36);
      this.labSelection.TabIndex = 17;
      this.labSelection.Text = "Include File Types ";
      this.labSelection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // butAddFileType
      // 
      this.butAddFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butAddFileType.Location = new System.Drawing.Point(68, 66);
      this.butAddFileType.Name = "butAddFileType";
      this.butAddFileType.Size = new System.Drawing.Size(115, 35);
      this.butAddFileType.TabIndex = 15;
      this.butAddFileType.Text = "==> Add ";
      this.butAddFileType.Click += new System.EventHandler(this.butAddFileType_Click);
      // 
      // butDeleteFileType
      // 
      this.butDeleteFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteFileType.Location = new System.Drawing.Point(400, 66);
      this.butDeleteFileType.Name = "butDeleteFileType";
      this.butDeleteFileType.Size = new System.Drawing.Size(115, 36);
      this.butDeleteFileType.TabIndex = 16;
      this.butDeleteFileType.Text = "Delete ";
      this.butDeleteFileType.Click += new System.EventHandler(this.butDeleteFileType_Click);
      // 
      // tabFileExclusions
      // 
      this.tabFileExclusions.Controls.Add(this.butDeleteFilePath);
      this.tabFileExclusions.Controls.Add(this.labExcludedRelFilePaths);
      this.tabFileExclusions.Controls.Add(this.butAddFilePath);
      this.tabFileExclusions.Controls.Add(this.lbFilePathExclude);
      this.tabFileExclusions.Controls.Add(this.butDeleteFile);
      this.tabFileExclusions.Controls.Add(this.labExcludedFileNames);
      this.tabFileExclusions.Controls.Add(this.butAddFile);
      this.tabFileExclusions.Controls.Add(this.lbFileExclude);
      this.tabFileExclusions.Location = new System.Drawing.Point(4, 29);
      this.tabFileExclusions.Name = "tabFileExclusions";
      this.tabFileExclusions.Size = new System.Drawing.Size(792, 559);
      this.tabFileExclusions.TabIndex = 1;
      this.tabFileExclusions.Text = "Files";
      // 
      // butDeleteFilePath
      // 
      this.butDeleteFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteFilePath.Location = new System.Drawing.Point(456, 219);
      this.butDeleteFilePath.Name = "butDeleteFilePath";
      this.butDeleteFilePath.Size = new System.Drawing.Size(115, 35);
      this.butDeleteFilePath.TabIndex = 25;
      this.butDeleteFilePath.Text = "Delete ";
      this.butDeleteFilePath.Click += new System.EventHandler(this.butDeleteFilePath_Click);
      // 
      // labExcludedRelFilePaths
      // 
      this.labExcludedRelFilePaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labExcludedRelFilePaths.Location = new System.Drawing.Point(136, 219);
      this.labExcludedRelFilePaths.Name = "labExcludedRelFilePaths";
      this.labExcludedRelFilePaths.Size = new System.Drawing.Size(312, 37);
      this.labExcludedRelFilePaths.TabIndex = 24;
      this.labExcludedRelFilePaths.Text = "Excluded Relative File Paths ";
      this.labExcludedRelFilePaths.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // butAddFilePath
      // 
      this.butAddFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butAddFilePath.Location = new System.Drawing.Point(16, 219);
      this.butAddFilePath.Name = "butAddFilePath";
      this.butAddFilePath.Size = new System.Drawing.Size(115, 35);
      this.butAddFilePath.TabIndex = 23;
      this.butAddFilePath.Text = "==> Add ";
      this.butAddFilePath.Click += new System.EventHandler(this.butAddFilePath_Click);
      // 
      // lbFilePathExclude
      // 
      this.lbFilePathExclude.ItemHeight = 20;
      this.lbFilePathExclude.Location = new System.Drawing.Point(8, 263);
      this.lbFilePathExclude.Name = "lbFilePathExclude";
      this.lbFilePathExclude.Size = new System.Drawing.Size(768, 264);
      this.lbFilePathExclude.TabIndex = 22;
      // 
      // butDeleteFile
      // 
      this.butDeleteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteFile.Location = new System.Drawing.Point(388, 7);
      this.butDeleteFile.Name = "butDeleteFile";
      this.butDeleteFile.Size = new System.Drawing.Size(115, 35);
      this.butDeleteFile.TabIndex = 21;
      this.butDeleteFile.Text = "Delete ";
      this.butDeleteFile.Click += new System.EventHandler(this.butDeleteFile_Click);
      // 
      // labExcludedFileNames
      // 
      this.labExcludedFileNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labExcludedFileNames.Location = new System.Drawing.Point(144, 7);
      this.labExcludedFileNames.Name = "labExcludedFileNames";
      this.labExcludedFileNames.Size = new System.Drawing.Size(238, 37);
      this.labExcludedFileNames.TabIndex = 20;
      this.labExcludedFileNames.Text = "Excluded File Names";
      this.labExcludedFileNames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // butAddFile
      // 
      this.butAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butAddFile.Location = new System.Drawing.Point(16, 7);
      this.butAddFile.Name = "butAddFile";
      this.butAddFile.Size = new System.Drawing.Size(115, 35);
      this.butAddFile.TabIndex = 19;
      this.butAddFile.Text = "==> Add ";
      this.butAddFile.Click += new System.EventHandler(this.butAddFile_Click);
      // 
      // lbFileExclude
      // 
      this.lbFileExclude.ItemHeight = 20;
      this.lbFileExclude.Location = new System.Drawing.Point(16, 51);
      this.lbFileExclude.Name = "lbFileExclude";
      this.lbFileExclude.Size = new System.Drawing.Size(487, 144);
      this.lbFileExclude.TabIndex = 18;
      // 
      // labComparisonName
      // 
      this.labComparisonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labComparisonName.Location = new System.Drawing.Point(254, 65);
      this.labComparisonName.Name = "labComparisonName";
      this.labComparisonName.Size = new System.Drawing.Size(992, 36);
      this.labComparisonName.TabIndex = 14;
      this.labComparisonName.Text = "labComparisonName";
      this.labComparisonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labTreeName
      // 
      this.labTreeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labTreeName.Location = new System.Drawing.Point(254, 118);
      this.labTreeName.Name = "labTreeName";
      this.labTreeName.Size = new System.Drawing.Size(992, 36);
      this.labTreeName.TabIndex = 15;
      this.labTreeName.Text = "labTreeName";
      this.labTreeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labProject
      // 
      this.labProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labProject.Location = new System.Drawing.Point(12, 14);
      this.labProject.Name = "labProject";
      this.labProject.Size = new System.Drawing.Size(236, 36);
      this.labProject.TabIndex = 16;
      this.labProject.Text = "Project: ";
      this.labProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(12, 65);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(236, 36);
      this.label1.TabIndex = 17;
      this.label1.Text = "Comparison: ";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label2
      // 
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(12, 118);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(236, 36);
      this.label2.TabIndex = 18;
      this.label2.Text = "Tree: ";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // frmExclusions
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
      this.ClientSize = new System.Drawing.Size(1496, 839);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.labProject);
      this.Controls.Add(this.labTreeName);
      this.Controls.Add(this.labComparisonName);
      this.Controls.Add(this.tabExclusionType);
      this.Controls.Add(this.butDone);
      this.Controls.Add(this.labProjectName);
      this.Controls.Add(this.tvDirs);
      this.Name = "frmExclusions";
      this.Text = "frmExclusions";
      this.tabExclusionType.ResumeLayout(false);
      this.tabDirExclusions.ResumeLayout(false);
      this.tabFileType.ResumeLayout(false);
      this.tabFileExclusions.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    #endregion

    private void butDone_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }

    private void RefreshTree()
    {
      CurrentTree.ReScanExclusions();
      tvDirs.Nodes.Clear();
      CurrentTree.CopyToTreeControl(tvDirs, false);
    }

    private void butAddDir_Click(object sender, System.EventArgs e)
    {
      if (!tvDirs.SelectedNode.Text.StartsWith("\\")) return;
      //Directory name, not relative path
      bool AddToDisplay = false;
      AddToDisplay = AddToList(CurrentTree.Spec.PathNameExcludes, tvDirs.SelectedNode.Text);
      if (AddToDisplay) {
        lbDirExclude.Items.Add(tvDirs.SelectedNode.Text);
        RefreshTree();
      }
    }

    private void butDeleteDir_Click(object sender, System.EventArgs e)
    {
      if (!tvDirs.SelectedNode.Text.StartsWith("\\")) return;
      //Directory name, not relative path
      if (lbDirExclude.SelectedIndex < 0) return;
      CurrentTree.Spec.PathNameExcludes.Remove(lbDirExclude.SelectedItem.ToString());
      lbDirExclude.Items.RemoveAt(lbDirExclude.SelectedIndex);
      RefreshTree();
    }

    private void butAddPath_Click(object sender, System.EventArgs e)
    {
      //This list seems redundant and misleading.  The relative path exclusion is the same, except the directory is not shown.
      if (!tvDirs.SelectedNode.Text.StartsWith("\\")) return;
      //relative path
      bool AddToDisplay = false;
      string RelDir = "";
      RelDir = BuildRelDirPath((FileTreeNode)tvDirs.SelectedNode, CurrentTree.RootDirectoryPath);
      AddToDisplay = AddToList(CurrentTree.Spec.PathRelativeExcludes, RelDir);
      if (AddToDisplay) {
        lbPathExclude.Items.Add(RelDir);
        RefreshTree();
      }
    }

    private void butDeletePath_Click(object sender, System.EventArgs e)
    {
      if (!tvDirs.SelectedNode.Text.StartsWith("\\")) return;
      //relative path
      if (lbPathExclude.SelectedIndex < 0) return;
      CurrentTree.Spec.PathRelativeExcludes.Remove(lbPathExclude.SelectedItem.ToString());
      lbPathExclude.Items.RemoveAt(lbPathExclude.SelectedIndex);
      RefreshTree();
    }

    protected string BuildRelFilePath(FileTreeNode aNode, string BaseDir)
    {
      string EndDir = aNode.Text;
      string StartDir = BuildDirPath((FileTreeNode)aNode.Parent).Substring(BaseDir.Length);
      return StartDir + "\\" + EndDir;
    }

    protected string BuildRelDirPath(FileTreeNode aNode, string BaseDir)
    {
      return BuildDirPath(aNode).Substring(BaseDir.Length);
    }

    protected string BuildDirPath(FileTreeNode aNode)
    {
      FileTreeNode theNode = aNode;
      string Dir = "";

      while (theNode != null)
      {
        Dir = theNode.Text + Dir;
        theNode = (FileTreeNode)theNode.Parent;
      }
      return Dir;
    }

    private bool AddToList(List<string> aList, string listItem)
    {
      //return true if item added, false if item already in list
      if (aList.Contains(listItem)) return false;
      aList.Add(listItem);
      return true;
    }

    private void butAddFile_Click(object sender, System.EventArgs e)
    {
      if (tvDirs.SelectedNode.Text.StartsWith("\\")) return;

      bool AddToDisplay = false;
      AddToDisplay = AddToList(CurrentTree.Spec.FileNameExcludes, tvDirs.SelectedNode.Text);
      if (AddToDisplay) {
        lbFileExclude.Items.Add(tvDirs.SelectedNode.Text);
        RefreshTree();
      }
    }

    private void butDeleteFile_Click(object sender, System.EventArgs e)
    {
      if (lbFileExclude.SelectedIndex < 0) return;
      CurrentTree.Spec.FileNameExcludes.Remove(lbFileExclude.SelectedItem.ToString());
      lbFileExclude.Items.RemoveAt(lbFileExclude.SelectedIndex);
      RefreshTree();
    }

    private void butAddFilePath_Click(object sender, System.EventArgs e)
    {
      //Excluded relative file paths, FilePathExcludes
      if (tvDirs.SelectedNode.Text.StartsWith("\\")) return;

      bool AddToDisplay = false;
      string RelFilePath = "";
      RelFilePath = BuildRelFilePath((FileTreeNode)tvDirs.SelectedNode, CurrentTree.RootDirectoryPath);
      AddToDisplay = AddToList(CurrentTree.Spec.FilePathExcludes, RelFilePath);
      if (AddToDisplay) {
        lbFilePathExclude.Items.Add(RelFilePath);
        RefreshTree();
      }
    }

    private void butDeleteFilePath_Click(object sender, System.EventArgs e)
    {
      if (lbFilePathExclude.SelectedIndex < 0) return;
      CurrentTree.Spec.FilePathExcludes.Remove(lbFilePathExclude.SelectedItem.ToString());
      lbFilePathExclude.Items.RemoveAt(lbFilePathExclude.SelectedIndex);
      RefreshTree();
    }

    private void butAddFileType_Click(object sender, System.EventArgs e)
    {
      if (tvDirs.SelectedNode.Text.StartsWith("\\")) return;

      bool AddToDisplay = false;
      AddToDisplay = AddToList(CurrentTree.Spec.IncludedFileExtensions, FileExtension(tvDirs.SelectedNode.Text));
      if (AddToDisplay) {
        lbFileType.Items.Add(FileExtension(tvDirs.SelectedNode.Text));
        RefreshTree();
      }
    }

    private string FileExtension(string FileName)
    {
      return FileName.Substring(FileName.LastIndexOf("."));
    }

    private void butDeleteFileType_Click(object sender, System.EventArgs e)
    {
      if (lbFileType.SelectedIndex < 0) return;
      CurrentTree.Spec.IncludedFileExtensions.Remove(lbFileType.SelectedItem.ToString());
      lbFileType.Items.RemoveAt(lbFileType.SelectedIndex);
      RefreshTree();
    }

    private void butAddDirFileExclude_Click(object sender, System.EventArgs e)
    {
      if (!tvDirs.SelectedNode.Text.StartsWith("\\")) return;
      bool AddToDisplay = false;
      string RelDir = "";
      RelDir = BuildRelDirPath((FileTreeNode)tvDirs.SelectedNode, CurrentTree.RootDirectoryPath);
      AddToDisplay = AddToList(CurrentTree.Spec.DirFileExcludes, RelDir);
      if (AddToDisplay) {
        lbDirFileExclude.Items.Add(RelDir);
        RefreshTree();
      }
    }

    private void butDeleteDirFileExclude_Click(object sender, System.EventArgs e)
    {
      if (lbDirFileExclude.SelectedIndex < 0) return;
      CurrentTree.Spec.DirFileExcludes.Remove(lbDirFileExclude.SelectedItem.ToString());
      lbDirFileExclude.Items.RemoveAt(lbDirFileExclude.SelectedIndex);
      RefreshTree();
    }

    private void labExcludedDirNames_Click(object sender, EventArgs e)
    {

    }
  }
}
