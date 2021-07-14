using NUnit;
using Moq;
using HT3_EditFile.Work_with_File;
using HT3_EditFile.Tasks;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HT3_EditFileNUnitTest
{
    public class TaskFunctionalityTest
    {
        
        [TestCase("", "s")]
        [TestCase("ssdk", "s")]
        [TestCase(null, "s")]
        public void WorkNewTaskAndTakeResultTest1_NumberCalls(string whereFindStr, string symbol)
        {
            var mock = new Mock<IReadWriteFile>();
            mock.Setup(foo => foo.ReadFileTakeResultAndWhenChangeFileWhichRead()).Returns(Tuple.Create(whereFindStr, new DateTime()));
            
            TaskFunctionality tfunc = new TaskFunctionality(mock.Object);

            //Act 
            tfunc.WorkNewTaskAndTakeResult(symbol);

            // Assert
            mock.Verify(foo => foo.ReadFileTakeResultAndWhenChangeFileWhichRead(), Times.Once());
        }

        
        [TestCase("", "s", 0)]
        [TestCase("ssdk", "s", 2)]
        [TestCase(null, "s", 0)]
        public void WorkNewTaskAndTakeResultTest2_CheckResault(string whereFindStr, string symbol, int expectedNumber)
        {
            var mock = new Mock<IReadWriteFile>();
            mock.Setup(foo => foo.ReadFileTakeResultAndWhenChangeFileWhichRead()).Returns(Tuple.Create(whereFindStr, new DateTime()));
            TaskFunctionality tfunc = new TaskFunctionality(mock.Object);
            Tuple<string, DateTime, int> expected = Tuple.Create(symbol, new DateTime(), expectedNumber);

            //Act 
            Tuple<string, DateTime, int> actual = tfunc.WorkNewTaskAndTakeResult(symbol);

            // Assert
            Assert.AreEqual(actual, expected);
        }

        
        [TestCase("s")]
        public void AddTaskWriteToFileTest1_NumberCalls(string symbol)
        {
            var mock = new Mock<IReadWriteFile>();
            mock.Setup(foo => foo.WriteFile(It.IsAny<string>())).Returns(true);
            TaskFunctionality tfunc = new TaskFunctionality(mock.Object);

            tfunc.AddTaskWriteToFile(symbol);

            mock.Verify(foo => foo.WriteFile(It.IsAny<string>()), Times.Once());
        }

    }
}
