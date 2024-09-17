using AdsManagementAPI.Modules.Auth.Domain.Entities;

namespace AdsManagementAPI.Modules.Auth.Domain.Repositories;

public interface IAuthRepository
{
    Task<Officer?> GetByOfficerIdAsync(Guid officerId);
}