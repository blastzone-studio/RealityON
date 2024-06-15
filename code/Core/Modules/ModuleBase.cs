using Blastzone.RealityOn.API.Enums;

namespace Blastzone.RealityOn.Core.Modules;

public abstract class ModuleBase : IModule
{
	public virtual string ModuleName => "Unnamed module";

	public virtual float ModuleVersion => .0f;

	public virtual string ModulePath => "notdefined";

	public EModuleStatus ModuleStatus { get; set; }

	public virtual async Task Load()
	{
		ModuleStatus = EModuleStatus.Loading;

		await Task.Delay( 500 );

		ModuleStatus = EModuleStatus.Running;

		await Task.CompletedTask;
	}

	public virtual async Task Reload()
	{
		ModuleStatus = EModuleStatus.Reloading;

		await Task.CompletedTask;
	}

	public virtual async Task Stop()
	{
		ModuleStatus = EModuleStatus.Stopped;

		await Task.CompletedTask;
	}

	public virtual void Update()
	{
	}

	public void SetError(string reason = "")
	{
		ModuleStatus = EModuleStatus.Error;
		Log.Error( $"[{Consts.GameName}] {ModuleName}: an error occured (reason: {(reason != "" ? reason : "N/A")})." );
	}
}
