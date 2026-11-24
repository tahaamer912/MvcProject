using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.Contexts;
namespace MVCProject.Controllers
{
    public class PlanController : Controller
    {
        private GymDbContext dbcontext = new GymDbContext();

        public IActionResult IndexTest()
        {
            return View();

        }

        public async Task<IActionResult> Index()
        {
            var plans = await dbcontext.Plans.ToListAsync();
            return View(plans);

        }

    }
}
