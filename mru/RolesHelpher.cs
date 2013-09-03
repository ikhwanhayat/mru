using System;
using System.Web.Security;


namespace Bespoke.Utils.Security
{
    [Serializable]
    public class RolesHelpher
    {
        public string Role { get; set; }
        public string UserName { get; set; }

        public void AddRole()
        {
            if (!Roles.RoleExists(Role))
            {
                Roles.CreateRole(this.Role);
            }
        }

        public void AssignUserToRole()
        {
            if (!Roles.IsUserInRole(this.UserName, this.Role))
            {
                Roles.AddUsersToRole(new[] { this.UserName }, this.Role);
            }
        }
    }

}
