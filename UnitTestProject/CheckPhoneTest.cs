using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class CheckPhoneTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            object[,] testcases = {
                {1, "Markantonis&01", -1,"null"},
                {2, "2109814217", 0, "Μητροπολιτική Περιοχή Αθήνας – Πειραιά"},
                {2, "2109814217", 0, "Μητροπολιτική Περιοχή Αθήνας – Πειραιά"}
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
                    string type = "";
                    int code = 0;
                    hRLib.CheckPhone((string)testcases[i, 1], ref code, ref type);
                    Assert.AreEqual((int)testcases[i, 2], code);
                    Assert.AreEqual((string)testcases[i, 3], type);
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: {1}/{2}/ \n \t Reason: {3} ",
                        (int)testcases[i, 0], (string)testcases[i, 1], (int)testcases[i, 2],
                        e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }
    }
}
