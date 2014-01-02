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
        public string SourcePathAndFileName { get; set; }
        public string SourcePath { get; set; }
        public string SourceFileName { get; set; }
        public string SourceExtension { get; set; }
        public string CreatedDate { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string DestFileName { get; set; }
        public string DestFileNumber { get; set; }

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
                SourcePathAndFileName = FileName;
                LoadFileProperties();
                return true;
            }
            return false;
        }

        private void LoadFileProperties()
        {
            SourcePath = Path.GetDirectoryName(SourcePathAndFileName);
            SourceFileName = Path.GetFileName(SourcePathAndFileName);
            SourceExtension = Path.GetExtension(SourcePathAndFileName);
            CreatedDateTime = File.GetCreationTimeUtc(SourcePathAndFileName);
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
