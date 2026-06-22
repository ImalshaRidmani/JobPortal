using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using System.Threading.Tasks;

namespace JobPortalAPI.Services
{
    public interface ICompanyService
    {
        Task<string> CreateCompany(CompanyDto request, int employerId);

        Company? GetMyCompany(int employerId);
    }
}
