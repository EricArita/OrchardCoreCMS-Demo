using System.Collections.Generic;
using OrchardCore.Security.Permissions;
using System.Threading.Tasks;
using System.Linq;

public class AAVPermissionProvider : IPermissionProvider
{
    public static readonly Permission AddNewStaff = new Permission("AddNewStaff", "Add a new staff to company");
    public static readonly Permission ApproveLeavePlan = new Permission("ApproveLeavePlan", "Approve that allowing an employee to leave");
    public static readonly Permission SubmitLeavePlan = new Permission("SubmitLeavePlan", "Submit a leave plan and waiting for approval");

    public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
    {
        return new[] {
            new PermissionStereotype {
                Name = "Administrator",
                Permissions = new[] { AddNewStaff, SubmitLeavePlan }
            },
            new PermissionStereotype {
                Name = "AAV",
                Permissions = new[] { AddNewStaff }
            },
        };
    }

    public Task<IEnumerable<Permission>> GetPermissionsAsync()
    {
        return Task.FromResult(new[] {
            AddNewStaff,
            //ApproveLeavePlan,
            SubmitLeavePlan
        }.AsEnumerable());
    }
}