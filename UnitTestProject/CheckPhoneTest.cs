using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class CheckPhoneTest
    {
        // Hint messages
        string notPhone = "The phone provided should be a valid phone number.";
        string notMobile = "The phone provided should be a valid mobile phone number.";
        string zoneMissMatch = "The zone isn't matching the phone provided.";

        // Methods for testing
        [TestMethod]
        public void TestIsPhone()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            object[,] testcases = {
                {1, "Markantonis&01", -1, "null", notPhone},
                {2, "210      7",     -1, "null", notPhone},
                {3, "1         ",     -1, "null", notPhone},
                {4, "100",            -1, "null", notPhone},
                {5, "2 09 1 217",     -1, "null", notPhone},
                {6, "2153202i8",      -1, "null", notPhone},
                {7, "2109814217",      0, "Μητροπολιτική Περιοχή Αθήνας – Πειραιά", notPhone},
                {8, "6990012345",      1, "Nova", notPhone},
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
                    Console.WriteLine("Failed Test Case: {0}: \n\t Input: {1} \n\t Expected output: {2} | {3} " +
                                      "\n \t Hint: {4} \n \t Reason: {5}", (int)testcases[i, 0],
                                      (string)testcases[i, 1], (int)testcases[i, 2], (string)testcases[i, 3],
                                      (string)testcases[i, 4], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestIsMobile()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            object[,] testcases = {
                {1, "6986602253",  1, "Unknown", notMobile},
                {3, "1         ", -1, "null", notMobile},
                {4, "6990012345",  1, "Nova", notMobile},
                {5, "697       ", -1, "null", notMobile},
                {6, "6970123458",  1, "Cosmote", notMobile},
                {7, "6955012345",  1, "Vodafone", notMobile},
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
                    Console.WriteLine("Failed Test Case: {0}: \n\t Input: {1} \n\t Expected output: {2} | {3} " +
                                      "\n \t Hint: {4} \n \t Reason: {5}", (int)testcases[i, 0],
                                      (string)testcases[i, 1], (int)testcases[i, 2], (string)testcases[i, 3],
                                      (string)testcases[i, 4], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestZone()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            object[,] testcases = {
                {1, "2109814217", 0, "Μητροπολιτική Περιοχή Αθήνας – Πειραιά", zoneMissMatch},
                {2, "2209814217", 0, "Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου", zoneMissMatch},
                {3, "2309814217", 0, "Κεντρική Μακεδονία", zoneMissMatch},
                {4, "2409814217", 0, "Θεσσαλία, Δυτική Μακεδονία", zoneMissMatch},
                {5, "2509814217", 0, "Θράκη, Ανατολική Μακεδονία", zoneMissMatch},
                {6, "2609814217", 0, "Ήπειρος, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησος, Ιόνια Νησιά", zoneMissMatch},
                {7, "2709814217", 0, "Ανατολική Πελοπόννησος, Κύθηρα", zoneMissMatch},
                {8, "2809814217", 0, "Κρήτη", zoneMissMatch},
                {9, "2909814217", 0, "Άγνωστο", zoneMissMatch},
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
                    Console.WriteLine("Failed Test Case: {0}: \n\t Input: {1} \n\t Expected output: {2} | {3} " +
                                      "\n \t Hint: {4} \n \t Reason: {5}", (int)testcases[i, 0],
                                      (string)testcases[i, 1], (int)testcases[i, 2], (string)testcases[i, 3],
                                      (string)testcases[i, 4], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }
    }
}
