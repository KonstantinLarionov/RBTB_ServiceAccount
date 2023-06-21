namespace RBTB_ServiceAccount.Application.Abstractions.Entities;

public class UserEntity
{
    public Guid Id {get; set; }

    public string Username { get; set; }

    public string Login {get; set; }

    public string Password {get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid RefferalFrom { get; set; }
}