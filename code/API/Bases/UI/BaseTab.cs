namespace Blastzone.RealityOn.API.Bases.UI;

/// <summary>
/// Represents the base class for tab panels within the HUD.
/// </summary>
[StyleSheet]
public abstract class BaseTab : RealityPanel
{
	/// <summary>
	/// Gets the instance of the current <see cref="BaseTab"/>.
	/// </summary>
	public static BaseTab Instance { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="BaseTab"/> class.
	/// </summary>
	protected BaseTab()
	{
		Instance = this;
		Log.Info( "new instance" );
		AddClass( "basetab" );
	}

	public void Show()
	{
		SetClass( "show", true );
	}
}
