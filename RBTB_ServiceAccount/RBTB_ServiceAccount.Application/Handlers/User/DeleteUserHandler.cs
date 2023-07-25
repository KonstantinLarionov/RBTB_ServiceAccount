using MediatR;
using RBTB_ServiceAccount.Application.Domains.Requests.Users;
using RBTB_ServiceAccount.Application.Domains.Responses.Users;
using RBTB_ServiceAccount.Application.Abstractions.Entities;
using RBTB_ServiceAccount.Application.Inerfaces;

namespace RBTB_ServiceAccount.Application.Handlers.User;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IRepository<UserEntity> _repositoryUsers;
    private readonly IRepository<PositionEntity> _repositoryPosition;
    private readonly IRepository<TradeEntity> _repositoryTrade;
    private readonly IRepository<WalletEntity> _repositoryWallet;

    public DeleteUserHandler(
        IRepository<UserEntity> repositoryUsers,
        IRepository<PositionEntity> repositoryPosition,
        IRepository<TradeEntity> repositoryTrade,
        IRepository<WalletEntity> repositoryWallet)
    {
        _repositoryUsers = repositoryUsers;
        _repositoryPosition = repositoryPosition;
        _repositoryTrade = repositoryTrade;
        _repositoryWallet = repositoryWallet;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var positions = _repositoryPosition.Get().Where(t => t.UserId == request.UserId).ToList();

        if (positions.Any())
        {
            foreach (var position in positions)
            {
                _repositoryPosition.Remove(position.Id);
            }
        }

        var trades = _repositoryTrade.Get().Where(t => t.UserId == request.UserId).ToList();

        if (trades.Any())
        {
            foreach (var trade in trades)
            {
                _repositoryTrade.Remove(trade.Id);
            }
        }

        var wallets = _repositoryWallet.Get().Where(t => t.UserId == request.UserId).ToList();

        if (wallets.Any())
        {
            foreach (var wallet in wallets)
            {
                _repositoryWallet.Remove(wallet.Id);
            }
        }

        var deleteUser = _repositoryUsers.Remove(request.UserId);
        if (deleteUser == 0)
        {
            return new DeleteUserResponse() { Success = false };
        }

        return new DeleteUserResponse() { Data = request.UserId };
    }
}
