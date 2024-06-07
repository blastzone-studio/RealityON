using Blastzone.RealityOn.Core.Modules.Job;

namespace Blastzone.RealityOn.Core.Modules.Job.Features;

/// <summary>
/// Represents a salary feature for a job.
/// </summary>
public class JobSalary : IJobFeatureBase
{
	public string Id => nameof( JobSalary );
	public string Name => "#salary";

	public float MinSalary { get; set; }
	public float MaxSalary { get; set; }

	public JobSalary( float minSalary, float maxSalary )
	{
		MinSalary = minSalary;
		MaxSalary = maxSalary;
	}
}
