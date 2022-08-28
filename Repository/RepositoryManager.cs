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
        private RepositoryContext _context;
        private readonly Lazy<IExerciseRepository> _exerciseRepository;
        private readonly Lazy<IMuscularGroupRepository> _muscularGroupRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            _exerciseRepository = new Lazy<IExerciseRepository>(() => new ExerciseRepository(_context));
            _muscularGroupRepository = new Lazy<IMuscularGroupRepository>(() => new MuscularGroupRepository(_context));
        }

        public IMuscularGroupRepository muscularGroup => _muscularGroupRepository.Value;

        public IExerciseRepository exercise => _exerciseRepository.Value;

        public void Save()=>_context.SaveChanges();
    }
}
