using Microsoft.AspNetCore.Mvc;
using server.Core.Context;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        //CRUD


        //Create
        [HttpPost]
        [Route("Create")]



        //Read

        //Update

        //Delete
    }
}
