using Sandbox.Network;

namespace Mbk.Frontier.LobbySystem;

public abstract class BaseLobby : Component, Component.INetworkListener
{
	/// <summary>
	/// Retrieve the clients list collection.
	/// </summary>
	public IReadOnlyList<Connection> Clients => Connection.All;

	/// <summary>
	/// Max clients slots of this lobby.
	/// </summary>
	public virtual ushort MaxClients { get; } = 100;

	/// <summary>
	/// Return true if the lobby has reached max clients slots otherwise false.
	/// </summary>
	public bool IsFull => (Clients.Count == MaxClients);

	/// <summary>
	/// Return the lobby host client that own this lobby.
	/// </summary>
	public Connection Host => Connection.Host;

	//public async long Id() => await Networking.QueryLobbies().Result.Select();;

	protected override void OnEnabled()
	{
		if ( Scene.IsEditor )
			return;

		if ( /*StartServer && */!GameNetworkSystem.IsActive )
		{
			GameNetworkSystem.CreateLobby();

			if ( Consts.Debug )
				Log.Warning( $"[{Consts.GameName}] BaseLobby: New lobby has been created" );
		}
	}

	/*private bool Create()
	{
		NetworkSystem net = (Networking.System = new NetworkSystem( "lobbyhost", IGameMenuDll.Current.TypeLibrary ));
		net.InitializeHost();
		NetworkSystem networkSystem = net;
		networkSystem.AddSocket( await SteamLobbySocket.Create( 64 ) );
		if ( Application.IsEditor )
		{
			net.AddSocket( new TcpSocket( "127.0.0.1", 55333 ) );
		}
	}*/

	public void OnActive( Connection con )
	{
		Log.Info( $"Clients.Count -> {Clients.Count}" );
		Log.Info( $"MaxClients -> {MaxClients}" );

		if ( Clients.Count == MaxClients )
			return;

		if ( Consts.Debug )
			Log.Warning( $"[{Consts.GameName}] BaseLobby: Client '{con.DisplayName}' has joined the lobby." );

		OnClientJoined( con );
	}

	/// <summary>
	/// A client is fully connected to the server. This is called on the host.
	/// </summary>
	public void OnDisconnected( Connection con )
	{
		if ( Consts.Debug )
			Log.Warning( $"[{Consts.GameName}] BaseLobby: Client '{con.DisplayName}' has leaved the lobby." );

		OnClientDisconnect( con );
	}

	public void Close()
	{
		GameNetworkSystem.Disconnect();
	}

	/// <summary>
	/// A client has joined the lobby.
	/// </summary>
	protected virtual void OnClientJoined(Connection user)
	{
	}

	/// <summary>
	/// A client has leaved the lobby.
	/// </summary>
	protected virtual void OnClientDisconnect( Connection user )
	{
	}
}
