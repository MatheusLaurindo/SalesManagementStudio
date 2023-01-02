using Microsoft.AspNetCore.Mvc;

namespace SalesManagement.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
