using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repository) : base(repository)
        {

        }

        public IEnumerable<Employee> GetEmployees(int companyId, bool trackChanges) =>
            FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                .OrderBy(e => e.Name).ToList();

        public Employee GetEmployee(int companyId,int id, bool trackChanges) =>
            FindByCondition(e => e.Id.Equals(id) && e.CompanyId.Equals(companyId),trackChanges)
            .SingleOrDefault();
    }
}
