namespace RBTB_ServiceAccount.Application.Abstractions.Entities.Enums;

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