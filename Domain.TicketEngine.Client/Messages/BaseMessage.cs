namespace Domain.TicketEngine.CustomerApi.Messages;

public abstract class BaseMessage
{
	public Guid Id { get; private set; }
	public string TypeMessage { get; private set; }
	public DateTime Timestamp { get; private set; }

	protected BaseMessage(string typeMessage)
	{
		Id = Guid.NewGuid();
		TypeMessage = typeMessage;
		Timestamp = DateTime.UtcNow;
	}
}
