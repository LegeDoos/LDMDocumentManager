using System;
using System.Collections.Generic;
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

        public void AddFilesOpenDialog()
        {
            if (TheFileList != null)
            {
                OpenFileDialog FileDialog = new OpenFileDialog();
                DialogResult Result = FileDialog.ShowDialog();
                if (Result == DialogResult.OK) 
                {
                }
            }
        }

        public void AddFilesFromSourceDir()
        {
            if (TheFileList != null)
            {
            }
        }

        public void AddFilesFromShell()
        {
            if (TheFileList != null)
            {
            }
        }
    }
}
