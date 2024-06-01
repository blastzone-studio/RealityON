namespace Blastzone.RealityOn.API.Bases.UI;

public abstract class BaseTab : Panel
{
	public static BaseTab Instance { get; set; }

	protected BaseTab()
	{
		Instance = this;
	}
}
