﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace UnitTestProject
{
    [TestClass]
    public class EncryptedPasswordTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
            object[,] testcases = {
                {1, "Markantonis&01", "Rfwpfsytsnx+56"}
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
                    string encryptedPassword = "";
                    hRLib.EncryptPassword((string) testcases[i, 1], ref encryptedPassword);
                    Assert.AreEqual((string)testcases[i, 2], encryptedPassword);
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: {1}/{2}/ \n \t Reason: {} ",
                        (int)testcases[i, 0], (string)testcases[i, 1], (string)testcases[i, 2], 
                        e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();

        }
    }
}
