using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace HT3_EditFile.Parsers
{
    public class StringNumber
    {
        public string[] Str { get; private set; } = null;

        public int N { get; private set; } = -1;

        public StringNumber()
        {
        }

        public bool SetValues(string allStr)
        {
            int startIndexNumber = allStr.LastIndexOf(' ');
            int numberInStr = 0;
            bool flag = true;

            if (!Int32.TryParse(allStr.Substring(startIndexNumber + 1), out numberInStr))
            {
                return false;
            }

            if (allStr.Length == 0 || (startIndexNumber <= 0 && flag == true))
            {
                return false;
            }
            else
            {
                if (numberInStr < 0)
                {
                    return false;
                }

                N = numberInStr;
                Str = (allStr.Substring(0, startIndexNumber + 1)).Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Where((s) => { s.Trim(); return s.Length == 1; }).Distinct().ToArray();
            }

            return true;
        }
    }
}
