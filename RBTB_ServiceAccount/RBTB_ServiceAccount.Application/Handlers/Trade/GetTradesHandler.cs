using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Trades;
using RBTB_ServiceAccount.Application.Domains.Responses.Trades;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Trade;

public class GetTradesHandler : IRequestHandler<GetTradesRequest, GetTradesResponse>
{
    private readonly IRepository<TradeEntity> _repositoryTrades;

    public GetTradesHandler( IRepository<TradeEntity> repositoryTrades )
    {
        _repositoryTrades = repositoryTrades;
    }

    public async Task<GetTradesResponse> Handle( GetTradesRequest request, CancellationToken cancellationToken )
    {
        var trades = _repositoryTrades.Get();

        if ( !trades.Any() )
        {
            return new GetTradesResponse();
        }

        if ( !string.IsNullOrEmpty( request.Symbol ) )
        {
            trades = trades.Where( p => p.Symbol == request.Symbol );
        }

        if ( request.OrderStatus != null )
        {
            trades = trades.Where( p => p.OrderStatus == request.OrderStatus );
        }

        if ( request.OrderType != null )
        {
            trades = trades.Where( p => p.OrderType == request.OrderType );
        }

        if ( request.Side != null )
        {
            trades = trades.Where( p => p.Side == request.Side );
        }

        if ( request.UserId != null )
        {
            trades = trades.Where( p => p.UserId == request.UserId );
        }

        if(request.Sort is not null)
        {
            if (request.Sort == Domains.Abstractions.Entities.Enums.SortEnum.Ascending)
            {
                trades = trades.OrderBy(a => a.CreatedDate);
            }
            else
            {
                trades = trades.OrderByDescending(a => a.CreatedDate);
            }
        }

        if (request.DateTo is not null)
        {
            trades = trades.Where(w => w.CreatedDate >= request.DateFrom && w.CreatedDate <= request.DateTo);
        }
        else
            trades = trades.Where(w => w.CreatedDate >= request.DateFrom && w.CreatedDate <= DateTime.Now);


        return new GetTradesResponse() { Data = trades.ToArray() };
    }
}
