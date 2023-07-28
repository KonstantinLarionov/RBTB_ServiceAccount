using MediatR;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;
using RBTB_ServiceAccount.Application.Domains.Requests.Wallets;

namespace RBTB_ServiceAccount.Application.Handlers.Wallet;

public class GetWalletsHandler : IRequestHandler<GetWalletsRequest, GetWalletsResponse>
{
    private readonly IRepository<WalletEntity> _repositoryWallets;

    public GetWalletsHandler(IRepository<WalletEntity> repositoryWallets)
    {
        _repositoryWallets = repositoryWallets;
    }

    public async Task<GetWalletsResponse> Handle(GetWalletsRequest request, CancellationToken cancellationToken)
    {
        var wallets = _repositoryWallets.Get();

        if (!wallets.Any())
        {
            return new GetWalletsResponse();
        }

        if (!string.IsNullOrEmpty(request.Symbol))
        {
            wallets = wallets.Where(w => w.Symbol == request.Symbol);
        }

        if (request.UserId is not null && request.UserId != Guid.Empty)
        {
            wallets = wallets.Where(w => w.UserId == request.UserId);
        }

        if (!string.IsNullOrWhiteSpace(request.Market))
        {
            wallets = wallets.Where(w => w.Market == request.Market.Trim());
        }

        if (request.DateEnd is not null)
        {
            wallets = wallets.Where(w => w.DateOfRecording >= request.DateBegin && w.DateOfRecording <= request.DateEnd);
        }

        wallets = wallets.Where(w => w.DateOfRecording >= request.DateBegin && w.DateOfRecording <= DateTime.Now);

        return new GetWalletsResponse() { Data = wallets.ToArray() };
    }
}
