using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace EmployeePayRoll_UsingThreads
{
    public class EmployeeDetails
    {

        // Default Constructor
        public EmployeeDetails()
        {

        }


        // Default Constructor
        public EmployeeDetails(string employeeName, SqlMoney salary, DateTime startDate, char gender, string phoneNumber, string department, string address, SqlMoney deduction, SqlMoney tax_pay, SqlMoney income_tax, SqlMoney net_pay)
        {
            EmployeeName = employeeName;
            Salary = salary;
            StartDate = startDate;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Address = address;
            Department = department;
            Deduction = deduction;
            Taxable_Pay = tax_pay;
            Income_Tax = income_tax;
            Net_Pay = net_pay;
        }


        //Auto Set Method
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public SqlMoney Salary { get; set; }
        public DateTime StartDate { get; set; }
        public char Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Department { get; set; }
        public string Address { get; set; }

        public SqlMoney Deduction { get; set; }

        public SqlMoney Taxable_Pay { get; set; }
        public SqlMoney Income_Tax { get; set; }
        public SqlMoney Net_Pay { get; set; }


    }
}

