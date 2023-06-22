using MediatR;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests.Wallets;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Wallet;

public class UpdateWalletHandler : IRequestHandler<UpdateWalletRequest, UpdateWalletResponse>
{
    private readonly IRepository<WalletEntity> _repositoryWallets;

    public UpdateWalletHandler( IRepository<WalletEntity> repositoryWallets )
    {
        _repositoryWallets = repositoryWallets;
    }

    public async Task<UpdateWalletResponse> Handle( UpdateWalletRequest request, CancellationToken cancellationToken )
    {
        var wallet = new WalletEntity()
        {
            Id = request.Id,
            UserId = request.UserId,
            Symbol = request.Symbol,
            Balance = request.Balance
        };

        var updateWallet = _repositoryWallets.Update( wallet );
        if ( updateWallet == 0 )
        {
            return new UpdateWalletResponse() { Success = false };
        }

        return new UpdateWalletResponse() { Data = wallet };
    }
}