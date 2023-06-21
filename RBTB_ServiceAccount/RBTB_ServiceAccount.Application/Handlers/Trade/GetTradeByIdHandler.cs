using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Trades;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Trade;

public class GetTradeByIdHandler : IRequestHandler<GetTradeByIdRequest, GetTradeByIdResponse>
{
    private readonly IRepository<TradeEntity> _repositoryTrades;

    public GetTradeByIdHandler( IRepository<TradeEntity> repositoryTrades )
    {
        _repositoryTrades = repositoryTrades;
    }

    public async Task<GetTradeByIdResponse> Handle( GetTradeByIdRequest request, CancellationToken cancellationToken )
    {
        var trade = _repositoryTrades.FindById( request.TradeId );

        if ( trade != null )
        {
            return new GetTradeByIdResponse() { Success = false };
        }

        return new GetTradeByIdResponse() { Data = trade };
    }
}