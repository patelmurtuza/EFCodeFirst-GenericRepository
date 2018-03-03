using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.HelperClasses;

namespace DataModel
{
    /// <summary>
    /// Interface IAutoComplete
    /// </summary>
    public interface IAutoComplete
    {
        List<AutoCompleteItem> RolesAutoList(string value);
        List<AutoCompleteItem> UserAutoList(string value);
        List<AutoCompleteItem> DepartmentAutoList(string value);
    }
}
