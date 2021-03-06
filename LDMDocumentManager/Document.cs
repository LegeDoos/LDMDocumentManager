﻿using System;
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
        public bool DoubleSided { get; set; }
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
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Document()
        {
            FileList = new List<TheFile>();
            xs = new XmlSerializer(typeof(Document));
            UnSaved = true;
            Category = string.Empty;
            Sender = string.Empty;
            CreatedDateYYYYMMDD = string.Empty;
            DoubleSided = false;
        }

        /// <summary>
        /// Add a file to the list
        /// </summary>
        /// <param name="_file">The file to add</param>
        public void AddFileToList(TheFile _file)
        {
            if (FileList != null)
            {
                FileList.Add(_file);
            }
        }

        /// <summary>
        /// Add a list of files to the file list
        /// </summary>
        /// <param name="_fileList">Files to add</param>
        public void AddFileList(List<TheFile> _fileList)
        {
            if (_fileList != null)
            {
                _fileList.ForEach(AddFileToList);
            }
        }

        /// <summary>
        /// Validate the document
        /// </summary>
        /// <returns>True if validation is successfull</returns>
        private bool Validate(List<TheFile> _fileList)
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

            if (retVal && DoubleSided && _fileList.Count % 2 == 1)
            {
                MessageBox.Show("You can only add an even number of files to a double sided document");
                retVal = false;
            }
            return retVal;
        }

        /// <summary>
        /// Save the document (metadata)
        /// </summary>
        /// <param name="_fileList">Files to add to the document</param>
        /// <returns>True if successfull</returns>
        internal bool Save(List<TheFile> _fileList)
        {
            bool retVal = true;
            if (Validate(_fileList) && _fileList != null)
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

        /// <summary>
        /// Init the document properties based on a file
        /// </summary>
        /// <param name="_file">The file to base the properties on</param>
        internal void InitFromFile(TheFile _file)
        {
            CreatedDateYYYYMMDD = _file.GetCreatedDateFromFileName == string.Empty ? _file.CreatedDate : _file.GetCreatedDateFromFileName;            
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

        /// <summary>
        /// Process the document. Processing means set correct file properties and save on the correct location
        /// </summary>
        /// <returns>true if successfull</returns>
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
                //SaveFileAttributes(); issue #22
                
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

        /// <summary>
        /// Not implemented
        /// </summary>
        private void SaveFileAttributes()
        {
            string DestinationFileLocal;
            foreach (TheFile f in FileList.OrderBy(f => f.CreatedDateTime))
            {
                DestinationFileLocal = Path.Combine(DestinationFolder, f.DestFileName);
                if (File.Exists(DestinationFileLocal))
                {
                    new NotImplementedException();
                }
            }
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

        /// <summary>
        /// Set the metadata of the files
        /// </summary>
        private void SetFilePoperties()
        {
            int i = 1;
            int count = 0;
            if (FileList != null)
                count = FileList.Count;
            int front = 1;
            int back = count;
            int destNumber;
            int half;

            foreach (TheFile f in FileList.OrderBy(f => f.CreatedDateTime))
            {
                //handle double sided docs
                if (DoubleSided && count % 2 == 0) //must be even number
                {
                    half = count/2;
                    if (i <= half)
                    {
                        //fronts
                        destNumber = front;
                        front += 2;
                    }
                    else
                    {
                        //backs
                        destNumber = back;
                        back -= 2;
                    }
                }
                else
                {
                    destNumber = i;
                }

                f.DestFileNumber = destNumber;
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
