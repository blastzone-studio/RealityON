namespace Blastzone.RealityOn.Core.Modules;

/// <summary>
/// Specifies that a class is a module of the realityon.
/// </summary>
[AttributeUsage( AttributeTargets.Class, Inherited = false )]
public class ModuleAttribute : Attribute
{
	public bool CanBeReloaded { get; set; }
	
	public ModuleAttribute() {}
	public ModuleAttribute(bool canBeReloaded = true) 
	{
		CanBeReloaded = canBeReloaded;
	}
}
