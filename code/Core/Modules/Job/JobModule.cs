using Blastzone.RealityOn.API.Enums;
using Blastzone.RealityOn.API.Interfaces;
using Blastzone.RealityOn.API.Utility;

namespace Blastzone.RealityOn.Core.Modules.Job;

/// <summary>
/// Manages the job system, including the list of available jobs and saving/loading job data.
/// </summary>
[Module]
public sealed class JobModule : IModule
{
	/// <summary>
	/// Gets the name of this module.
	/// </summary>
	public string ModuleName => "Job";

	/// <summary>
	/// Gets the version of this module.
	/// </summary>
	public float ModuleVersion => 0.1f;

	/// <summary>
	/// Gets the version of this module.
	/// </summary>
	public string ModulePath => "jobmodule";

	/// <summary>
	/// Gets the current status of this module.
	/// </summary>
	public EModuleStatus ModuleStatus { get; set; } = EModuleStatus.NotLoaded;

	/// <summary>
	/// Gets the list of available jobs.
	/// </summary>
	public IList<Job> JobsList { get; private set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="JobModule"/> class.
	/// </summary>
	public JobModule()
	{
		// Check if the "systems" directory exists, if not, create it.
		if ( !IModule.Path.DirectoryExists( $"{IModule.DirectoryPath}/{ModulePath}" ) )
		{
			IModule.Path.CreateDirectory( $"{IModule.DirectoryPath}/{ModulePath}" );

			if ( Consts.Debug )
				Log.Info( $"[{ModuleName} - v{ModuleVersion}] folder {IModule.DirectoryPath}/{ModulePath} created." );
		}

		JobsList = new List<Job>();

		// Discover and instantiate all job types in the TypeLibrary.
		foreach ( var type in TypeLibrary.GetTypes().Where( x => x.IsClass && !x.IsAbstract ) )
		{
			var baseType = type.TargetType.BaseType;
			var targetType = type.TargetType;

			if ( baseType is not null && baseType == typeof( Job ) )
			{
				Job job = TypeLibrary.Create<Job>( targetType );
				JobsList.Add( job );
			}
		}
	}

	/// <summary>
	/// Saves the list of jobs to a JSON file.
	/// </summary>
	public void Save()
	{
		if ( Consts.Debug )
			Log.Info( $"[{ModuleName} - v{ModuleVersion}] jobs.json file saved." );

		IModule.Path.WriteAllText( $"{IModule.DirectoryPath}/{ModulePath}/jobs.json", JsonUtility.Serialize( JobsList ) );
	}

	/// <summary>
	/// Loads the module, initializing any necessary resources or dependencies.
	/// </summary>
	public async Task Load()
	{
		if ( Consts.Debug )
			Log.Info( $"[{ModuleName} - v{ModuleVersion}] loading.." );

		await Task.Delay( 1000 );

		if ( Consts.Debug )
			Log.Info( $"[{ModuleName} - v{ModuleVersion}] loaded succesfully." );
	}

	/// <summary>
	/// Stops the module, releasing any resources or dependencies.
	/// </summary>
	public async Task Stop()
	{
		if ( Consts.Debug )
			Log.Info( $"[{ModuleName} - v{ModuleVersion}] stopping.." );

		await Task.Delay( 1000 );

		if ( Consts.Debug )
			Log.Info( $"[{ModuleName} - v{ModuleVersion}] stopped succesfully." );
	}

	/// <summary>
	/// Reloads the module, typically by calling <see cref="Stop"/> followed by <see cref="Load"/>.
	/// </summary>
	public async Task Reload()
	{
		if( Consts.Debug)
			Log.Info( $"[{ModuleName} - v{ModuleVersion}] reloading.." );

		await Stop();
		await Load();

		if ( Consts.Debug )
			Log.Info( $"[{ModuleName} - v{ModuleVersion}] reloaded succesfully." );
	}
}
