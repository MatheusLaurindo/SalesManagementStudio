using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SalesManagement.Context;
using SalesManagement.Models;
using System.Reflection.Metadata;

namespace SalesManagement.Controllers
{
    public class VendedorController : Controller
    {
        private readonly AppDbContext _context;

        public VendedorController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaVendedores = _context.Vendedores.ToList();
            return View(listaVendedores);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Vendedores.Add(vendedor);
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
            var vendedor = _context.Vendedores.FirstOrDefault(x => x.IdVendedor== id);

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Vendedor vendedor)
        {
            var vendedorExistente = _context.Vendedores.FirstOrDefault(x => x.IdVendedor == vendedor.IdVendedor);

            if (vendedorExistente != null)
            {
                _context.Entry(vendedorExistente).CurrentValues.SetValues(vendedor);
                _context.Entry(vendedorExistente).State = EntityState.Modified;
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
            var vendedor = _context.Vendedores.FirstOrDefault(x => x.IdVendedor == id);

            return View(vendedor);
        }

        [HttpPost]
        public IActionResult Deletar(Vendedor vendedor)
        {
            if(vendedor != null)
            {
                var vendedorExistente = _context.Vendedores.FirstOrDefault(x => x.IdVendedor == vendedor.IdVendedor);
                _context.Remove(vendedorExistente);
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
