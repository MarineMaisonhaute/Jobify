using Jobify.Dto.Response;
using Jobify.Models;

namespace Jobify.Repositories
{
    public interface IJobRepositories
    {
        List<Job> GetAll();
        void DeleteJob(List<int> jobIds);
        void CreateJobs(List<Job> jobs);
        List<Job> GetAutocomplete(string search);
    }
}
