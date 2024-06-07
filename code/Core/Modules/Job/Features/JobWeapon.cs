using Blastzone.RealityOn.Core.Modules.Job;

namespace Blastzone.RealityOn.Core.Modules.Job.Features;

/// <summary>
/// Allow this job certains weapons.
/// </summary>
public class JobWeapon : IJobFeatureBase
{
	public string Id => nameof( JobWeapon );
	public string Name => "#weapons";
}
