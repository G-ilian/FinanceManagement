using Finance_console;
using FinanceManagement.Shared.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagement.Shared.Data.DB
{
    public class FinanceContext : IdentityDbContext<AccessUser, AccessRoles, int>
    {
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        public DbSet<Investimentos> Investimentos { get; set; }

        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FinanceDB_V0;" +
            "Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Conta>().HasMany(inv => inv.investimentos).WithMany(conta => conta.contas);
        }
    }
}
