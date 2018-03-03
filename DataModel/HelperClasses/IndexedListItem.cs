using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
namespace DataModel.HelperClasses
{
    /// <summary>
    /// class for IndexedListItem
    /// </summary>
    [DataContract]
    public class IndexedListItem
    {
        [NotMapped]
        [DataMember]
        public int MyIndex { get; set; }
        [NotMapped]
        [DataMember]
        public virtual int PrimaryKey { get; set; }
        [NotMapped]
        [DataMember]
        public int MainGridIndex { get; set; }
    }
}