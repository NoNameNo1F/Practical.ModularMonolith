using AdsManagementAPI.Modules.Auth.Application.Contracts;

namespace AdsManagementAPI.Modules.Auth.Application.Commands.Login;

public class LoginCommand : CommandBase<string>
{
    public string Email { get; }
    public string Password { get; }

    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }
}