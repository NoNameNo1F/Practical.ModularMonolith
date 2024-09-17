using AdsManagementAPI.Modules.Auth.Domain.Entities;
using AdsManagementAPI.Modules.Auth.Domain.Repositories;
using AdsManagementAPI.Modules.Auth.Infrastructure.Database;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Domain.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly AuthContext _authContext;

    public AuthRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }
    
    public async Task<Officer?> GetByOfficerIdAsync(Guid officerId)
    {
        return await _authContext.Officers.FindAsync(officerId);
    }
    
    // Add more here
}