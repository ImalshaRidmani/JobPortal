using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories;

namespace JobPortalAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<string> CreateCompany(
            CompanyDto request,
            int employerId)
        {
            var existing =
                _companyRepository.GetCompanyByEmployerId(employerId);

            if (existing != null)
                return "Company already exists";

            var company = new Company
            {
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                Website = request.Website,
                EmployerId = employerId
            };

            _companyRepository.AddCompany(company);

            await _companyRepository.SaveChangesAsync();

            return "Company created successfully";
        }

        public Company? GetMyCompany(int employerId)
        {
            return _companyRepository.GetCompanyByEmployerId(employerId);
        }

        public async Task<string> UpdateCompany(
        CompanyDto request,
        int employerId)
        {
            var company =
                _companyRepository.GetCompanyByEmployerId(employerId);

            if (company == null)
                return "Company not found";

            company.Name = request.Name;
            company.Description = request.Description;
            company.Location = request.Location;
            company.Website = request.Website;

            _companyRepository.UpdateCompany(company);

            await _companyRepository.SaveChangesAsync();

            return "Company updated successfully";
        }
    }
}
