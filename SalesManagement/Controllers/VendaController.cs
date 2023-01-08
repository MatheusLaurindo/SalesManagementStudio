using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var listaVenda = _context.Vendas
                .Include(x => x.Vendedor)
                .Include(x => x.Produto)
                .ToList();

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
            var vendedor = _context.Vendedores.FirstOrDefault(x => x.IdVendedor == venda.VendedorId);
            var produto = _context.Produtos.FirstOrDefault(x => x.IdProduto == venda.ProdutoId);
            var total = produto.Preco * venda.Quantidade;
            //regra - comissao = 5% do total da venda
            var comissao = ((decimal)5 / 100) * total;

            if (ModelState.IsValid)
            {
                var objVenda = new Venda
                {
                    VendedorId = venda.VendedorId,
                    ProdutoId = venda.ProdutoId,
                    Quantidade = venda.Quantidade,
                    Vendedor = vendedor,
                    Produto = produto,
                    Total = total,
                    Comissao = comissao
                };

                _context.Vendas.Add(objVenda);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }

        public IActionResult RelatorioVendas()
        {
            var relatorio = _context.Vendas
                .Include(x => x.Produto)
                .Include(x => x.Vendedor)
                .ToList();

            return View(relatorio);
        }

    }
}
