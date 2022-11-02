using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IWeaponRepository
    {
        Task<Weapon> GetWeapon(string name,bool trackChanges);
    }
}
