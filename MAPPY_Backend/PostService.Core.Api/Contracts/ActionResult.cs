using System.Runtime.Serialization;

namespace PostService.Core.Api.Contracts;

public enum ActionResult
{
    [DataMember]
    [EnumMember(Value = "Succesvol")]
    Succesvol,
    
    [DataMember]
    [EnumMember(Value = "Onsuccesvol")]
    Onsuccesvol,
    
    [DataMember]
    [EnumMember(Value = "NietGevonden")]
    NietGevonden
}