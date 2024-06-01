using Blastzone.RealityOn.API.Bases.Inventory;

namespace Blastzone.RealityOn.API.Bases.Players;

[Category("Frontier")]
public class Player : RealityComponent, Component.ICollisionListener
{
	[Property]
	public InventoryContainer Inventory { get; set; }

	protected override void OnAwake()
	{
		Inventory = new InventoryContainer(16);
		GameObject.BreakFromPrefab();

		//Inventory.Add<Medkit>();
	}

	public void OnCollisionStart( Collision other )
	{
		Log.Info( other );
	}
}
