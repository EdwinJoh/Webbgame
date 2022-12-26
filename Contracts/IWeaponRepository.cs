using Entities.Models;

namespace Contracts;

public interface IWeaponRepository
{
    Task<Weapon> GetWeapon(string name, bool trackChanges);
    Task<IEnumerable<Weapon>> GetAllWeapons(bool trackChanges);
    void CreateWeapon(Weapon weapon);
}