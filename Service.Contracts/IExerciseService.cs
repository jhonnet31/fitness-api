using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IExerciseService
    {
        IEnumerable<ExerciseDto> GetAllExercises(bool trackChanges);
        ExerciseDto GetExercise(int id, bool trackChanges);
        ExerciseDto AddExercise(ExerciseForCreationDto exercise);
        void DeleteExercise(int muscularGroupId, int id, bool trackchanges);
    }
}
