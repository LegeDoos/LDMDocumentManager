using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegeDoos.LDM;

namespace LDM
{
    public partial class Main : Form
    {
        public GlobalSettings m_GlobalSettings { get; set; }
        private FileManager m_FileManager = null;

        public Main()
        {
            InitializeComponent();
            m_GlobalSettings = new GlobalSettings();
            m_FileManager = new FileManager();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FileManager.AddFilesOpenDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About AboutForm = new About();
            AboutForm.Show();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences PreferencesForm = new Preferences();
            PreferencesForm.ShowDialog();
        }

        private void openFromSourceDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_FileManager.AddFilesFromSourceDir();
        }
    }
}