namespace Service.Contracts;

public interface IServiceManager
{
    IAuthService AuthenticationService { get; }
    ICharacterService CharacterService { get; }
    IMissionService MissionService { get; }

}
