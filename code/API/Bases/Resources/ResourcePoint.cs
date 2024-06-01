using Blastzone.RealityOn.API.Bases.Players;

namespace Blastzone.RealityOn.API.Bases.Resources;

[Category( "Frontier" )]
public class ResourcePoint : Component, Component.ICollisionListener
{
	[Property]
	[Description( "Resource type that will be spawned at this point" )]
	public ResourceBase Resource { get; set; }

	protected override void OnValidate()
	{
		GameObject.BreakFromPrefab();
	}

	public void OnCollisionStart( Collision collider )
	{
		if ( Resource == null )
			return;

		Log.Info( Resource );

		var player = collider.Other.GameObject.Components.Get<Player>( FindMode.InAncestors );

		if ( player == null )
			return;

		Resource.OnPickedUp( player );

		GameObject.Destroy();
	}
}
