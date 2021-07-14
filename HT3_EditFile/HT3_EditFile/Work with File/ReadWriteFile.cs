using System;
using System.IO;

namespace HT3_EditFile.Work_with_File
{
    public class ReadWriteFile: IReadWriteFile
    {
        public string PathToFile { 

            get => _pathToFile;

            set {
                if (File.Exists(value))
                {
                    _pathToFile = value;
                }
                else
                    throw new FileNotFoundException("Error!"); 
            } 
        }

        private static object myLocker = new object();

        public ReadWriteFile(string path)
        {
            PathToFile = path;
        }

        private string _pathToFile = null;

        public Tuple<string, DateTime> ReadFileTakeResultAndWhenChangeFileWhichRead()//ReadFile()
        {
            string resaultReadFile = "";
            DateTime lastModifFile;

            lock (myLocker)
            {
                using (StreamReader reader = new StreamReader(PathToFile))
                {
                    resaultReadFile = reader.ReadToEnd();
                }

                lastModifFile = File.GetLastWriteTime(PathToFile);
            }

            return Tuple.Create(resaultReadFile, lastModifFile);
        }

        public bool WriteFile(string message)
        {
            DateTime dateTimeBeforeWrite, dateTimeAfterWrite;
            lock (myLocker)
            {
                dateTimeBeforeWrite = File.GetLastWriteTime(PathToFile);

                using (StreamWriter writer = new StreamWriter(PathToFile, true))
                {
                    writer.WriteLine(message);
                }

                dateTimeAfterWrite = File.GetLastWriteTime(PathToFile);
            }

            return dateTimeAfterWrite != dateTimeBeforeWrite;
        }

        //public DateTime GetFileLastModificationDateTime()
        //{
        //    return File.GetLastWriteTime(PathToFile);
        //}
    }
}
