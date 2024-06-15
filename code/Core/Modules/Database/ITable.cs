namespace Blastzone.RealityOn.Core.Modules.Database;

/// <summary>
/// Represents a table in the database.
/// </summary>
public interface ITable
{
	/// <summary>
	/// Gets the name of the table.
	/// </summary>
	string Name { get; }

	/// <summary>
	/// Gets the controller endpoint for the table.
	/// </summary>
	string Controller { get; }

	/// <summary>
	/// Loads the data from the controller.
	/// </summary>
	Task Load();

	/// <summary>
	/// Saves the data to the controller.
	/// </summary>
	Task Save();

	/// <summary>
	/// Inserts a new record into the table.
	/// </summary>
	/// <typeparam name="T">The type of the record to insert.</typeparam>
	/// <param name="value">The record to insert.</param>
	Task Insert<T>( T value );

	/// <summary>
	/// Updates an existing record in the table.
	/// </summary>
	/// <typeparam name="T">The type of the record to update.</typeparam>
	/// <param name="value">The record to update.</param>
	/// <returns>True if the update was successful, otherwise false.</returns>
	Task<bool> Update<T>( T value );

	/// <summary>
	/// Get a record from the table.
	/// </summary>
	/// <typeparam name="T">The type of the record to get.</typeparam>
	/// <param name="value">The record to get.</param>
	Task Get<T>( T value );

	public static string BaseUrl => "https://realityon.blastzone.studio/api/v1/";
}
