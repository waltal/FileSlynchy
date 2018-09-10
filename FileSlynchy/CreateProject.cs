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
  public partial class CreateProject : Form
  {
    public bool FileExists { get; set; }

    public string ProjectName { get; set; }
    public string ProjectFile { get; set; }

    public string ProjectPathFile { get; set; }

    public CreateProject()
    {
      InitializeComponent();
    }

    private void tbFileName_TextChanged(object sender, EventArgs e)
    {
      if (!String.IsNullOrEmpty(tbFileName.Text))
      {
        var path = SlynchyProjectFiles.GetProjectFilesPath();
        var pathFile = Path.Combine(path, tbFileName.Text + ".slynchy");
        if (!File.Exists(pathFile))
        {
          labPathFile.Text = pathFile;
        }
      }
    }

    private void butCreateProject_Click(object sender, EventArgs e)
    {
      if (!String.IsNullOrEmpty(labPathFile.Text) && !String.IsNullOrEmpty(tbProjectName.Text))
      {
        var project = new SlynchyProject(tbProjectName.Text);
        ProjectFile = tbFileName.Text + ".slynchy";
        ProjectPathFile = labPathFile.Text;
        ProjectName = tbProjectName.Text;
        SlynchyProjectFiles.SaveProject(project, ProjectFile);
        this.Close();
      }
    }

    private void butCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
