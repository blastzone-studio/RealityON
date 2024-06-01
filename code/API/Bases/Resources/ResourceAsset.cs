using Blastzone.RealityOn.API.Utility;

namespace Blastzone.RealityOn.API.Bases.Resources;

[GameResource( "Resource asset", "resource", "Describes an resource (weapon, collectible, etc..)", Icon = "sprint", Category = "RealityOn" )]
public partial class ResourceAsset : GameResource, IResource
{
	public static HashSet<ResourceAsset> All { get; set; } = new();

	[Category( "Definition" )]
	[Description( "Name of this resource." )]
	public string Name { get; set; }

	[Category( "Definition" )]
	[Description( "Description of this resource (ex: what it does or what it is)." )]
	public string Description { get; set; }

	[Category( "Definition" )]
	[Description( "Should this resource be enabled or not." )]
	public bool IsEnabled { get; set; }

	[Category( "Definition" )]
	[Description( "Resource category/type, if this is a weapon, food, etc..." )]
	public ResourceType Type { get; set; }

	[Category( "Definition" )]
	[Description( "Prefab file of this resource." )]
	public PrefabFile PrefabSource { get; set; }

	[Category( "Definition" )]
	[Description( "Weight of this resource, in kilogram." )]
	public int Weight { get; set; }

	[Category( "Definition" )]
	[Description( "Max quantity of this resource that can be hold in one container." )]
	public int MaxStack { get; set; } = 5;

	[Hide]
	public int Quantity { get; set; }

	protected override void PostLoad()
	{
		if ( All.Contains( this ) )
		{
			Log.Warning( "Tried to add two of the same trap (?)" );
			return;
		}

		All.Add( this );
	}

	public GameObject Spawn( Vector3 position )
	{
		if ( PrefabSource == null )
			return null;

		var obj = PrefabUtility.CreateGameObject( PrefabSource );
		obj.Transform.Position = position;

		var component = obj.Components.Get<ResourceBase>();
		/*if ( component != null )
			component.SetResource( this );
		else
			obj.Destroy();*/

		return obj ?? null;
	}
}
