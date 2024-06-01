using Mbk.RealityOn.UI.Layout.GameMenu;
using Mbk.RealityOn.UI.Layout.Launcher;

namespace Blastzone.RealityOn.Core;

public static class Consts
{
	public static string GameName => "RealityOn";

	/// <summary>
	/// Debug mode of the game
	/// It will print all methods, properties, etc... called
	/// </summary>
	public static bool Debug => true;

	/// <summary>
	/// Default main menu UI interface.
	/// </summary>
	public static Type GameMenu => typeof( DefaultGameMenu );

	/// <summary>
	/// Default UI interface launcher.
	/// </summary>
	public static Type Launcher => typeof( DefaultLauncher );

	/// <summary>
	/// Default campaign menu UI interface.
	/// </summary>
	//public static Type CampaignMenu => typeof( DefaultCampaignMenu );

	/// <summary>
	/// Default multiplayer menu UI interface.
	/// </summary>
	//public static Type MultiplayerMenu => typeof( DefaultMultiplayerMenu );

	/// <summary>
	/// Default zombie menu UI interface.
	/// </summary>
	//public static Type ZombieMenu => typeof( DefaultZombieMenu );
}
