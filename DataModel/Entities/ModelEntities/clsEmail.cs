using System.Collections.Generic;
using DataModel.HelperClasses;
using System.Runtime.Serialization;

namespace DataModel
{
    /// <summary>
    /// class for clsEmail
    /// </summary>
    [DataContract]
    public class clsEmail : clsEntityBaseClass
    {
        [DataMember]
        public string EmailFrom { get; set; }
        [DataMember]
        public List<string> EmailToList { get; set; }
        [DataMember]
        public List<string> EmailCCList { get; set; }
        [DataMember]
        public string EmailSub { get; set; }
        [DataMember]
        public string Emailbody { get; set; }

    }
}
