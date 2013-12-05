using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegeDoos.LDM
{
    class FileManager
    {
        public List<TheFile> TheFileList = null;

        public FileManager()
        {
            InitList();
        }

        public void InitList()
        {
            TheFileList = new List<TheFile>();
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
    }
}
