namespace RBTB_ServiceAccount.Database.Entities.Enums;

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