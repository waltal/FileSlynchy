namespace FileSlynchy
{
  partial class EditComparisons
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
      this.butDeleteComparison = new System.Windows.Forms.Button();
      this.cboSelectComparison = new System.Windows.Forms.ComboBox();
      this.labSelectComparison = new System.Windows.Forms.Label();
      this.gbAddComparison = new System.Windows.Forms.GroupBox();
      this.butAddComparison = new System.Windows.Forms.Button();
      this.tbAddComparisonName = new System.Windows.Forms.TextBox();
      this.labAddComparisonName = new System.Windows.Forms.Label();
      this.butDeleteDirTree = new System.Windows.Forms.Button();
      this.cboDirTree = new System.Windows.Forms.ComboBox();
      this.labSelectDirTree = new System.Windows.Forms.Label();
      this.groupAddTreeBox = new System.Windows.Forms.GroupBox();
      this.butAddTree = new System.Windows.Forms.Button();
      this.tbAddTreeName = new System.Windows.Forms.TextBox();
      this.labTreeName = new System.Windows.Forms.Label();
      this.tbAddTreeRootDirectory = new System.Windows.Forms.TextBox();
      this.butSelectAddTreeRootDirectory = new System.Windows.Forms.Button();
      this.labRootDirectory = new System.Windows.Forms.Label();
      this.butExclusions = new System.Windows.Forms.Button();
      this.labProjectName = new System.Windows.Forms.Label();
      this.fbSelectRootDir = new System.Windows.Forms.FolderBrowserDialog();
      this.gbAddComparison.SuspendLayout();
      this.groupAddTreeBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // butDeleteComparison
      // 
      this.butDeleteComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteComparison.Location = new System.Drawing.Point(287, 143);
      this.butDeleteComparison.Name = "butDeleteComparison";
      this.butDeleteComparison.Size = new System.Drawing.Size(238, 35);
      this.butDeleteComparison.TabIndex = 45;
      this.butDeleteComparison.Text = "Delete Comparison";
      this.butDeleteComparison.Click += new System.EventHandler(this.butDeleteComparison_Click);
      // 
      // cboSelectComparison
      // 
      this.cboSelectComparison.Location = new System.Drawing.Point(230, 109);
      this.cboSelectComparison.Name = "cboSelectComparison";
      this.cboSelectComparison.Size = new System.Drawing.Size(295, 28);
      this.cboSelectComparison.TabIndex = 44;
      this.cboSelectComparison.SelectedIndexChanged += new System.EventHandler(this.cboSelectComparison_SelectedIndexChanged);
      // 
      // labSelectComparison
      // 
      this.labSelectComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labSelectComparison.Location = new System.Drawing.Point(12, 108);
      this.labSelectComparison.Name = "labSelectComparison";
      this.labSelectComparison.Size = new System.Drawing.Size(205, 28);
      this.labSelectComparison.TabIndex = 43;
      this.labSelectComparison.Text = "Select Comparison";
      // 
      // gbAddComparison
      // 
      this.gbAddComparison.Controls.Add(this.butAddComparison);
      this.gbAddComparison.Controls.Add(this.tbAddComparisonName);
      this.gbAddComparison.Controls.Add(this.labAddComparisonName);
      this.gbAddComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.gbAddComparison.Location = new System.Drawing.Point(547, 108);
      this.gbAddComparison.Name = "gbAddComparison";
      this.gbAddComparison.Size = new System.Drawing.Size(628, 111);
      this.gbAddComparison.TabIndex = 46;
      this.gbAddComparison.TabStop = false;
      this.gbAddComparison.Text = "Add Comparison";
      // 
      // butAddComparison
      // 
      this.butAddComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butAddComparison.Location = new System.Drawing.Point(213, 65);
      this.butAddComparison.Name = "butAddComparison";
      this.butAddComparison.Size = new System.Drawing.Size(204, 35);
      this.butAddComparison.TabIndex = 40;
      this.butAddComparison.Text = "Add Comparison";
      this.butAddComparison.Click += new System.EventHandler(this.butAddComparison_Click);
      // 
      // tbAddComparisonName
      // 
      this.tbAddComparisonName.Location = new System.Drawing.Point(213, 29);
      this.tbAddComparisonName.Name = "tbAddComparisonName";
      this.tbAddComparisonName.Size = new System.Drawing.Size(405, 30);
      this.tbAddComparisonName.TabIndex = 39;
      // 
      // labAddComparisonName
      // 
      this.labAddComparisonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labAddComparisonName.Location = new System.Drawing.Point(9, 32);
      this.labAddComparisonName.Name = "labAddComparisonName";
      this.labAddComparisonName.Size = new System.Drawing.Size(191, 27);
      this.labAddComparisonName.TabIndex = 38;
      this.labAddComparisonName.Text = "Comparison Name";
      // 
      // butDeleteDirTree
      // 
      this.butDeleteDirTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butDeleteDirTree.Location = new System.Drawing.Point(875, 392);
      this.butDeleteDirTree.Name = "butDeleteDirTree";
      this.butDeleteDirTree.Size = new System.Drawing.Size(179, 35);
      this.butDeleteDirTree.TabIndex = 49;
      this.butDeleteDirTree.Text = "Delete Tree";
      this.butDeleteDirTree.Click += new System.EventHandler(this.butDeleteDirTree_Click);
      // 
      // cboDirTree
      // 
      this.cboDirTree.Location = new System.Drawing.Point(258, 398);
      this.cboDirTree.Name = "cboDirTree";
      this.cboDirTree.Size = new System.Drawing.Size(371, 28);
      this.cboDirTree.TabIndex = 48;
      this.cboDirTree.SelectedIndexChanged += new System.EventHandler(this.cboDirTree_SelectedIndexChanged);
      // 
      // labSelectDirTree
      // 
      this.labSelectDirTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labSelectDirTree.Location = new System.Drawing.Point(19, 397);
      this.labSelectDirTree.Name = "labSelectDirTree";
      this.labSelectDirTree.Size = new System.Drawing.Size(226, 28);
      this.labSelectDirTree.TabIndex = 47;
      this.labSelectDirTree.Text = "Select Directory Tree";
      // 
      // groupAddTreeBox
      // 
      this.groupAddTreeBox.Controls.Add(this.butAddTree);
      this.groupAddTreeBox.Controls.Add(this.tbAddTreeName);
      this.groupAddTreeBox.Controls.Add(this.labTreeName);
      this.groupAddTreeBox.Controls.Add(this.tbAddTreeRootDirectory);
      this.groupAddTreeBox.Controls.Add(this.butSelectAddTreeRootDirectory);
      this.groupAddTreeBox.Controls.Add(this.labRootDirectory);
      this.groupAddTreeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupAddTreeBox.Location = new System.Drawing.Point(24, 226);
      this.groupAddTreeBox.Name = "groupAddTreeBox";
      this.groupAddTreeBox.Size = new System.Drawing.Size(1226, 160);
      this.groupAddTreeBox.TabIndex = 50;
      this.groupAddTreeBox.TabStop = false;
      this.groupAddTreeBox.Text = "Add Comparison Directory Tree";
      // 
      // butAddTree
      // 
      this.butAddTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butAddTree.Location = new System.Drawing.Point(179, 108);
      this.butAddTree.Name = "butAddTree";
      this.butAddTree.Size = new System.Drawing.Size(140, 35);
      this.butAddTree.TabIndex = 34;
      this.butAddTree.Text = "Add Tree";
      this.butAddTree.Click += new System.EventHandler(this.butAddTree_Click);
      // 
      // tbAddTreeName
      // 
      this.tbAddTreeName.Location = new System.Drawing.Point(179, 33);
      this.tbAddTreeName.Name = "tbAddTreeName";
      this.tbAddTreeName.Size = new System.Drawing.Size(405, 30);
      this.tbAddTreeName.TabIndex = 37;
      // 
      // labTreeName
      // 
      this.labTreeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labTreeName.Location = new System.Drawing.Point(9, 36);
      this.labTreeName.Name = "labTreeName";
      this.labTreeName.Size = new System.Drawing.Size(164, 27);
      this.labTreeName.TabIndex = 36;
      this.labTreeName.Text = "Tree Name";
      // 
      // tbAddTreeRootDirectory
      // 
      this.tbAddTreeRootDirectory.Location = new System.Drawing.Point(179, 72);
      this.tbAddTreeRootDirectory.Name = "tbAddTreeRootDirectory";
      this.tbAddTreeRootDirectory.Size = new System.Drawing.Size(929, 30);
      this.tbAddTreeRootDirectory.TabIndex = 35;
      // 
      // butSelectAddTreeRootDirectory
      // 
      this.butSelectAddTreeRootDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butSelectAddTreeRootDirectory.Location = new System.Drawing.Point(1114, 76);
      this.butSelectAddTreeRootDirectory.Name = "butSelectAddTreeRootDirectory";
      this.butSelectAddTreeRootDirectory.Size = new System.Drawing.Size(102, 27);
      this.butSelectAddTreeRootDirectory.TabIndex = 36;
      this.butSelectAddTreeRootDirectory.Text = "Select... ";
      this.butSelectAddTreeRootDirectory.Click += new System.EventHandler(this.butSelectAddTreeRootDirectory_Click);
      // 
      // labRootDirectory
      // 
      this.labRootDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labRootDirectory.Location = new System.Drawing.Point(9, 75);
      this.labRootDirectory.Name = "labRootDirectory";
      this.labRootDirectory.Size = new System.Drawing.Size(164, 27);
      this.labRootDirectory.TabIndex = 34;
      this.labRootDirectory.Text = "Root Directory";
      // 
      // butExclusions
      // 
      this.butExclusions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butExclusions.Location = new System.Drawing.Point(659, 392);
      this.butExclusions.Name = "butExclusions";
      this.butExclusions.Size = new System.Drawing.Size(179, 35);
      this.butExclusions.TabIndex = 51;
      this.butExclusions.Text = "Exclusions...";
      this.butExclusions.Click += new System.EventHandler(this.butExclusions_Click);
      // 
      // labProjectName
      // 
      this.labProjectName.AutoSize = true;
      this.labProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labProjectName.Location = new System.Drawing.Point(162, 45);
      this.labProjectName.Name = "labProjectName";
      this.labProjectName.Size = new System.Drawing.Size(259, 37);
      this.labProjectName.TabIndex = 52;
      this.labProjectName.Text = "labProjectName";
      // 
      // EditComparisons
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1282, 453);
      this.Controls.Add(this.labProjectName);
      this.Controls.Add(this.butExclusions);
      this.Controls.Add(this.groupAddTreeBox);
      this.Controls.Add(this.butDeleteDirTree);
      this.Controls.Add(this.cboDirTree);
      this.Controls.Add(this.labSelectDirTree);
      this.Controls.Add(this.gbAddComparison);
      this.Controls.Add(this.butDeleteComparison);
      this.Controls.Add(this.cboSelectComparison);
      this.Controls.Add(this.labSelectComparison);
      this.Name = "EditComparisons";
      this.Text = "Edit Comparisons";
      this.Load += new System.EventHandler(this.EditComparisons_Load);
      this.gbAddComparison.ResumeLayout(false);
      this.gbAddComparison.PerformLayout();
      this.groupAddTreeBox.ResumeLayout(false);
      this.groupAddTreeBox.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button butDeleteComparison;
    private System.Windows.Forms.ComboBox cboSelectComparison;
    private System.Windows.Forms.Label labSelectComparison;
    private System.Windows.Forms.GroupBox gbAddComparison;
    private System.Windows.Forms.Button butAddComparison;
    private System.Windows.Forms.TextBox tbAddComparisonName;
    private System.Windows.Forms.Label labAddComparisonName;
    private System.Windows.Forms.Button butDeleteDirTree;
    private System.Windows.Forms.ComboBox cboDirTree;
    private System.Windows.Forms.Label labSelectDirTree;
    private System.Windows.Forms.GroupBox groupAddTreeBox;
    private System.Windows.Forms.Button butAddTree;
    private System.Windows.Forms.TextBox tbAddTreeName;
    private System.Windows.Forms.Label labTreeName;
    private System.Windows.Forms.TextBox tbAddTreeRootDirectory;
    private System.Windows.Forms.Button butSelectAddTreeRootDirectory;
    private System.Windows.Forms.Label labRootDirectory;
    private System.Windows.Forms.Button butExclusions;
    private System.Windows.Forms.Label labProjectName;
    private System.Windows.Forms.FolderBrowserDialog fbSelectRootDir;
  }
}