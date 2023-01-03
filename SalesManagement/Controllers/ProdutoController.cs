using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Context;
using SalesManagement.Models;

namespace SalesManagement.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaProduto = _context.Produtos.ToList();

            return View(listaProduto);
        }

        public IActionResult Detalhes(long id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.IdProduto == id);

            if (produto != null)
            {
                return View(produto);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Editar(long id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.IdProduto == id);

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Produto produto)
        {
            var produtoExistente = _context.Produtos.FirstOrDefault(x => x.IdProduto == produto.IdProduto);

            if (produtoExistente != null)
            {
                _context.Entry(produtoExistente).CurrentValues.SetValues(produto);
                _context.Entry(produtoExistente).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(long id)
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.IdProduto == id);

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(Produto produto)
        {
            if (produto != null)
            {
                var produtoExistente = _context.Produtos.FirstOrDefault(x => x.IdProduto == produto.IdProduto);
                _context.Remove(produtoExistente);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
