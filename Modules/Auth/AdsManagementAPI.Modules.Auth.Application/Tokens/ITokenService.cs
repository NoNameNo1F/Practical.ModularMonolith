using AdsManagementAPI.Modules.Auth.Domain.Entities;

namespace AdsManagementAPI.Modules.Auth.Application.Tokens;

public interface ITokenService
{
    string CreateToken(Officer officer, string tokenType);
}