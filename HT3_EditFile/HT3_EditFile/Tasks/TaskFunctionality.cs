using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using HT3_EditFile.Work_with_File;

namespace HT3_EditFile.Tasks
{
    public class TaskFunctionality: ITaskFunctionality
    {
        //public List<Task> tasksList { get; private set; } = new List<Task>();

        IReadWriteFile ReadWriteFile { get; set; }

        public TaskFunctionality(IReadWriteFile readWriteFile)
        {
            ReadWriteFile = readWriteFile;
        }

        public Tuple<string, DateTime, int> WorkNewTaskAndTakeResult(string symbolForSearch)
        {
            Tuple<string, DateTime> resaultRead = ReadWriteFile.ReadFileTakeResultAndWhenChangeFileWhichRead();
            return Tuple.Create(symbolForSearch, resaultRead.Item2, new Regex(symbolForSearch).Matches(resaultRead.Item1 != null ? resaultRead.Item1 : "").Count);
        }

        public bool AddTaskWriteToFile(string symbolToWrite)
        {
            if (symbolToWrite != null)
            {
                return ReadWriteFile.WriteFile(symbolToWrite);
            }

            return false;
        }
    }
}
