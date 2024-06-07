using Blastzone.RealityOn.API.Bases.UI;
using Blastzone.RealityOn.API.Bases.UI.Defaults;
using Blastzone.RealityOn.API.Interfaces;
using System;

namespace Blastzone.RealityOn.UI.Layout.PlayerView;

/// <summary>
/// Represents the main container for the player's HUD (Heads-Up Display).
/// </summary>
[StyleSheet]
public class PlayerHudContainer : Panel, IRootView
{
	/// <summary>
	/// Initializes a new instance of the <see cref="PlayerHudContainer"/> class.
	/// </summary>
	public PlayerHudContainer()
	{
		// Lists to hold type descriptions for different HUD components
		IList<TypeDescription> chatCounts = new List<TypeDescription>();
		IList<TypeDescription> hudCounts = new List<TypeDescription>();
		IList<TypeDescription> tabCounts = new List<TypeDescription>();

		/*
		 * Checkup for all custom addons / libraries for UI.
		*/
		foreach ( var type in TypeLibrary.GetTypes().Where( x => x.IsClass && !x.IsAbstract && x.TargetType.BaseType != null ))
		{
			var baseType = type.TargetType.BaseType;

			if ( baseType.BaseType == typeof( RealityPanel ) )
			{
				if( baseType == typeof( BaseChat ))
					chatCounts.Add( type );
				else if( baseType == typeof( BaseHud ))
					hudCounts.Add( type );
				else if ( baseType == typeof( BaseTab ) )
					tabCounts.Add( type );
			}
		}

		#region CHAT
		/*
		 * Add appropriate chat ui libraries
		 * First it will checkup if there is an extern addon / script that implements BaseChat
		 * If so it will make sure to not instanciate the default Chat.
		*/
		if ( chatCounts.Count > 1 )
		{
			foreach ( var chat in chatCounts )
			{
				if ( chat.TargetType == typeof( DefaultChat ) )
					continue;
				AddChild( TypeLibrary.Create<Panel>( chat.TargetType ) );

				if ( Consts.Debug )
					Log.Info( $"[{Consts.GameName}] PlayerHudContainer: Custom chat ui library created {chat}." );
			}
		}
		else
		{
			if ( Consts.Debug )
				Log.Info( $"[{Consts.GameName}] PlayerHudContainer: No custom chat ui library found so the default is being used." );

			AddChild( new DefaultChat() );
		}
		#endregion

		#region HUD
		/*
		 * Add appropriate hud ui libraries
		 * First it will checkup if there is an extern addon / script that implements BaseHud
		 * If so it will make sure to not instanciate the default Hud.
		*/
		if ( hudCounts.Count > 1 )
		{
			foreach ( var hud in hudCounts )
			{
				if ( hud.TargetType == typeof( DefaultHud ) )
					continue;
				AddChild( TypeLibrary.Create<Panel>( hud.TargetType ) );

				if ( Consts.Debug )
					Log.Info( $"[{Consts.GameName}] PlayerHudContainer: Custom hud ui library created {hud}." );
			}
		}
		else
		{
			if ( Consts.Debug )
				Log.Info( $"[{Consts.GameName}] PlayerHudContainer: No custom hud ui library found so the default is being used." );

			AddChild( new DefaultHud() );
		}
			
		#endregion

		#region TAB
		/*
		 * Add appropriate tab ui libraries
		 * First it will checkup if there is an extern addon / script that implements BaseTab
		 * If so it will make sure to not instanciate the default Tab.
		*/
		if ( tabCounts.Count > 1 )
		{
			foreach ( var tab in tabCounts )
			{
				if ( tab.TargetType == typeof( DefaultTab ) )
					continue;
				AddChild( TypeLibrary.Create<Panel>( tab.TargetType ) );

				if ( Consts.Debug )
					Log.Info( $"[{Consts.GameName}] PlayerHudContainer: Custom tab ui library created {tab}." );
			}
		}
		else
		{
			if ( Consts.Debug )
				Log.Info( $"[{Consts.GameName}] PlayerHudContainer: No custom tab ui library found so the default is being used." );
			AddChild( new DefaultTab() );
		}
		#endregion
	}
}
