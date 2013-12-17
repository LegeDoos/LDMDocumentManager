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
        public string PathAndFileName { get; private set; }

        public string ThePath { get; private set; }
        public string TheFileName { get; private set; }
        public string TheExtension { get; private set; }
        public string CreatedDate { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        public TheFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                PathAndFileName = FileName;
                LoadFileProperties();
            }
            else
            {
                throw new Exception(string.Format("File {0} not found", FileName));
            }
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
