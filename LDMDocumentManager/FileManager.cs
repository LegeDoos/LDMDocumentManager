﻿using System;
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
        public AutoCompleteStringCollection SendersAutoCompleteCollection { get; private set; }

        public event MainSelectedFileChange MainSelectedFileChangeEvent;
        public event CurrentDocumentChange CurrentDocumentChange;

        private ImageCacheThreading ImageCacheThreading = null;
       
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
            InitNumberSequenceManager();
            SendersAutoCompleteCollection = new AutoCompleteStringCollection();
            this.ReloadSendersAutoComplete();
        }

        private void InitNumberSequenceManager()
        {
            NumberSequenceManager.TheNumberSequenceManager.ConfigLocation = GlobalSettings.theSettings.SettingsFolder;
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
                where (Document.FileList.FirstOrDefault(f => f.SourcePathAndFileName == _file.SourcePathAndFileName) != null)
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
            
            //cache images
            ImageCacheThreading = new ImageCacheThreading(this);
            ImageCacheThreading.StartThread();
           
        }

        /// <summary>
        /// Add a file to the file list
        /// </summary>
        /// <param name="FileName">File to add</param>
        /// <returns>True if successfull</returns>
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

        /// <summary>
        /// Add files to the file list using an open dialog
        /// </summary>
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
                FileDialog.Filter = GlobalSettings.theSettings.OpenDialogFilterSupportedFiles;
                FileDialog.FilterIndex = GlobalSettings.theSettings.SupportedFileTypes.Count + 1; //set to all supported
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

        /// <summary>
        /// Add files from  the source dir to the file list
        /// </summary>
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

        /// <summary>
        /// Not implemented
        /// </summary>
        public void AddFilesFromShell()
        {
            if (TheFileList != null)
            {
                InitGridView();
            }
        }

        /// <summary>
        /// Check if the file list is empty
        /// </summary>
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
            string oldFileName = MainSelectedFile != null ? MainSelectedFile.SourceFileName : "";
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

            SelectedFiles = SelectedFiles.OrderBy(f => f.CreatedDateTime).ThenBy(f => f.SourceFileName).ToList();

            //determine main file (first created from selected)
            MainSelectedFile = SelectedFiles.FirstOrDefault();

            //trigger event so the new immage can be loaded
            if (MainSelectedFile.SourceFileName != oldFileName && MainSelectedFileChangeEvent != null)
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

            //add to senders autocompletion collection
            if (SendersAutoCompleteCollection != null && !SendersAutoCompleteCollection.Contains(CurrentDocument.Sender))
            {
                SendersAutoCompleteCollection.Add(CurrentDocument.Sender);
            }
        }

        internal void DeleteDocument()
        {
            DocumentList.Remove(CurrentDocument);
            CurrentDocument = getDocumentForFile(MainSelectedFile, true);
            if (CurrentDocumentChange != null)
                CurrentDocumentChange();
            m_FileListDataGridView.Refresh();
        }

        /// <summary>
        /// Set the correct value in the grid for the document name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDataGridRowValue(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow row = m_FileListDataGridView.Rows[e.RowIndex];
                
                TheFile FileLocal;
                FileLocal = TheFileList.FirstOrDefault(f => f.SourceFileName == row.Cells[0].Value.ToString());

                Document documentLocal;
                documentLocal = getDocumentForFile(FileLocal);
                
                //todo: get column by name
                row.Cells[1].Value = documentLocal != null ? documentLocal.DocumentName : string.Empty;
            }
        }

        /// <summary>
        /// Process the documents: save everything on the correct location
        /// </summary>
        internal void ProcessDocuments()
        {
            var docs =
                from Document in DocumentList
                where Document.UnSaved == false
                select Document;

            List<Document> delete = new List<Document>();

            foreach (Document d in docs)
            {
                if (!d.Process())
                {
                    //show message
                    MessageBox.Show(string.Format("Something went wrong processing {0}", d.DocumentName));
                }
            }

            //delete files from list
            var docsToDelete =
                from Document in DocumentList
                where Document.Processed == true
                select Document;

            foreach (Document d in docsToDelete)
            {
                foreach (TheFile f in d.FileList)
                {
                    TheFileList.Remove(f);
                }
            }

            //delete docs
            DocumentList.RemoveAll(d => d.Processed = true);
            
            //reload grid
            InitGridView();
        }

        /// <summary>
        /// Create the auto complete collection for the senders textbox
        /// </summary>
        internal void ReloadSendersAutoComplete()
        {
            if (SendersAutoCompleteCollection == null)
                return;

            SendersAutoCompleteCollection.Clear();

            //add dirs
            if (Directory.Exists(GlobalSettings.theSettings.DestPath))
            {
                foreach (string dir in Directory.GetDirectories(GlobalSettings.theSettings.DestPath))
                {
                    SendersAutoCompleteCollection.Add(new DirectoryInfo(dir).Name.Replace('_', ' '));
                }
            }
        }
    }
}
