using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using SharedHelpers.DTO.CharacterDtos.Weapons;

namespace Service;

internal sealed class WeaponSevice : IWeaponService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public WeaponSevice(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<WeaponDto> CreateWeponAsync(WeaponForCreation weaponForCreation, bool trackChanges)
    {
        var weaponEntity = _mapper.Map<Weapon>(weaponForCreation);

        _repository.Weapon.CreateWeapon(weaponEntity);
        await _repository.SaveAsync();

        var weaponToReturn = _mapper.Map<WeaponDto>(weaponEntity);
        return weaponToReturn;
    }

    public async Task<WeaponDto> GetWeaponAsync(string name, bool trackChanges)
    {
        await CheckIfWeaponExistByName(name, trackChanges);
        var weapon = await _repository.Weapon.GetWeapon(name, trackChanges);
        var weaponDto = _mapper.Map<WeaponDto>(weapon);

        return weaponDto;
    }

    public async Task<IEnumerable<WeaponDto>> GetAllWeaponsAsync(bool trackChanges)
    {
        var weapons = await _repository.Weapon.GetAllWeapons(trackChanges);
        var weaponDto = _mapper.Map<IEnumerable<WeaponDto>>(weapons);
        return weaponDto;
    }

    private async Task CheckIfWeaponExistByName(string name, bool trackChanges)
    {
        var weapon = await _repository.Weapon.GetWeapon(name, trackChanges);
        if (weapon == null)
            throw new WeaponNotFound(name);
    }
}