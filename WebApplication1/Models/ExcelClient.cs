using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ExcelClient
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public DateTime Dob { set; get; }

        public ExcelClient(string firstname, string lastname, DateTime dob, string email)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Dob = dob;
            this.Email = email;
        }
    }
}