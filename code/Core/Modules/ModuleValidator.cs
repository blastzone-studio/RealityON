using Blastzone.RealityOn.API.Interfaces;

namespace Blastzone.RealityOn.Core.Modules;

/// <summary>
/// Validates that all classes marked with ModuleAttribute implement IModule.
/// </summary>
public static class ModuleValidator
{
	/// <summary>
	/// Validates modules in the current AppDomain.
	/// </summary>
	public static void ValidateModules()
	{
		var types = TypeLibrary.GetTypes().Where( x => x.IsInterface && !x.IsAbstract && x.GetAttribute<ModuleAttribute>() != null);

		foreach ( var type in types )
		{
			if ( !typeof( IModule ).IsAssignableFrom( type.GetType() ) )
			{
				throw new InvalidOperationException( $"{type.Name} is marked with ModuleAttribute but does not implement IModule." );
			}
		}
	}
}
