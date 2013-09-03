using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Bespoke.Utils.Security
{
    public class AspAddUser : Task
    {
        private string m_configurationFile;
        private string m_email;
        private string m_password;
        private string[] m_roles;
        private string m_userName; 
        private string m_taskAssemblyDirectory;

        public string TaskAssemblyDirectory
        {
            get { return m_taskAssemblyDirectory; }
            set { m_taskAssemblyDirectory = value; }
        }

        // Methods
        public override bool Execute()
        {
            AppDomain domainSecurityHelper = Program.CreateAppDomain(m_configurationFile, m_taskAssemblyDirectory);

            MembershipHelper mh = new MembershipHelper();
            mh.UserName = m_userName;
            mh.Password = m_password;
            mh.Email = m_email;

            domainSecurityHelper.DoCallBack(new CrossAppDomainDelegate(mh.AddUser));


            foreach (string r in m_roles)
            {
                RolesHelpher rh = new RolesHelpher();
                rh.UserName = m_userName;
                rh.Role = r;
                domainSecurityHelper.DoCallBack(new CrossAppDomainDelegate(rh.AddRole));
                domainSecurityHelper.DoCallBack(new CrossAppDomainDelegate(rh.AssignUserToRole));

            }

            AppDomain.Unload(domainSecurityHelper);

            return true;
        }

        [Required]
        public string ConfigurationFile
        {
            get { return m_configurationFile; }
            set { m_configurationFile = value; }
        }

        public string Email
        {
            get { return m_email; }
            set { m_email = value; }
        }

        [Required]
        public string Password
        {
            get { return m_password; }
            set { m_password = value; }
        }

        public string[] Roles
        {
            get { return m_roles; }
            set { m_roles = value; }
        }

        [Required]
        public string UserName
        {
            get { return m_userName; }
            set { m_userName = value; }
        }
    }
 

}
