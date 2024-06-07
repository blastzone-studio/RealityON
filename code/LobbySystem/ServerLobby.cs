using Mbk.Frontier.LobbySystem;
using Sandbox;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Blastzone.RealityOn.LobbySystem;

public sealed class ServerLobby : BaseLobby
{
	[Property]
	public GameObject PlayerPrefab { get; set; }

	[Property]
	public List<GameObject> Spawns { get; set; }

	protected override void OnClientJoined( Connection user )
	{
		Transform destination;
		
		if( Spawns != null)
			destination = Spawns[Game.Random.Int( 0, (Spawns.Count - 1) )].Transform.World;
		else
			destination = Scene.Transform.World;

		Log.Info( destination );

		if( PlayerPrefab is null)
		{
			Log.Error( $"[{Consts.GameName}] ServerLobby: PlayerPrefab entry is empty, please setup one before try to spawn." );
			return;
		}

		// Spawn this object and make the client the owner
		var player = PlayerPrefab.Clone( destination, name: $"Player - {user.DisplayName}" );
		player.NetworkSpawn( user );
	}
}
