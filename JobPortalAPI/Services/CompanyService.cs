using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories;

namespace JobPortalAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IWebHostEnvironment _env;

        public CompanyService(ICompanyRepository companyRepository, IWebHostEnvironment env)
        {
            _companyRepository = companyRepository;
            _env = env;
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

        public async Task<string> UploadLogo(int employerId, IFormFile file)
        {
            var company =
                _companyRepository.GetCompanyByEmployerId(employerId);

            if (company == null)
                return "Company not found";

            var extension =
                Path.GetExtension(file.FileName).ToLower();

            if (extension != ".jpg" &&
                extension != ".jpeg" &&
                extension != ".png")
            {
                return "Only JPG and PNG files allowed";
            }

            var fileName =
                Guid.NewGuid() + extension;

            var filePath =
                Path.Combine(
                    _env.WebRootPath,
                    "company-logos",
                    fileName);

            using var stream =
                new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);

            company.LogoPath =
                "/company-logos/" + fileName;

            _companyRepository.UpdateCompany(company);

            await _companyRepository.SaveChangesAsync();

            return "Logo uploaded successfully";
        }
    }
}
