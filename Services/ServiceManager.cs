using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Services
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<IExerciseService> _exerciseService;
        private readonly Lazy<IMuscularGroupService> _muscularService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _muscularService = new Lazy<IMuscularGroupService>(() => new MuscularGroupService(repositoryManager,logger,mapper));
            _exerciseService= new Lazy<IExerciseService> (()=> new ExerciseService(repositoryManager,logger,mapper));
        }

        public IMuscularGroupService MuscularGroupService => _muscularService.Value;
        public IExerciseService ExerciseService => _exerciseService.Value;
    }
}