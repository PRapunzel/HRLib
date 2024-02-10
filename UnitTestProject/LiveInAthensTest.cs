using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static HRLib.HRLib;

namespace UnitTestProject
{
    [TestClass]
    public class LiveInAthensTest
    {
        [TestMethod]
        public void TestMethod1()
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

            object[,] testcases = {
                {1, list1, 2},
                {2, list2, 1}
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
                    Console.WriteLine("Failed Test Case: {0}: {1}/{2}/ \n \t Reason: {3} ",
                        (int)testcases[i, 0], (Employee[])testcases[i, 1], (int)testcases[i, 2],
                        e.Message);
                };
            };

            //Στην περίπτωση που κάποια περίπτωση ελέγχου απέτυχε, πέταξε εξαίρεση.
            if (failed) Assert.Fail();
        }
    }
}
