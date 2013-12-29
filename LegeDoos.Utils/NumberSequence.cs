using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LegeDoos.Utils
{

    public class NumberSequenceManager
    {
        private static NumberSequenceManager m_NumberSequenceManager = null;
        private static List<NumberSequence> NumberSequenceList { get; set; }
        public string ConfigLocation { get; set; }
 
        public NumberSequenceManager()
        {
            NumberSequenceList = new List<NumberSequence>();
        }

        public static NumberSequenceManager TheNumberSequenceManager //(string ConfigLocation)
        {
            get 
            {
                if (m_NumberSequenceManager == null)
                    m_NumberSequenceManager = new NumberSequenceManager();
                return m_NumberSequenceManager;
            }
        }

        public NumberSequence GetNumberSequence(string SequenceId)
        {
            NumberSequence retVal;

            retVal = NumberSequenceList.FirstOrDefault(ns => ns.NumberSequenceId == SequenceId);

            if (retVal == null)
            {
                retVal = NumberSequence.GetNumberSequence(SequenceId, ConfigLocation);
                NumberSequenceList.Add(retVal);
            }
            return retVal;
        }
    }

    public class NumberSequence
    {
        //external
        public Int64 NextNum { get; set; }
        public Guid LockGuid { get; set; }
        public string NumberSequenceId { get; set; }
        
      //  private Guid CurrentGuid = Guid.NewGuid();

        //internal
       // private int m_CacheSize = 10;
       // private static readonly object ThisLock = new object();
        public static XmlSerializer xs;
      //  private Int64 NumbersInCache = 0;
      //  private Int64 NextNumCache = 0;
     //   private string ConfigFileLocation { get; set; }

        #region Contstructors

        /// <summary>
        /// Constructor for deserialize
        /// </summary>
        public NumberSequence()
        {
            xs = new XmlSerializer(typeof(NumberSequence));
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="SequenceID">Id of the number sequence</param>
        /// <param name="ConfigFileLocation">Location of the config file for the number sequence</param>
        public NumberSequence(string SequenceID, string _ConfigFileLocation) : this()
        {
            if (Directory.Exists(_ConfigFileLocation))
            {
                NumberSequenceId = SequenceID;
                NextNum = 1;
                LockGuid = Guid.Empty;
                //ConfigFileLocation = _ConfigFileLocation;
                SaveToFile(GetFileName(SequenceID, _ConfigFileLocation));
            }
            else
            {
                throw new FileNotFoundException(string.Format("{0} not found for number sequence {1}", _ConfigFileLocation, SequenceID));
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get the numbersequence
        /// </summary>
        /// <param name="SequenceID">Id of the number sequence</param>
        /// <param name="ConfigFileLocation">Location of the config file for the number sequence</param>
        /// <returns></returns>
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
        /*
        public Int64 GetNextNum()
        {
            Int64 retVal = 0;
            if (NumbersInCache == 0)
            {
                //get new nums from cache
                lock (ThisLock)
                {
                    NumberSequence NumberSequenceHelper = new NumberSequence(NumberSequenceId, ConfigFileLocation);
                    if (NumberSequenceHelper.LockGuid == Guid.Empty)
                    {
                        LockGuid = CurrentGuid;
                        SaveToFile(GetFileName(NumberSequenceId, ConfigFileLocation));
                        NumbersInCache = m_CacheSize;
                        NextNumCache = NextNum;
                        NextNum = NextNum + NumbersInCache;
                        LockGuid = Guid.Empty;
                        SaveToFile(GetFileName(NumberSequenceId, ConfigFileLocation));
                    }
                    else
                    {
                        //wait and try again
                    }
                    
                }
            }

            NumbersInCache--;
            retVal = NextNumCache;
            NextNumCache++;
            return retVal;
        }
        */
        #endregion

        #region Helpers
        /// <summary>
        /// Load number sequence settings from config file
        /// </summary>
        /// <param name="FileName">File name of the config file</param>
        /// <returns></returns>
        private static NumberSequence LoadFromFile(string FileName)
        {
            using (StreamReader sr = new StreamReader(FileName))
            {
                return xs.Deserialize(sr) as NumberSequence;
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
