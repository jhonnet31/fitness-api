using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class MuscularGroupCollectionBadRequest:BadRequestException
    {
        public MuscularGroupCollectionBadRequest():base("Muscular Group collection cannot be null")
        {

        }
    }
}
