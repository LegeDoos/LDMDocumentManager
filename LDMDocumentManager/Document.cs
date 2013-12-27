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

namespace LegeDoos.LDM
{
    public class Document
    {
        public Guid Id { get; set; }
        public String DocumentName 
        { 
            get
            {
                return CreatedDateYYYYMMDD != null || Sender != null || Category != null ? string.Format("{0}_{1}_{2}_{3}", CreatedDateYYYYMMDD, Sender, Category, Id) : "";
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

        public Document()
        {
            //Id = Guid.NewGuid();
            Id = new Guid();
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
        /// Save the document to XML
        /// </summary>
        /// <param name="_filename">Filename to save to</param>
        internal void SaveToFile(string _filename)
        {
            try
            {
                if (Directory.Exists(Path.GetDirectoryName(_filename)) && UnSaved == false)
                {
                    using (StreamWriter sw = new StreamWriter(_filename))
                    {
                        xs.Serialize(sw, this);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
