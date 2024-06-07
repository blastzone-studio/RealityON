using Blastzone.RealityOn.API.Bases;
using Blastzone.RealityOn.API.Interfaces;
using Blastzone.RealityOn.Core.Modules.Job;
using Blastzone.RealityOn.Core.Systems;
using System.Reflection;

namespace Blastzone.RealityOn.Core.Modules;


/// <summary>
/// This class is will iniate all the required systems so it's very important and required one in the scene.
/// </summary>
public sealed class ModuleManager : RealityComponent
{
	public static ModuleManager Instance { get; private set; }
	
	[Property] private IList<IModule> _modules;

	/// <summary>
	/// Initializes a new instance of the <see cref="ModuleManager"/> class.
	/// </summary>
	public ModuleManager()
	{
		Instance = this;

		// Check if the "systems" directory exists, if not, create it.
		if ( !IModule.Path.DirectoryExists( IModule.DirectoryPath ) )
		{
			IModule.Path.CreateDirectory( IModule.DirectoryPath );

			if ( Consts.Debug )
				Log.Info( $"[{Consts.GameName}] ModuleManager: directory {IModule.DirectoryPath} created." );
		}

		_modules = new List<IModule>();

		var types = TypeLibrary.GetTypes().Where( x => x.IsClass && !x.IsAbstract && x.GetAttribute<ModuleAttribute>() != null );

		// Discover and instantiate all job types in the TypeLibrary.
		foreach ( var type in types )
		{
			Log.Info( type );

			var targetType = type.TargetType;

			var module = TypeLibrary.Create<IModule>( targetType );
			module.ModuleStatus = API.Enums.EModuleStatus.Loading;
			module.Load();

			_modules.Add( module );
		}
		
		// Validate modules at application startup
		ModuleValidator.ValidateModules();
	}

	/// <summary>
	/// Adds a module to the manager.
	/// </summary>
	/// <param name="module">The module to add.</param>
	public void AddModule( IModule module )
	{
		_modules.Add( module );

		if( Consts.Debug )
			Log.Info( $"[{Consts.GameName}] ModuleManager: new module loaded {module.ModuleName}." );
	}

	/// <summary>
	/// Stops all modules.
	/// </summary>
	public void StopModules()
	{
		foreach ( var module in _modules )
		{
			module.Stop();
		}
	}

	/// <summary>
	/// Reloads all modules.
	/// </summary>
	public void ReloadModules()
	{
		foreach ( var module in _modules )
		{
			module.Reload();
		}
	}

	/// <summary>
	/// Gets the loaded modules.
	/// </summary>
	public static IEnumerable<IModule> Modules => Instance._modules.AsReadOnly();
}
