using DataModel.HelperClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataModel
{
    /// <summary>
    /// class for AccessControlList
    /// </summary>
    [DataContract]
    public partial class AccessControlList : BaseClassEntity
    {

        #region Public Members....
        [Key]
        [DataMember]
        public int AccesscontrolListId { get; set; }
        [DataMember]
        public int ScreenId { get; set; }
        [ForeignKey("ScreenId")]
        public ScreenMaster screenmaster { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public RoleMaster rolemaster { get; set; }
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
        [NotMapped]
        public string MenuName { get; set; }
        [DataMember]
        [NotMapped]
        public string ScreenName { get; set; }
        [DataMember]
        [NotMapped]
        public int MenuId { get; set; }
        [DataMember]
        [NotMapped]
        public string ScreenUrl { get; set; }
        [DataMember]
        [NotMapped]
        public override int PrimaryKey
        {
            get
            {
                return AccesscontrolListId;
            }
            set
            {
                value = AccesscontrolListId;
            }

        }
        #endregion


    }
}
