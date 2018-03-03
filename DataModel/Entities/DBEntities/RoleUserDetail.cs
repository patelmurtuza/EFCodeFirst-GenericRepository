using DataModel.HelperClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataModel
{
    /// <summary>
    /// class for RoleUserDetail
    /// </summary>
    [DataContract]
    public partial class RoleUserDetail : BaseClassEntity
    {

        #region Public Members...
        [Key]
        [DataMember]
        public int RoleUserId { get; set; }
        [DataMember]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserMaster usermaster { get; set; }

        [DataMember]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public RoleMaster rolemaster { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        [NotMapped]
        public string RoleName { get; set; }

        [DataMember]
        [NotMapped]
        public override int PrimaryKey
        {
            get
            {
                return RoleUserId;
            }
            set
            {
                value = RoleUserId;
            }

        }
        #endregion
    }
}
