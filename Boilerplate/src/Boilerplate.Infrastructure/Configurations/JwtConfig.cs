namespace Boilerplate.Infrastructure.Configurations;

public class JwtConfig
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double ExpirationInMinutes { get; set; }
    public string PrivateKey { get; set; }
}
