namespace Blastzone.RealityOn.API.Bases.Job.Features;

/// <summary>
/// Allowing hierarchy to being builded (grades).
/// </summary>
public class JobHierarchy : IJobFeatureBase
{
	public string Id => nameof( JobHierarchy );
	public string Name => "#hierarchy";

	public IList<JobGrade> Grades => new List<JobGrade>();

	public class JobGrade
	{
		/// <summary>
		/// Gets or sets the name of the grade.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the rank of the grade.
		/// Higher values indicate higher ranks.
		/// </summary>
		public int Rank { get; set; }

		/// <summary>
		/// Gets or sets the minimum salary associated with this grade.
		/// </summary>
		public float MinSalary { get; set; }

		/// <summary>
		/// Gets or sets the maximum salary associated with this grade.
		/// </summary>
		public float MaxSalary { get; set; }

		public JobGrade() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="JobGrade"/> class.
		/// </summary>
		/// <param name="name">The name of the grade.</param>
		/// <param name="rank">The rank of the grade.</param>
		/// <param name="minSalary">The minimum salary associated with the grade.</param>
		/// <param name="maxSalary">The maximum salary associated with the grade.</param>
		public JobGrade( string name, int rank, float minSalary, float maxSalary )
		{
			Name = name;
			Rank = rank;
			MinSalary = minSalary;
			MaxSalary = maxSalary;
		}
	}
}
