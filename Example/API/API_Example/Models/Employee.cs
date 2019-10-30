using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Example.Models
{
    public class Employee
    {

        public int StaffId { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }

        public Employee(int sid, string gname, string sname)
        {
            StaffId = sid;
            GivenName = gname;
            Surname = sname;
        }

        public Employee()
        {
       
        }

    }
}