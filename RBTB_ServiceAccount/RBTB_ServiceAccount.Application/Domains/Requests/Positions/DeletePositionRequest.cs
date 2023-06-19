using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Positions
{
    public class DeletePositionRequest : IRequest<DeletePositionResponse>
    {
        public Guid PositionId { get; set; }
    }
}