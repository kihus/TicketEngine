using Domain.User.Entities;

namespace Infrastructure.Data.Bearer_Token.Interfaces;

public interface IAuthToken
{
	string GenerateToken(Customer customer);
}
