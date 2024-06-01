namespace Blastzone.RealityOn.API.Bases.Job;

/// <summary>
/// Interface allowing implementation of a job feature
/// </summary>
public interface IJobFeatureBase
{
	/// <summary>
	/// Unique identifier of this feature. (Required)
	/// </summary>
	string Id { get; }

	/// <summary>
	/// Name of the feature.
	/// </summary>
	string Name { get; }
}
