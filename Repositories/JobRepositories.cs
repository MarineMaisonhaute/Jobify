using AutoMapper;
using Jobify.DBContext;
using Jobify.Models;
using System.Collections.Generic;
using System.Linq;

namespace Jobify.Repositories
{
    public class JobRepositories : IJobRepositories
    {
        private readonly JobifyDBContext _context;
        private readonly IMapper _mapper;
        public JobRepositories(JobifyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreateJobs(List<Job> jobs)
        {
            _context.Job.AddRange(jobs);
            _context.SaveChanges();
        }
        public List<Job> GetAll()
        {
            return _context.Job.ToList();
        }
        public void DeleteJob(List<int> jobIds)
        {
            List<Job> jobsToDelete = _context.Job.Where(j => jobIds.Contains(j.JobId)).ToList();
            _context.Job.RemoveRange(jobsToDelete);
            _context.SaveChanges();
        }

        public List<Job> GetAutocomplete(string search)
        {
            return _context.Job.Where(j => j.Name.Contains(search)).ToList();
        }
        public List<Job> GetNameWithId(int Id)
        {
            return _context.Job.Where(j => j.JobId.Equals(Id)).ToList();
        }
    }
}
