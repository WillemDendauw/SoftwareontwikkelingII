using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleProgram;
using ProxyModel;
using ProxyModel.Pattern;

namespace BestandsBeheerTesten
{
    [TestClass]
    public class AuthenticationProxyTest
    {
        [TestMethod]
        public void TestReadFile()
        {
            User testuser = new User("test", false);
            IFile file1 = new AuthenticationProxyFile(testuser, "file1.txt");
            User testadmin = new User("admin", true);
            IFile file2 = new AuthenticationProxyFile(testadmin, "file1.txt");
            Assert.AreEqual(file1.Content, file2.Content);
        }

        [TestMethod]
        public void TestAdminAcces()
        {
            User testadmin = new User("admin", true);
            AuthenticationProxyFile file1 = new AuthenticationProxyFile(testadmin, ".file1.txt");
            string content = file1.Content;
        }

        [TestMethod]
        [ExpectedException(typeof(FileAccesException))]
        public void TestAdminAccesException()
        {
            User testuser = new User("test", false);
            IFile file1 = new AuthenticationProxyFile(testuser, ".file1.txt");
            string content = file1.Content;
        }
    }
}
