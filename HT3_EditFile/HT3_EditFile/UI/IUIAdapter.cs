using System;
using System.Collections.Generic;
using System.Text;

namespace HT3_EditFile
{
    public interface IUIAdapter
    {
        public void SplitToStringSymbolInfo(Tuple<string, DateTime, int> toSplitStringParametrs);

        public void ShowBoolWriteFils(bool writeResultToShow);
    }
}
