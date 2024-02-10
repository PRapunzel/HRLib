using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HRLib;

namespace UnitTestProject
{
    [TestClass]
    public class ValidPasswordTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            Assert.AreEqual(true, hRLib.ValidPassword("Markantonis&01"));
            Assert.AreEqual(false, hRLib.ValidPassword("Markantonis&"));
        }
    }
}
