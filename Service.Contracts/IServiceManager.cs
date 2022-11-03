namespace Service.Contracts;

public interface IServiceManager
{
    IAuthenticationService AuthenticationService { get; }
    ICharacterService CharacterService { get; }
    IMissionService MissionService { get; }
    IWeaponService WeaponService { get; }

}
