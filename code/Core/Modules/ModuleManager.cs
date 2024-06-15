using Blastzone.RealityOn.API.Bases;
using Blastzone.RealityOn.API.Enums;
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

	/// <summary>
	/// The loaded modules list.
	/// </summary>
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

		// Validate modules at application startup
		//ModuleValidator.ValidateModules(types);

		// Discover and instantiate all modules types in the TypeLibrary.
		foreach ( var type in types )
		{
			Log.Info( type );

			var targetType = type.TargetType;

			var module = TypeLibrary.Create<IModule>( targetType );
			_modules.Add( module );
		}
	}

	protected override void OnEnabled()
	{
		foreach ( var module in _modules )
		{
			module.ModuleStatus = EModuleStatus.Loading;
			module.Load();
		}
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
			if( module.ModuleStatus != EModuleStatus.Stopped )
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

	protected override void OnUpdate()
	{
		foreach ( var module in _modules )
		{
			if ( module.ModuleStatus != EModuleStatus.Running )
				continue;

			module.Update();
		}
	}

	/// <summary>
	/// Gets if a module runs.
	/// </summary>
	public static bool IsModuleRunning( IModule module ) => Instance._modules.SingleOrDefault(x=> x == module).ModuleStatus == EModuleStatus.Running;

	/// <summary>
	/// Gets the loaded modules.
	/// </summary>
	public static IEnumerable<IModule> Modules => Instance._modules.AsReadOnly();
}
