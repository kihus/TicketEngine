namespace Infrastructure.Data.Bearer_Token.Settings;

public class TokenSettings
{
	public string? SecretKey { get; set; }
	public string? Issuer { get; set; }
	public string? Audience { get; set; }
	public int ExpirationTimeInMinutes { get; set; }
	public int RefreshExpirationTimeInMinutes { get; set; }
}
