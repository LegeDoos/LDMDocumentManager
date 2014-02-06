using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using LegeDoos.Utils;
using System.Windows.Forms;

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
        private Boolean Isimage { get; set; }
        private Boolean ImageFail { get; set; }
        private Object ImageLock = new Object();

        public TheFile(string FileName)
        {
            if (!Init(FileName))
            {
                throw new Exception(string.Format("File {0} not found or not supported", FileName));
            }
        }

        public TheFile()
        {
        }

        private Boolean Init(string FileName)
        {
            if (File.Exists(FileName) && FileFormatSupported(FileName))
            {
                SourcePathAndFileName = FileName;
                LoadFileProperties();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the file is supported
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private bool FileFormatSupported(string FileName)
        {
            string ext = Path.GetExtension(FileName).Substring(1).ToLower(); //get rid of dot
            return GlobalSettings.theSettings.SupportedFileTypes.ContainsKey(ext);            
        }

        private void LoadFileProperties()
        {
            SourcePath = Path.GetDirectoryName(SourcePathAndFileName);
            SourceFileName = Path.GetFileName(SourcePathAndFileName);
            SourceExtension = Path.GetExtension(SourcePathAndFileName);
            CreatedDateTime = File.GetCreationTimeUtc(SourcePathAndFileName);
            CreatedDate = StringManagement.DateToString(CreatedDateTime);
        }

        public string GetCreatedDateFromFileName
        {
            get
            {
                int dateFromFileName = 0;
                if (SourceFileName.Length <= 8)
                    return string.Empty;
                bool isNumeric = int.TryParse(SourceFileName.Substring(0, 8), out dateFromFileName);
                return isNumeric ? dateFromFileName.ToString() : string.Empty;
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
            ClearImage();            
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
            lock (ImageLock)
            {
                if (!Isimage && !ImageFail && GlobalSettings.theSettings.SupportedImageFileTypes.Contains(SourceExtension.Substring(1).ToLower()) && File.Exists(SourcePathAndFileName))
                {
                    try
                    {
                        using (var fs = new System.IO.FileStream(SourcePathAndFileName, System.IO.FileMode.Open))
                        {
                            var bmp = new Bitmap(fs);
                            m_Image = (Bitmap)bmp.Clone();
                            bmp.Dispose();
                            Isimage = true;
                        }
                    }
                    catch
                    {
                        ImageFail = true;
                        MessageBox.Show(String.Format("Can't load image file {0}", SourcePathAndFileName));
                    }
                }
            }
            return m_Image;
        }

        /// <summary>
        /// Clear the image and free memory
        /// </summary>
        public void ClearImage()
        {
            if (m_Image != null)
                m_Image.Dispose();
            m_Image = null;
            Isimage = false;
        }
    }
} 
