namespace Blastzone.RealityOn.Core.Modules;

/// <summary>
/// Validates that all classes marked with ModuleAttribute implement IModule.
/// </summary>
public static class ModuleValidator
{
	/// <summary>
	/// Validates modules in the current AppDomain.
	/// </summary>
	public static void ValidateModules(IEnumerable<TypeDescription> modules)
	{
		foreach ( var type in modules )
		{
			if ( !typeof( IModule ).IsAssignableFrom( type.GetType() ) )
			{
				throw new InvalidOperationException( $"({type}){type.Name} is marked with ModuleAttribute but does not implement IModule." );
			}
		}
	}
}
