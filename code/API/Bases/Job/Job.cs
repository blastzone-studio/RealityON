namespace Blastzone.RealityOn.API.Bases.Job;

/// <summary>
/// Definition of a job.
/// </summary>
public class Job
{
	public IList<IJobFeatureBase> Features { get; private set; }

	public IJobFeatureBase GetFeature(string name)
	{
		return Features.SingleOrDefault(x=> x.Name == name) ?? null;
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
