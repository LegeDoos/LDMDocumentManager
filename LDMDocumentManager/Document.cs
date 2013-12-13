using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LegeDoos.LDM
{
    public class Document
    {
        public Guid Id { get; private set; }
        public String DocumentName { get; set; }
        public String CreatedDateYYYYMMDD { get; set; }
        public String Category { get; set; }
        public String Sender { get; set; }
        public String Description { get; set; }
        public String[] Tags { get; set; }
        public List<TheFile> FileList { get; set; }
        public Boolean UnSaved { get; private set; }


        public Document()
        {
            Id = new Guid();
            FileList = new List<TheFile>();
            UnSaved = true;
            Category = "test123";
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



    }
}
