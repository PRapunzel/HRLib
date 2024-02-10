using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HRLib;

namespace UnitTestProject
{
    [TestClass]
    public class ValidNameTest
    {
        [TestMethod]
        public void Test_name_contains_number()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            Assert.AreEqual(false, hRLib.ValidName("Dimitris Markantonis8"));
            Assert.AreEqual(true, hRLib.ValidName("Dimitris Zovoilis"));
            Assert.AreEqual(false, hRLib.ValidName("Dimitri5 Pappa5"));
        }

        [TestMethod]
        public void Test_fullname_is_split()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            Assert.AreEqual(false, hRLib.ValidName("DimitrisMarkantonis"));
            Assert.AreEqual(true, hRLib.ValidName("Dimitris Zovoilis"));
            Assert.AreEqual(false, hRLib.ValidName("DimitrisPappas"));
        }

        [TestMethod]
        public void Test_name_exists()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            Assert.AreEqual(false, hRLib.ValidName(""));
            Assert.AreEqual(true, hRLib.ValidName("Dimitris Zovoilis"));
        }
    }
}
