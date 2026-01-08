using Domain.TicketEngine.CustomerApi.Entities;

namespace Infrastructure.CustomerApi.Data.Bearer_Token.Interfaces;

public interface IAuthToken
{
	string GenerateToken(Customer customer);
}
