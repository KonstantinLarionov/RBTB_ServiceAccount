using MediatR;
using RBTB_ServiceAccount.Application.Abstractions.Entities.Enums;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Positions
{
    public class GetPositionsRequest : IRequest<GetPositionsResponse>
    {
        public Guid? UserId { get; set; }

        public Side? Side { get; set; }

        public PositionStatus? PositionStatus { get; set; }

        public string Symbol { get; set; }
    }
}