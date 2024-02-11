using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.HRLib;

namespace UnitTestProject
{
    [TestClass]
    public class LiveInAthensTest
    {
        // Hint messages
        string notValidPhone = "The phones provided are not valid. The count should be 0!";
        string emptyList = "The list with Employees is empty.";
        string zeroMatch = "There are no Employees living in Athens";
        string countMissMatch = "The count of the people living in Athens is wrong.";

        [TestMethod]
        public void TestCount()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();
         
            Employee[] list1 = new Employee[]{
                new Employee("Markantonis Dimitrios", "2109814217", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2109814217", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7))
            };

            Employee[] list2 = new Employee[]{
                new Employee("Markantonis Dimitrios", "2609814217", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2109814217", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7))
            };

            Employee[] list3 = new Employee[]{
                new Employee("Markantonis Dimitrios", "2109814123", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2109814217", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2109813223", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2109841123", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2103456789", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
            };

            object[,] testcases = {
                {1, list1, 2, countMissMatch},
                {2, list2, 1, countMissMatch},
                {3, list3, 5, countMissMatch},
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
                    Assert.AreEqual((int)testcases[i, 2], hRLib.LiveInAthens((Employee[])testcases[i,1]));
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: \n\t Input: {1} \n\t Expected output: {2}" +
                                      "\n \t Hint: {3} \n \t Reason: {4}", (int)testcases[i, 0],
                                      HRLib.HRLib.formatEmployees((Employee[])testcases[i, 1]),
                                      (int)testcases[i, 2], (string)testcases[i, 3], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }

        [TestMethod]
        public void TestZero()
        {
            HRLib.HRLib hRLib = new HRLib.HRLib();

            Employee[] list1 = new Employee[]{};

            Employee[] list2 = new Employee[]{
                new Employee("Markantonis Dimitrios", " 9814217", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "21        ", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "21       1", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7))
            };

            Employee[] list3 = new Employee[]{
                new Employee("Markantonis Dimitrios", "2309814123", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2409814217", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2509813223", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2609841123", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
                new Employee("Markantonis Dimitrios", "2703456789", "6972634757", new DateTime(2001, 11, 3), new DateTime(2023, 1, 7)),
            };

            object[,] testcases = {
                {1, list1, 0, emptyList},
                {2, list2, 0, notValidPhone},
                {3, list3, 0, zeroMatch},
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
                    Assert.AreEqual((int)testcases[i, 2], hRLib.LiveInAthens((Employee[])testcases[i, 1]));
                }
                catch (Exception e)
                {
                    //Απέτυχε η περίπτωση ελέγχου
                    failed = true;
                    //Καταγράφουμε την περίπτωση ελέγχου που απέτυχε
                    Console.WriteLine("Failed Test Case: {0}: \n\t Input: {1} \n\t Expected output: {2}" +
                                      "\n \t Hint: {3} \n \t Reason: {4}", (int)testcases[i, 0],
                                      HRLib.HRLib.formatEmployees((Employee[])testcases[i, 1]),
                                      (int)testcases[i, 2], (string)testcases[i, 3], e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }
    }
}
