namespace Blastzone.RealityOn.API.Enums;


/// <summary>
/// Represents the status of a module.
/// </summary>
public enum EModuleStatus
{
	/// <summary>
	/// The module is not loaded yet.
	/// </summary>
	NotLoaded = 0,

	/// <summary>
	/// The module is currently being loaded.
	/// </summary>
	Loading = 0,

	/// <summary>
	/// The module is currently running.
	/// </summary>
	Running,

	/// <summary>
	/// The module is in the process of reloading.
	/// </summary>
	Reloading,

	/// <summary>
	/// The module has been stopped.
	/// </summary>
	Stopped
}
