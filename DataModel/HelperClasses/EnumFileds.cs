using System.Runtime.Serialization;

namespace DataModel
{

    /// <summary>
    /// Enum for Screen
    /// </summary>
    public enum Screen
    {
        None = 0,
        ModuleMaster = 6
    };


    /// <summary>
    /// Enum for RepoclassName consisting of Repository Names
    /// </summary>
    [DataContract]
    public enum RepoClassName
    {
        [EnumMemberAttribute]
        UserMasterRepository = 1,
        [EnumMemberAttribute]
        RoleMasterRepository = 2,
        [EnumMemberAttribute]
        AssignRoleRepository = 3,
        [EnumMemberAttribute]
        AccessControlListRepository = 4,
        [EnumMemberAttribute]
        AccessRightsRepository = 5,
        [EnumMemberAttribute]
        ExplicitAssignRoleRepository = 6,
        [EnumMemberAttribute]
        ExplicitAccessControlListRepository = 7,
        [EnumMemberAttribute]
        LoginRepository = 8,
        [EnumMemberAttribute]
        AutocompleteRepository = 9,
        [EnumMemberAttribute]
        UserPreferencesRepository = 10,
    };
}