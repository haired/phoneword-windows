using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneWord.Utils
{
    public enum ConvertionMode 
    {
        [Description("Phone Number to Words")]
        NumberToWords = 0,
        [Description("Phone Number to Words")]
        WordsToNumber = 1
    }
}
