
using DataModel.HelperClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace DataModel
{
    /// <summary>
    /// class for MenuMaster
    /// </summary>
    [DataContract]
    public partial class MenuMaster : BaseClassEntity
    {
        [Key]
        [DataMember]
        public int MenuId { get; set; }
        [DataMember]
        public string MenuName { get; set; }
        [DataMember]
        [NotMapped]
        public override int PrimaryKey
        {
            get
            {
                return MenuId;
            }
            set
            {
                value = MenuId;
            }

        }
    }
}
