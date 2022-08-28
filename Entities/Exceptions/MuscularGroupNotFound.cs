using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class MuscularGroupNotFound:NotFoundException
    {
        public MuscularGroupNotFound(int id) : base($"the muscular group with id {id } doesn't exist in the database.")
        {

        }
    }
}
