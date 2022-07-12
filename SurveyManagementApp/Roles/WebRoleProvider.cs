using System;
using System.Web.Security;
using Project.BLL.Concrete;
using Project.DAL.EntityFramework;
using Project.ENTITIES.Concrete;

namespace SurveyManagementApp.Roles {
   public class WebRoleProvider : RoleProvider
    {
        AdminManager _adminManager = new AdminManager(new EfAdminDal());
        PersonelManager _personelManager = new PersonelManager(new EfPersonelDal()); 
        public override string[] GetRolesForUser(string username)
        {
            string[] RoleForUser()
            {
                var p = _personelManager.GetPersonelByUserName(username).Role;
                return p == Role.Manager ? new string[] { "Manager" } : new string[] { };
            }
            var a = _adminManager.GetAdminByUserName(username);
            return a != null ? new string[] { "Admin" } :RoleForUser();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }

}