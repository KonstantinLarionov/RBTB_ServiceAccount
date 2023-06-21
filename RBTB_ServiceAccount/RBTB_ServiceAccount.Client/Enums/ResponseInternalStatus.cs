namespace Derzhava.Id.Common.Components.Enums
{
    using System.Runtime.Serialization;

    public enum ResponseInternalStatus
    {
        [EnumMember(Value = "")]
        Success,
        [EnumMember(Value = "Error")]
        Error
    }
}