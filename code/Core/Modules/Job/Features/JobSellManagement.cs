using Blastzone.RealityOn.API.Bases.Resources;
using Blastzone.RealityOn.Core.Modules.Job;

namespace Blastzone.RealityOn.Core.Modules.Job.Features;

/// <summary>
/// Allowing the job to be able to sell.
/// </summary>
public class JobSellManagement : IJobFeatureBase
{
	public string Id => nameof( JobSellManagement );
	public string Name => "#sellmanagement";

	/// <summary>
	/// The resources that the job will be able to sell.
	/// </summary>
	public IList<ResourceBase> Resources { get; } = new List<ResourceBase>();

	public JobSellManagement() { }

	public JobSellManagement( IList<ResourceBase> resources ) : base()
	{
		Resources = resources;
	}
}
