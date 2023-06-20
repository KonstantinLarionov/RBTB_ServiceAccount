namespace RBTB_ServiceAccount.Abstractions.Models;

public class User
{
    public Guid Id {get; set; }

    public string Username { get; set; }

    public string Login {get; set; }

    public string Password {get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid RefferalFrom { get; set; }
}