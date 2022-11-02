using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class WeaponRepository:RepositoryBase<Weapon>,IWeaponRepository
{
	public WeaponRepository(RepositoryContext context) : base(context)
	{

	}
	public async Task<Weapon> GetWeapon(string name, bool trackChanges) =>
		await FindByCondition(x => x.Name.Equals(name),trackChanges).FirstOrDefaultAsync();
}
