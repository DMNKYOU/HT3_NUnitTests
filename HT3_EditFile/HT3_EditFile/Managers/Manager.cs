using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using HT3_EditFile.Parsers;
using HT3_EditFile.Tasks;
using HT3_EditFile.Work_with_File;

namespace HT3_EditFile
{
    public class Manager
    {
        private IUIAdapter uiAdapter { get; set; }

        private ITaskFunctionality taskFunctional { get; set; }

        public Manager(IUIAdapter uiAdapt, ITaskFunctionality taskFuс) 
        {
            uiAdapter = uiAdapt;
            taskFunctional = taskFuс;
        }


        public void StartTasks(string[] symbolsToFind, int N) 
        {
            Parallel.ForEach<string>(symbolsToFind, (symbolToSearch, psl, indexString) => {
                Thread.Sleep((int)indexString * 100);
                uiAdapter.SplitToStringSymbolInfo(taskFunctional.WorkNewTaskAndTakeResult(symbolToSearch));

                if (indexString % N == 0)
                {
                    taskFunctional.AddTaskWriteToFile(symbolsToFind[(new Random()).Next(0, symbolsToFind.Length)]);//uiAdapter.ShowBoolWriteFils
                }
            });

        }

        
    }
}
