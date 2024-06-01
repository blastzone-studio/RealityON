
using System.Text.Json;

namespace Blastzone.RealityOn.API.Utility;

public static class JsonUtility
{
	public static string Serialize<T>( T content ) => JsonSerializer.Serialize( content, new JsonSerializerOptions() { WriteIndented = true } );
}
