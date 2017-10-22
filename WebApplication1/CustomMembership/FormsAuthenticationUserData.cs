using System;
using Web.ViewModels.Permission;
using System.Collections.Generic;
namespace Web.CustomMembership
{
    internal class FormAuthenticationUserData
    {
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// /
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyId { get; set; }

        public string BusinessCode { get; set; }


        public bool IsSystemRole { get; set; }


        public Int32 StaffId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LoginId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSuperAdmin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int[] UserRoleId { get; set; }
        public string MasterPassword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PermissionModel> Permissions { get; set; }

    }
}