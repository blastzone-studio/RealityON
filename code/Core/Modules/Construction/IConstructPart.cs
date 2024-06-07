
using Blastzone.RealityOn.Core.Systems.Construction.Parts;

namespace Blastzone.RealityOn.Core.Systems.Construction;

public interface IConstructPart
{
	ConstructType ConstructType { get; }
	string Model { get; }
}
