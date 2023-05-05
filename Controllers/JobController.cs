using AutoMapper;
using Jobify.Dto.Job;
using Jobify.Dto.Rating;
using Jobify.Models;
using Jobify.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

namespace Jobify.Controllers
{ 
    [ApiController]
    [Route("job")]
    public class JobController : Controller
    {
        private readonly IJobRepositories _jobRepositories;
        private readonly IMapper _mapper;
        public JobController(IJobRepositories jobRepositories, IMapper mapper)
        {
            _jobRepositories = jobRepositories;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult CreateJobs(List<CreateJobDto> jobDtos)
        {
            List<Job> jobsToCreate = new List<Job>();

            foreach(var jobDto in jobDtos)
            {
                jobsToCreate.Add(new Job {
                    Name = jobDto.Appelation_Metier
                });
            }

            _jobRepositories.CreateJobs(jobsToCreate);

            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Job>> GetAll()
        {
            return Ok(_jobRepositories.GetAll());
        }
        [HttpGet("{search}")]
        public ActionResult<IEnumerable<Job>> GetAutocomplete(string search)
        {
            return Ok(_jobRepositories.GetAutocomplete(search));
        }
        [HttpDelete("{jobIds}")]
        public ActionResult DeleteJobs(List<int> jobIds)
        {
            _jobRepositories.DeleteJob(jobIds);
            return NoContent();
        }

    }
}
