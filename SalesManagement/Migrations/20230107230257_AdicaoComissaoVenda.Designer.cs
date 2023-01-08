﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesManagement.Context;

#nullable disable

namespace SalesManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230107230257_AdicaoComissaoVenda")]
    partial class AdicaoComissaoVenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SalesManagement.Models.Produto", b =>
                {
                    b.Property<long>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdProduto"), 1L, 1);

                    b.Property<string>("Descrição")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SalesManagement.Models.Venda", b =>
                {
                    b.Property<long>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdVenda"), 1L, 1);

                    b.Property<decimal>("Comissao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("VendedorId")
                        .HasColumnType("bigint");

                    b.HasKey("IdVenda");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("SalesManagement.Models.Vendedor", b =>
                {
                    b.Property<long>("IdVendedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdVendedor"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdVendedor");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("SalesManagement.Models.Venda", b =>
                {
                    b.HasOne("SalesManagement.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesManagement.Models.Vendedor", "Vendedor")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("SalesManagement.Models.Vendedor", b =>
                {
                    b.Navigation("Vendas");
                });
#pragma warning restore 612, 618
        }
    }
}