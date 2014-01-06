using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
        public int DestFileNumber { get; set; }
        private Image m_Image;

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

        internal void CopyToDest(string DestinationFolder)
        {
            string DestinationFileLocal = Path.Combine(DestinationFolder, DestFileName);

            if (File.Exists(DestinationFileLocal))
                throw new FileLoadException(String.Format("File {0} already exists", DestinationFileLocal));

            if (File.Exists(SourcePathAndFileName))
            {
                File.Copy(SourcePathAndFileName, DestinationFileLocal);
            }
            else
                throw new FileLoadException(String.Format("File {0} does not exists", DestinationFileLocal));
        }

        public string DestFileNumberStrPad()
        {
            return DestFileNumber.ToString().PadLeft(3, '0');
        }

        internal void DeleteSource(string DestinationFolder)
        {
            File.Delete(SourcePathAndFileName);
        }

        internal void Move(string DestinationFolder)
        {
            string DestinationFileLocal = Path.Combine(DestinationFolder, DestFileName);

            if (File.Exists(DestinationFileLocal))
                throw new FileLoadException(String.Format("File {0} already exists", DestinationFileLocal));

            if (File.Exists(SourcePathAndFileName))
            {
                File.Move(SourcePathAndFileName, DestinationFileLocal);
            }
            else
                throw new FileLoadException(String.Format("File {0} does not exists", DestinationFileLocal));
        }
        /// <summary>
        /// Load image once without locking the file
        /// </summary>
        /// <returns></returns>
        public Image Image()
        {       
            if (!ImageManagement.IsImage(m_Image) && File.Exists(SourcePathAndFileName))
            {
                using (var fs = new System.IO.FileStream(SourcePathAndFileName, System.IO.FileMode.Open))
                {
                    var bmp = new Bitmap(fs);
                    m_Image = (Bitmap)bmp.Clone();
                    bmp.Dispose();
                }
            }
            return m_Image;
        }
    }
} 
