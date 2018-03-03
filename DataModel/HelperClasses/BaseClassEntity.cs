using System;
using System.Runtime.Serialization;

namespace DataModel.HelperClasses
{
    /// <summary>
    /// class for clsEntityBaseClass
    /// </summary>
    [DataContract]
    public class BaseClassEntity : IndexedListItem
    {
        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public DateTime? CreatedDate { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        [DataMember]
        public DateTime? ModifiedDate { get; set; }

        [DataMember]
        public int? SortOrder { get; set; }
    }
}
