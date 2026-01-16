using Domain.User.Entities;
using Infrastructure.Data.Bearer_Token.Interfaces;
using Infrastructure.Data.Bearer_Token.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Data.Bearer_Token;

public sealed class AuthToken(
	TokenSettings settings
	) : IAuthToken
{
	private readonly TokenSettings _settings = settings;

	public string GenerateToken(Customer customer)
	{
		var secretKey = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(
				_settings.SecretKey
				?? string.Empty
				)
			);

		var claims = new List<Claim>()
		{
			new (JwtRegisteredClaimNames.Sub, customer.Name),
			new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new (ClaimTypes.Role, customer.Role)
		};

		var expirationTimeInMinutes = _settings.ExpirationTimeInMinutes;

		var token = new JwtSecurityToken(
			issuer: _settings.Issuer,
			audience: _settings.Audience,
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationTimeInMinutes),
			signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
			);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
