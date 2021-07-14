using System;

namespace HT3_EditFile.Work_with_File
{
    public interface IReadWriteFile
    {
        public Tuple<string, DateTime> ReadFileTakeResultAndWhenChangeFileWhichRead();

        public bool WriteFile(string message);

        //public DateTime GetFileLastModificationDateTime();
    }
}
