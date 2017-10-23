using System.Web.Security;
using DataAccess.BLL;

namespace Web.CustomMembership
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        bool ValidateUser(User user);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        MembershipCreateStatus CreateUser(User user);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
