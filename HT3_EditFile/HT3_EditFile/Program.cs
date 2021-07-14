using System;
using System.IO;
using HT3_EditFile.Parsers;
using HT3_EditFile.Tasks;
using HT3_EditFile.Work_with_File;

namespace HT3_EditFile
{
    // k,l,j,q,w,e,r,t,y,z,y 9 сохраненный пример для ввода
    class Program
    {
        static void Main(string[] args)
        {
            UI view = new UI();
            UIAdapter uIAdapter = new UIAdapter(view);
            ReadWriteFile file;
            StringNumber stringNumber = new StringNumber();

            try
            {
                file = new ReadWriteFile("..\\..\\..\\File\\Text.txt");
            }
            catch (FileNotFoundException ex)
            {
                view.ShowMessage(ex.Message);
                return;
            }
           
            view.ShowMessage(view.EnterChoiseWithExample);

            while (!stringNumber.SetValues(view.UserEnterString()))
            {
                view.ShowMessage(view.ErrorTryAgain);
            }

            TaskFunctionality taskRunner = new TaskFunctionality(file);
            Manager manager = new Manager(uIAdapter, taskRunner);
            manager.StartTasks(stringNumber.Str, stringNumber.N);
        }
    }
}
