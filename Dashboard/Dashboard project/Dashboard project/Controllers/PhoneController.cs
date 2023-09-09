using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dashboard_project.Models;
using Dashboard_project.Data;
namespace Dashboard_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PhoneController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public JsonResult Get()
        {
            var phoneDetails=_context.ProductDetails.ToList();
            if (phoneDetails == null)
                return new JsonResult("Not Found");
            return  new JsonResult(Ok(phoneDetails));

        }
    }
}
