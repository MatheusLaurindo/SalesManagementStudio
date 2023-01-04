using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesManagement.Context;
using SalesManagement.Models;

namespace SalesManagement.Controllers
{
    public class VendaController : Controller
    {
        private readonly AppDbContext _context;

        public VendaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaVenda = _context.VendaProduto.ToList();

            return View(listaVenda);
        }

        public IActionResult Adicionar()
        {
            ViewBag.Vendedores = new SelectList(_context.Vendedores.ToList(), "IdVendedor", "Nome");
            ViewBag.Produtos = new SelectList(_context.Produtos.ToList(), "IdProduto", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Vendas.Add(venda);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }
    }
}
