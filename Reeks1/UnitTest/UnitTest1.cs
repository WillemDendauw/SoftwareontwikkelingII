using System;
using EersteProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestName()
        {
            Student s = new Student("Jan", 250);
            Assert.AreEqual(s.Name, "Jan");
        }

        [TestMethod]
        public void testConstructor()
        {
            Persoon s = new Student("Jan", 250);
            Assert.IsTrue(s is Student);
        }
    }
}
