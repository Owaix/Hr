using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Department { get; set; }
        public String Designation { get; set; }
        public float Salary { get; set; }
    }
}
