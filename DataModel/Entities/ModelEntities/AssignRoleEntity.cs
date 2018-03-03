using DataModel.HelperClasses;
using System.Runtime.Serialization;

namespace DataModel
{
    /// <summary>
    /// class for clsAssignRole
    /// </summary>
    [DataContract]
    public class AssignRoleEntity : BaseClassEntity, IAggregateRoot
    {

        #region Public Members...
        [DataMember]
        public int RoleUserId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string UserName { get; set; }
        #endregion

        #region IAggregateRoot Members

        public BaseClassEntity GetTableName
        {
            get { return new RoleUserDetail(); }
        }

        public string EntitySetName
        {
            get { return "tblRoleUserDetails"; }
        }

        #endregion
    }
}
