using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RaceCatsTask;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Creating two test objects to test that both are from same type while one is directly called and the other is from the method.
            var TestObj1 = Factory.GetAPunter("Joe");
            var TestObj2 = new Joe();
            // Using assert to check equality of types.
            Assert.AreEqual(TestObj1, TestObj2);
            
        }
    }
}
