using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class WeaponNotFound : NotFoundException
{
	public WeaponNotFound(string id):base($"The weapon with name: {id} does not exist")
	{

	}
}
