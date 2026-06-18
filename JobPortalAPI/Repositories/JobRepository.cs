using JobPortalAPI.Data;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Job> GetAllJobs()
        {
            return _context.Jobs.ToList();
        }

        public JobApplication? GetApplication(int jobId, int userId)
        {
            return _context.JobApplications
                .FirstOrDefault(x => x.JobId == jobId && x.UserId == userId);
        }

        public void AddApplication(JobApplication application)
        {
            _context.JobApplications.Add(application);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void AddJob(Job job)
        {
            _context.Jobs.Add(job);
        }

        public List<JobApplicationViewDto> GetApplicationForEmployer(int employerId)
        {
            return (from app in _context.JobApplications
                    join job in _context.Jobs on app.JobId equals job.Id
                    join user in _context.Users on app.UserId equals user.Id
                    where job.EmployerId == employerId
                    select new JobApplicationViewDto
                    {
                        ApplicationId = app.Id,
                        JobTitle = job.Title,
                        ApplicantEmail = user.email,
                        Status = app.Status,
                        AppliedDate = app.AppliedDate,
                    }).ToList();
        }

        public JobApplication? GetApplicationById(int id)
        {
            return _context.JobApplications
                .FirstOrDefault(x => x.Id == id);
        }

        public List<MyApplicationDto> GetApplicationsByUserId(int userId)
        {
            return (from app in _context.JobApplications
                    join job in _context.Jobs on app.JobId equals job.Id
                    where app.UserId == userId
                    select new MyApplicationDto
                    {
                        ApplicationId = app.Id,
                        JobTitle = job.Title,
                        Location = job.Location,
                        Status = app.Status,
                        AppliedDate = app.AppliedDate
                    }).ToList();
        }
    }
}
