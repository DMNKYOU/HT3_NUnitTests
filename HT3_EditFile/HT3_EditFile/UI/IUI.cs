namespace HT3_EditFile
{
    public interface IUI
    {
        public string EnterChoiseWithExample { get; set; }

        public string ErrorTryAgain { get; set; }

        public string MainWork { get; set; }

        public string StartMethod { get; set; }

        public string EndMethod { get; set; }

        public string LastWriteTime { get; set; }

        public string ErrorFilePath { get; set; }

        public void ShowMessage(string s);

        public string UserEnterString();
    }
}
