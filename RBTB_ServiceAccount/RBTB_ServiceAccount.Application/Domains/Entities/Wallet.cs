namespace RBTB_ServiceAccount.Application.Domains.Entities;

public class Wallet
{
    public Guid Id { get; set; }
    public Guid UserId {get;set;}
    public string Symbol{get;set;}
    public decimal Balance{get;set;}
}