using Blastzone.RealityOn.API.Bases.Resources;

namespace Blastzone.RealityOn.API.Bases.Inventory;

public class InventoryContainer
{
	public ushort MaxSlots { get; private set; }
	public List<IResource> ResourcesList { get; private set; }

	public InventoryContainer(ushort maxslots = 32)
	{
		MaxSlots = maxslots;
		ResourcesList = new List<IResource>();
	}

	public void SetMaxSlots(ushort amount)=> MaxSlots = amount;

	#region ADD
	public void Add<T>() where T : IResource, new()
	{
		T resource = new T();

		Log.Info( resource );
		
		if(resource != null)
			InternalAdd( resource );
	}

	public void Add( IResource resource )
	{
		InternalAdd( resource );
	}

	internal void InternalAdd( IResource resource )
	{
		IResource existingResource = ResourcesList.Find( r => r.Name == resource.Name );
		if ( existingResource != null )
		{
			Log.Info($"ExistingResource quantity -> {existingResource.Quantity}");

			// Calculate the remaining space in the stack
			int remainingSpace = existingResource.MaxStack - existingResource.Quantity;


			// Add to the stack if there's enough space
			if ( remainingSpace >= resource.Quantity )
			{
				existingResource.Quantity += resource.Quantity;
			}
			else
			{
				// If the stack is full, add as a separate stack
				ResourcesList.Add( resource );
			}
		}
		else
		{
			ResourcesList.Add( resource );
		}

		Log.Info( $"New resource added {resource.Name}" );
		DisplayInventory();
	}
	#endregion

	#region REMOVE
	public void Remove<T>( T resource, int quantity = 1 ) where T : IResource
	{
		InternalRemove( resource, quantity );
	}

	public void Remove( IResource resource, int quantity = 1 )
	{
		InternalRemove( resource, quantity );
	}

	internal void InternalRemove( IResource resource, int quantity ) 
	{
		// Check if the item exists in the inventory
		IResource existingItem = ResourcesList.Find( i => i.Name == resource.Name && i.Type == resource.Type );
		if ( existingItem != null )
		{
			// If the quantity to remove is greater than or equal to the existing quantity, remove the item completely
			if ( quantity >= existingItem.Quantity )
			{
				ResourcesList.Remove( existingItem );
			}
			else
			{
				// Otherwise, decrement the quantity
				existingItem.Quantity -= quantity;
			}
		}
	}
	#endregion

	// Eject effect of all items of this container
	public void Eject()
	{
		foreach( IResource item in ResourcesList )
		{

		}
	}

	// Transfer all resources of this container to another one.
	public void ToContainer( InventoryContainer container ) => container.ResourcesList.AddRange( ResourcesList );

	public void DisplayInventory()
	{
		Log.Info( "Inventory:" );
		foreach ( IResource resource in ResourcesList )
		{
			Log.Info( resource.Name );
		}
	}
}
