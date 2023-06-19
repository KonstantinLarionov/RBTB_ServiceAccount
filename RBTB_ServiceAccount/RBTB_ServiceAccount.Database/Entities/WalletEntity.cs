using Microsoft.EntityFrameworkCore;

namespace RBTB_ServiceAccount.Database.Entities;

public class WalletEntity
{
    public Guid Id { get; set; }

    public Guid UserId {get;set;}

    public string Symbol{get;set;}

    [Precision( 18, 2 )]
    public decimal Balance{get;set;}
}