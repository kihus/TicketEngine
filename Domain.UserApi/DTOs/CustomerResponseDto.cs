namespace Domain.User.DTOs;

public class CustomerResponseDto
{
	public string? Name { get; init; }
	public string? LastName { get; init; } 
	public DateOnly Birthdate { get; init; } 
	public string? Phone { get; init; } 
	public string? Role { get; init; }
}
