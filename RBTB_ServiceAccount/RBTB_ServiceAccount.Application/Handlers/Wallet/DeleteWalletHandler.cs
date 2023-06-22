using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Wallets;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Wallet;

public class DeleteWalletHandler : IRequestHandler<DeleteWalletRequest, DeleteWalletResponse>
{
    private readonly IRepository<WalletEntity> _repositoryWallets;

    public DeleteWalletHandler( IRepository<WalletEntity> repositoryWallets )
    {
        _repositoryWallets = repositoryWallets;
    }

    public async Task<DeleteWalletResponse> Handle( DeleteWalletRequest request, CancellationToken cancellationToken )
    {
        var deleteWallet = _repositoryWallets.Remove( request.WalletId );
        if ( deleteWallet == 0 )
        {
            return new DeleteWalletResponse() { Success = false };
        }

        return new DeleteWalletResponse() { Data = request.WalletId };
    }
}
