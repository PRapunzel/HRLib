using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace UnitTestProject
{
    [TestClass]
    public class InfoEmployeeTest
    {
        // Hint messages
        string notvalidInfo = "The dates provided are not valid (later than today).";
        string resultMissMatch = "The results aren't matching the info provided.";

        HRLib.HRLib hRLib = new HRLib.HRLib();

        [TestMethod]
        public void TestCorrectResult()
        {
            object[,] testcases = {
                {
                    1, new HRLib.HRLib.Employee("Markantonis Dimitrios", "2109813567", "6972847262",
                    new DateTime(2001,11,3), new DateTime(2023,1,7)), 23, 1, resultMissMatch
                },
                {
                    2, new HRLib.HRLib.Employee("MarkantonisDimitrios", "2109832132", "6972328201", 
                    new DateTime(2003,11,3), new DateTime(2020,1,7)), 21, 4, resultMissMatch
                },
            };

            //Αρχικοποίηση δείκτη περιπτώσεων ελέγχου
            int i = 0;
            bool failed = false;

            //Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            //Για κάθε περίπτωση ελέγχου, δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    //Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    //δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    int age = 0;
                    int experience = 0;
                    hRLib.InfoEmployee((HRLib.HRLib.Employee)testcases[i, 1], ref age, ref experience);
                    Assert.AreEqual((int)testcases[i, 2], age);
                    Assert.AreEqual((int)testcases[i, 3], experience);
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}:\n\t Input:\n{1}\n\t Expexted Results: {2} | {3}\n\t Hint: {4}\n\t Reason: {5}",
                                      (int)testcases[i, 0], HRLib.HRLib.formatEmployee((HRLib.HRLib.Employee)testcases[i, 1]), 
                                      (int)testcases[i, 2], (int)testcases[i, 3], (string)testcases[i, 4],
                                      e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestNotValidInfo()
        {
            object[,] testcases = {
                {
                    1, new HRLib.HRLib.Employee("Markantonis Dimitrios", "2109813567", "6972847262",
                    new DateTime(2025,11,3), new DateTime(2023,1,7)), -1, -1, notvalidInfo
                },
                {
                    2, new HRLib.HRLib.Employee("MarkantonisDimitrios", "2109832132", "6972328201",
                    new DateTime(2003,11,3), new DateTime(2030,1,7)), -1, -1, notvalidInfo
                },
            };

            //Αρχικοποίηση δείκτη περιπτώσεων ελέγχου
            int i = 0;
            bool failed = false;

            //Προσπέλαση και εκτέλεση περιπτώσεων ελέγχου
            for (i = 0; i < testcases.GetLength(0); i++)
            //Για κάθε περίπτωση ελέγχου, δηλαδή για κάθε γραμμή i του πίνακα testcases
            {
                try
                {
                    //Καλούμε την Assert.AreEqual δίνοντας ως παραμέτρους τα στοιχεία της περίπτωσης ελέγχου,
                    //δηλαδή τα αντίστοιχα στοιχεία της γραμμής i του πίνακα testcases
                    int age = 0;
                    int experience = 0;
                    hRLib.InfoEmployee((HRLib.HRLib.Employee)testcases[i, 1], ref age, ref experience);
                    Assert.AreEqual((int)testcases[i, 2], age);
                    Assert.AreEqual((int)testcases[i, 3], experience);
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}:\n\t Input:\n{1}\n\t Expexted Results: {2} | {3}\n\t Hint: {4}\n\t Reason: {5}",
                                      (int)testcases[i, 0], HRLib.HRLib.formatEmployee((HRLib.HRLib.Employee)testcases[i, 1]),
                                      (int)testcases[i, 2], (int)testcases[i, 3], (string)testcases[i, 4],
                                      e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }
    }
}
