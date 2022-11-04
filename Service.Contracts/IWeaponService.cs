using SharedHelpers.DTO.CharacterDtos.Weapons;

namespace Service.Contracts;

public interface IWeaponService
{
    Task<WeaponDto> GetWeaponAsync(string name, bool trackChanges);
    Task<WeaponDto> CreateWeponAsync(WeaponForCreation weapon,bool trackChanges);
    Task<IEnumerable<WeaponDto>> GetAllWeaponsAsync(bool trackChanges);
}

