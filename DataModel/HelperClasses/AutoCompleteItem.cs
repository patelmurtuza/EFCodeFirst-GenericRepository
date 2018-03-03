using System;
using System.Runtime.Serialization;

namespace DataModel.HelperClasses
{

    [DataContract]
    public class AutoCompleteItem
    {
        [DataMember]
        public Int32 value
        {
            get;
            set;
        }
        [DataMember]
        public string label
        {
            get;
            set;
        }
        [DataMember]
        public string sort
        {
            get;
            set;
        }
    }

    [DataContract]
    public class AutoCompleteStrItem
    {
        [DataMember]
        public string value
        {
            get;
            set;
        }
        [DataMember]
        public string label
        {
            get;
            set;
        }
        [DataMember]
        public string sort
        {
            get;
            set;
        }
    }
    [DataContract]
    public class AutoCompleteBoolItem
    {
        [DataMember]
        public Boolean value
        {
            get;
            set;
        }
        [DataMember]
        public string label
        {
            get;
            set;
        }
        [DataMember]
        public string sort
        {
            get;
            set;
        }

    }
}
