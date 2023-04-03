namespace RBTB_ServiceAccount.Application.Domains.Requests
{
    public class AddWalletRequest
    { 
        public Guid UserId { get; set; }
        public string Symbol { get; set; }
        public decimal Balance { get; set; }
    }
}