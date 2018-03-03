using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace DataModel
{
    /// <summary>
    /// Class for AssignRoleRepository
    /// </summary>
    [Export(typeof(IAssignRole))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class AssignRoleRepository : GenericComplexRepository<AssignRoleEntity,RoleUserDetail>, IAssignRole
    {
        #region AssignRoleRepository Methods
        /// <summary>
        /// Get Users with their roles from databse.
        /// </summary>
        /// <returns>Type of object list.</returns>
        public List<AssignRoleEntity> UsersWithRolesList()
        {
            List<AssignRoleEntity> objUsersWithRoleList = new List<AssignRoleEntity>();
            try
            {
                using (mFrameworkDbContext objmFrameworkDbContext = new mFrameworkDbContext())
                {
                    objUsersWithRoleList = (from a in objmFrameworkDbContext.roleuserdtl
                                            join b in objmFrameworkDbContext.rolemaster on a.RoleId equals b.RoleId
                                            join c in objmFrameworkDbContext.usermaster on a.UserId equals c.UserId
                                            where c.IsActive == true
                                            select new AssignRoleEntity
                                            {
                                                RoleUserId = (int)a.RoleUserId,
                                                RoleId = (int)a.RoleId,
                                                UserId = (int)a.UserId,
                                                UserName = c.UserName,
                                                RoleName = b.RoleName
                                            }).ToList();
                }
            }
            catch
            {
                throw;
            }
            return objUsersWithRoleList;
        }
        #endregion
    }
}
