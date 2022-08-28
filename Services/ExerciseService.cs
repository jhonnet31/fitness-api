using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ExerciseService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
         }
        public ExerciseDto AddExercise(ExerciseForCreationDto exercise) {

            var exerciseEntity = _mapper.Map<Exercise>(exercise);
            _repositoryManager.exercise.CreateExercise(exerciseEntity);
            _repositoryManager.Save();
            var exerciseCreated=_mapper.Map<ExerciseDto>(exerciseEntity);
            return exerciseCreated;

        }


        public IEnumerable<ExerciseDto> GetAllExercises(bool trackChanges) { 
          var exercises= _repositoryManager.exercise.GetAllExercises(trackChanges);
            var exercisesDto = _mapper.Map<IEnumerable<ExerciseDto>>(exercises);
            return exercisesDto;
        }

        public ExerciseDto GetExercise(int id, bool trackChanges)
        {
            var exercise=_repositoryManager.exercise.GetExercise(id, trackChanges);
            if (exercise is null)
                throw new ExerciseNotFound(id);

            var exerciseDto=_mapper.Map<ExerciseDto>(exercise);
            return exerciseDto;
        }
    }
}
