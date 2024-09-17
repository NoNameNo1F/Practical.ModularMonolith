using System.Reflection;
using AdsManagementAPI.Modules.Auth.Application.Contracts;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Configuration;

internal static class Assemblies
{
    public static readonly Assembly Application = typeof(IAuthModule).Assembly;
}