using MediatR;
using Microsoft.IdentityModel.Tokens;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Request;
using RBTB_ServiceAccount.Application.Domains.Responses;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Application.Handlers;

public class GetHander:IRequestHandler<GetRequest,GetResponse>
{

    private IRepository<Trades> _repositoryTrades;
    private IRepository<Users> _repositoryUsers;
    private IRepository<Wallet> _repositoryWallet;
    private IRepository<Positions> _repositoryPositions;
    private  GetHander(IRepository<Trades> Trades, IRepository<Users>Users, IRepository<Wallet> Wallet, IRepository<Positions> Positions)
    {
        _repositoryTrades = Trades;
        _repositoryUsers = Users;
        _repositoryWallet = Wallet;
        _repositoryPositions = Positions;
    }

    public async Task<GetResponse> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        var respTrades = _repositoryTrades.Get(x => x.Id == request.idTrades).FirstOrDefault();
        var respUsers = _repositoryUsers.Get(x => x.Id == request.idUsers).FirstOrDefault();
        var respWallet = _repositoryWallet.Get(x => x.Id == request.idWallet).FirstOrDefault();
        var respPositions = _repositoryPositions.Get(x => x.Id == request.idPositions).FirstOrDefault();
        if (respTrades != null && respUsers != null && respWallet != null && respPositions != null)
        {
            return new GetResponse()
                { Positions = respPositions, Trades = respTrades, Wallet = respWallet, Users = respUsers, Success = true};
        }

        return new GetResponse() { Success = false, ErrorMessage = "ОШИБКА" };
    }
}
