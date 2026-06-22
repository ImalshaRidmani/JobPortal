using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public interface ICompanyRepository
    {
        Company? GetCompanyByEmployerId(int employerId);

        void AddCompany(Company company);

        Task SaveChangesAsync();
    }
}
