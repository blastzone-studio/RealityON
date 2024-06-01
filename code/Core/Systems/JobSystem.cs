using Blastzone.RealityOn.API.Bases.Job;
using Blastzone.RealityOn.API.Interfaces;

namespace Blastzone.RealityOn.Core.Systems;

public sealed class JobSystem : ISystemVersion
{
	public float Version => 0.1f;

	public IList<Job> JobsList { get; private set; }

	public JobSystem()
	{
		if ( !FileSystem.Data.DirectoryExists( "systems/jobs" ) )
		{
			FileSystem.Data.CreateDirectory( "systems/jobs" );

			if ( Consts.Debug )
				Log.Info( $"[{Consts.GameName}] JobSystem: directory systems/jobs created." );
		}
		
		JobsList = new List<Job>();

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
}
