namespace Blastzone.RealityOn.API.Bases.UI;

public abstract class BaseHud : Panel
{
	public static BaseHud Instance { get; set; }

	protected BaseHud()
	{
		Instance = this;
	}
}
