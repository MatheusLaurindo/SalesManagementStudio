using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesManagement.Models;

namespace SalesManagement.Context.Maps
{
    public class VendedorMap : IEntityTypeConfiguration<Vendedor>
    {
        public virtual void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedores");
            builder.HasKey(x => x.IdVendedor);
            builder.Property(x => x.IdVendedor).ValueGeneratedOnAdd().HasColumnName("IdVendedor");
            builder.Property(x => x.Nome).HasColumnName("Nome");
            builder.Property(x => x.DataNascimento).HasColumnName("DataNascimento");
            builder.Property(x => x.Documento).HasColumnName("Documento");
        }
    }
}
