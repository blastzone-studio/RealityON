using Blastzone.RealityOn.API.Bases;
using Blastzone.RealityOn.Core.Systems;

namespace Blastzone.RealityOn.Core;


/// <summary>
/// This class is will iniate all the required systems so it's very important and required one in the scene.
/// </summary>
public sealed class Manager : RealityComponent
{

	public Manager()
	{
		_ = new JobSystem();
	}
}
