using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebapiProyect.Models;

namespace WebapiProyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Animal : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Animal(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
