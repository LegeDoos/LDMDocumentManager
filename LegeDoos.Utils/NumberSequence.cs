using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LegeDoos.Utils
{
    /// <summary>
    /// Class to handle multiple number sequences in a static list
    /// </summary>
    public class NumberSequenceManager
    {
        private static NumberSequenceManager m_NumberSequenceManager = null;
        private static List<NumberSequence> NumberSequenceList { get; set; }
        public string ConfigLocation { get; set; }
 
        public NumberSequenceManager()
        {
            NumberSequenceList = new List<NumberSequence>();
        }

        public static NumberSequenceManager TheNumberSequenceManager
        {
            get 
            {
                if (m_NumberSequenceManager == null)
                    m_NumberSequenceManager = new NumberSequenceManager();
                return m_NumberSequenceManager;
            }
        }

        /// <summary>
        /// Find or create the number sequence
        /// </summary>
        /// <param name="SequenceId">Number sequence to find or create</param>
        /// <returns>NumberSequence object</returns>
        public NumberSequence GetNumberSequence(string SequenceId)
        {
            NumberSequence retVal;

            ValidateConfigLocation();

            retVal = NumberSequenceList.FirstOrDefault(ns => ns.NumberSequenceId == SequenceId);

            if (retVal == null)
            {
                retVal = NumberSequence.GetNumberSequence(SequenceId, ConfigLocation);
                NumberSequenceList.Add(retVal);
            }
            return retVal;
        }

        /// <summary>
        /// Validate if the configlocation is set
        /// </summary>
        private void ValidateConfigLocation()
        {
            if (ConfigLocation == null || !Directory.Exists(ConfigLocation))
            {
                throw new Exception("Config location not set for numbersequence manager");
            }
        }
    }

    /// <summary>
    /// Create continuous numbers
    /// </summary>
    public class NumberSequence
    {
        public Int64 NextNum { get; set; }
        public Guid LockGuid { get; set; }
        public string NumberSequenceId { get; set; }
        
        private Guid CurrentGuid = Guid.NewGuid();
        private const Int64 m_CacheSize = 3;
        private static readonly object ThisLock = new object();
        public static XmlSerializer xs;
        private Int64 NumbersInCache = 0;
        private Int64 NextNumCache = 0;
        private string ConfigFileName { get; set; }
        private string ConfigPath
        {
            get
            {
                return ConfigFileName != null ? Path.GetDirectoryName(ConfigFileName) : String.Empty;
            }
        }

        #region Contstructors

        /// <summary>
        /// Constructor for deserialize
        /// </summary>
        public NumberSequence()
        {
            InitXmlSerializer();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="SequenceID">Id of the number sequence</param>
        /// <param name="_ConfigFileLocation">Location of the config file for the number sequence</param>
        public NumberSequence(string SequenceID, string _ConfigFileLocation) : this()
        {
            ConfigFileName = GetFileName(SequenceID, _ConfigFileLocation);

            if (File.Exists(ConfigFileName))
            {
                throw new Exception("The number sequence already exists, use NumberSequence.GetNumbersequence instead");
            }

            if (Directory.Exists(ConfigPath))
            {
                NumberSequenceId = SequenceID;
                NextNum = 1;
                LockGuid = Guid.Empty;
                SaveToFile(ConfigFileName);
            }
            else
            {
                throw new FileNotFoundException(string.Format("{0} not found for number sequence {1}", ConfigFileName, SequenceID));
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get the numbersequence
        /// </summary>
        /// <param name="SequenceID">Id of the number sequence</param>
        /// <param name="ConfigFileLocation">Location of the config file for the number sequence</param>
        /// <returns>NumberSequence</returns>
        public static NumberSequence GetNumberSequence(string SequenceID, string ConfigFileLocation)
        {
            string FileName = GetFileName(SequenceID, ConfigFileLocation);

            if (File.Exists(FileName))
            {
                return LoadFromFile(FileName);
            }
            else
            {
                return new NumberSequence(SequenceID, ConfigFileLocation);
            }
        }
        
        /// <summary>
        /// Get the next number from the numbersequence
        /// </summary>
        /// <param name="_CustomCacheSize">If you know the numbers you need you can set a custom cache size so the number sequence is continuous after restarting the application</param>
        /// <returns></returns>
        public Int64 GetNextNum(int _CustomCacheSize = -1)
        {
            Int64 retVal = 0;
            if (NumbersInCache == 0)
            {
                //get new nums from cache
                lock (ThisLock)
                {
                    NumberSequence NumberSequenceHelper = GetNumberSequence(NumberSequenceId, ConfigPath);
                    if (NumberSequenceHelper.LockGuid == Guid.Empty)
                    {
                        LockGuid = CurrentGuid;
                        //get next num from file (can be changed)
                        NextNumCache = NumberSequenceHelper.NextNum;
                        
                        SaveToFile(ConfigFileName);
                        NumbersInCache = _CustomCacheSize == -1 ? m_CacheSize : _CustomCacheSize;
                        NextNum = NextNumCache + NumbersInCache;
                        LockGuid = Guid.Empty;
                        SaveToFile(ConfigFileName);
                    }
                    else
                    {
                        //wait and try again
                        throw new NotImplementedException();
                    }
                    
                }
            }

            NumbersInCache--;
            retVal = NextNumCache;
            NextNumCache++;
            return retVal;
        }
        
        #endregion

        #region Helpers
        /// <summary>
        /// Initialize the XML serializer
        /// </summary>
        private static void InitXmlSerializer()
        {
            if (xs == null)
                xs = new XmlSerializer(typeof(NumberSequence));
        }

        /// <summary>
        /// Load number sequence settings from config file
        /// </summary>
        /// <param name="FileName">File name of the config file</param>
        /// <returns></returns>
        private static NumberSequence LoadFromFile(string FileName)
        {
            InitXmlSerializer();
            NumberSequence RetVal;
            using (StreamReader sr = new StreamReader(FileName))
            {
                RetVal = xs.Deserialize(sr) as NumberSequence;
                RetVal.ConfigFileName = FileName;
                return RetVal;
            }
        }

        /// <summary>
        /// Save the number sequence settings to the config file
        /// </summary>
        /// <param name="FileName"></param>
        private void SaveToFile(string FileName)
        {
            using (StreamWriter sw = new StreamWriter(FileName))
            {
                xs.Serialize(sw, this);
            }
        }

        /// <summary>
        /// Generate the file name for the number sequence
        /// </summary>
        /// <param name="SequenceID"></param>
        /// <param name="ConfigFileLocation"></param>
        /// <returns></returns>
        static string GetFileName(string SequenceID, string ConfigFileLocation)
        {
            return string.Format(@"{0}\{1}.xml", ConfigFileLocation, SequenceID);
        }
        #endregion

    }

}
