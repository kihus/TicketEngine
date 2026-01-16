namespace Domain.User.Messages.Commands;

public class CreateCustomerCommand
{
	public required string Name { get; init; } 
	public required string LastName { get; init; } 
	public DateTime Birthdate { get; init; }
	public string? Phone { get; init; }
	public required string Document { get; init; }
	public required string Role { get; init; }
	public required string Email { get; init; }
	public required string Password { get; init; }
}
