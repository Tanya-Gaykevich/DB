using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab4.Controllers
{
    public class ClientsController : Controller
    {
        TouristAgencyContext _dbContext;
        public ClientsController(TouristAgencyContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /<controller>/
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 244)]
        public IActionResult Index()
        {
            return View(_dbContext.Clients);
        }
    }
}
