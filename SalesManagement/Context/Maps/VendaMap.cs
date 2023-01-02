using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManagement.Models;

namespace SalesManagement.Context.Maps
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public virtual void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Vendas");
            builder.HasKey(x => x.IdVenda);
            builder.Property(x => x.IdVenda).ValueGeneratedOnAdd().HasColumnName("IdVenda");

            //foreignkey definition
            builder.HasOne(x => x.Vendedor).WithMany(x => x.Vendas).HasForeignKey(x => x.VendedorId);

            builder.HasMany(x => x.Produtos).WithMany(x => x.Vendas).UsingEntity<VendaProduto>(

                    x => x.HasOne(p => p.Produto).WithMany().HasForeignKey(f => f.ProdutoId),
                    x => x.HasOne(p => p.Venda).WithMany().HasForeignKey(f => f.VendaId),
                    x =>
                    {
                        x.ToTable("VendaProduto");
                        x.HasKey(p => new { p.VendaId, p.ProdutoId });
                        x.Property(x => x.Quantidade).HasColumnName("Quantidade").IsRequired();
                        x.Property(x => x.VendaId).HasColumnName("VendaId");
                        x.Property(x => x.ProdutoId).HasColumnName("ProdutoId");
                    }
                    );
        }
    }
}
