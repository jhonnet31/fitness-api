using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ExerciseNotFound:NotFoundException
    {
        public ExerciseNotFound(int id):base($"The Exercise with id {id} doesn't exits in the database.")
        {

        }
    }
}
