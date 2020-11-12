using System;

namespace EmployeePayRoll_UsingThreads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Employee PayRoll Services");

            EmployeePayRollDetail employeePayRollDetail = new EmployeePayRollDetail();             //Declare object of EmployeePayRollDetail

            employeePayRollDetail.AddEmployeesToPayroll();                                         //Addition of Values 

        }
    }
}
