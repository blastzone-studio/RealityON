namespace Blastzone.RealityOn.API.Interfaces;

/// <summary>
/// Interface representing a weapon.
/// </summary>
public interface IWeapon
{
	/// <summary>
	/// Gets or sets the name of the weapon.
	/// </summary>
	string Name { get; set; }

	/// <summary>
	/// Gets or sets the damage dealt by the weapon.
	/// </summary>
	int Damage { get; set; }

	/// <summary>
	/// Gets or sets the range of the weapon.
	/// </summary>
	float Range { get; set; }

	/// <summary>
	/// Attacks a target.
	/// </summary>
	void Attack();

	/// <summary>
	/// Reloads the weapon.
	/// </summary>
	void Reload();
}
