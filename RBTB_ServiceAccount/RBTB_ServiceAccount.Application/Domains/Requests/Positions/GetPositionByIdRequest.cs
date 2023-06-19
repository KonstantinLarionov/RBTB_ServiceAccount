using MediatR;
using RBTB_ServiceAccount.Application.Domains.Responses.Positions;

namespace RBTB_ServiceAccount.Application.Domains.Requests.Positions
{
    public class GetPositionByIdRequest : IRequest<GetPositionByIdResponse>
    {
        public Guid PositionId { get; set; }
    }
}