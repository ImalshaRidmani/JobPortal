using JobPortalAPI.DTOs;
using System.Threading.Tasks;

namespace JobPortalAPI.Services
{
    public interface ICompanyService
    {
        Task<string> CreateCompany(CompanyDto request, int employerId);
    }
}
