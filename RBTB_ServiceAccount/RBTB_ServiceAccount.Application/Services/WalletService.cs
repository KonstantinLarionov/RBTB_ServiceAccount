using Azure.Core;
using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;
using RBTB_ServiceAccount.Database.Abstractions;

namespace RBTB_ServiceAccount.Application.Services;
public class WalletService : IWalletService
{
    private IRepository<Wallet> _repositoryWallet;

    public WalletService(IRepository<Wallet> Wallet)
    {
        _repositoryWallet = Wallet;
    }

    public BaseResponse<Wallet> GetWallet(Guid id)
    {
        var walletGetResult = _repositoryWallet.FindById(id);
        if (walletGetResult == null)
        {
            return new BaseResponse<Wallet>
            {
                IsSuccess = false,
                ErrorMessage = $"Wallet with id {id} not found"
            };
        }
        return new BaseResponse<Wallet>
        {
            Data = walletGetResult
        };
    }

    public BaseResponse<Guid> AddWallet(AddWalletRequest request)
    {
        var wallet = new Wallet
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Symbol = request.Symbol,
            Balance = request.Balance
        };

        var walletUpdateResult = _repositoryWallet.Create(wallet);

        if (walletUpdateResult == 0)
        {
            return new BaseResponse<Guid>
            {
                IsSuccess = false,
                ErrorMessage = $"Don`t added wallet{wallet}"
            };
        }

        return new BaseResponse<Guid>
        {
            Data = wallet.Id
        };
    }


    public BaseResponse<bool> DeleteWallet(Guid walletId)
    {
        var walletDeleteResult = _repositoryWallet.FindById(walletId);

        if (walletDeleteResult != null)
        {
            var walletRemoveResult= _repositoryWallet.Remove(walletDeleteResult);
            if(walletRemoveResult != 0) 
            {
                return new BaseResponse<bool>();
            }
        }
  
        return new BaseResponse<bool>
        {
            IsSuccess = false,
            ErrorMessage = $"Wallet don`t delete. Wallet:{walletId}"
        };
    }

    public BaseResponse<bool> UpdateWallet(Wallet wallet)
    { 
        var walletUpdateResult = _repositoryWallet.Update(wallet);

        if (walletUpdateResult == 0)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                ErrorMessage = $"Wallet don`t update. Wallet:{wallet}"
            };
        }

        return new BaseResponse<bool>
        {
            IsSuccess = true
        };
    }

    public BaseResponse<List<Wallet>> GetWalletByUserId(Guid userId)
    {
        var walletGetIdResult = _repositoryWallet.Get().Where(w => w.UserId == userId).ToList();

        return new BaseResponse<List<Wallet>>
        {
            Data = walletGetIdResult
        };
    }

    public BaseResponse<Wallet> GetWalletBySymbol(Guid userId, string symbol)
    {
        var walletGetSymbolResult = _repositoryWallet.Get().Where(w => w.UserId == userId && w.Symbol == symbol).FirstOrDefault();
        if (walletGetSymbolResult == null)
        {
            return new BaseResponse<Wallet>
            {
                IsSuccess = false,
                ErrorMessage = $"Wallet with userId {userId} and symbol {symbol} not found"
            };
        }
        return new BaseResponse<Wallet>
        {
            Data = walletGetSymbolResult
        };
    }
}