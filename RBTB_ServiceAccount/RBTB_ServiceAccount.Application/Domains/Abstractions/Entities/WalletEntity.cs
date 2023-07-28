namespace RBTB_ServiceAccount.Application.Abstractions.Entities;

public class WalletEntity
{
    public Guid Id { get; set; }

    public UserEntity User { get; set; }

    public Guid UserId { get; set; }

    public string Symbol { get; set; }

    public string Market { get; set; }

    public DateTime DateOfRecording { get; set; }

    public decimal Balance { get; set; }
}