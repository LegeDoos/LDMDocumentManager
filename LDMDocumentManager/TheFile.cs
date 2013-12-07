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
        private string m_PathAndFileName;

        public string ThePath { get; private set;}
        public string TheFileName { get; private set; }
        public string TheExtension { get; private set; }
        public string CreatedDate { get; private set; }
        public DateTime CreatedDateTime { get; private set; }

        public TheFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                m_PathAndFileName = FileName;
                LoadFileProperties();
            }
            else
            {
                throw new Exception(string.Format("File {0} not found", FileName));
            }
        }

        private void LoadFileProperties()
        {
            ThePath = Path.GetDirectoryName(m_PathAndFileName);
            TheFileName = Path.GetFileName(m_PathAndFileName);
            TheExtension = Path.GetExtension(m_PathAndFileName);
            CreatedDateTime = File.GetCreationTimeUtc(m_PathAndFileName);
            CreatedDate = StringManagement.DateToString(CreatedDateTime);
            
        }
    }
}
