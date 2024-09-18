namespace AdsManagementAPI.Modules.Auth.Infrastructure.Token;

public class TokensConfiguration
{
    public string Issuer { get; }
    public string Audience { get; }
    public string Key { get; }

    public TokensConfiguration(string issuer, string audience, string key)
    {
        Issuer = issuer;
        Audience = audience;
        Key = key;
    }
}