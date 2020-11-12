using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRoll_UsingThreads
{
    public class EmployeePayRollDetail
    {
        public List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();    //List of Details


        //Adding Values to Database
        public void AddEmployeesToPayroll()
        {
            EmployeePayRollOperation employeePayRollOperation = new EmployeePayRollOperation();

            //2 Values To be added
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
