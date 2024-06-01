namespace Blastzone.RealityOn.API.Bases.UI;

/// <summary>
/// Abstract base class for a chat system in the game. 
/// This class provides basic functionalities and can be extended for custom behaviors.
/// </summary>
public abstract class BaseChat : Panel
{
	/// <summary>
	/// Instance of BaseChat
	/// </summary>
	public static BaseChat Instance { get; set; }

	/// <summary>
	/// Gets the list of muted clients.
	/// </summary>
	public IList<Connection> MutedClients { get; private set; } = new List<Connection>();

	protected BaseChat()
	{
		Instance = this;
	}

	/// <summary>
	/// Sends a message.
	/// </summary>
	/// <param name="message">The message to send.</param>
	public virtual void Send( string message )
	{

	}

	/// <summary>
	/// Clears the chat.
	/// </summary>
	public virtual void Clear()
	{
	}

	/// <summary>
	/// Receives a message from a sender.
	/// </summary>
	/// <param name="message">The message received.</param>
	/// <param name="sender">The sender of the message.</param>
	public virtual void ReceiveMessage( string message, string sender )
	{
		// Default implementation (if any)
	}

	/// <summary>
	/// Called when a message is received.
	/// </summary>
	/// <param name="message">The message received.</param>
	/// <param name="sender">The sender of the message.</param>
	public virtual void OnMessageReceived( string message, string sender )
	{
		// Default implementation (if any)
	}

	/// <summary>
	/// Called when a message is sent.
	/// </summary>
	/// <param name="message">The message sent.</param>
	/// <param name="sender">The sender of the message.</param>
	public virtual void OnMessageSent( string message, string sender )
	{
		// Default implementation (if any)
	}

	/// <summary>
	/// Mutes a specific user in the chat.
	/// </summary>
	/// <param name="user">The user to mute.</param>
	public virtual void MuteUser( string user )
	{
		// Default implementation (if any)
	}

	/// <summary>
	/// Unmutes a specific user in the chat.
	/// </summary>
	/// <param name="user">The user to unmute.</param>
	public virtual void UnmuteUser( string user )
	{
		// Default implementation (if any)
	}

	/// <summary>
	/// Bans a user from the chat.
	/// </summary>
	/// <param name="user">The user to ban.</param>
	public virtual void BanUser( string user )
	{
		// Default implementation (if any)
	}

	/// <summary>
	/// Unbans a user from the chat.
	/// </summary>
	/// <param name="user">The user to unban.</param>
	public virtual void UnbanUser( string user )
	{
		// Default implementation (if any)
	}
}
