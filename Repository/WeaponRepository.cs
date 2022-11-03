using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class WeaponRepository : RepositoryBase<Weapon>, IWeaponRepository
{
	public WeaponRepository(RepositoryContext context) : base(context)
	{

	}
	public async Task<Weapon> GetWeapon(string name, bool trackChanges) =>
		await FindByCondition(x => x.Name.Equals(name), trackChanges).FirstOrDefaultAsync();

	public async Task<IEnumerable<Weapon>> GetAllWeapons(bool trackChanges) =>
		await FindAll(trackChanges).ToListAsync();

	public void CreateWeapon(Weapon weapon) => Create(weapon);
}
