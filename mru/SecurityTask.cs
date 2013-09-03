using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Bespoke.Utils.Security
{

    public class AspAddRole : Task
    {
        public string TaskAssemblyDirectory { get; set; }


        public override bool Execute()
        {
           AppDomain secDomain =  Program.CreateAppDomain(ConfigurationFile, TaskAssemblyDirectory);
           foreach (string r in Roles)
           {
               var rh = new RolesHelpher {Role = r};
               secDomain.DoCallBack(rh.AddRole);
           }

           return true;
        }

        [Required]
        public string ConfigurationFile { get; set; }

        [Required]
        public string[] Roles { get; set; }
    }

}
