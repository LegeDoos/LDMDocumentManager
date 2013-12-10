using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LegeDoos.Utils;

namespace LegeDoos.LDM
{
    class FileManager
    {
        public List<TheFile> TheFileList { get; private set; }
        private DataGridView m_FileListDataGridView = null;
        public List<TheFile> SelectedFiles { get; private set; }
        public TheFile MainSelectedFile { get; private set; }


        /// <summary>
        /// Constructor accepts DataGridView to show the file list in
        /// </summary>
        /// <param name="_dataGridViewFileList"></param>
        public FileManager(DataGridView _dataGridViewFileList)
        {
            InitList();
            m_FileListDataGridView = _dataGridViewFileList;
            m_FileListDataGridView.SelectionChanged += new System.EventHandler(this.FileListSelectionChanged);

        }

        public void InitList()
        {
            TheFileList = new List<TheFile>();
        }

        private void InitGridView()
        {
            m_FileListDataGridView.DataSource = TheFileList.OrderBy(TheFile => TheFile.CreatedDateTime).ToList();
        }

        public Boolean AddFileToList(string FileName)
        {
            Boolean retVal = false;

            try
            {
                TheFile fileLocal = new TheFile(FileName);
                TheFileList.Add(fileLocal);
                retVal = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            return retVal;
        }

        public void AddFilesToList(string[] FileNames)
        {
            foreach (string File in FileNames)
            {
                AddFileToList(File);
            }
        }

        public void AddFilesOpenDialog()
        {
            if (TheFileList != null)
            {
                CheckFileListEmpty();
                OpenFileDialog FileDialog = new OpenFileDialog();
                FileDialog.InitialDirectory = GlobalSettings.theSettings.SourcePath;
                FileDialog.Filter = "Images jpg|*.jpg|Images jpeg|*.jpeg|All files|*.*";
                FileDialog.FilterIndex = 1;
                FileDialog.Multiselect = true;
                //FileDialog.CheckFileExists = true;
                FileDialog.AddExtension = true;
                DialogResult Result = FileDialog.ShowDialog();
                if (Result == DialogResult.OK) 
                {
                    AddFilesToList(FileDialog.FileNames);
                }
                InitGridView();
            }
        }

        public void AddFilesFromSourceDir()
        {
            if (TheFileList != null)
            {
                if (Directory.Exists(GlobalSettings.theSettings.SourcePath))
                {
                    CheckFileListEmpty();
                    foreach (string File in Directory.EnumerateFiles(GlobalSettings.theSettings.SourcePath, "*.jpg"))
                    {
                        AddFileToList(File);
                    }
                    InitGridView();
                }
                else 
                {
                    MessageBox.Show(string.Format("Path {0} not found", GlobalSettings.theSettings.SourcePath));
                }
            }
        }

        public void AddFilesFromShell()
        {
            if (TheFileList != null)
            {
                InitGridView();
            }
        }

        private void CheckFileListEmpty()
        {
            if (TheFileList.Count > 0)
            {
                if (MessageBox.Show("Close open files?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    InitList();
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Handle the change of selection in the grid with files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileListSelectionChanged(object sender, EventArgs e)
        {
            TheFile item;

            //fill list of selected items
            SelectedFiles = new List<TheFile>();
            foreach (DataGridViewRow r in m_FileListDataGridView.SelectedRows)
            {
                item = r.DataBoundItem as TheFile;
                SelectedFiles.Add(item);
            }

            if (SelectedFiles.Count == 0)
                return;

            SelectedFiles = SelectedFiles.OrderBy(f => f.CreatedDateTime).ToList();
            //determine main image (first created)
            MainSelectedFile = SelectedFiles.FirstOrDefault();

            //load image

            //load values
        }
        
    }
}
