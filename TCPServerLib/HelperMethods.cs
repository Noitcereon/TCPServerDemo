using System;
using System.Collections.Generic;
using System.Text;

namespace TCPLib
{
    public class HelperMethods
    {
        /// <summary>
        /// Counts the number of words in a message based on space seperation.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountWordsInString(string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            int output = str.Split(' ').Length;

            return output;
        }
    }
}
