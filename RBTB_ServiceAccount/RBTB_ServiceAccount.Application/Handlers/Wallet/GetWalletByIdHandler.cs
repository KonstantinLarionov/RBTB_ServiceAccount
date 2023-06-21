using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Wallets;
using RBTB_ServiceAccount.Application.Domains.Responses.Wallets;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.Wallet;

public class GetWalletByIdHandler : IRequestHandler<GetWalletByIdRequest, GetWalletByIdResponse>
{
    private readonly IRepository<WalletEntity> _repositoryWallets;

    public GetWalletByIdHandler( IRepository<WalletEntity> repositoryWallets )
    {
        _repositoryWallets = repositoryWallets;
    }

    public async Task<GetWalletByIdResponse> Handle( GetWalletByIdRequest request, CancellationToken cancellationToken )
    {
        var Wallet = _repositoryWallets.FindById( request.WalletId );

        if ( Wallet != null )
        {
            return new GetWalletByIdResponse() { Success = false };
        }

        return new GetWalletByIdResponse() { Data = Wallet };
    }
}