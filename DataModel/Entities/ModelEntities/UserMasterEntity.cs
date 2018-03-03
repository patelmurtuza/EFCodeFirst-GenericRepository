
using DataModel.HelperClasses;
using System.Runtime.Serialization;
namespace DataModel
{
    /// <summary>
    /// class for clsUserMaster
    /// </summary>
    [DataContract]
    public class UserMasterEntity : BaseClassEntity, IAggregateRoot
    {
        #region Public Members
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string UserEmail { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string ActiveUser { get; set; }

        #endregion

        #region IAggregateRoot Members

        public BaseClassEntity GetTableName
        {
            get { return new UserMaster(); }
        }

        public string EntitySetName
        {
            get { return "tblUserMasters"; }
        }

        #endregion
    }
}
