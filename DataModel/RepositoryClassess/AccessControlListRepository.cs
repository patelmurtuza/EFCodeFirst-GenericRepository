using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace DataModel
{
    /// <summary>
    /// Class for AccessControlListRepository
    /// </summary>
    [Export(typeof(IAccessControlList))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class AccessControlListRepository : GenericComplexRepository<AccessControlListEntity, AccessControlList>,IAccessControlList
    {
        public List<AccessRightsEntity> SearchAssignRoles()
        {

            try
            {
                using (mFrameworkDbContext objmFrameworkDbContext = new mFrameworkDbContext())
                {

                    AccessControlListEntity objAccessControl = new AccessControlListEntity();
                    List<AccessRightsEntity> AccessRightsList = new List<AccessRightsEntity>();

                    List<ScreenMaster> ScreenMasterList = (from SM in objmFrameworkDbContext.screenmaster
                                                              select SM).ToList();

                    AccessRightsList = (from RM in objmFrameworkDbContext.rolemaster
                                        select new AccessRightsEntity { RoleId = (int)RM.RoleId, RoleName = RM.RoleName, }).ToList();

                    foreach (var itm in AccessRightsList)
                    {
                        List<AccessControlListEntity> objAccessControlList = new List<AccessControlListEntity>();
                        foreach (var screen in ScreenMasterList)
                        {

                            objAccessControl = (from ACL in objmFrameworkDbContext.accesscontrollist
                                                where ACL.RoleId == itm.RoleId
                                                && ACL.ScreenId == (int)screen.ScreenId
                                                select new AccessControlListEntity
                                                {
                                                    AccesscontrolListId = (int)ACL.AccesscontrolListId,
                                                    ScreenId = (int)ACL.ScreenId,
                                                    ScreenName = screen.ScreenName,
                                                    RoleId = (int)ACL.RoleId,
                                                    ScreenAccessId = ACL.ScreenAccessId,
                                                    CanAdd = ACL.CanAdd,
                                                    CanEdit = ACL.CanEdit,
                                                    CanDelete = ACL.CanDelete,
                                                    CanSearch = ACL.CanSearch,
                                                    CanUpload = ACL.CanUpload
                                                }).SingleOrDefault();
                            if (objAccessControl == null)
                            {
                                objAccessControl = new AccessControlListEntity();
                                objAccessControl.ScreenId = (int)screen.ScreenId;
                                objAccessControl.AccesscontrolListId = 0;
                                objAccessControl.ScreenName = screen.ScreenName;
                            }
                            objAccessControlList.Add(objAccessControl);
                        }
                        itm.AccessControlList = objAccessControlList;
                    }
                    return AccessRightsList;
                }

            }
            catch
            {
                throw;
            }

        }

    }
}
