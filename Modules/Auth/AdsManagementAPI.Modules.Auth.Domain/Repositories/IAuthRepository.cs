using AdsManagementAPI.Modules.Auth.Domain.Entities;

namespace AdsManagementAPI.Modules.Auth.Domain.Repositories;

public interface IAuthRepository
{
    Task<Officer?> GetOfficerByIdAsync(Guid officerId);
    Task<Officer?> GetOfficerWithRolesPrivilegesByEmailAsync(string email);
    // more...
}