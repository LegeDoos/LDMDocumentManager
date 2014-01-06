using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using LegeDoos.Utils;

namespace LegeDoos.LDM
{
    public class Document
    {
        public Guid Id { get; set; }
        public Int64 DocumentNumber { get; set; }
        private string DocumentNumberAsString
        {
            get
            {
                return DocumentNumber == 0 ? "xxx" : DocumentNumber.ToString();
            }
        }
        public String DocumentName 
        { 
            get
            {
                string RetVal = CreatedDateYYYYMMDD != null || Sender != null || Category != null ? string.Format("{0}-{1}-{2}-{3}", CreatedDateYYYYMMDD, Sender, Category, DocumentNumberAsString) : "";
                return RetVal.Replace(' ', '_');
            }
        }
        public String CreatedDateYYYYMMDD { get; set; }
        public String Category { get; set; }
        public String Sender { get; set; }
        public String Description { get; set; }
        public String Tags { get; set; }
        public List<TheFile> FileList { get; set; }
        public Boolean UnSaved { get; set; }
        public static XmlSerializer xs;
        private const string NumberSequenceIdDocNo = "DOCUMENTNUMBER";
        private string DestinationFolder 
        {
            get
            {
                string RetVal = GlobalSettings.theSettings.DestPath != null && Sender != null ? Path.Combine(GlobalSettings.theSettings.DestPath, Sender) : string.Empty;
                return RetVal.Replace(' ', '_');
            }
        }
        public bool Processed { get; set; }

        public Document()
        {
            FileList = new List<TheFile>();
            xs = new XmlSerializer(typeof(Document));
            UnSaved = true;
            Category = string.Empty;
            Sender = string.Empty;
            CreatedDateYYYYMMDD = string.Empty;
        }

        public void AddFileToList(TheFile _file)
        {
            if (FileList != null)
            {
                FileList.Add(_file);
            }
        }

        public void AddFileList(List<TheFile> _fileList)
        {
            if (_fileList != null)
            {
                _fileList.ForEach(AddFileToList);
            }
        }


        private bool Validate()
        {
            bool retVal = true;
            
            if (Category == string.Empty || Sender == string.Empty || CreatedDateYYYYMMDD == string.Empty)
            {
                MessageBox.Show("Some required values are empty");
                retVal = false;
            }

            if (retVal && CreatedDateYYYYMMDD.Length != 8)
            {
                MessageBox.Show("Date has incorrect length");
                retVal = false;
            }
            return retVal;
        }

        internal bool Save(List<TheFile> _fileList)
        {
            bool retVal = true;
            if (Validate() && _fileList != null)
            {
                if (UnSaved)
                {
                    AddFileList(_fileList);
                    UnSaved = false;
                }
                retVal = true;
            }
            else
            {
                UnSaved = true;
                retVal = false;
            }
            return retVal;
        }

        internal void InitFromFile(TheFile _file)
        {
            CreatedDateYYYYMMDD = _file.CreatedDate;
            Sender = _file.GetSenderFromPath;
            Category = _file.GetCategoryFromFileName;
        }

        /// <summary>
        /// Save the document metadata to XML
        /// </summary>
        /// <param name="_filename">Filename to save to</param>
        internal void SaveMetaDataToFile(string _filename)
        {
            if (Directory.Exists(Path.GetDirectoryName(_filename)) && UnSaved == false)
            {
                using (StreamWriter sw = new StreamWriter(_filename))
                {
                    xs.Serialize(sw, this);
                }
            }
            if (File.Exists(_filename))
            {
                File.SetAttributes(_filename, FileAttributes.Hidden);
            }

        }

        internal bool Process()
        {
            bool retVal = true;

            try
            {
                //create or validate destination
                retVal = CreateDestinationFolder();

                //set document guid and number
                if (retVal)
                {
                    Id = Guid.NewGuid();
                    DocumentNumber = NumberSequenceManager.TheNumberSequenceManager.GetNumberSequence(NumberSequenceIdDocNo).GetNextNum();
                }

                //set file properties
                SetFilePoperties();

                //copy files
                CopyFilesToDest();
                
                //set file attributes
                SaveFileAttributes();
                
                //set processed to true
                Processed = true;
                
                //save xml
                SaveMetaDataToFile(Path.Combine(DestinationFolder, string.Format("{0}.xml", DocumentName)));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if (retVal)
                {
                    //delete files
                    DeleteSourceFiles();
                }
            }

            return retVal;
        }

        private void SaveFileAttributes()
        {
           // throw new NotImplementedException();
        }

        private void MoveFilesToDest()
        {
            foreach (TheFile f in FileList.OrderBy(f => f.CreatedDateTime))
            {
                f.Move(DestinationFolder);
            }
        }

        private void DeleteSourceFiles()
        {
            foreach (TheFile f in FileList.OrderBy(f => f.CreatedDateTime))
            {
                f.DeleteSource(DestinationFolder);
            }
        }

        private void CopyFilesToDest()
        {
            foreach (TheFile f in FileList.OrderBy(f => f.CreatedDateTime))
            {
                f.CopyToDest(DestinationFolder);
            }
        }

        private void SetFilePoperties()
        {
            int i = 1;

            foreach (TheFile f in FileList.OrderBy(f => f.CreatedDateTime))
            {
                //todo: handle double sided docs
                
                f.DestFileNumber = i;
                f.DestFileName = string.Format("{0}-{1}{2}", DocumentName, f.DestFileNumberStrPad(), f.SourceExtension);
                i++;
            }
        }

        private bool CreateDestinationFolder()
        {
            bool retVal;
            
            if (Directory.Exists(DestinationFolder))
            {
                retVal = true;
            }
            else
            {
                try
                {
                    //create folder
                    Directory.CreateDirectory(DestinationFolder);
                    retVal = true;
                }
                catch
                {
                    retVal = false;
                }
            }
            return retVal;
        }
    }
}
