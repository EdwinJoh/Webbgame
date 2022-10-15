using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICharacterService> _characterService;
        public readonly IMapper _mapper;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager
        logger, IMapper mapper,UserManager<User> userManager,IConfiguration configuration)
        {
            _characterService = new Lazy<ICharacterService>(() => new
            CharacterService(repositoryManager, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(logger, mapper, userManager,configuration));
        }
        public ICharacterService CharacterService => _characterService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;


    }
}
