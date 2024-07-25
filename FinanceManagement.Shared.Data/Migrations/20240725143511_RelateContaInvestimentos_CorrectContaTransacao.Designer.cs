﻿// <auto-generated />
using System;
using FinanceManagement.Shared.Data.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceManagement.Shared.Data.Migrations
{
    [DbContext(typeof(FinanceContext))]
    [Migration("20240725143511_RelateContaInvestimentos_CorrectContaTransacao")]
    partial class RelateContaInvestimentos_CorrectContaTransacao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContaInvestimentos", b =>
                {
                    b.Property<int>("contasid")
                        .HasColumnType("int");

                    b.Property<int>("investimentosid")
                        .HasColumnType("int");

                    b.HasKey("contasid", "investimentosid");

                    b.HasIndex("investimentosid");

                    b.ToTable("ContaInvestimentos");
                });

            modelBuilder.Entity("Finance_console.Conta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("instituicao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("saldo")
                        .HasColumnType("float");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("Finance_console.Investimentos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("corretora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("rentabilidade")
                        .HasColumnType("float");

                    b.Property<string>("riscoInvestimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipoInvestimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valorInvestido")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Investimentos");
                });

            modelBuilder.Entity("Finance_console.Transacao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("contaid")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataTransacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("valor")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("contaid");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("ContaInvestimentos", b =>
                {
                    b.HasOne("Finance_console.Conta", null)
                        .WithMany()
                        .HasForeignKey("contasid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finance_console.Investimentos", null)
                        .WithMany()
                        .HasForeignKey("investimentosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Finance_console.Transacao", b =>
                {
                    b.HasOne("Finance_console.Conta", "conta")
                        .WithMany("transacaoes")
                        .HasForeignKey("contaid");

                    b.Navigation("conta");
                });

            modelBuilder.Entity("Finance_console.Conta", b =>
                {
                    b.Navigation("transacaoes");
                });
#pragma warning restore 612, 618
        }
    }
}