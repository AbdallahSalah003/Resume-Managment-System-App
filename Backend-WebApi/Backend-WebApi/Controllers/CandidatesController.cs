using AutoMapper;
using Backend_WebApi.Core.Context;
using Backend_WebApi.Core.Dtos.Candidate;
using Backend_WebApi.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private AppDbContext _context { get; }
        private IMapper _mapper;
        public CandidatesController(AppDbContext cntxt, IMapper mapper)
        {
            _context = cntxt;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> addCandidate([FromForm] CandidateCreateDto dto, IFormFile pdffile)
        {
            // i first save pdf to server then save url to our entity
            var fiveMegaBytes = 5 * 1024 * 1024;
            var pdfMineType = "application/pdf";
            if (pdffile.Length > fiveMegaBytes || pdffile.ContentType != pdfMineType) return BadRequest("Not Valid File");
            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Documents" , "pdfs" , resumeUrl);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdffile.CopyToAsync(stream);
            }
            var newCandidate = _mapper.Map<Candidates>(dto);
            newCandidate.ResumeUrl = resumeUrl;
            await _context.candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();
            return Ok(newCandidate);
        }
    }
}
