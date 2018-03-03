using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{

    /// <summary>
    /// Interface IAssignRole
    /// </summary>
    public interface IAssignRole : IGenericComplexRepository<AssignRoleEntity, RoleUserDetail>
    {
        List<AssignRoleEntity> UsersWithRolesList();
    }


}
