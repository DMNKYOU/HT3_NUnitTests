using Moq;
using System;
using System.IO;
using NUnit.Framework;
using HT3_EditFileNUnitTest;
using HT3_EditFile.Tasks;
using HT3_EditFile.Work_with_File;
using NUnit;
namespace HT3_EditFileNUnitTest.ReadWrite
{
    public class ReadWriteTest
    {
        
        [TestCase("Hello.txt")]
        public void CtorTest(string pathToFile)
        {
            Assert.Throws<FileNotFoundException>(() => new ReadWriteFile(path: pathToFile));
        }


        [TestCase("..\\..\\..\\File\\TextTest.txt")]
        public void ReadFileTest(string pathToFile)
        {
            ReadWriteFile readWriteFile = new ReadWriteFile(pathToFile);
            Tuple<string, DateTime> resaultWorkFile = readWriteFile.ReadFileTakeResultAndWhenChangeFileWhichRead();
            Assert.NotNull(resaultWorkFile.Item1);
        }

        
        [TestCase("..\\..\\..\\File\\TextTest.txt")]
        public void WriteFileTest(string pathToFile)
        {
            ReadWriteFile readWriteFile = new ReadWriteFile(pathToFile);
            Assert.True(readWriteFile.WriteFile("Hello, Test!"));
        }
    }
}
