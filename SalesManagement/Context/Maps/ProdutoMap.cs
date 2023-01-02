using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManagement.Models;

namespace SalesManagement.Context.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public virtual void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(x => x.IdProduto);
            builder.Property(x => x.IdProduto).ValueGeneratedOnAdd().HasColumnName("IdProduto");
            builder.Property(x => x.Nome).HasColumnName("Nome");
            builder.Property(x => x.Descrição).HasColumnName("Descrição");
            builder.Property(x => x.Preco).HasColumnName("Preco");
        }
    }
}
