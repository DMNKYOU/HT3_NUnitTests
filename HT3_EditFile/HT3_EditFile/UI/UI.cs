using System;

namespace HT3_EditFile
{
    public class UI : IUI
    {
        public string EnterChoiseWithExample { get; set; } = "Enter characters separated by a comma and the int number with a space at the end\nExample: \"k,l,j,o  9\" - good                \"k,l,j, ok 9\" - ignore part\"ok\"";
        
        public string ErrorTryAgain { get; set; } = "Error! Try again!";
        
        public string MainWork { get; set; } = "Main work";
        
        public string StartMethod { get; set; } = "Start method ";

        public string EndMethod { get; set; } = "End method ";

        public string LastWriteTime { get; set; } = "LastWriteTime File at ";

        public string ErrorFilePath { get; set; } = "Error! Enter valid path";

        public UI()
        {

        }

        public void ShowMessage(string s)
        {
            Console.WriteLine(s);
        }

        public string UserEnterString()
        {
            return Console.ReadLine();
        }
    }
}
