using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Models
{
    public class Venda
    {
        [Key]
        public long IdVenda { get; set; }
        public long VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public decimal Comissao { get; set; }
    }
}
