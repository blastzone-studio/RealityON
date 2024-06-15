namespace Blastzone.RealityOn.Core.Modules.Database;

public abstract class TableBase : ITable
{
	public virtual string Name => "new_table";

	public virtual string Controller => "";

	protected TableBase()
	{

	}

	public virtual async Task Load()
	{
		throw new NotImplementedException();
	}

	public virtual async Task Save()
	{
		throw new NotImplementedException();
	}

	public async Task Insert<T>( T value )
	{
		throw new NotImplementedException();
	}

	public async Task<bool> Update<T>( T value )
	{
		throw new NotImplementedException();
	}

	public async Task Get<T>( T value )
	{
		throw new NotImplementedException();
	}
}
