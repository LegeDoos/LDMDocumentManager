using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegeDoos.LDM
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            GlobalSettings.theSettings.SaveSettings();       
            this.Close();
        }

        private void btnSrcDlg_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SourceDocsTextBox.Text = dlg.SelectedPath;
            }
        }

        private void btnDestDlg_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DestinationPathTextBox.Text = dlg.SelectedPath;
            }
        }


    }
}
