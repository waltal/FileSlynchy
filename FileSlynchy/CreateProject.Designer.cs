namespace FileSlynchy
{
  partial class CreateProject
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
      this.butCreateProject = new System.Windows.Forms.Button();
      this.tbProjectName = new System.Windows.Forms.TextBox();
      this.labCreateProjectName = new System.Windows.Forms.Label();
      this.labProjectPathFile = new System.Windows.Forms.Label();
      this.tbFileName = new System.Windows.Forms.TextBox();
      this.labFileName = new System.Windows.Forms.Label();
      this.labPathFile = new System.Windows.Forms.Label();
      this.butCancel = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // butCreateProject
      // 
      this.butCreateProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butCreateProject.Location = new System.Drawing.Point(242, 218);
      this.butCreateProject.Name = "butCreateProject";
      this.butCreateProject.Size = new System.Drawing.Size(204, 35);
      this.butCreateProject.TabIndex = 43;
      this.butCreateProject.Text = "Create Project";
      this.butCreateProject.Click += new System.EventHandler(this.butCreateProject_Click);
      // 
      // tbProjectName
      // 
      this.tbProjectName.Location = new System.Drawing.Point(242, 47);
      this.tbProjectName.Name = "tbProjectName";
      this.tbProjectName.Size = new System.Drawing.Size(405, 26);
      this.tbProjectName.TabIndex = 42;
      // 
      // labCreateProjectName
      // 
      this.labCreateProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labCreateProjectName.Location = new System.Drawing.Point(16, 47);
      this.labCreateProjectName.Name = "labCreateProjectName";
      this.labCreateProjectName.Size = new System.Drawing.Size(191, 27);
      this.labCreateProjectName.TabIndex = 41;
      this.labCreateProjectName.Text = "Project Name";
      // 
      // labProjectPathFile
      // 
      this.labProjectPathFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labProjectPathFile.Location = new System.Drawing.Point(16, 153);
      this.labProjectPathFile.Name = "labProjectPathFile";
      this.labProjectPathFile.Size = new System.Drawing.Size(220, 27);
      this.labProjectPathFile.TabIndex = 44;
      this.labProjectPathFile.Text = "Project File and Path";
      // 
      // tbFileName
      // 
      this.tbFileName.Location = new System.Drawing.Point(242, 101);
      this.tbFileName.Name = "tbFileName";
      this.tbFileName.Size = new System.Drawing.Size(405, 26);
      this.tbFileName.TabIndex = 46;
      this.tbFileName.TextChanged += new System.EventHandler(this.tbFileName_TextChanged);
      // 
      // labFileName
      // 
      this.labFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labFileName.Location = new System.Drawing.Point(16, 100);
      this.labFileName.Name = "labFileName";
      this.labFileName.Size = new System.Drawing.Size(191, 27);
      this.labFileName.TabIndex = 47;
      this.labFileName.Text = "File Name";
      // 
      // labPathFile
      // 
      this.labPathFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.labPathFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labPathFile.Location = new System.Drawing.Point(242, 147);
      this.labPathFile.Name = "labPathFile";
      this.labPathFile.Size = new System.Drawing.Size(1070, 35);
      this.labPathFile.TabIndex = 48;
      this.labPathFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // butCancel
      // 
      this.butCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.butCancel.Location = new System.Drawing.Point(572, 218);
      this.butCancel.Name = "butCancel";
      this.butCancel.Size = new System.Drawing.Size(204, 35);
      this.butCancel.TabIndex = 50;
      this.butCancel.Text = "Cancel";
      this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
      // 
      // CreateProject
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1330, 301);
      this.Controls.Add(this.butCancel);
      this.Controls.Add(this.labPathFile);
      this.Controls.Add(this.labFileName);
      this.Controls.Add(this.tbFileName);
      this.Controls.Add(this.labProjectPathFile);
      this.Controls.Add(this.butCreateProject);
      this.Controls.Add(this.tbProjectName);
      this.Controls.Add(this.labCreateProjectName);
      this.Name = "CreateProject";
      this.Text = "Create Project";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button butCreateProject;
    private System.Windows.Forms.TextBox tbProjectName;
    private System.Windows.Forms.Label labCreateProjectName;
    private System.Windows.Forms.Label labProjectPathFile;
    private System.Windows.Forms.TextBox tbFileName;
    private System.Windows.Forms.Label labFileName;
    private System.Windows.Forms.Label labPathFile;
    private System.Windows.Forms.Button butCancel;
  }
}