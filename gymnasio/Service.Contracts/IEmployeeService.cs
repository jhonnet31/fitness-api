using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(int companyId,bool trackChanges);
        EmployeeDto GetEmployee(int companyId,int Id, bool trackChanges);
    }
}
