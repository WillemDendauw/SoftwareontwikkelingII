using System;
using FileSystem.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTestFileSystem
    {
        [TestMethod]
        public void TestCreateFile()
        {
            Folder testFolder = new Folder("");
            TextFile testFile = testFolder.CreateTextFile("test");
            testFile.Inhoud = "line1";

            //test
            TextFile temp = (TextFile)testFolder.GetFile("test");
            Assert.AreEqual("line1", temp.Inhoud);
        }

        [TestMethod]
        [ExpectedException(typeof(FileSystemException))]
        public void TestException()
        {
            Folder testFolder = new Folder("");
            testFolder.CreateTextFile("test");
            testFolder.CreateTextFile("test");//dit hoort exceptie op te werpen
        }

        [TestMethod]
        public void TestIndexer()
        {
            Folder testFolder = new Folder("");
            testFolder.CreateTextFile("test");
            testFolder.CreateTextFile("test2");
            Assert.AreEqual(testFolder.GetFile("test"), testFolder["test"]);
        }
    }
}
