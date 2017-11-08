using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LT.QMS.Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

using LT.QMS.UI.Utility;
using Newtonsoft.Json;
using LT.QMS.Common.ViewModels;

namespace LT.QMS.UI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int OrganizationId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType); //DefaultAuthenticationTypes.ApplicationCookie

            // Add custom user claims here
            var u = manager.FindById(userIdentity.GetUserId());
            userIdentity.AddClaim(new Claim("User", JsonConvert.SerializeObject(u)));

            foreach (Claim claim in userIdentity.GetAllUserClaims())
            {
                userIdentity.AddClaim(claim);
            }
            var loc = userIdentity.GetUserLocations();
            return userIdentity;
        }
    }

    public class UserProfile
    {
        [Key]
        public string UserID { get; set; }

        [StringLength(20)]
        public string PinCode { get; set; }
        public DateTime? DOB { get; set; }
        [StringLength(20)]
        public string Gender { get; set; }
        [StringLength(150)]
        public string ImageUrl { get; set; }

    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public ApplicationRole(string Name) : base(Name) { }

        public string parentId { get; set; }

        public string Type { get; set; }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}