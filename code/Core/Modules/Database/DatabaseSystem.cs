using Blastzone.RealityOn.API.Enums;
using Blastzone.RealityOn.API.Interfaces;
using Blastzone.RealityOn.Core.Modules;
using Blastzone.RealityOn.Core.Modules.Job;

namespace Blastzone.RealityOn.Core.Modules.Database;

[Module( false )]
public class DatabaseSystem : ModuleBase
{
	public static DatabaseSystem Instance { get; private set; }

	public DatabaseSystem() { Instance = this; }

	public override string ModuleName => "Database";

	public override float ModuleVersion => .1f;

	public override string ModulePath => "database";

	public IList<ITable> Tables { get; set; }

	public override async Task Load()
	{
		Tables = new List<ITable>();

		Log.Info( "Initialize" );

		foreach ( var type in TypeLibrary.GetTypes().Where( x => x.IsClass ) )
		{
			if ( type.Interfaces.Any( x => x.Name == "ITable" ) )
			{
				var table = type.Create<ITable>();
				table.Load().Wait();
				Tables.Add( table );
			}
		}

		// Discover and instantiate all job types in the TypeLibrary.
		foreach ( var type in TypeLibrary.GetTypes().Where( x => x.IsClass && !x.IsAbstract ) )
		{
			var baseType = type.TargetType.BaseType;
			var targetType = type.TargetType;

			if ( baseType is not null && baseType == typeof( TableBase ) )
			{
				Tables.Add( TypeLibrary.Create<ITable>( targetType ) );
			}
		}

		await base.Load();
	}

	public override async Task Reload()
	{
		await base.Reload();
	}

	public override async Task Stop()
	{
		await base.Stop();
	}

	/// <summary>
	/// Gets a specific table by type.
	/// </summary>
	/// <typeparam name="T">The type of table to get.</typeparam>
	/// <returns>The table of the specified type.</returns>
	public static T Get<T>() where T : ITable
	{
		return Instance.Tables.OfType<T>().FirstOrDefault();
	}
}
