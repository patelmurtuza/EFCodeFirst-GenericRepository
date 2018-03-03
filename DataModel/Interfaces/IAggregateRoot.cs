using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.HelperClasses;

namespace DataModel
{
    /// <summary>
    /// Interface IAggregateRoot
    /// </summary>
    public interface IAggregateRoot
    {
        BaseClassEntity GetTableName
        {
            get;
        }

        String EntitySetName
        {
            get;
        }
        
    }
}
