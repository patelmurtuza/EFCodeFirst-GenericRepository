using System.Collections.Generic;
using DataModel.HelperClasses;
using System.Runtime.Serialization;

namespace DataModel
{
    /// <summary>
    /// class for AccessRightsEntity
    /// </summary>
    [DataContract]
    public class AccessRightsEntity : BaseClassEntity,IAggregateRoot
    {
        public AccessRightsEntity()
        {
           
        }

        #region Public Members...
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public List<AccessControlListEntity> AccessControlList
        {
            get;
            set;
        }
        #endregion
        
        public BaseClassEntity GetTableName
        {
            get { return new AccessControlList(); }
        }

        public string EntitySetName
        {
            get { return "tblAccessControlLists"; }
        }
    }
}
