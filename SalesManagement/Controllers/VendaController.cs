using Microsoft.AspNetCore.Mvc;

namespace SalesManagement.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
