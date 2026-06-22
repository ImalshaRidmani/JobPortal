using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCompany(
            CompanyDto request)
        {
            var userIdClaim =
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int employerId = int.Parse(userIdClaim);

            var result =
                await _companyService.CreateCompany(
                    request,
                    employerId);

            if (result == "Company already exists")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("my")]
        [Authorize]
        public IActionResult GetMyCompany()
        {
            var userIdClaim =
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int employerId = int.Parse(userIdClaim);

            var company =
                _companyService.GetMyCompany(employerId);

            if (company == null)
                return NotFound("Company not found");

            return Ok(company);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateCompany(CompanyDto request)
        {
            var userIdClaim =
                User.FindFirst(
                    System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null)
                return Unauthorized();

            int employerId = int.Parse(userIdClaim);

            var result =
                await _companyService.UpdateCompany(
                    request,
                    employerId);

            if (result == "Company not found")
                return NotFound(result);

            return Ok(result);
        }
    }
}
