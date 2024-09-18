using System.Security.Claims;

namespace AdsManagementAPI.API.Configurations.Extensions;

public static class HttpContextExtention
{
    public const string PrivilegesClaimName = "privileges";

    public static string GetIpAddress(this HttpContext context)
    {
        try
        {
            var address = context.Connection.RemoteIpAddress;
            return address!.ToString();
        }
        catch
        {
            return "localhost";
        }
    }

    public static Guid? GetCurrentUserId(this HttpContext context)
    {
        var userId = context?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (userId is not null && Guid.TryParse(userId, out Guid id))
        {
            return id;
         }
        
         return null;
    }
    public static string? GetCurrentUserRole(this HttpContext context) => context?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

    public static string? GetCurrentUserEmail(this HttpContext context) => context?.User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

    public static List<string> GetCurrentUserPrivileges(this HttpContext context) => context?.User?.Claims?.Where(c => c.Type == PrivilegesClaimName)?.Select(claim => claim.Value).ToList() ?? new List<string>();
}