using RBTB_ServiceAccount.Application.Domains.Entities;
using RBTB_ServiceAccount.Application.Domains.Requests;
using RBTB_ServiceAccount.Application.Domains.Responses;

namespace RBTB_ServiceAccount.Application.Abstractions
{
    public interface IWalletService
    {
        BaseResponse<Wallet> GetWallet(Guid id);

        BaseResponse<Guid> AddWallet(AddWalletRequest request);

        BaseResponse<bool> DeleteWallet(Guid walletId);

        BaseResponse<bool> UpdateWallet(Wallet wallet);

        BaseResponse<List<Wallet>> GetWalletByUserId(Guid userId);

        BaseResponse<Wallet> GetWalletBySymbol(Guid userId , string symbol);
    }
}
