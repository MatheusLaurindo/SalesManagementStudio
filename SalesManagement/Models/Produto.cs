using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Models
{
    public class Produto
    {
        [Key]
        public long IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
    }
}