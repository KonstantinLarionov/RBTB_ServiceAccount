namespace RBTB_ServiceAccount.Application.Domains.Entities.Enums;

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