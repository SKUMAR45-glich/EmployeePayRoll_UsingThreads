using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll_UsingThreads
{
    public class EmployeePayRollOperation
    {
        // Get the Database Connection
        public static string connectionString = @"Data Source=DESKTOP-SC0MR56\SQLEXPRESS;Initial Catalog=EmployeePayRoll_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);


        // Print the Employees Details
        public void GetAllEmployee()
        {
            try
            {
                EmployeeDetails employeeDetails = new EmployeeDetails();
                string query = @"Select * from employee_payroll;";
                SqlCommand cmd = new SqlCommand(query, this.connection);
                this.connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Console.WriteLine(" ID NAME SALARY STARTDATE \n");

                    while (dr.Read())
                    {
                        employeeDetails.EmployeeId = dr.GetInt32(0);
                        employeeDetails.EmployeeName = dr.GetString(1);
                        employeeDetails.Salary = dr.GetSqlMoney(2);
                        employeeDetails.StartDate = dr.GetDateTime(3);

                        Console.WriteLine("\t" + employeeDetails.EmployeeId + "\t" + employeeDetails.EmployeeName + "\t\t" + employeeDetails.Salary + "\t" + employeeDetails.StartDate);

                    }
                }
                else
                {
                    System.Console.WriteLine("No data found");
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        //Add Data To the Employees Using Stored Procedure
        public bool AddEmployee(EmployeeDetails employeeDetails)
        {
            SqlCommand command = new SqlCommand("SpAddEmployeeDetails", this.connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeName", employeeDetails.EmployeeName);
            command.Parameters.AddWithValue("@PhoneNumber", employeeDetails.PhoneNumber);
            command.Parameters.AddWithValue("@Address", employeeDetails.Address);
            command.Parameters.AddWithValue("@Department", employeeDetails.Department);
            command.Parameters.AddWithValue("@Gender", employeeDetails.Gender);
            command.Parameters.AddWithValue("@BasicPay", employeeDetails.Salary);
            command.Parameters.AddWithValue("@Deductions", employeeDetails.Deduction);
            command.Parameters.AddWithValue("@TaxablePay", employeeDetails.Taxable_Pay);
            command.Parameters.AddWithValue("@Tax", employeeDetails.Income_Tax);
            command.Parameters.AddWithValue("@NetPay", employeeDetails.Net_Pay);
            command.Parameters.AddWithValue("@StartDate", DateTime.Now);
            try
            {
                this.connection.Open();
                var result = command.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }



        //Add Multiple Employees To the PayRoll

        public bool AddMultipleEmployee(List<EmployeeDetails> employeesList)
        {
            try
            {
                employeesList.ForEach(employeeData =>
                {
                    AddEmployee(employeeData);
                });
            }
            catch
            {
                return false;
            }
            return true;
        }



        //Add Multiple Employees To the PayRoll With Thread

        public bool AddMultipleEmployeeWithThread(List<EmployeeDetails> employeesList)
        {
            try
            {
                employeesList.ForEach(employeeData =>
                {
                    Task thread = new Task(() =>
                    {
                        Console.WriteLine("Employee being added: " + employeeData.EmployeeName);
                        AddEmployee(employeeData);
                        Console.WriteLine("Employee added: " + employeeData.EmployeeName);
                    }
                    );
                    thread.Start();
                }
                );
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
