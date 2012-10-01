using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public enum SocialNetworkType
    {
        [EnumMember]
        Facebook =1,
        [EnumMember]
        Twitter = 2,
        [EnumMember]
        GooglePlus = 3,
        [EnumMember]
        LinkedIn = 4,
        [EnumMember]
        LastFm = 5,

    }
}