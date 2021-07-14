using System;
using System.Collections.Generic;
using System.Text;

namespace HT3_EditFile
{
    public class UIAdapter :IUIAdapter
    {
        private IUI View { get; set; }

        public UIAdapter(IUI ui)
        {
            View = ui;
        }

        public void SplitToStringSymbolInfo(Tuple<string, DateTime, int> toSplitStringParametrs)
        {
            View.ShowMessage($"File has {toSplitStringParametrs.Item3} {toSplitStringParametrs.Item1} symbols at {toSplitStringParametrs.Item2}");
        }

        public void ShowBoolWriteFils(bool writeResultToShow)
        {
            View.ShowMessage($"File overrite {writeResultToShow}");
        }

    }
}
