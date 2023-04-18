using RBTB_ServiceAccount.Application.Domains.Entities.Enums;

namespace RBTB_ServiceAccount.Application.Domains.Entities;

public class GetPositionsBySymbolRequest
{
    public Side? Side { get; set; }
    public PositionStatus? PositionStatus { get; set; }

}