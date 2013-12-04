using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegeDoos.Utils
{
    public class StringManagement
    {
        public static string DateToString(DateTime _dateTime)
        {
            string retVal = string.Empty;
            
            if (_dateTime != null)
            {
                retVal = string.Format("{0}{1}{2}", _dateTime.Year, _dateTime.Month.ToString("00"), _dateTime.Day.ToString("00"));
            }
            return retVal;
        }
    }
}
