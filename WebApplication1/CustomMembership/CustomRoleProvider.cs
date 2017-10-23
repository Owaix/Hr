using System;
using System.Linq;
using System.Web.Security;
using Service.Contracts;

namespace Web.CustomMembership
{
    public class CustomRoleProvider : RoleProvider
    {

        /// <summary>
        /// 
        /// </summary>
        public IUserService UserService
        {
            get
            {
                return StructureMap.ObjectFactory.GetInstance<IUserService>();
            }
        }

        public IRoleService RoleService
        {
            get
            {
                return StructureMap.ObjectFactory.GetInstance<IRoleService>();
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {

            var user = UserService.GetUserByUsername(username);
            if (user == null)
                return false;
            return false; // user.UserRole != null;// && user.UserRole.Select(u => u.RoleName == roleName);

        }

        public override string[] GetRolesForUser(string username)
        {

            var user = UserService.GetUserByID(int.Parse(username)); //.GetUserByUsername(username);
            if (user == null)
                return new string[] { };

            //if (user.UserRole == null)
            //    return new string[] { };
            
            var roles= user.UserRoles.Select(s=>s.Role.RoleName).ToArray();
            return roles;

            //return user.UserRole == null ? new string[] { } : user.UserRoles.Select(u => u.Role).Select(u => u.RoleName).ToArray();

        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return RoleService.GetRoles().Select(r => r.RoleName).ToArray();

        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}