using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Core.Context;
using server.Core.Dtos.Job;
using server.Core.Entities;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateJob([FromBody] JobCreateDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);
            await _context.Jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();

            return Ok("Job Created Successfully");
        }


        //Read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> Getjobs()
        {
            var jobs = await _context.Jobs.Include(x => x.Company).ToListAsync();
            var convertedjobs = _mapper.Map<IEnumerable<JobGetDto>>(jobs);

            return Ok(convertedjobs);
        }

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<CompanyGetDto>> GetCompany(int id)
        //{
        //    var Company = _context.Companies.First(x => x.ID == id);
        //    var convertedCompany = _mapper.Map<CompanyGetDto>(Company);

        //    return Ok(convertedCompany);
        //}

        ////Update

        ////Delete
        //[HttpDelete("{id:int}")]
        //public ActionResult DeleteCompany(int id)
        //{
        //    try
        //    {
        //        var companyById = _context.Companies.FirstOrDefault(x => x.ID == id);
        //        if (companyById != null)
        //        {
        //            _context.Companies.Remove(companyById);
        //            _context.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    return Ok();
        //}
    }
}
