namespace RBTB_ServiceAccount.Client.Abstractions.Enums;

public enum OrderStatus
{
    Created,
    New,
    Rejected,
    PartiallyFilled,
    Filled,
    PendingCancel,
    Cancelled,
    Untriggered,
    Deactivated,
    Triggered,
    Active
}