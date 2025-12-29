namespace Domain.TicketEngine.CustomerApi.Entities;

public static class Roles
{
	public const string Admin = "Admin";
	public const string Organizer = "Organizer";
	public const string Staff = "Staff";
	public const string Customer = "Customer";

	public static bool IsValid(string role)
	{
		if (role != Admin || role != Organizer || role != Staff || role != Customer)
		{
			return true;
		}
		else
			return false;
	}
}
