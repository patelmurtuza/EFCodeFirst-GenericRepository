using System.Collections.Generic;
using System.Linq;
using DataModel.HelperClasses;
using System.ComponentModel.Composition;
namespace DataModel
{
    [Export(typeof(IAutoComplete))]
    [PartCreationPolicy(System.ComponentModel.Composition.CreationPolicy.NonShared)]
    public class AutocompleteRepository : IAutoComplete
    {
        public List<AutoCompleteItem> RolesAutoList(string value)
        {
            List<AutoCompleteItem> objRolesList = new List<AutoCompleteItem>();
            try
            {
                using (mFrameworkDbContext objmFrameworkDbContext = new mFrameworkDbContext())
                {
                    objRolesList = (from e in objmFrameworkDbContext.rolemaster where (value == null ? e.RoleName == e.RoleName : e.RoleName.StartsWith(value))
                                    select new AutoCompleteItem
                                    {
                                        label = e.RoleName,
                                        value = (int)e.RoleId
                                    }).ToList();
                }
            }
            catch
            {
                throw;
            }
            return objRolesList;
        }

        public List<AutoCompleteItem> UserAutoList(string value)
        {
            List<AutoCompleteItem> objUserList = new List<AutoCompleteItem>();
            try
            {
                using (mFrameworkDbContext objmFrameworkDbContext = new mFrameworkDbContext())
                {
                    objUserList = (from e in objmFrameworkDbContext.usermaster
                                   where (value == null ? e.UserName == e.UserName : e.UserName.StartsWith(value))
                                   && e.IsActive == true
                                   select new AutoCompleteItem
                                   {
                                       label = e.UserName,
                                       value = (int)e.UserId
                                   }).ToList();


                }
            }
            catch
            {
                throw;
            }
            return objUserList;
        }

        public List<AutoCompleteItem> DepartmentAutoList(string value)
        {
            List<AutoCompleteItem> objRolesList = new List<AutoCompleteItem>();
            try
            {
                using (mFrameworkDbContext objmFrameworkDbContext = new mFrameworkDbContext())
                {
                    objRolesList = (from e in objmFrameworkDbContext.departmentmaster where (value == null ? e.DepartmentName == e.DepartmentName : e.DepartmentName.StartsWith(value))
                                    select new AutoCompleteItem
                                    {
                                        label = e.DepartmentName,
                                        value = (int)e.DepartmentId
                                    }).ToList();
                }
            }
            catch
            {
                throw;
            }
            return objRolesList;
        }
        
    }
}
