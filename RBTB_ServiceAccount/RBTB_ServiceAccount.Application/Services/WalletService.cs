using RBTB_ServiceAccount.Application.Abstractions;
using RBTB_ServiceAccount.Application.Domains.Entities;
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

    public BaseResponse<Guid> AddWallet(Wallet wallet)
    {
        var walletUpdateResult = _repositoryWallet.Create(wallet);

        if (walletUpdateResult == 0)
        {
            return new BaseResponse<Guid>
            {
                IsSuccess = false,
                ErrorMessage = $"Don`t added trade{wallet}"
            };
        }

        return new BaseResponse<Guid>
        {
            Data = wallet.Id
        };
    }


    public BaseResponse<bool> DeleteTrade(Guid walletId)
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
            ErrorMessage = $"Trade don`t delete. Trade:{walletId}"
        };
    }

    public BaseResponse<bool> UpdateTrade(Wallet wallet)
    { 
        var walletUpdateResult = _repositoryWallet.Update(wallet);

        if (walletUpdateResult == 0)
        {
            return new BaseResponse<bool>
            {
                IsSuccess = false,
                ErrorMessage = $"Trade don`t update. Trade:{wallet}"
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
