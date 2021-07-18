using Moq;
using System;
using NUnit.Framework;
using HT3_EditFile;
using HT3_EditFile.Tasks;
using NUnit;
namespace HT3_EditFileNUnitTest
{
    public class ReadWriteTest
    {
        [TestCase(new string[] { "s", "d", "w" }, 2)]
        [TestCase(new string[] { }, 2)]
        public void StartTasksTest1_VerifuNumebCallWorkNewTaskAndTakeResult(string[] str, int N)
        {
            var mockUIAdapter = new Mock<IUIAdapter>();
            var mockTaskFunct = new Mock<ITaskFunctionality>();
            
            mockTaskFunct.Setup(foo => foo.WorkNewTaskAndTakeResult(It.IsAny<string>())).Returns(It.IsAny<Tuple<string, DateTime, int>>());

            Manager manager = new Manager(mockUIAdapter.Object, mockTaskFunct.Object);

            manager.StartTasks(str, N);

            mockTaskFunct.Verify(foo => foo.WorkNewTaskAndTakeResult(It.IsAny<string>()), Times.Exactly(str.Length));
        }

        
        [TestCase(new string[] { "s", "d", "w" }, 2)]
        [TestCase(new string[] { }, 2)]
        public void StartTasksTest2_VerifuNumebCallWorkNewTaskAndTakeResult(string[] str, int N)
        {
            var mockUIAdapter = new Mock<IUIAdapter>();
            var mockTaskFunct = new Mock<ITaskFunctionality>();

            mockUIAdapter.Setup(foo => foo.SplitToStringSymbolInfo(It.IsAny<Tuple<string, DateTime, int>>()));

            Manager manager = new Manager(mockUIAdapter.Object, mockTaskFunct.Object);

            manager.StartTasks(str, N);

            mockUIAdapter.Verify(foo => foo.SplitToStringSymbolInfo(It.IsAny<Tuple<string, DateTime, int>>()), Times.Exactly(str.Length));
        }

        
        [TestCase(new string[] { "s", "d", "w" }, 2)]
        public void StartTasksTest3_VerifuNumebCallAddTaskWriteToFile(string[] str, int N)
        {
            var mockUIAdapter = new Mock<IUIAdapter>();
            var mockTaskFunct = new Mock<ITaskFunctionality>();

            mockTaskFunct.Setup(foo => foo.AddTaskWriteToFile(It.IsAny<string>())).Returns(true);

            Manager manager = new Manager(mockUIAdapter.Object, mockTaskFunct.Object);

            manager.StartTasks(str, N);

            mockTaskFunct.Verify(foo => foo.AddTaskWriteToFile(It.IsAny<string>()), Times.Exactly(N % str.Length));
        }
    }
}
