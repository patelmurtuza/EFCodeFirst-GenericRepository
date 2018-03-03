using DataModel.HelperClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace DataModel
{
    /// <summary>
    /// class for RoleMaster
    /// </summary>
    [DataContract]
    public partial class RoleMaster : BaseClassEntity
    {
        [Key]
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public bool RoleStatus { get; set; }
        [DataMember]
        [NotMapped]
        public override int PrimaryKey
        {
            get
            {
                return RoleId;
            }
            set
            {
                value = RoleId;
            }

        }
    }
}
