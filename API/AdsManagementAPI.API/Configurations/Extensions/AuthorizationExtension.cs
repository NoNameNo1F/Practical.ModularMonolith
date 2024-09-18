using AdsManagementAPI.API.Common;
using AdsManagementAPI.BuildingBlocks.Domain.DomainConstraints.Constraints;
using Microsoft.AspNetCore.Authorization;

namespace AdsManagementAPI.API.Configurations.Extensions;

internal static class AuthorizationExtension
{
    internal static IServiceCollection AddApiAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(HeaderConstraints.TokenType, TokenTypeNames.Access)
                .Build();
        });

        return services;
    }
}