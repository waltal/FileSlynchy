namespace FileSlynchy
{
  partial class SynchWorkbench
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
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
      this.tabSynchOptions = new System.Windows.Forms.TabControl();
      this.tabDirectorySync = new System.Windows.Forms.TabPage();
      this.butRemoveUncommonDir = new System.Windows.Forms.Button();
      this.labCopyNotes = new System.Windows.Forms.Label();
      this.labUncommonDirectoriesReport = new System.Windows.Forms.Label();
      this.butCopyUncommonDir = new System.Windows.Forms.Button();
      this.tbDirReport = new System.Windows.Forms.TextBox();
      this.labUncommonDirs = new System.Windows.Forms.Label();
      this.cboUncommonDirs = new System.Windows.Forms.ComboBox();
      this.tabUncommonFileSync = new System.Windows.Forms.TabPage();
      this.labFilesCopied = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tbUncommonFilesinDir = new System.Windows.Forms.TextBox();
      this.butRemoveUncommonFiles = new System.Windows.Forms.Button();
      this.butCopyUncommonFiles = new System.Windows.Forms.Button();
      this.labUncommonFileDirs = new System.Windows.Forms.Label();
      this.cboUncommonFileDirs = new System.Windows.Forms.ComboBox();
      this.tabDifferentFileSync = new System.Windows.Forms.TabPage();
      this.labCopiedFiles = new System.Windows.Forms.Label();
      this.labDifferentFilesInDirReport = new System.Windows.Forms.Label();
      this.tbDifferentFilesInDir = new System.Windows.Forms.TextBox();
      this.butCopyDifferentFiles = new System.Windows.Forms.Button();
      this.labDifferentFileDirs = new System.Windows.Forms.Label();
      this.cboDifferentFileDirs = new System.Windows.Forms.ComboBox();
      this.tvTree = new System.Windows.Forms.TreeView();
      this.labLoadTree = new System.Windows.Forms.Label();
      this.cboSelectTree = new System.Windows.Forms.ComboBox();
      this.cboSelectComparison = new System.Windows.Forms.ComboBox();
      this.labSelectComparison = new System.Windows.Forms.Label();
      this.labProjectName = new System.Windows.Forms.Label();
      this.tbSelectedFile = new System.Windows.Forms.TextBox();
      this.butDeleteSelectedFile = new System.Windows.Forms.Button();
      this.tabSynchOptions.SuspendLayout();
      this.tabDirectorySync.SuspendLayout();
      this.tabUncommonFileSync.SuspendLayout();
      this.tabDifferentFileSync.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabSynchOptions
      // 
      this.tabSynchOptions.Controls.Add(this.tabDirectorySync);
      this.tabSynchOptions.Controls.Add(this.tabUncommonFileSync);
      this.tabSynchOptions.Controls.Add(this.tabDifferentFileSync);
      this.tabSynchOptions.Location = new System.Drawing.Point(12, 66);
      this.tabSynchOptions.Name = "tabSynchOptions";
      this.tabSynchOptions.SelectedIndex = 0;
      this.tabSynchOptions.Size = new System.Drawing.Size(656, 719);
      this.tabSynchOptions.TabIndex = 0;
      // 
      // tabDirectorySync
      // 
      this.tabDirectorySync.Controls.Add(this.butRemoveUncommonDir);
      this.tabDirectorySync.Controls.Add(this.labCopyNotes);
      this.tabDirectorySync.Controls.Add(this.labUncommonDirectoriesReport);
      this.tabDirectorySync.Controls.Add(this.butCopyUncommonDir);
      this.tabDirectorySync.Controls.Add(this.tbDirReport);
      this.tabDirectorySync.Controls.Add(this.labUncommonDirs);
      this.tabDirectorySync.Controls.Add(this.cboUncommonDirs);
      this.tabDirectorySync.Location = new System.Drawing.Point(4, 29);
      this.tabDirectorySync.Name = "tabDirectorySync";
      this.tabDirectorySync.Padding = new System.Windows.Forms.Padding(3);
      this.tabDirectorySync.Size = new System.Drawing.Size(648, 686);
      this.tabDirectorySync.TabIndex = 0;
      this.tabDirectorySync.Text = "Directory Synch";
      this.tabDirectorySync.UseVisualStyleBackColor = true;
      // 
      // butRemoveUncommonDir
      // 
      this.butRemoveUncommonDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butRemoveUncommonDir.Location = new System.Drawing.Point(312, 124);
      this.butRemoveUncommonDir.Name = "butRemoveUncommonDir";
      this.butRemoveUncommonDir.Size = new System.Drawing.Size(325, 36);
      this.butRemoveUncommonDir.TabIndex = 44;
      this.butRemoveUncommonDir.Text = "Remove Uncommon Directory";
      this.butRemoveUncommonDir.UseVisualStyleBackColor = true;
      this.butRemoveUncommonDir.Click += new System.EventHandler(this.butRemoveUncommonDir_Click);
      // 
      // labCopyNotes
      // 
      this.labCopyNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labCopyNotes.Location = new System.Drawing.Point(13, 93);
      this.labCopyNotes.Name = "labCopyNotes";
      this.labCopyNotes.Size = new System.Drawing.Size(593, 28);
      this.labCopyNotes.TabIndex = 43;
      this.labCopyNotes.Text = "Files and subdirs copied or removed from selected tree";
      // 
      // labUncommonDirectoriesReport
      // 
      this.labUncommonDirectoriesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labUncommonDirectoriesReport.Location = new System.Drawing.Point(8, 180);
      this.labUncommonDirectoriesReport.Name = "labUncommonDirectoriesReport";
      this.labUncommonDirectoriesReport.Size = new System.Drawing.Size(329, 28);
      this.labUncommonDirectoriesReport.TabIndex = 42;
      this.labUncommonDirectoriesReport.Text = "Uncommon Directories Report";
      // 
      // butCopyUncommonDir
      // 
      this.butCopyUncommonDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butCopyUncommonDir.Location = new System.Drawing.Point(13, 124);
      this.butCopyUncommonDir.Name = "butCopyUncommonDir";
      this.butCopyUncommonDir.Size = new System.Drawing.Size(293, 36);
      this.butCopyUncommonDir.TabIndex = 41;
      this.butCopyUncommonDir.Text = "Copy Uncommon Directory";
      this.butCopyUncommonDir.UseVisualStyleBackColor = true;
      this.butCopyUncommonDir.Click += new System.EventHandler(this.butCopyUncommonDir_Click);
      // 
      // tbDirReport
      // 
      this.tbDirReport.Location = new System.Drawing.Point(18, 211);
      this.tbDirReport.Multiline = true;
      this.tbDirReport.Name = "tbDirReport";
      this.tbDirReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbDirReport.Size = new System.Drawing.Size(619, 469);
      this.tbDirReport.TabIndex = 40;
      // 
      // labUncommonDirs
      // 
      this.labUncommonDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labUncommonDirs.Location = new System.Drawing.Point(13, 14);
      this.labUncommonDirs.Name = "labUncommonDirs";
      this.labUncommonDirs.Size = new System.Drawing.Size(329, 28);
      this.labUncommonDirs.TabIndex = 39;
      this.labUncommonDirs.Text = "Uncommon Directories";
      // 
      // cboUncommonDirs
      // 
      this.cboUncommonDirs.Location = new System.Drawing.Point(13, 45);
      this.cboUncommonDirs.Name = "cboUncommonDirs";
      this.cboUncommonDirs.Size = new System.Drawing.Size(624, 28);
      this.cboUncommonDirs.TabIndex = 38;
      this.cboUncommonDirs.SelectedIndexChanged += new System.EventHandler(this.cboUncommonDirs_SelectedIndexChanged);
      // 
      // tabUncommonFileSync
      // 
      this.tabUncommonFileSync.Controls.Add(this.labFilesCopied);
      this.tabUncommonFileSync.Controls.Add(this.label1);
      this.tabUncommonFileSync.Controls.Add(this.tbUncommonFilesinDir);
      this.tabUncommonFileSync.Controls.Add(this.butRemoveUncommonFiles);
      this.tabUncommonFileSync.Controls.Add(this.butCopyUncommonFiles);
      this.tabUncommonFileSync.Controls.Add(this.labUncommonFileDirs);
      this.tabUncommonFileSync.Controls.Add(this.cboUncommonFileDirs);
      this.tabUncommonFileSync.Location = new System.Drawing.Point(4, 29);
      this.tabUncommonFileSync.Name = "tabUncommonFileSync";
      this.tabUncommonFileSync.Padding = new System.Windows.Forms.Padding(3);
      this.tabUncommonFileSync.Size = new System.Drawing.Size(648, 686);
      this.tabUncommonFileSync.TabIndex = 1;
      this.tabUncommonFileSync.Text = "Uncommon File Synch";
      this.tabUncommonFileSync.UseVisualStyleBackColor = true;
      // 
      // labFilesCopied
      // 
      this.labFilesCopied.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labFilesCopied.Location = new System.Drawing.Point(18, 95);
      this.labFilesCopied.Name = "labFilesCopied";
      this.labFilesCopied.Size = new System.Drawing.Size(455, 28);
      this.labFilesCopied.TabIndex = 49;
      this.labFilesCopied.Text = "Files copied from selected tree";
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(8, 180);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(413, 28);
      this.label1.TabIndex = 48;
      this.label1.Text = "Uncommon Files in Directory Report";
      // 
      // tbUncommonFilesinDir
      // 
      this.tbUncommonFilesinDir.Location = new System.Drawing.Point(18, 211);
      this.tbUncommonFilesinDir.Multiline = true;
      this.tbUncommonFilesinDir.Name = "tbUncommonFilesinDir";
      this.tbUncommonFilesinDir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbUncommonFilesinDir.Size = new System.Drawing.Size(619, 469);
      this.tbUncommonFilesinDir.TabIndex = 47;
      // 
      // butRemoveUncommonFiles
      // 
      this.butRemoveUncommonFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butRemoveUncommonFiles.Location = new System.Drawing.Point(317, 126);
      this.butRemoveUncommonFiles.Name = "butRemoveUncommonFiles";
      this.butRemoveUncommonFiles.Size = new System.Drawing.Size(325, 36);
      this.butRemoveUncommonFiles.TabIndex = 46;
      this.butRemoveUncommonFiles.Text = "Remove Uncommon Files";
      this.butRemoveUncommonFiles.UseVisualStyleBackColor = true;
      this.butRemoveUncommonFiles.Click += new System.EventHandler(this.butRemoveUncommonFiles_Click);
      // 
      // butCopyUncommonFiles
      // 
      this.butCopyUncommonFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butCopyUncommonFiles.Location = new System.Drawing.Point(18, 126);
      this.butCopyUncommonFiles.Name = "butCopyUncommonFiles";
      this.butCopyUncommonFiles.Size = new System.Drawing.Size(293, 36);
      this.butCopyUncommonFiles.TabIndex = 45;
      this.butCopyUncommonFiles.Text = "Copy Uncommon Files";
      this.butCopyUncommonFiles.UseVisualStyleBackColor = true;
      this.butCopyUncommonFiles.Click += new System.EventHandler(this.butCopyUncommonFiles_Click);
      // 
      // labUncommonFileDirs
      // 
      this.labUncommonFileDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labUncommonFileDirs.Location = new System.Drawing.Point(18, 13);
      this.labUncommonFileDirs.Name = "labUncommonFileDirs";
      this.labUncommonFileDirs.Size = new System.Drawing.Size(329, 28);
      this.labUncommonFileDirs.TabIndex = 41;
      this.labUncommonFileDirs.Text = "Uncommon File Directories";
      // 
      // cboUncommonFileDirs
      // 
      this.cboUncommonFileDirs.Location = new System.Drawing.Point(18, 44);
      this.cboUncommonFileDirs.Name = "cboUncommonFileDirs";
      this.cboUncommonFileDirs.Size = new System.Drawing.Size(624, 28);
      this.cboUncommonFileDirs.TabIndex = 40;
      this.cboUncommonFileDirs.SelectedIndexChanged += new System.EventHandler(this.cboUncommonFileDirs_SelectedIndexChanged);
      // 
      // tabDifferentFileSync
      // 
      this.tabDifferentFileSync.Controls.Add(this.labCopiedFiles);
      this.tabDifferentFileSync.Controls.Add(this.labDifferentFilesInDirReport);
      this.tabDifferentFileSync.Controls.Add(this.tbDifferentFilesInDir);
      this.tabDifferentFileSync.Controls.Add(this.butCopyDifferentFiles);
      this.tabDifferentFileSync.Controls.Add(this.labDifferentFileDirs);
      this.tabDifferentFileSync.Controls.Add(this.cboDifferentFileDirs);
      this.tabDifferentFileSync.Location = new System.Drawing.Point(4, 29);
      this.tabDifferentFileSync.Name = "tabDifferentFileSync";
      this.tabDifferentFileSync.Size = new System.Drawing.Size(648, 686);
      this.tabDifferentFileSync.TabIndex = 2;
      this.tabDifferentFileSync.Text = "Different File Synch";
      this.tabDifferentFileSync.UseVisualStyleBackColor = true;
      // 
      // labCopiedFiles
      // 
      this.labCopiedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labCopiedFiles.Location = new System.Drawing.Point(17, 92);
      this.labCopiedFiles.Name = "labCopiedFiles";
      this.labCopiedFiles.Size = new System.Drawing.Size(455, 28);
      this.labCopiedFiles.TabIndex = 55;
      this.labCopiedFiles.Text = "Files copied from selected tree";
      // 
      // labDifferentFilesInDirReport
      // 
      this.labDifferentFilesInDirReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labDifferentFilesInDirReport.Location = new System.Drawing.Point(7, 177);
      this.labDifferentFilesInDirReport.Name = "labDifferentFilesInDirReport";
      this.labDifferentFilesInDirReport.Size = new System.Drawing.Size(413, 28);
      this.labDifferentFilesInDirReport.TabIndex = 54;
      this.labDifferentFilesInDirReport.Text = "Different Files in Directory Report";
      // 
      // tbDifferentFilesInDir
      // 
      this.tbDifferentFilesInDir.Location = new System.Drawing.Point(17, 208);
      this.tbDifferentFilesInDir.Multiline = true;
      this.tbDifferentFilesInDir.Name = "tbDifferentFilesInDir";
      this.tbDifferentFilesInDir.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbDifferentFilesInDir.Size = new System.Drawing.Size(619, 469);
      this.tbDifferentFilesInDir.TabIndex = 53;
      // 
      // butCopyDifferentFiles
      // 
      this.butCopyDifferentFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butCopyDifferentFiles.Location = new System.Drawing.Point(17, 123);
      this.butCopyDifferentFiles.Name = "butCopyDifferentFiles";
      this.butCopyDifferentFiles.Size = new System.Drawing.Size(293, 36);
      this.butCopyDifferentFiles.TabIndex = 52;
      this.butCopyDifferentFiles.Text = "Copy Different Files";
      this.butCopyDifferentFiles.UseVisualStyleBackColor = true;
      this.butCopyDifferentFiles.Click += new System.EventHandler(this.butCopyDifferentFiles_Click);
      // 
      // labDifferentFileDirs
      // 
      this.labDifferentFileDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labDifferentFileDirs.Location = new System.Drawing.Point(17, 10);
      this.labDifferentFileDirs.Name = "labDifferentFileDirs";
      this.labDifferentFileDirs.Size = new System.Drawing.Size(329, 28);
      this.labDifferentFileDirs.TabIndex = 51;
      this.labDifferentFileDirs.Text = "Different File Directories";
      // 
      // cboDifferentFileDirs
      // 
      this.cboDifferentFileDirs.Location = new System.Drawing.Point(17, 41);
      this.cboDifferentFileDirs.Name = "cboDifferentFileDirs";
      this.cboDifferentFileDirs.Size = new System.Drawing.Size(624, 28);
      this.cboDifferentFileDirs.TabIndex = 50;
      this.cboDifferentFileDirs.SelectedIndexChanged += new System.EventHandler(this.cboDifferentFileDirs_SelectedIndexChanged);
      // 
      // tvTree
      // 
      this.tvTree.Location = new System.Drawing.Point(674, 112);
      this.tvTree.Name = "tvTree";
      this.tvTree.Size = new System.Drawing.Size(677, 592);
      this.tvTree.TabIndex = 2;
      this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
      // 
      // labLoadTree
      // 
      this.labLoadTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labLoadTree.Location = new System.Drawing.Point(673, 70);
      this.labLoadTree.Name = "labLoadTree";
      this.labLoadTree.Size = new System.Drawing.Size(146, 28);
      this.labLoadTree.TabIndex = 37;
      this.labLoadTree.Text = "Source Tree";
      // 
      // cboSelectTree
      // 
      this.cboSelectTree.Location = new System.Drawing.Point(825, 70);
      this.cboSelectTree.Name = "cboSelectTree";
      this.cboSelectTree.Size = new System.Drawing.Size(526, 28);
      this.cboSelectTree.TabIndex = 36;
      this.cboSelectTree.SelectedIndexChanged += new System.EventHandler(this.cboSelectTree_SelectedIndexChanged);
      // 
      // cboSelectComparison
      // 
      this.cboSelectComparison.Location = new System.Drawing.Point(231, 32);
      this.cboSelectComparison.Name = "cboSelectComparison";
      this.cboSelectComparison.Size = new System.Drawing.Size(371, 28);
      this.cboSelectComparison.TabIndex = 42;
      this.cboSelectComparison.SelectedIndexChanged += new System.EventHandler(this.cboSelectComparison_SelectedIndexChanged);
      // 
      // labSelectComparison
      // 
      this.labSelectComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labSelectComparison.Location = new System.Drawing.Point(13, 31);
      this.labSelectComparison.Name = "labSelectComparison";
      this.labSelectComparison.Size = new System.Drawing.Size(205, 28);
      this.labSelectComparison.TabIndex = 41;
      this.labSelectComparison.Text = "Select Comparison";
      // 
      // labProjectName
      // 
      this.labProjectName.AutoSize = true;
      this.labProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labProjectName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.labProjectName.Location = new System.Drawing.Point(624, 22);
      this.labProjectName.Name = "labProjectName";
      this.labProjectName.Size = new System.Drawing.Size(259, 37);
      this.labProjectName.TabIndex = 53;
      this.labProjectName.Text = "labProjectName";
      // 
      // tbSelectedFile
      // 
      this.tbSelectedFile.Location = new System.Drawing.Point(678, 710);
      this.tbSelectedFile.Name = "tbSelectedFile";
      this.tbSelectedFile.Size = new System.Drawing.Size(672, 26);
      this.tbSelectedFile.TabIndex = 54;
      // 
      // butDeleteSelectedFile
      // 
      this.butDeleteSelectedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteSelectedFile.Location = new System.Drawing.Point(1073, 747);
      this.butDeleteSelectedFile.Name = "butDeleteSelectedFile";
      this.butDeleteSelectedFile.Size = new System.Drawing.Size(278, 34);
      this.butDeleteSelectedFile.TabIndex = 55;
      this.butDeleteSelectedFile.Text = "Delete Selected File";
      this.butDeleteSelectedFile.UseVisualStyleBackColor = true;
      this.butDeleteSelectedFile.Click += new System.EventHandler(this.butDeleteSelectedFile_Click);
      // 
      // SynchWorkbench
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1363, 795);
      this.Controls.Add(this.butDeleteSelectedFile);
      this.Controls.Add(this.tbSelectedFile);
      this.Controls.Add(this.labProjectName);
      this.Controls.Add(this.cboSelectComparison);
      this.Controls.Add(this.labSelectComparison);
      this.Controls.Add(this.tabSynchOptions);
      this.Controls.Add(this.tvTree);
      this.Controls.Add(this.cboSelectTree);
      this.Controls.Add(this.labLoadTree);
      this.Name = "SynchWorkbench";
      this.Text = "Synch Workbench";
      this.tabSynchOptions.ResumeLayout(false);
      this.tabDirectorySync.ResumeLayout(false);
      this.tabDirectorySync.PerformLayout();
      this.tabUncommonFileSync.ResumeLayout(false);
      this.tabUncommonFileSync.PerformLayout();
      this.tabDifferentFileSync.ResumeLayout(false);
      this.tabDifferentFileSync.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabSynchOptions;
    private System.Windows.Forms.TabPage tabDirectorySync;
    private System.Windows.Forms.TabPage tabUncommonFileSync;
    private System.Windows.Forms.TreeView tvTree;
    private System.Windows.Forms.Label labLoadTree;
    private System.Windows.Forms.ComboBox cboSelectTree;
    private System.Windows.Forms.ComboBox cboSelectComparison;
    private System.Windows.Forms.Label labSelectComparison;
    private System.Windows.Forms.Label labProjectName;
    private System.Windows.Forms.Label labUncommonDirs;
    private System.Windows.Forms.ComboBox cboUncommonDirs;
    private System.Windows.Forms.TextBox tbDirReport;
    private System.Windows.Forms.Button butCopyUncommonDir;
    private System.Windows.Forms.Label labUncommonDirectoriesReport;
    private System.Windows.Forms.Label labCopyNotes;
    private System.Windows.Forms.Button butRemoveUncommonDir;
    private System.Windows.Forms.Label labUncommonFileDirs;
    private System.Windows.Forms.ComboBox cboUncommonFileDirs;
    private System.Windows.Forms.TabPage tabDifferentFileSync;
    private System.Windows.Forms.Label labFilesCopied;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbUncommonFilesinDir;
    private System.Windows.Forms.Button butRemoveUncommonFiles;
    private System.Windows.Forms.Button butCopyUncommonFiles;
    private System.Windows.Forms.Label labCopiedFiles;
    private System.Windows.Forms.Label labDifferentFilesInDirReport;
    private System.Windows.Forms.TextBox tbDifferentFilesInDir;
    private System.Windows.Forms.Button butCopyDifferentFiles;
    private System.Windows.Forms.Label labDifferentFileDirs;
    private System.Windows.Forms.ComboBox cboDifferentFileDirs;
    private System.Windows.Forms.TextBox tbSelectedFile;
    private System.Windows.Forms.Button butDeleteSelectedFile;
  }
}