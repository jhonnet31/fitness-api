
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto GetCompany(int id, bool trackChanges);
        CompanyDto CreateCompany(CompanyForCreationDto company);
    }
}