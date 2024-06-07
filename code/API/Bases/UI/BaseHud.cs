namespace Blastzone.RealityOn.API.Bases.UI;

[StyleSheet]
public abstract class BaseHud : RealityPanel
{
	public static BaseHud Instance { get; set; }

	protected BaseHud()
	{
		Instance = this;
	}
}
