namespace Blastzone.RealityOn.API.Bases.UI;

/// <summary>
/// Abstract base class for the player hud in game.
/// This class provides basic functionalities and can be extended for custom behaviors.
/// </summary>
[StyleSheet]
public abstract class BaseHud : RealityPanel
{
	/// <summary>
	/// Gets the instance of the current <see cref="BaseHud"/>.
	/// </summary>
	public static BaseHud Instance { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="BaseTab"/> class.
	/// </summary>
	protected BaseHud()
	{
		Instance = this;
	}
}
