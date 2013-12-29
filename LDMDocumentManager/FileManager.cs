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
    public delegate void MainSelectedFileChange();
    public delegate void CurrentDocumentChange();

    class FileManager
    {
        public List<TheFile> TheFileList { get; private set; }
        private DataGridView m_FileListDataGridView = null;
        public List<TheFile> SelectedFiles { get; private set; }
        public TheFile MainSelectedFile { get; private set; }
        public Document CurrentDocument { get; set; }
        private List<Document> DocumentList = null;

        public event MainSelectedFileChange MainSelectedFileChangeEvent;
        public event CurrentDocumentChange CurrentDocumentChange;

        private string m_NumberSequenceIdDocNo = "DOCUMENTNUMBER";
        private string m_NumberSequenceSaveLocation = @"d:\a\"; //todo
        private NumberSequence DocumentNumberSequence;

        /// <summary>
        /// Constructor accepts DataGridView to show the file list in
        /// </summary>
        /// <param name="_dataGridViewFileList"></param>
        public FileManager(DataGridView _dataGridViewFileList)
        {
            Init();
            m_FileListDataGridView = _dataGridViewFileList;
            
            //subscribe to events
            m_FileListDataGridView.SelectionChanged += new System.EventHandler(this.FileListSelectionChanged);
            
            //this.dataGridViewFileList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewFileList_CellFormatting);

            m_FileListDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(SetDataGridRowValue);
            //m_FileListDataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(SetDataGridRowValue);
        }

        public void Init()
        {
            TheFileList = new List<TheFile>();
            DocumentList = new List<Document>();
            CurrentDocument = getNewDocument();
            NumberSequenceManager.TheNumberSequenceManager.ConfigLocation = m_NumberSequenceSaveLocation;
            NumberSequence test;
            test = NumberSequenceManager.TheNumberSequenceManager.GetNumberSequence(m_NumberSequenceIdDocNo);
            test = NumberSequenceManager.TheNumberSequenceManager.GetNumberSequence(m_NumberSequenceIdDocNo);
        }
        /// <summary>
        /// Get a new document from te list
        /// </summary>
        /// <returns>A new document</returns>
        private Document getNewDocument()
        {
            Document retVal = null;
            if (DocumentList != null)
            {
                retVal = DocumentList.FirstOrDefault(d => d.UnSaved == true);
                if (retVal == null)
                {
                    retVal = new Document();
                    DocumentList.Add(retVal);
                }
            }
            return retVal;
        }
        /// <summary>
        /// Get the document for a file. Return new documemt if no documnet found
        /// </summary>
        /// <param name="_file">The file to find te document for</param>
        /// <returns>The document for the file or a new document</returns>
        private Document getDocumentForFile(TheFile _file, bool _newIfNotFound = false)
        {
            Document retVal = null;
            var localDocuments =
                from Document in DocumentList
                where (Document.FileList.FirstOrDefault(f => f.PathAndFileName == _file.PathAndFileName) != null)
                select Document;

            retVal = localDocuments.FirstOrDefault();

            if (retVal == null && _newIfNotFound)
            {
                retVal = getNewDocument();
                retVal.InitFromFile(_file);
            }
            
            return retVal;
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
                /* Disabled: this takes too long if the folder doesn't exist
                if (Directory.Exists(GlobalSettings.theSettings.SourcePath))
                    FileDialog.InitialDirectory = GlobalSettings.theSettings.SourcePath;
                */
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
                    Init();
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
            string oldFileName = MainSelectedFile != null ? MainSelectedFile.TheFileName : "";
            Guid oldGuid = CurrentDocument != null ? CurrentDocument.Id : Guid.Empty;

            //fill list of selected items
            SelectedFiles = new List<TheFile>();
            foreach (DataGridViewRow r in m_FileListDataGridView.SelectedRows)
            {
                item = r.DataBoundItem as TheFile;
                SelectedFiles.Add(item);
            }

            if (SelectedFiles.Count == 0)
                return;

            SelectedFiles = SelectedFiles.OrderBy(f => f.CreatedDateTime).ThenBy(f => f.TheFileName).ToList();

            //determine main file (first created from selected)
            MainSelectedFile = SelectedFiles.FirstOrDefault();

            //trigger event so the new immage can be loaded
            if (MainSelectedFile.TheFileName != oldFileName && MainSelectedFileChangeEvent != null)
                MainSelectedFileChangeEvent();
            
            //load values
            CurrentDocument = getDocumentForFile(MainSelectedFile, true);

            //trigger event so the new document can be loaded
            if ((oldGuid == Guid.Empty || CurrentDocument.Id != oldGuid) && CurrentDocumentChange != null)
                CurrentDocumentChange();
        }


        internal void SaveDocumentMetaData()
        {
            if (!CurrentDocument.Save(SelectedFiles))
            {
                MessageBox.Show("Unable to save document metadata");
            }
          
            //refresh datagrid (colors for items with document
            m_FileListDataGridView.Refresh();

        }

        internal void DeleteDocument()
        {
            DocumentList.Remove(CurrentDocument);
            CurrentDocument = getDocumentForFile(MainSelectedFile, true);
            if (CurrentDocumentChange != null)
                CurrentDocumentChange();
            m_FileListDataGridView.Refresh();
        }

        private void SetDataGridRowValue(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = m_FileListDataGridView.Rows[e.RowIndex];
                
                TheFile FileLocal;
                FileLocal = TheFileList.FirstOrDefault(f => f.TheFileName == row.Cells[0].Value);

                Document documentLocal;
                documentLocal = getDocumentForFile(FileLocal);
                
                //todo: get column by name
                row.Cells[1].Value = documentLocal != null ? documentLocal.DocumentName : string.Empty;
            }
        }


        internal void ProcessDocuments()
        {
            var docs =
                from Document in DocumentList
                where Document.UnSaved == false
                select Document;

            foreach (Document d in docs)
            {
                //test save
                string test = @"d:\a\test.xml";
                d.SaveToFile(test);
            }
        }
    }
}
