using AutoMapper;
using Backend_WebApi.Core.Context;
using Backend_WebApi.Core.Dtos.Company;
using Backend_WebApi.Core.Dtos.Job;
using Backend_WebApi.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private AppDbContext _context { get; }
        private IMapper _mapper;
        public JobsController(AppDbContext cntxt, IMapper mapper)
        {
            _context = cntxt;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> addJob([FromBody] JobCreateDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);
            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();
            return Ok(newJob);
        }
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> getJobs()
        {
            var Jobs = await _context.Jobs.Include(job => job.Company).ToListAsync();
            var ConvertedJobs = _mapper.Map<IEnumerable<JobGetDto>>(Jobs);
            return Ok(ConvertedJobs);
        }
    }
}
