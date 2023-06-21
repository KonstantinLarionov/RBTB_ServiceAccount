using MediatR;
using RBTB_ServiceAccount.Application.Abstractions.Entities.Enums;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Positions
{
    public class CreatePositionRequest : IRequest<CreatePositionResponse>
    {
        public Guid UserId { get; set; }

        public Guid TradesId { get; set; }

        public decimal Price { get; set; }

        public string Symbol { get; set; }

        public decimal Count { get; set; }

        public Side Side { get; set; }

        public PositionStatus PositionStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}