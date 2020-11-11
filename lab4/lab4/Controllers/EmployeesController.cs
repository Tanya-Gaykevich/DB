using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab4.Controllers
{
    public class EmployeesController : Controller
    {
        TouristAgencyContext _dbContext;
        public EmployeesController(TouristAgencyContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /<controller>/
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 244)]
        public IActionResult Index()
        {
            return View(_dbContext.Employees
                .Include(emp=>emp.Position)
                .Take(500));
        }
    }
}
