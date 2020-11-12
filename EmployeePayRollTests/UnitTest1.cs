using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayRoll_UsingThreads;
using System.Collections.Generic;
using System;

namespace EmployeePayRollTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();             //List of EmployeeDetails 

            EmployeePayRollOperation employeePayRollOperation = new EmployeePayRollOperation();

            //Add Employee To Payroll without Using Thread

            employeeDetails.Add(new EmployeeDetails("VK", 10000, new DateTime(2020, 11, 12), 'M', "9999999999", "Captain", "Delhi", 100, 100, 100, 100));
            employeeDetails.Add(new EmployeeDetails("MSD", 100000, new DateTime(2020, 11, 11), 'M', "9999999999", "Legend", "Ranchi", 100, 100, 100, 100));

            DateTime startDateTime = DateTime.Now;
            employeePayRollOperation.AddMultipleEmployee(employeeDetails);                        //Adding Values without Thread
            DateTime endDateTime = DateTime.Now;
            Console.WriteLine("Without Thread : " + (endDateTime - startDateTime));               // Time Taken For Addition Without Thread

            DateTime startDateTimeThread = DateTime.Now;
            employeePayRollOperation.AddMultipleEmployeeWithThread(employeeDetails);              //Adding Values With Threads
            DateTime endDateTimeThread = DateTime.Now;
            Console.WriteLine("With Thread : " + (endDateTimeThread - startDateTimeThread));       // Time Taken For Addition With Thread


        }
    }
}
