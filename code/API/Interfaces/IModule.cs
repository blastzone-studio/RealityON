using Blastzone.RealityOn.API.Enums;

namespace Blastzone.RealityOn.API.Interfaces;

/// <summary>
/// Represents a module.
/// </summary>
public interface IModule
{
	/// <summary>
	/// Gets the name of this module.
	/// </summary>
	string ModuleName { get; }

	/// <summary>
	/// Gets the version of this module.
	/// </summary>
	float ModuleVersion { get; }

	/// <summary>
	/// Gets the path of this module.
	/// </summary>
	string ModulePath { get; }

	/// <summary>
	/// Gets the current status of this module.
	/// </summary>
	EModuleStatus ModuleStatus { get; set; }

	public static BaseFileSystem Path => FileSystem.Data;
	public static string DirectoryPath => "modules";

	/// <summary>
	/// Loads the module, initializing any necessary resources or dependencies.
	/// </summary>
	Task Load();

	/// <summary>
	/// Stops the module, releasing any resources or dependencies.
	/// </summary>
	Task Stop();

	/// <summary>
	/// Reloads the module, typically by calling <see cref="Stop"/> followed by <see cref="Load"/>.
	/// </summary>
	Task Reload();
}
