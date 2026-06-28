using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public interface ICompanyRepository
    {
        Company? GetCompanyByEmployerId(int employerId);

        void AddCompany(Company company);

        Task SaveChangesAsync();

        void UpdateCompany(Company company);

        List<CompanyJobDto> GetCompanyJobs(int companyId);
    }
}
