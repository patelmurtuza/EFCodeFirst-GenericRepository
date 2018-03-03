using System.Collections.Generic;

namespace DataModel
{
    /// <summary>
    /// Interface IAccessControlList
    /// </summary>
    public interface IAccessControlList : IGenericComplexRepository<AccessControlListEntity, AccessControlList>
    {
        List<AccessRightsEntity> SearchAssignRoles();
    }
}
