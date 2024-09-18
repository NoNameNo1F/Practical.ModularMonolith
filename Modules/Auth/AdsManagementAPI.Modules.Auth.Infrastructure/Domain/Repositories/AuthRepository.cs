using AdsManagementAPI.Modules.Auth.Domain.Entities;
using AdsManagementAPI.Modules.Auth.Domain.Repositories;
using AdsManagementAPI.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Domain.Repositories;

internal class AuthRepository : IAuthRepository
{
    private readonly AuthContext _authContext;

    internal AuthRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }

    public async Task<Officer?> GetOfficerByIdAsync(Guid officerId)
    {
        return await _authContext.Officers.FindAsync(officerId);
    }

    public async Task<Officer?> GetOfficerWithRolesPrivilegesByEmailAsync(string email)
    {
        return await _authContext.Officers
            .Include(o => o.Role)
            .Include(o => o.Privileges)
            .FirstOrDefaultAsync(o => o.Email == email);
    }
}