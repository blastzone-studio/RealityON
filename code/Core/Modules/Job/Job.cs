namespace Blastzone.RealityOn.Core.Modules.Job;

/// <summary>
/// Reprents the structure of a job.
/// </summary>
public class Job
{
	/// <summary>
	/// Is this job part of the government (police, etc...)
	/// </summary>
	public bool PartOfGovernment { get; private set; } = false;

	/// <summary>
	/// Features that this job can do / having.
	/// </summary>
	public IList<IJobFeatureBase> Features { get; private set; }

	public IJobFeatureBase GetFeature( string id )
	{
		return Features.SingleOrDefault( x => x.Id == id ) ?? null;
	}

	public IJobFeatureBase GetFeature<T>() where T : IJobFeatureBase
	{
		return Features.SingleOrDefault( x => x is T );
	}

	/// <summary>
	/// Add a feature to this job.
	/// </summary>
	public IJobFeatureBase AddFeature<T>() where T : IJobFeatureBase, new()
	{
		if ( Features == null )
			return null;

		T feature = new T();

		Features.Add( feature );

		return feature;
	}
}
