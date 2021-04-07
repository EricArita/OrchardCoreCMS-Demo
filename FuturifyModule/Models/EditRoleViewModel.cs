using System;
using System.Collections.Generic;
using System.Text;

namespace FuturifyModule.Models
{
    public class UpdateRoleViewModel
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public IEnumerable<string> SelectedPermissions { get; set; }
    }
}
