using System.Runtime.Serialization;
namespace DataModel.HelperClasses
{
    /// <summary>
    /// class for clsSearchContext
    /// </summary>

    [DataContract]
    public class SearchContextEntity
    {
        [DataMember]
        public string value { get; set; }

        [DataMember]
        public string label { get; set; }

        [DataMember]
        public string Operator { get; set; }

    }
}
