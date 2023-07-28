using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Wallets;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Wallet;

public class CreateWalletHandler : IRequestHandler<CreateWalletRequest, CreateWalletResponse>
{
    private readonly IRepository<WalletEntity> _repositoryWallets;

    public CreateWalletHandler( IRepository<WalletEntity> repositoryWallets )
    {
        _repositoryWallets = repositoryWallets;
    }

    public async Task<CreateWalletResponse> Handle( CreateWalletRequest request, CancellationToken cancellationToken )
    {
        var wallet = new WalletEntity()
        {
            Id = Guid.NewGuid(),
            Balance = request.Balance,
            Symbol = request.Symbol,
            UserId = request.UserId,
            DateOfRecording = request.DateOfRecording,
            Market = request.Market
        };

        var createWallet = _repositoryWallets.Create( wallet );
        if ( createWallet == 0 )
        {
            return new CreateWalletResponse() { Success = false };
        }

        return new CreateWalletResponse() { Data = wallet.Id };
    }
}
