using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegeDoos.Utils;

namespace LegeDoos.LDM
{
    public class TheFile
    {
        public string PathAndFileName { get; set; }

        public string ThePath { get; set; }
        public string TheFileName { get; set; }
        public string TheExtension { get; set; }
        public string CreatedDate { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public TheFile(string FileName)
        {
            if (!Init(FileName))
            {
                throw new Exception(string.Format("File {0} not found", FileName));
            }
        }

        public TheFile()
        {
        }

        private Boolean Init(string FileName)
        {
            if (File.Exists(FileName))
            {
                PathAndFileName = FileName;
                LoadFileProperties();
                return true;
            }
            return false;
        }

        private void LoadFileProperties()
        {
            ThePath = Path.GetDirectoryName(PathAndFileName);
            TheFileName = Path.GetFileName(PathAndFileName);
            TheExtension = Path.GetExtension(PathAndFileName);
            CreatedDateTime = File.GetCreationTimeUtc(PathAndFileName);
            CreatedDate = StringManagement.DateToString(CreatedDateTime);
        }

        public string GetSenderFromPath 
        { 
            get 
            {
                //#15
                return "";
            } 
        }

        public string GetCategoryFromFileName 
        { 
            get
            {
                //#15
                return "";
            }
        }
    }
} 
