using Microsoft.AspNetCore.Mvc;

namespace SalesManagement.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
