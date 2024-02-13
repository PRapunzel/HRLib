using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HRLib;

namespace UnitTestProject
{
    [TestClass]
    public class ValidNameTest
    {
        [TestMethod]
        public void TestContainsNumber()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            object[,] testcases = {
                {1,true, "Markantonis Dimitrios", "ContainsNumber"},
                {2,false, "Markantoni5 Dimitrios", "ContainsNumber"},
                {2,false, "Markant0n15 D1m1tr105", "ContainsNumber"}
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
                    Assert.AreEqual((bool)testcases[i, 1], hRLib.ValidName((string)testcases[i, 2]));
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: {1}/{2}/ \n \t Hint: {3} \n \t Reason: {4} ",
                        (int)testcases[i, 0], (bool)testcases[i, 1], (string)testcases[i, 2], (string)testcases[i, 3], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void Test_FullName_IsSplit()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            object[,] testcases = {
                {1,true, "Markantonis Dimitrios", "FullNameIsSplit"},
                {2,false, "MarkantonisDimitrios", "FullNameIsSplit"},
                {3,false, "ZovoilisDim", "FullNameIsSplit"},
                {4,true, "MarkantonisDim", "FullNameIsSplit"}
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
                    Assert.AreEqual((bool)testcases[i, 1], hRLib.ValidName((string)testcases[i, 2]));
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: {1}/{2}/ \n \t Hint: {3} \n \t Reason: {4} ",
                        (int)testcases[i, 0], (bool)testcases[i, 1], (string)testcases[i, 2], (string)testcases[i, 3], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void Test_Name_Exists()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            object[,] testcases = {
                {1,true, "Markantonis Dimitrios", "NameExists"},
                {2,false, "", "NameExists"},
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
                    Assert.AreEqual((bool)testcases[i, 1], hRLib.ValidName((string)testcases[i, 2]));
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: {1}/{2}/ \n \t Hint: {3} \n \t Reason: {4} ",
                        (int)testcases[i, 0], (bool)testcases[i, 1], (string)testcases[i, 2], (string)testcases[i, 3], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }
    }
}
