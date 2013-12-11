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
using LegeDoos.LDM;
using LegeDoos.Utils;

namespace LDM
{
    public partial class Main : Form
    {
        public GlobalSettings m_GlobalSettings { get; set; }
        private FileManager m_FileManager = null;
        private int m_ImageIndex = 0;

        public Main()
        {
            InitializeComponent();
            m_GlobalSettings = new GlobalSettings();
            m_FileManager = new FileManager(dataGridViewFileList);
            m_FileManager.MainSelectedFileChangeEvent += new MainSelectedFileChange(resetImage);
        }

        private EventHandler LoadImage()
        {
            throw new NotImplementedException();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string txt;
            if (m_FileManager.MainSelectedFile != null)
                txt = m_FileManager.MainSelectedFile.TheFileName;
            else
                txt = "Nothing";
            MessageBox.Show(txt);
        }

        private void resetImage()
        {
            m_ImageIndex = 0;
            loadImage();
        }

        /// <summary>
        /// Load the image of the main selected item
        /// </summary>
        private void loadImage()
        {
            string fileNameLocal = string.Empty;

            if (m_FileManager.SelectedFiles != null && (m_ImageIndex >= 0 && m_ImageIndex < m_FileManager.SelectedFiles.Count))
            {
                fileNameLocal = m_FileManager.SelectedFiles[m_ImageIndex].PathAndFileName;
                if (fileNameLocal != string.Empty && File.Exists(fileNameLocal))
                {
                    pictureBoxPreview.Image = new Bitmap(fileNameLocal);
                    labelImageName.Text = string.Format("Preview of: {0}", m_FileManager.SelectedFiles[m_ImageIndex].TheFileName);
                    labelImageName.Visible = true;
                }
                else
                    labelImageName.Visible = false;
            }
            else
            {
                labelImageName.Visible = false;
            }
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (pictureBoxPreview.Image != null)
                RotateImage(pictureBoxPreview, pictureBoxPreview.Image, 90);
        }

        private void RotateImage(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null)
                return;

            Image oldImage = pb.Image;
            pb.Image = ImageManagement.RotateImage(img, angle);
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (m_FileManager.SelectedFiles != null && m_FileManager.SelectedFiles.Count > 0 && m_ImageIndex > 0)
            {
                m_ImageIndex--;
                loadImage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (m_FileManager.SelectedFiles != null && m_FileManager.SelectedFiles.Count > 0 && m_ImageIndex < m_FileManager.SelectedFiles.Count - 1)
            {
                m_ImageIndex++;
                loadImage();
            }
        }
    }
}