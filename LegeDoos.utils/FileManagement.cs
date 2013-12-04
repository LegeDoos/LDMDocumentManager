using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegeDoos.Utils
{
    public class FileManagement
    {
        /// <summary>
        /// Move the file to a new destination
        /// </summary>
        /// <param name="_sourcePath">Source path of the source file</param>
        /// <param name="_sourceFile">Source file name</param>
        /// <param name="_destPath">Destination path</param>
        /// <param name="_destFile">Destination filen ame</param>
        /// <returns>True on succes</returns>
        public static Boolean MoveFile(string _sourcePath, string _sourceFile, string _destPath, string _destFile)
        {
            Boolean retVal = false;
            string  source = string.Format(@"{0}\{1}", _sourcePath, _sourceFile);
            string  destination = string.Format(@"{0}\{1}", _destPath, _destFile);

            if (File.Exists(source) && Directory.Exists(_destPath))
            {
                //move and rename
                try
                {
                    File.Move(source, destination);
                    retVal = true;
                }
                catch (IOException)
                {
                    retVal = false;
                }
            }
            return retVal;
        }
        /// <summary>
        /// Get the created date from the file as string in format yyyymmdd
        /// </summary>
        /// <param name="_filePath">File to get the date from</param>
        /// <returns>The created date of the file in foprmat yyyymmdd, current date when file not found</returns>
        public static string GetFileCreatedDateAsString(string _filePath)
        {
            string retVal = string.Empty;
            DateTime creationTime = DateTime.Now;

            if (File.Exists(_filePath))
            {
                creationTime = File.GetCreationTimeUtc(_filePath);
            }

            return StringManagement.DateToString(creationTime);
        }
    }
}
