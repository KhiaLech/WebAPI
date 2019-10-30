
using API_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using API_Example.Views;
using System.Web.Http;

namespace API_Example.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee

        public IEnumerable<Employee> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<Employee> output = new List<Employee>();


            try
            {
                conn.Open();

                query = "select * from employee";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new Employee(Int32.Parse(rdr.GetValue(0).ToString()),
                        rdr.GetValue(1).ToString(),
                        rdr.GetValue(2).ToString()));
                }

            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;

        }

        // GET: Employee/5
        public Employee Get(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            Employee output = new Employee();


            try
            {
                conn.Open();

                query = "select * from employee where StaffId = " + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = new Employee(Int32.Parse(rdr.GetValue(0).ToString()),
                        rdr.GetValue(1).ToString(),
                        rdr.GetValue(2).ToString());
                }

            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;

        }

        // POST: Employee
        public string Post([FromBody]Employee emp)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            string query;
            string output = "Not Assigned";


            try
            {
                conn.Open();

                query = "insert into employee(StaffId, GivenName, Surname)" + "values(" + emp.StaffId + ", '" + emp.GivenName + "','" + emp.Surname + "')";
                cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();

                output = "Insert Succesfull";

            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
        }
        // PUT: Employee/5
        public string Put(int id, [FromBody] Employee emp)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            string query;
            string output = "Not Assigned";


            try
            {
                conn.Open();

                query = "update employee set GivenName = '" + emp.GivenName + "', Surname = '" + emp.Surname + "' where StaffId = " + id;


                cmd = new SqlCommand(query, conn);

                int res = cmd.ExecuteNonQuery();

                output = res.ToString() + "Rows Updated";

            }

            catch (Exception e)
            {
                output = e.Message;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
        }

        // DELETE: Employee/5
        public string Delete(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            string query;
            string output = "Not Assigned";


            try
            {
                conn.Open();

                query = "Delete from Employee where StaffId = " + id;


                cmd = new SqlCommand(query, conn);

                int res = cmd.ExecuteNonQuery();

                output = res.ToString() + "Rows Deleted";

            }

            catch (Exception e)
            {
                output = e.Message;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
        }
    }



}

