using Microsoft.AspNet.Identity.EntityFramework;
using System;


namespace WebApplication1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}