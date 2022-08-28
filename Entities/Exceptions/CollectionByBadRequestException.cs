using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CollectionByBadRequestException:BadRequestException
    {
        public CollectionByBadRequestException():base("Collection count mismatch to ids")
        {

        }
    }
}
