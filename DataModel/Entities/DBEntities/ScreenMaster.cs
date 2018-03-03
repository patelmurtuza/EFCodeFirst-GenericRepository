using DataModel.HelperClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataModel
{
    /// <summary>
    /// class for ScreenMaster
    /// </summary>
    [DataContract]
    public partial class ScreenMaster : BaseClassEntity
    {
        [Key]
        [DataMember]
        public int ScreenId { get; set; }
        [DataMember]
        public int? MenuId { get; set; }
        [ForeignKey("MenuId")]
        public MenuMaster menumaster { get; set; }
        [DataMember]
        public string ScreenName { get; set; }
        [DataMember]
        public string ScreenUrl { get; set; }
        [DataMember]
        [NotMapped]
        public override int PrimaryKey
        {
            get
            {
                return ScreenId;
            }
            set
            {
                value = ScreenId;
            }

        }
    }
}
