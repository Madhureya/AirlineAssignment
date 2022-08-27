using AirlineAssignment.Data;
using Microsoft.AspNetCore.Mvc;

namespace AirlineAssignment.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context;


        public AdminController(ApplicationDbContext context) {

            _context = context;


            }

        public IActionResult Index()
        {

            var List =  _context.Approvals.ToList();

            
            return View();
        }



    }
}
