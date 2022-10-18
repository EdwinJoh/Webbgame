using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ICharacterRepository> _characterRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _characterRepository = new Lazy<ICharacterRepository>(() => new
            CharacterRepository(repositoryContext));

        }
        public ICharacterRepository Character => _characterRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

    }
}
