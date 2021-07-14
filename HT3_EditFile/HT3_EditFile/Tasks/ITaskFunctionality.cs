using System;
using System.Collections.Generic;
using System.Text;

namespace HT3_EditFile.Tasks
{
    public interface ITaskFunctionality
    {
        public Tuple<string, DateTime, int> WorkNewTaskAndTakeResult(string symbolForSearch);

        public bool AddTaskWriteToFile(string symbolToWrite);


    }
}
