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
            m_FileManager.CurrentDocumentChange += new CurrentDocumentChange(LoadDocument);
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


        private void btnApply_Click(object sender, EventArgs e)
        {
            m_FileManager.SaveDocumentMetaData();
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
                pictureBoxPreview.Image = m_FileManager.SelectedFiles[m_ImageIndex].Image();
                if (pictureBoxPreview.Image != null)
                {
                    labelImageName.Text = string.Format("Preview of: {0}", m_FileManager.SelectedFiles[m_ImageIndex].SourceFileName);
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

        private void LoadDocument()
        {
            if (m_FileManager.CurrentDocument != null)
            {
                Document current = m_FileManager.CurrentDocument;
                documentBindingSource.DataSource = current;

                textBoxDocumentCategory.Text = current.Category;
                textBoxDocumentDate.Text = current.CreatedDateYYYYMMDD;
                textBoxDocumentDescription.Text = current.Description;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            m_FileManager.DeleteDocument();
        }

        private void btnSaveDocuments_Click(object sender, EventArgs e)
        {
            m_FileManager.ProcessDocuments();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {

            //handle arrow down and up
            if (!dataGridViewFileList.Focused &&
                    (textBoxDocumentDate.Focused || textBoxSender.Focused || textBoxDocumentCategory.Focused || textBoxDocumentDescription.Focused || textBoxDocumentTags.Focused
                        || checkBoxDoubleSided.Focused || btnApply.Focused || btnDelete.Focused))
            {
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                {
                    //set focus
                    
                    if (GridSelectNextRow(e.KeyCode == Keys.Up))
                        dataGridViewFileList.Focus();
                    e.Handled = true;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Tab)
                {
                    //todo: keep selecttion
                    textBoxDocumentDate.Focus();
                }
            }

        }

        private bool GridSelectNextRow(Boolean previous = false)
        {
            int CurrentRow;
            bool retVal = false;

            if (dataGridViewFileList.CurrentRow == null)
                return retVal;
            
            CurrentRow = dataGridViewFileList.CurrentRow.Index;

            if (previous)
            {
                if (CurrentRow > 0)
                {
                    dataGridViewFileList.CurrentCell = dataGridViewFileList[1, --CurrentRow];
                    retVal = true;
                }
            }
            else
            {
                if (CurrentRow < dataGridViewFileList.RowCount - 1)
                {
                    dataGridViewFileList.CurrentCell = dataGridViewFileList[1, ++CurrentRow];
                    retVal = true;
                }
            }

            return retVal;
        }
    }
}