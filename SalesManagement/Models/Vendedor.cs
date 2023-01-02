using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.Models
{
    public class Vendedor
    {
        [Key]
        public long IdVendedor { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string Documento { get; set; }
        public decimal Salario { get; set; }
        public virtual List<Venda> Vendas { get; set; }
    }
}
