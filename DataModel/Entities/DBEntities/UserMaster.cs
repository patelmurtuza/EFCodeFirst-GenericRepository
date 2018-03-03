using DataModel.HelperClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Linq;

namespace DataModel
{
    /// <summary>
    /// class for UserMaster
    /// </summary>
    [DataContract]
    public partial class UserMaster : BaseClassEntity
    {
        int _DepartmentId;
        [Key]
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string UserPassword { get; set; }
        [DataMember]
        public string UserEmail { get; set; }
        [DataMember]
        public int DepartmentId
        {
            get { return _DepartmentId; }
            set
            {
                _DepartmentId = value;
                using (mFrameworkDbContext objAdInsightDataContext = new mFrameworkDbContext())
                {
                    DepartmentName = (from o in objAdInsightDataContext.departmentmaster
                                      where o.DepartmentId == value
                                      select o.DepartmentName).FirstOrDefault();
                }

            }
        }
        [DataMember]
        public string UserPhoneNo { get; set; }
        [DataMember]
        public string UserFullName { get; set; }
        [DataMember]
        public bool? IsActive { get; set; }
        [NotMapped]
        [DataMember]
        public string ActiveUser
        {
            get
            {
                if (IsActive == true)
                    return "Yes";
                else return "No"; ;
            }
            set
            {
                if (IsActive == true)
                    value = "Yes";
                else value = "No";
            }
        }
        [NotMapped]
        [DataMember]
        public string DepartmentName { get; set; }
        [DataMember]
        [NotMapped]
        public override int PrimaryKey
        {
            get
            {
                return UserId;
            }
            set
            {
                value = UserId;
            }

        }

    }


}

