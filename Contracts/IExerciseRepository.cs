using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IExerciseRepository
    {
        void CreateExercise(Exercise exercise);
        IEnumerable<Exercise> GetAllExercises(bool trackChanges);
        Exercise GetExercise(int id, bool trackChanges);
        void DeleteExercise(Exercise exercise);
    }
}
