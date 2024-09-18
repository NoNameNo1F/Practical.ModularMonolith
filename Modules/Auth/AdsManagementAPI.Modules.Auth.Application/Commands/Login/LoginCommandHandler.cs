using AdsManagementAPI.BuildingBlocks.Domain.DomainConstraints.Constraints;
using AdsManagementAPI.Modules.Auth.Application.Configuration.Commands;
using AdsManagementAPI.Modules.Auth.Application.Tokens;
using AdsManagementAPI.Modules.Auth.Domain.Repositories;

namespace AdsManagementAPI.Modules.Auth.Application.Commands.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly ITokenService _tokenService;
    private readonly IAuthRepository _authRepository;

    public LoginCommandHandler(ITokenService tokenService, IAuthRepository authRepository)
    {
        _tokenService = tokenService;
        _authRepository = authRepository;
    }
    
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var officer = await _authRepository.GetOfficerWithRolesPrivilegesByEmailAsync(request.Email);

        var tokenType = TokenTypeNames.Access;

        var token = _tokenService.CreateToken(officer!, tokenType);

        return token;
    }
}