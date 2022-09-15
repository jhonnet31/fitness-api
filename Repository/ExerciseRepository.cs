using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateExercise(Exercise exercise) => Create(exercise);

        public void DeleteExercise(Exercise exercise) => Delete(exercise);

        public IEnumerable<Exercise> GetAllExercises(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(x => x.Name).ToList();

        public Exercise GetExercise(int id, bool trackChanges) =>
            FindByCondition(x => x.Id.Equals(id), trackChanges).SingleOrDefault();



    }
}