using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Models
{
    public class Venda
    {
        [Key]
        public long IdVenda { get; set; }
        public long VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}
