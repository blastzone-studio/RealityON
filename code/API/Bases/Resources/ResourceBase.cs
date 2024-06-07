using Blastzone.RealityOn.API.Bases.Players;

namespace Blastzone.RealityOn.API.Bases.Resources;

/// <summary>
/// This is the final resource game object status created by the game resources files 
/// </summary>
public abstract class ResourceBase : RealityComponent, IResource
{
	[Property]
	[Category( "Definition" )]
	[Description( "Name of this resource." )]
	public string Name => ResourceAsset.Name ?? "Not Initialized";

	[Property]
	[Category( "Definition" )]
	[Description( "Description of this resource (ex: what it does or what it is)." )]
	public string Description => ResourceAsset.Description ?? "Not Initialized";

	[Property]
	[Category( "Definition" )]
	[Description( "Should this resource be enabled or not." )]
	public bool IsEnabled => ResourceAsset.IsEnabled;

	[Property]
	[Category( "Definition" )]
	[Description( "Resource category/type, if this is a weapon, food, etc..." )]
	public ResourceType Type => ResourceAsset.Type;

	[Property]
	[Category( "Definition" )]
	[Description( "Prefab file of this resource." )]
	public PrefabFile PrefabSource => ResourceAsset.PrefabSource ?? null;

	[Property]
	[Category( "Definition" )]
	[Description( "Weight of this resource, in kilogram." )]
	public int Weight => ResourceAsset.Weight;

	[Property]
	[Category( "Definition" )]
	[Description( "Max quantity of this resource that can be hold in one container." )]
	public int MaxStack => ResourceAsset.MaxStack;

	[Category( "Definition" )]
	[Property]
	[Sandbox.Range( 1, 100 )]
	[Description( "Current quantity of this resource in the container." )]
	public int Quantity { get; set; } = 1;

	[Property]
	[Category( "Important" )]
	[RequireComponent]
	[Description( "Resource asset file of this resource" )]
	public ResourceAsset ResourceAsset { get; set; }

	public void SetResource( ResourceAsset asset ) => ResourceAsset = asset;

	public Action<Player> WhenPickedUp { get; set; }
	public Action WhenUsed { get; set; }

	// Called when this resource has been picked up by a player.
	public virtual void OnPickedUp( Player player )
	{
		//WhenPickedUp.Invoke( player );
		//player.Inventory.Add( this );
	}

	// Called when this resource has been used / consumed.
	protected virtual void OnUsed()
	{
		WhenUsed.Invoke();
	}
}

public interface IResource
{
	string Name { get; }
	string Description { get; }
	bool IsEnabled { get; }
	ResourceType Type { get; }
	PrefabFile PrefabSource { get; }
	int Weight { get; }
	int MaxStack { get; }
	int Quantity { get; set; }
}

public enum ResourceType
{
	Miscellaneous = 0,
	Weapons,
	Consumable,
	Collectible,
	Environmental
}
