using AutoMapper;
using Backend_WebApi.Core.Context;
using Backend_WebApi.Core.Dtos.Company;
using Backend_WebApi.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private AppDbContext _context {  get;  }
        private IMapper _mapper;
        public CompaniesController(AppDbContext cntxt, IMapper mapper)
        {
            _context = cntxt;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> addCompany([FromBody] CompanyCreateDto dto)
        {
            Company newCompany = _mapper.Map<Company>(dto);
            await _context.companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();
            return Ok(newCompany);
        }
        [HttpGet]
        [Route("Get")]
        public  async Task<ActionResult<IEnumerable<CompanyGetDto>>> getCompanies()
        {
            var companies = await _context.companies.ToListAsync();
            var Convertedcompanies = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);
            return Ok(Convertedcompanies);
        }
    }
}
