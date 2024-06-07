using Blastzone.RealityOn.API.Bases.Players;

namespace Blastzone.RealityOn.API.Bases.Resources;

[Title( "[Resource] Medkit" )]
public sealed class Medkit : ResourceBase
{
	public Medkit()
	{

	}

	public override void OnPickedUp( Player player )
	{
		base.OnPickedUp( player );
	}

	protected override void OnUsed()
	{
		base.OnUsed();
	}
}
