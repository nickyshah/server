using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Core.Context;
using server.Core.Dtos.Company;
using server.Core.Entities;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompanyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyCreateDto dto)
        {
            Company newCompany = _mapper.Map<Company>(dto);
            await _context.AddAsync(newCompany);
            await _context.SaveChangesAsync();

            return Ok("Company Created Successfully");
        }


        //Read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyGetDto>>> GetCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            var convertedCompanies = _mapper.Map<IEnumerable<CompanyGetDto>>(companies);

            return Ok(convertedCompanies);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CompanyGetDto>> GetCompany(int id)
        {
            var Company = _context.Companies.First(x => x.ID == id);
            var convertedCompany = _mapper.Map<CompanyGetDto>(Company);

            return Ok(convertedCompany);
        }

        //Update

        //Delete
        [HttpDelete("{id:int}")]
        public ActionResult DeleteCompany(int id)
        {
            try
            {
                var companyById = _context.Companies.FirstOrDefault(x => x.ID == id);
                if (companyById != null)
                {
                    _context.Companies.Remove(companyById);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
