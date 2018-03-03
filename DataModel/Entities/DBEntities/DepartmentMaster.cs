using DataModel.HelperClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace DataModel
{
    /// <summary>
    /// Entity class for DepartmentMaster
    /// </summary>
    [DataContract]
    public class DepartmentMaster : BaseClassEntity
    {
        [Key]
        [DataMember]
        public int DepartmentId { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
        public override int PrimaryKey
        {
            get
            {
                return DepartmentId;
            }
            set
            {
                value = DepartmentId;


            }

        }

    }
}
