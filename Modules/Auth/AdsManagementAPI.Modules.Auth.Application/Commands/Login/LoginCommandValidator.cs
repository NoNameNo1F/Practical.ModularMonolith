using AdsManagementAPI.Modules.Auth.Domain.Repositories;
using FluentValidation;

namespace AdsManagementAPI.Modules.Auth.Application.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator(IAuthRepository authRepository)
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Username must be an email address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MustAsync(async (request, password, cancel) =>
            {
                var user = await authRepository.GetOfficerWithRolesPrivilegesByEmailAsync(request.Email);

                return true;
            })
            .WithMessage("Invalid password");
    }
}
