using Blastzone.RealityOn.API.Bases.Resources;

namespace Blastzone.RealityOn.Core.Systems.Construction.Parts;

public class ConstructAssetResource : GameResource
{
	public static HashSet<ConstructAssetResource> All { get; set; } = new();

	protected override void PostLoad()
	{
		base.PostLoad();

		if( !All.Contains(this) )
			All.Add(this);
	}
}

/// <summary>
/// Represents a wall construction part resource in the game.
/// </summary>
[GameResource( "Wall part", "wall", "Wall construction part" )]
public class WallPartResource : ConstructAssetResource, IConstructPart
{
	/// <summary>
	/// Gets or sets the type of construction part.
	/// </summary>
	public ConstructType ConstructType => ConstructType.Wall;

	/// <summary>
	/// Gets or sets the model of the wall.
	/// </summary>
	[ResourceType( "vmdl" )] 
	public string Model { get; set; }

	/// <summary>
	/// Gets or sets the size of the wall.
	/// </summary>
	public Vector3 Size { get; set; }
}

/// <summary>
/// Represents a wall construction part resource in the game.
/// </summary>
[GameResource( "Ceiling part", "ceiling", "Ceiling construction part" )]
public class CeilingPartResource : ConstructAssetResource, IConstructPart
{
	/// <summary>
	/// Gets or sets the type of construction part.
	/// </summary>
	public ConstructType ConstructType => ConstructType.Ceiling;

	/// <summary>
	/// Gets or sets the model of the ceiling.
	/// </summary>
	[ResourceType( "vmdl" )]
	public string Model { get; set; }

	/// <summary>
	/// Gets or sets the size of the ceiling.
	/// </summary>
	public Vector3 Size { get; set; }
}

/// <summary>
/// Enum representing different types of construction parts.
/// </summary>
public enum ConstructType
{
	Wall,
	Ceiling,
	Door,
	DoorFrame,
	Window,
	Floor,
	Roof,
	Pillar,
	Stairs
}
