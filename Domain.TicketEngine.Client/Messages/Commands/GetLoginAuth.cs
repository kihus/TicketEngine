namespace Domain.TicketEngine.CustomerApi.Messages.Commands;

public class GetLoginAuth
{
	public required string Email { get; init; }
	public required string Password { get; init; }
}
