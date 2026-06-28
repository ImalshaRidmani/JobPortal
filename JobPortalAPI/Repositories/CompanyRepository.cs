using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public Company? GetCompanyByEmployerId(int employerId)
        {
            return _context.Companies
                .FirstOrDefault(c => c.EmployerId == employerId);
        }

        public void AddCompany(Company company)
        {
            _context.Companies.Add(company);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
        }

        public List<CompanyJobDto> GetCompanyJobs(int companyId)
        {
            return _context.Jobs
                .Where(j => j.CompanyId == companyId)
                .Select(j => new CompanyJobDto
                {
                    Id = j.Id,
                    Title = j.Title,
                    Location = j.Location,
                    Salary = j.Salary
                })
                .ToList();
        }
    }
}
