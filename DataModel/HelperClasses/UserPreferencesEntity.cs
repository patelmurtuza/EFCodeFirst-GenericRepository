using System.Runtime.Serialization;
using DataModel.HelperClasses;

namespace DataModel
{
    /// <summary>
    /// class for clsUserPreferences
    /// </summary>
    [DataContract]
    public class UserPreferencesEntity : BaseClassEntity
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string PrefKey { get; set; }

        [DataMember]
        public string PrefValue { get; set; }
    }

}
