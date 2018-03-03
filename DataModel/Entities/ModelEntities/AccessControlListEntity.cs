using DataModel.HelperClasses;
using System.Runtime.Serialization;

namespace DataModel
{
    /// <summary>
    /// class for AccessControlListEntity
    /// </summary>
    [DataContract]
    public class AccessControlListEntity : BaseClassEntity, IAggregateRoot
    {
      
        #region Public Members....
        [DataMember]
        public int AccesscontrolListId { get; set; }
        [DataMember]
        public int ScreenId { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public bool ScreenAccessId { get; set; }
        [DataMember]
        public bool CanAdd { get; set; }
        [DataMember]
        public bool CanEdit { get; set; }
        [DataMember]
        public bool CanDelete { get; set; }
        [DataMember]
        public bool CanSearch { get; set; }
        [DataMember]
        public bool CanUpload { get; set; }
        [DataMember]
        public string MenuName { get; set; }
        [DataMember]
        public string ScreenName { get; set; }
        [DataMember]
        public int RoleUserId { get; set; }
        #endregion

        #region IAggregateRoot Members

        public BaseClassEntity GetTableName
        {
            get { return new AccessControlList(); }
        }

        public string EntitySetName
        {
            get { return "tblAccessControlLists"; }
        }


        #endregion
    }
}
