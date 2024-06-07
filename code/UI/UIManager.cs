using Blastzone.RealityOn.API.Bases;
using Blastzone.RealityOn.API.Interfaces;
using Blastzone.RealityOn.UI.Layout.PlayerView;

namespace Blastzone.RealityOn.UI;

public class UIManager : RealityComponent, IRootView
{
	/// <summary>
	/// Current instanciated class of UIManager.
	/// </summary>
	public static UIManager Instance { get; private set; }

	private IRootView _rootView;

	/// <summary>
	/// Current active RootView or null.
	/// </summary>
	public IRootView RootView
	{
		get => _rootView;
		set
		{
			if( _rootView == value ) return;

			var panel = _rootView as Panel;
			if ( panel != null )
				panel.Delete();

			if( value is Panel panelref)
			{
				var screenpanel = GetRootPanel();

				if ( screenpanel != null )
				{
					screenpanel.AddChild( panelref );
					_rootView = value;
				}
				else
				{
					if ( Consts.Debug )
						Log.Error( $"[{Consts.GameName}] An error occured when trying to set a rootview, there is none ScreenPanel found in the current scene !" );
				}
				
			}
		}
	}

	public UIManager()
	{
		Instance = this;
	}

	protected override void OnStart()
	{
		if( Menu )
		{
			Log.Info( Menu );
			RootView = (IRootView)CreatePanelFromRef( Consts.Launcher );
		}
		else
		{
			RootView = new PlayerHudContainer();
		}
	}

	/// <summary>
	/// Used as multipurpose
	/// If true, logic for gamemenu will be implemented at the startup.
	/// If false, logic for game will be implemented at the startup.
	/// </summary>
	[Property]
	public bool Menu { get; set; }

	/// <summary>
	/// Returns a Panel instance created from a Type (.razor file classname)
	/// </summary>
	/// <param name="typeref">The panel instance from ref.</param>
	public static Panel CreatePanelFromRef( Type typeref ) => TypeLibrary.Create<Panel>( typeref );

	/// <summary>
	/// Retrieves the active ScreenPanel in the current scene.
	/// </summary>
	public static Panel GetRootPanel() => Game.ActiveScene.Components.Get<ScreenPanel>( FindMode.EverythingInChildren ).GetPanel();
}
